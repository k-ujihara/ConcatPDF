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

using iText.Kernel.Events;
using iText.Kernel.Pdf;
using System;
using System.Collections;
using System.IO;
using System.Text;
using Ujihara.PDF;
using static iText.Kernel.Pdf.PdfViewerPreferences;

namespace Ujihara.ConcatPDF
{
	class MainModule
	{
		static Encoding encoding = Encoding.UTF8;
		static PdfEncryptInfo encryptInfo = null;
		static PdfConcatenatorOption appendOption = new PdfConcatenatorOption();
        static PageViewerPreferences viewerPreference = new PageViewerPreferences();

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
						string len = args[i++].Trim().ToUpperInvariant();
						string userPass = args[i++];
						string ownerPass = args[i++];
                        int permission = 0;
                        int encryption = 0;
                        #region Set encryption length
                        {
                            try
                            {
                                switch (len)
                                {
                                    case "40":
                                        encryption |= EncryptionConstants.STANDARD_ENCRYPTION_40;
                                        break;
                                    case "128":
                                        encryption |= EncryptionConstants.STANDARD_ENCRYPTION_128;
                                        break;
                                    case "AES128":
                                        encryption |= EncryptionConstants.ENCRYPTION_AES_128;
                                        break;
                                    case "AES256":
                                        encryption |= EncryptionConstants.ENCRYPTION_AES_256;
                                        break;
                                    default:
                                        throw new Exception();
                                }
                            }
                            catch (Exception)
                            {
                                throw new Exception($"Illegal length: {len}");
                            }
                        }
                        #endregion
                        #region Set permission
                        for (; i < args.Length; i++)
                        {
                            string p = args[i].ToLower();
                            if (false) { }
                            else if (p == "printing") permission |= EncryptionConstants.ALLOW_PRINTING;
                            else if (p == "modify-contents") permission |= EncryptionConstants.ALLOW_MODIFY_CONTENTS;
                            else if (p == "copy") permission |= EncryptionConstants.ALLOW_COPY;
                            else if (p == "modify-annotations") permission |= EncryptionConstants.ALLOW_MODIFY_ANNOTATIONS;
                            else if (p == "fill-in") permission |= EncryptionConstants.ALLOW_FILL_IN;
                            else if (p == "screen-readers") permission |= EncryptionConstants.ALLOW_SCREENREADERS;
                            else if (p == "assembly") permission |= EncryptionConstants.ALLOW_ASSEMBLY;
                            else if (p == "degraded-printing") permission |= EncryptionConstants.ALLOW_DEGRADED_PRINTING;
                            else
                            {
                                break;
                            }
                        }
                        #endregion
                        encryptInfo = new PdfEncryptInfo(permission, encryption, userPass, ownerPass);						
					}
					else if (parm == "/viewer")
					{
                        for (; i < args.Length; i++)
                        {
                            #region Set viewer option
                            string p = args[i].ToLower();
                            switch (p)
                            {
                                case "page-layout-single-page":
                                    //Display one page at a time.
                                    viewerPreference.PageLayout = PdfName.SinglePage;
                                    break;
                                case "page-layout-continuous":
                                    // Display the pages in one column.
                                    viewerPreference.PageLayout = PdfName.OneColumn;
                                    break;
                                case "page-layout-continuous-facing-left":
                                    //Display the pages in two columns, with oddnumbered pages on the left.
                                    viewerPreference.PageLayout = PdfName.TwoColumnLeft;
                                    break;
                                case "page-layout-continuous-facing":
                                case "page-layout-continuous-facing-right":
                                    //Display the pages in two columns, with oddnumbered pages on the right.
                                    viewerPreference.PageLayout = PdfName.TwoColumnRight;
                                    break;
                                case "page-mode-use-none":
                                    // Neither document outline nor thumbnail images visible.
                                    viewerPreference.NonFullScreenPageMode = PdfViewerPreferencesConstants.USE_NONE;
                                    break;
                                case "page-mode-use-outlines":
                                    // Document outline visible.
                                    viewerPreference.NonFullScreenPageMode = PdfViewerPreferencesConstants.USE_OUTLINES;
                                    break;
                                case "page-mode-use-thumbs":
                                    // Thumbnail images visible.
                                    viewerPreference.NonFullScreenPageMode = PdfViewerPreferencesConstants.USE_THUMBS;
                                    break;
                                case "page-mode-full-screen":
                                    // Full-screen mode, with no menu bar, window  controls, or any other window visible.
                                    viewerPreference.PageMode = PdfName.FullScreen;
                                    break;
                                case "hide-toolbar":
                                    // A flag specifying whether to hide the viewer application's toolbars when the document is active.
                                    viewerPreference.HideToolbar = true;
                                    break;
                                case "hide-menubar":
                                    // A flag specifying whether to hide the viewer application's menu bar when the document is active.
                                    viewerPreference.HideMenubar = true;
                                    break;
                                case "hide-window-ui":
                                    // A flag specifying whether to hide user interface elements in the document's window (such as scroll bars and navigation controls), leaving only the document's contents displayed.
                                    viewerPreference.HideWindowUI = true;
                                    break;
                                case "fit-window":
                                    // A flag specifying whether to resize the document's window to fit the size of the first displayed page.
                                    viewerPreference.FitWindow = true;
                                    break;
                                case "center-window":
                                case "centre-window":
                                    // A flag specifying whether to position the document's window in the center of the screen.
                                    viewerPreference.CenterWindow = true;
                                    break;
                                default:
                                    goto L1000;
                            }
                            #endregion
                        }
                    L1000:
                        ;
					}
					else if (parm == "/add-outlines")
					{
                        appendOption.AddOutlines = true;
					}
                    else if (parm == "/fitting")
                    {
                        string s = args[i++];
                        switch (s)
                        {
                            case "XYZ":
                                s = "/" + s + " null null null";
                                break;
                            case "Fit":
                            case "FitB":
                                s = "/" + s;
                                break;
                            case "FitH":
                            case "FitV":
                            case "FitBH":
                            case "FitBV":
                                s = "/" + s + " null";
                                break;
                            case "FitR":
                                s = "/" + s + " null null null null";
                                break;
                            default:
                                if (s.Length > 0 && s[0] != '/')
                                    s = "/" + s;
                                break;
                        }
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
                                con.Append(UriGetFullPath(fileName), pageRanges, appendOption);
                            }
                        }
                        finally
                        {
                            con.Close();
                            concatenatedFileStream.Close();
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
