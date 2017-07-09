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

using iText.Kernel.Pdf;

namespace Ujihara.PDF
{
    public class PdfEncryptInfo
    {
        public bool Enabled { get; set; }
        public string OwnerPassword { get; set; }
        public string UserPassword { get; set; }

        /// <seealso cref="EncryptionConstants"/>
        public int Permission { get; set; }

        /// <summary>
        /// Encrytion type
        /// </summary>
        /// <seealso cref="EncryptionConstants"/>
        public int Encryption { get; set; }

        public PdfEncryptInfo()
        {
            Enabled = false;
            OwnerPassword = null;
            UserPassword = null;
            Permission = 0;
            Encryption = 0;
        }

        public PdfEncryptInfo(int permission, int encryption, string userPassword, string ownerPassword)
        {
            this.Enabled = true;
            this.Permission = permission;
            this.Encryption = encryption;
            this.UserPassword = userPassword;
            this.OwnerPassword = ownerPassword;
        }
    }
}
