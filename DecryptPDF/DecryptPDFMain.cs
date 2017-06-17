/*
    Copyright 2005, 2006, 2012 by Kazuya Ujihara. 
  
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

using iTextSharp.text;
using iTextSharp.text.pdf;
using Ujihara.PDF;

namespace Ujihara.ConcatPDF
{
	class MainModule
	{
		private static string CommandLineExample = "DecryptPDF [switches] {input-file} {output-file}";

		static void ShowUsage()
		{
			Console.Write(
				CommandLineExample + "\n" +
				"Switches:\n" +
				"  /password {password} Owner(Master) password of the file.\n" +
				"  /help    Show this message.\n" +
				"");
		}

		[STAThread]
		static int Main(string[] args)
		{
			ArrayList argArray = new ArrayList(args.Length);
			int i;
			string password = "";

			try
			{
				for (i = 0; i < args.Length; ) 
				{
					string parm = args[i++];

					if (false)  
					{
					} 
					else if (parm == "/password")
					{
						password = args[i++];
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

						string source = parm;
						source = UriGetFullPath(source);
						parm = args[i++];
						string dest = parm;
						dest = UriGetFullPath(dest);

						PDFDecryptor.Decrypt(source, dest, password);
					}
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

	/// <summary>
	/// It decrypts encrypted PDF file.
	/// </summary>
	public class PDFDecryptor
	{
		private PDFDecryptor()
		{
		}

		public static void Decrypt(string EncryptedFileName, string DecryptedFileName, string Password)
		{
			PdfReader reader = new PdfReader(EncryptedFileName, Encoding.ASCII.GetBytes(Password));
			PdfStamper stamper = new PdfStamper(reader, new FileStream(DecryptedFileName, FileMode.Create, FileAccess.Write));
			stamper.Close();
		}
	}
}
