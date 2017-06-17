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
using System.IO;
using System.Threading;

namespace Ujihara.Lib
{
	public class FileOperation
	{
		private class ExecFileImpl
		{
			string uri;
			string verb;
			string param;
			string execFolder;

			public ExecFileImpl(String uri, String verb, String param, string execFolder) 
			{
				this.uri = uri;
				this.verb = verb;
				this.param = param;
				this.execFolder = execFolder;
			}

			public void Do()
			{
                try
                {
                    var a = new System.Diagnostics.Process();
                    a.StartInfo.Verb = verb;
                    a.StartInfo.FileName = uri;
                    a.StartInfo.Arguments = param;
                    a.StartInfo.WorkingDirectory = execFolder;
                    a.Start();
                    Thread.Sleep(5000);
                }
                catch (Exception)
                {
                    // ignore it   
                }
			}
		}

		public static void ExecuteFile(string uri, string verb, string param, string execFolder) 
		{
            ExecFileImpl clazz = new ExecFileImpl(uri, verb, param, execFolder);
            Thread thread = new Thread(new ThreadStart(clazz.Do));
            thread.Start();
		}

		public static void ExecuteFile(string uri) 
		{
			ExecuteFile(uri, "open", "", null);
		}

		public static string GetTempFile()
		{
			return GetTempFile("", "");
		}

		public static string GetTempFile(string prefix, string suffix)
		{
			String fileName = prefix + System.Guid.NewGuid().ToString() + suffix;
			return Path.Combine(Path.GetTempPath(), fileName);
		}
	}
}
