/*
     Copyright 2003, 2004, 2012 by Kazuya Ujihara.
 
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>. 
 */

using System;
using System.Collections;
using System.IO;
using System.Text;

using iTextSharp.text.pdf;
using Ujihara.PDF;
using System.Collections.Generic;

namespace Ujihara.ConcatPDF
{
	class MainModule
	{
		static Encoding encoding = Encoding.UTF8;
		static PdfEncryptInfo encryptInfo = null;
		static PdfConcatenatorOption appendOption = new PdfConcatenatorOption();
		static int viewerPreference = 0;

		private static string CommandLineExample = "ConcatPDF [switches] {input-file}...";

		static void ShowUsage()
		{
			Console.Write(
				CommandLineExample + "\n" +
				"Switches:\n" +
				"  /outfile {file-name}    Specify concatenated PDF file name.\n" +
				"  /add-outlines    Add file names as outline.\n" +
				"  /fitting ( XYZ | Fit | FitB )   Set how to fit on a destination page.\n" +
				"  /copy-outlines    Copy bookmarks from the original file.\n" +
				"  /security {128|40} {user-password|\"} {master-password|\"} {permission}...\n" +
				"    permission := ( printing | modify-contents | copy | modify-annotations | fill-in | screen-readers | assembly | degraded-printing\n" +
				"  /viewer {preference}...    Set viewer preferences.\n" +
				"    preference := ( page-layout-single-page | page-layout-continuous | page-layout-continuous-facing-left | page-layout-continuous-facing-right | page-mode-use-none | page-mode-use-outlines | page-mode-use-thumbs | page-mode-full-screen | hide-toolbar hide-menubar | hide-window-UI | fit-window | center-window )\n" +
				"  @{file-name}    Read options from file. Options are splited by line feed.\n" +
				"  /charset    Character set for @{file-name}.\n" +
				"  /help    Show this message.\n" +
				"");
		}

		[STAThread]
		static int Main(string[] args)
		{
			ArrayList argArray = new ArrayList(args.Length);
			int i;

			try
			{
				for (i = 0; i < args.Length; ) 
				{
					string parm = args[i++];

					if (parm == null) 
					{
						break;
					} 
					else if (parm == "/charset") 
					{
						parm = args[i++];
						encoding = Encoding.GetEncoding(parm);
					} 
					else if (parm == "/?" || parm == "/help") 
					{
						ShowUsage();
						return 0;
					} 
					else 
					{
						if (parm.Length == 0) 
						{
							argArray.Add(parm);
						}
						else if (parm.Substring(0, 1) == "@")
						{
							string fileName = parm.Substring(1);
							StreamReader reader = new StreamReader(fileName, encoding);
							string opt = reader.ReadToEnd();
							string[] opts = opt.Split('\n');
							for (int j = 0; j < opts.Length; j++)
							{
								string o = opts[j].Trim();
								if (!(o == "")) argArray.Add(o);
							}
						} 
						else 
						{
							argArray.Add(parm);
						}
					}
				} /*GetOptLoop*/

				args = new string[argArray.Count];
				for (i = 0; i < argArray.Count; i++)
				{
					args[i] = (string)argArray[i];
				}

				Stream concatenatedFileStream = null;

				for (i = 0; i < args.Length; ) 
				{
					string parm = args[i++];

					if (false)  
					{
					} 
					else if (parm == "/outfile")
					{
						string s = args[i++];
                        if (s == "-")
                            concatenatedFileStream = System.Console.OpenStandardOutput();
                        else
                            concatenatedFileStream = new FileStream(Path.GetFullPath(s), FileMode.Create, FileAccess.Write);
					}
					else if (parm == "/security") 
					{
						string len = args[i++];
						string userPass = args[i++];
						string ownerPass = args[i++];
						encryptInfo = new PdfEncryptInfo(int.Parse(len), userPass, ownerPass, 0);
						for (; i < args.Length; i++) 
						{
							string p = args[i].ToLower();
							if (false) {}
							else if (p == "printing") encryptInfo.permissions |= PdfWriter.AllowPrinting;
							else if (p == "modify-contents") encryptInfo.permissions |= PdfWriter.AllowModifyContents;
							else if (p == "copy") encryptInfo.permissions |= PdfWriter.AllowCopy;
							else if (p == "modify-annotations") encryptInfo.permissions |= PdfWriter.AllowModifyAnnotations;
							else if (p == "fill-in") encryptInfo.permissions |= PdfWriter.AllowFillIn;
							else if (p == "screen-readers") encryptInfo.permissions |= PdfWriter.AllowScreenReaders;
							else if (p == "assembly") encryptInfo.permissions |= PdfWriter.AllowAssembly;
							else if (p == "degraded-printing") encryptInfo.permissions |= PdfWriter.AllowDegradedPrinting;
							else 
							{
								break;
							}
						} 
					}
					else if (parm == "/viewer")
					{
						for (; i < args.Length; i++)
						{
							string p = args[i].ToLower();
							if (false) {}
							else if (p == "page-layout-single-page") viewerPreference |= PdfWriter.PageLayoutSinglePage; //Display one page at a time.
							else if (p == "page-layout-continuous") viewerPreference |= PdfWriter.PageLayoutOneColumn; // Display the pages in one column.
							else if (p == "page-layout-continuous-facing-left") viewerPreference |= PdfWriter.PageLayoutTwoColumnLeft; //Display the pages in two columns, with oddnumbered pages on the left.
							else if (p == "page-layout-continuous-facing" || p == "page-layout-continuous-facing-right") viewerPreference |= PdfWriter.PageLayoutTwoColumnRight; //Display the pages in two columns, with oddnumbered pages on the right.
							else if (p == "page-mode-use-none") viewerPreference |= PdfWriter.PageModeUseNone; // Neither document outline nor thumbnail images visible.
							else if (p == "page-mode-use-outlines") viewerPreference |= PdfWriter.PageModeUseOutlines; // Document outline visible.
							else if (p == "page-mode-use-thumbs") viewerPreference |= PdfWriter.PageModeUseThumbs; // Thumbnail images visible.
							else if (p == "page-mode-full-screen") viewerPreference |= PdfWriter.PageModeFullScreen; // Full-screen mode, with no menu bar, window  controls, or any other window visible.
							else if (p == "hide-toolbar") viewerPreference |= PdfWriter.HideToolbar; // A flag specifying whether to hide the viewer application's toolbars when the document is active.
							else if (p == "hide-menubar") viewerPreference |= PdfWriter.HideMenubar; // A flag specifying whether to hide the viewer application's menu bar when the document is active.
							else if (p == "hide-window-ui") viewerPreference |= PdfWriter.HideWindowUI; // A flag specifying whether to hide user interface elements in the document's window (such as scroll bars and navigation controls), leaving only the document's contents displayed.
							else if (p == "fit-window") viewerPreference |= PdfWriter.FitWindow; // A flag specifying whether to resize the document's window to fit the size of the first displayed page.
							else if (p == "center-window" || p == "centre-window") viewerPreference |= PdfWriter.CenterWindow; // A flag specifying whether to position the document's window in the center of the screen.
							else
							{
								break;
							}
						}
						if ((viewerPreference & PdfWriter.PageModeFullScreen) != 0)
						{
							if ((viewerPreference & PdfWriter.PageModeUseNone) != 0) viewerPreference |= PdfWriter.NonFullScreenPageModeUseNone; // Neither document outline nor thumbnail images visible.
							if ((viewerPreference & PdfWriter.PageModeUseOutlines) != 0) viewerPreference |= PdfWriter.NonFullScreenPageModeUseOutlines; // Document outline visible.
							if ((viewerPreference & PdfWriter.PageModeUseThumbs) != 0) viewerPreference |= PdfWriter.NonFullScreenPageModeUseThumbs; // Thumbnail images visible.					
						}
					}
					else if (parm == "/add-outlines")
					{
                        appendOption.AddOutlines = true;
					}
                    else if (parm == "/fitting")
                    {
                        string s = args[i++];
                        if (false) { }
                        else if (s.Equals("XYZ"))
                            s = "/" + s + " null null null";
                        else if (s.Equals("Fit") || s.Equals("FitB"))
                            s = "/" + s;
                        else if (s.Equals("FitH") || s.Equals("FitV") || s.Equals("FitBH") || s.Equals("FitBV"))
                            s = "/" + s + " null";
                        else if (s.Equals("FitR"))
                            s = "/" + s + " null null null null";
                        else
                            if (s[0] != '/')
                                s = "/" + s;
                        appendOption.FittingStyle = s;
                    }
                    else if (parm == "/copy-outlines")
                    {
                        appendOption.CopyOutlines = true;
                    }
                    else
                    {
                        if (concatenatedFileStream == null)
                            throw new Exception("Missing outfile.");
                        PdfConcatenator con = new PdfConcatenator(concatenatedFileStream, encryptInfo, viewerPreference);
                        var readers = new List<PdfReader>();
                        try
                        {
                            --i;
                            int fileCount = args.Length - i;
                            for (int j = 0; j < fileCount; j++)
                            {
                                PageRange[] pageRanges = null;
                                string fileName = args[i + j].Trim();

                                int cp = fileName.LastIndexOf('#');
                                if (cp >= 0)
                                {
                                    string pageRange = fileName.Substring(cp + 1).Trim();
                                    fileName = fileName.Substring(0, cp).Trim();

                                    char[] spt = new char[1];
                                    spt[0] = ',';
                                    string[] ranges = pageRange.Split(spt);
                                    pageRanges = new PageRange[ranges.Length];

                                    for (int k = 0; k < ranges.Length; k++)
                                    {
                                        string pageSpec = ranges[k];
                                        int start = 1;
                                        int end = int.MaxValue;
                                        int indxedOfH = pageSpec.IndexOf('-');
                                        if (indxedOfH < 0)
                                        {
                                            start = end = IntXParse(pageSpec);
                                        }
                                        else
                                        {
                                            string begin = pageSpec.Substring(0, indxedOfH).Trim();
                                            string last = pageSpec.Substring(indxedOfH + 1).Trim();
                                            if (begin != "")
                                                start = IntXParse(begin);
                                            if (last != "")
                                                end = IntXParse(last);
                                        }
                                        pageRanges[k] = new PageRange(start, end);
                                    }
                                }
                                PdfReader reader = con.CreatePdfReader(fileName, appendOption);
                                readers.Add(reader);
                                con.Append(reader, Path.GetFileNameWithoutExtension(fileName), pageRanges, appendOption);
                            }
                        }
                        finally
                        {
                            con.Close();
                            concatenatedFileStream.Close();
                            foreach (PdfReader reader in readers)
                                reader.Close();
                        }
                        return 0;
                    }
				}
			}
			catch (Exception ee)
			{
				Console.Write(ee.Message);
				System.Diagnostics.Debug.WriteLine(ee.StackTrace);
				return 1;
			}

			//no imput files.
			Console.Write(CommandLineExample + "\n" + "\"ConcatPDF /help\" for details.\n");
			return 0;
		}

		private static string UriGetFullPath(string fileName)
		{
			try
			{
				return Path.GetFullPath(fileName);
			}
			catch
			{
			}
			return fileName;
		}

		private static int IntXParse(string str)
		{
			if (str.Substring(0, 1) == "B")
				str = "-" + str.Substring(1);
			return int.Parse(str);
		}
	}
}
