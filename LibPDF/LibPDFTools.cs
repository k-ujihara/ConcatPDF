/*
    Copyright 2003, 2012 by Kazuya Ujihara. 
  
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

using iText.IO.Image;
using iText.Kernel.Crypto;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using System;
using System.IO;
using System.Net;

namespace Ujihara.PDF
{
    public class LibPDFTools
    {
        private LibPDFTools()
        {
        }

        static public string GetDefaultEncoding(string fontFamilyName)
        {
            string enc;
            switch (fontFamilyName)
            {
                case "HeiseiMin-W3":
                case "HeiseiKakuGo-W5":
                case "KozMinPro-Regular":
                    enc = "UniJIS-UCS2-H";
                    break;
                default:
                    enc = "";
                    break;
            }
            return enc;
        }

        static public PdfFont GetBaseFont(string familyName)
        {
            if (familyName == null)
                familyName = "";
            string enc = LibPDFTools.GetDefaultEncoding(familyName);
            PdfFont baseFont = PdfFontFactory.CreateFont(familyName, enc, false);
            return baseFont;
        }        

        public static Uri ToUri(string filenameOrUrl)
        {
            Uri inUri = null;
            {
                try
                {
                    inUri = new Uri(filenameOrUrl);
                }
                catch (UriFormatException)
                {
                    var s = new FileInfo(filenameOrUrl);
                    inUri = new Uri(s.FullName);
                }
            }
            return inUri;
        }

        public static PdfDocument CreatePdfReader(string filename, ListenPasswordHandler passwordListener, bool requiresOwnerPermission)
        {
            var uri = ToUri(filename);
            return CreatePdfReader(uri, passwordListener, requiresOwnerPermission);
        }

        public static PdfDocument CreatePdfReader(byte[] bytes, ListenPasswordHandler passwordListener, bool requiresOwnerPermission)
        {
            PdfReader rreader = null;
            try
            {
                rreader = new PdfReader(new MemoryStream(bytes));
            }
            catch (BadPasswordException ex)
            {
                rreader = ListenPassword(bytes, passwordListener, rreader, ex);
            }

            while (requiresOwnerPermission && !rreader.IsOpenedWithFullPermission())
            {
                rreader = ListenPassword(bytes, passwordListener, rreader, new BadPasswordException("Owner password is required."));
            }

            PdfDocument reader = null;
            reader = new PdfDocument(rreader);

            return reader;
        }

        private static PdfReader ListenPassword(byte[] bytes, ListenPasswordHandler passwordListener, PdfReader reader, BadPasswordException ex)
        {
            if (passwordListener == null)
                throw ex;
        L10:
            byte[] password = passwordListener();
            if (password == null)
                throw ex;
            try
            {
                ReaderProperties prop = new ReaderProperties();
                prop.SetPassword(password);
                reader = new PdfReader(new MemoryStream(bytes), prop);
            }
            catch (BadPasswordException)
            {
                goto L10;
            }
            return reader;
        }

        public static byte[] GetBytes(string url)
        {
            return LibPDFTools.GetBytes(LibPDFTools.ToUri(url));
        }

        public static byte[] GetBytes(Uri uri)
        {
            WebRequest wr = WebRequest.Create(uri);
            wr.Credentials = CredentialCache.DefaultCredentials;
            using (var res = wr.GetResponse())
            using (var isp = res.GetResponseStream())
            {
                byte[] bytes = null;
                using (var aa = new MemoryStream())
                {
                    int b;
                    while ((b = isp.ReadByte()) != -1)
                    {
                        aa.WriteByte((byte)b);
                    }
                    bytes = aa.ToArray();

                    return bytes;
                }
            }
        }

        public static PdfDocument CreatePdfReader(Uri uri, ListenPasswordHandler passwordListener, bool requiresOwnerPermission)
        {
            var bytes = GetBytes(uri);
            return CreatePdfReader(bytes, passwordListener, requiresOwnerPermission);
        }

        internal static PdfDocument CreatePdfReaderFromTiff(byte[] sourceBytes, PageSize pageSize, Margins margins)
        {
            using (var stream = new MemoryStream())
            {
                PdfDocument pdfDoc = new PdfDocument(new PdfWriter(stream));
                try
                {
                    Document doc = null;

                    using (var ra = new MemoryStream(sourceBytes))
                    {
                        int numberOfPages = TiffImageData.GetNumberOfPages(sourceBytes);
                        for (int i = 1; i <= numberOfPages; i++)
                        {
                            var image = new Image(ImageDataFactory.CreateTiff(sourceBytes, true, i, true));
                             PageSize currentPageSize = pageSize == null ? new PageSize(image.GetImageScaledWidth() + margins.Left + margins.Right + 1, image.GetImageScaledHeight() + margins.Top + margins.Bottom + 1) : pageSize;

                            if (doc == null)
                                doc = new Document(pdfDoc, currentPageSize);

                            pdfDoc.AddNewPage(currentPageSize);
                            doc.SetMargins(margins.Left, margins.Right, margins.Top, margins.Bottom);
                            doc.Add(image);
                        }
                    }
                    doc.Close();
                }
                finally
                {
                    pdfDoc.Close();
                }

                var pdfArray = stream.ToArray();
                var r = new PdfReader(new MemoryStream(pdfArray));
                return new PdfDocument(r);
            }
        }

        public static PdfDocument CreatePdfReaderFromImage(byte[] sourceBytes, PageSize pageSize, Margins margins)
        {
            Image image = new Image(ImageDataFactory.Create(sourceBytes));
            if (pageSize == null)
            {
                pageSize = new PageSize(image.GetImageScaledWidth() + margins.Left + margins.Right + 1, image.GetImageScaledHeight() + margins.Top + margins.Bottom + 1);
            }
            else
            {
                //}‚Ì‘å‚«‚³
                float width = pageSize.GetWidth() - (margins.Left + margins.Right + 1);
                float height = pageSize.GetHeight() - (margins.Top + margins.Bottom + 1);
                if (width <= 0 || height <= 0)
                    throw new IOException("Margin is too big.");
                image.ScaleToFit(width, height);
            }

            using (var stream = new MemoryStream())
            {
                PdfDocument pdfDoc = new PdfDocument(new PdfWriter(stream));
                var document = new Document(pdfDoc, pageSize);
                document.SetMargins(margins.Left, margins.Right, margins.Top, margins.Bottom);
                document.Add(image);
                document.Close();

                var pdfArray = stream.ToArray();
                var r = new PdfReader(new MemoryStream(pdfArray));
                return new PdfDocument(r);
            }
        }

        private static int[] PNGID = { 137, 80, 78, 71, 13, 10, 26, 10 };
        public static ImageFileType GetImageFileType(byte[] cc)
        {
            if (cc[0] == 'G' && cc[1] == 'I' && cc[2] == 'F')
                return ImageFileType.GIF;
            if (cc[0] == 0xFF && cc[1] == 0xD8)
                return ImageFileType.JPEG;
            if (cc[0] == 0x00 && cc[1] == 0x00 && cc[2] == 0x00 && cc[3] == 0x0c)
                return ImageFileType.JPEG2000;
            if (cc[0] == 0xff && cc[1] == 0x4f && cc[2] == 0xff && cc[3] == 0x51)
                return ImageFileType.JPEG2000;
            if (cc[0] == PNGID[0] && cc[1] == PNGID[1] && cc[2] == PNGID[2] && cc[3] == PNGID[3])
                return ImageFileType.PNG;
            if (cc[0] == 0xD7 && cc[1] == 0xCD)
                return ImageFileType.WMF;
            if (cc[0] == 'B' && cc[1] == 'M')
                return ImageFileType.BMP;
            if ((cc[0] == 'M' && cc[1] == 'M' && cc[2] == 0 && cc[3] == 42)
                    || (cc[0] == 'I' && cc[1] == 'I' && cc[2] == 42 && cc[3] == 0))
                return ImageFileType.TIFF;
            if (cc[0] == '%' && cc[1] == 'P' && cc[2] == 'D' && cc[3] == 'F')
                return ImageFileType.PDF;

            return ImageFileType.Unknown;
        }
    }

    public enum ImageFileType
    {
        Unknown,
        GIF,
        JPEG,
        JPEG2000,
        PNG,
        TIFF,
        WMF,
        BMP,
        PDF,
    }
}
