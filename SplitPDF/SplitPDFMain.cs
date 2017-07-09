/*
     Copyright 2006, 2012 by Kazuya Ujihara.
 
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
using System.IO;
using Ujihara.PDF;

namespace Ujihara.ConcatPDF
{
	class SplitPDFMain
	{
		private static string CommandLineExample = "SplitPDF [switches] {input-file}";

		static void ShowUsage()
		{
			Console.Write(
				CommandLineExample + "\n" +
				"Switches:\n" +
				"  /outdir {output-directry} Directry name to store splitted files.\n" +
				"  /help    Show this message.\n" +
				"");
		}

		[STAThread]
		static int Main(string[] args)
		{
			int i;
			string outputDir = null;
			PdfSplitter spliter = new PdfSplitter();
			try
			{
				for (i = 0; i < args.Length; ) 
				{
					string parm = args[i++];

					if (false)  
					{
					} 
					else if (parm == "/outdir")
					{
						outputDir = UriGetFullPath(args[i++]);
					}
					else if (parm == "/help") 
					{
						ShowUsage();
						return 0;
					}
					else
					{
						if (parm[0] == '/')
							throw new ApplicationException("Invalid argument '" + parm + "'.");

						string outDir;
						if (outputDir == null)
							outDir = Path.Combine(
								Environment.GetFolderPath(Environment.SpecialFolder.Desktop), 
								Path.GetFileNameWithoutExtension(parm));
						else
							outDir = outputDir;

						if (Directory.Exists(outDir))
						{
							Console.Out.WriteLine("Directory '" + outDir + "' is exist.");
							Console.Out.Write("Are you sure to overwrite it? Yes(y) / No(n) / Abort(a)");
							for (;;)
							{
								int c = Console.In.Read();
								if (c == 'a')
									return 1;
								if (c == 'n')
									goto GoReadNextOption;
								if (c == 'y')
									break;
							}
						}

						if (!Directory.Exists(outDir))
						{
							Directory.CreateDirectory(outDir);
						}
						spliter.Split(parm, outDir);
					}
				GoReadNextOption:
					;
				}
			}
			catch (IndexOutOfRangeException)
			{
				Console.Write("Error: Input or output file names aren't specified.");
				return 1;
			}
			catch (Exception ee)
			{
				Console.Write(ee.Message);
				System.Diagnostics.Debug.WriteLine(ee.StackTrace);
				return 1;
			}

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
	}
}
