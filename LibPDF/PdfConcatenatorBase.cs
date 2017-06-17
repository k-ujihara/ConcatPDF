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
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Ujihara.PDF
{
    public abstract class PdfConcatenatorBase : IDisposable
    {
        protected Document document = null;
        protected Stream outStream = null;

        protected bool encryptionStrength;
        protected String userPassword = null;
        protected String ownerPassword = null;
        protected int permissions = 0;
        protected int viewerPreference = 0;

        protected void Setup(Stream outStream, int encryptionLength, string userPassword, string ownerPassword, int permissions, int viewerPreference)
        {
            this.outStream = outStream;

            if (encryptionLength != 0)
            {
                switch (encryptionLength)
                {
                    case 40:
                        this.encryptionStrength = PdfWriter.STRENGTH40BITS;
                        break;
                    case 128:
                        this.encryptionStrength = PdfWriter.STRENGTH128BITS;
                        break;
                    default:
                        throw new ArgumentException("Illegal encryption strength (" + encryptionLength + ").");
                }
                this.userPassword = userPassword;
                this.ownerPassword = ownerPassword;
                this.permissions = permissions;
            }

            this.viewerPreference = viewerPreference;
        }

        public virtual void Dispose()
        {
            if (document != null)
                document.Close();
        }

        public void Close()
        {
            Dispose();
        }
    }
}
