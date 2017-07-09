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
using iText.Kernel.Pdf;

namespace Ujihara.PDF
{
    public abstract class PdfConcatenatorBase : IDisposable
    {
        protected PdfDocument document = null;
        protected Stream outStream = null;
        protected PdfEncryptInfo EncryptInfo { get; set; }
        protected PdfName PageLayout { get; set; }
        protected PdfName PageMode { get; set; }
        protected PdfViewerPreferences ViewerPreference { get; set; }

        protected void Setup(Stream outStream, PdfEncryptInfo encryptInfo, PageViewerPreferences viewerPreference)
        {
            this.outStream = outStream;
            this.EncryptInfo = encryptInfo;
            this.PageLayout = viewerPreference.PageLayout;
            this.PageMode = viewerPreference.PageMode;
            this.ViewerPreference = viewerPreference.ViewerPreferences;
        }

        public virtual void Dispose()
        {
            if (document != null)
            {
                try
                {
                    document.Close();
                }
                catch (Exception)
                { }
            }
        }

        public void Close()
        {
            this.Dispose();
        }
    }
}
