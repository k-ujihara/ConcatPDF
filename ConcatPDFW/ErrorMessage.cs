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
using System.Windows.Forms;

namespace Ujihara.Lib
{
	public class ErrorMessage
	{
		public static void Show(string message, string caption, MessageBoxIcon icon)
		{
			MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
		}

		public static void Show(Exception exception, string caption, MessageBoxIcon icon)
		{
			String str = null;
			if (str == null) str = exception.Message;
#if DEBUG
			if (str == null) str = "";
			str = str + exception.StackTrace;
#endif
			Show(str, caption, icon);
		}

		public static void Show(Exception exception, string caption)
		{
			Show(exception, caption, MessageBoxIcon.Error);
		}

		public static void Show(Exception except, MessageBoxIcon icon)
		{
			Show(except, "", icon);
		}

		public static void Show(Exception exception)
		{
			Show(exception, "");
		}

		public static void Show(string message)
		{
			Show(message, "", MessageBoxIcon.Error);
		}
	}
}
