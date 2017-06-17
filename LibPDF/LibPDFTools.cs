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

using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Net;
using iTextSharp.text.pdf.codec;

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

        static public BaseFont GetBaseFont(string familyName)
        {
            if (familyName == null)
                familyName = "";
            string enc = LibPDFTools.GetDefaultEncoding(familyName);
            BaseFont baseFont = BaseFont.CreateFont(familyName, enc, BaseFont.NOT_EMBEDDED);
            return baseFont;
        }

        static public Font GetFont(string familyName, float size, int style)
        {
            if (familyName == null)
                familyName = "";
            Font font;
            if (familyName.Trim() == "")
            {

                font = new Font(Font.FontFamily.UNDEFINED, size, style);
            }
            else
            {
                Font.FontFamily familyIndex = Font.GetFamilyIndex(familyName);
                if (familyIndex != Font.FontFamily.UNDEFINED)
                {
                    font = new Font(familyIndex, size, style);
                }
                else
                {
                    font = new Font(GetBaseFont(familyName), size, style);
                }
            }
            return font;
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

        public static PdfReader CreatePdfReader(string filename, ListenPasswordHandler passwordListener, bool requiresOwnerPermission)
        {
            var bytes = ToUri(filename);
            return CreatePdfReader(bytes, passwordListener, requiresOwnerPermission);
        }

        public static PdfReader CreatePdfReader(byte[] bytes, ListenPasswordHandler passwordListener, bool requiresOwnerPermission)
        {
            PdfReader reader = null;
            try
            {
                reader = new PdfReader(bytes);
                
            }
            catch (BadPasswordException ex)
            {
                reader = ListenPassword(bytes, passwordListener, reader, ex);
            }

            while (requiresOwnerPermission && !reader.IsOpenedWithFullPermissions)
            {
                reader = ListenPassword(bytes, passwordListener, reader, new BadPasswordException("Owner password is required."));
            }

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
                reader = new PdfReader(bytes, password);
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
            var isp = wr.GetResponse().GetResponseStream();
            byte[] bytes = null;
            try
            {
                bytes = RandomAccessFileOrArray.InputStreamToArray(isp);
            }
            finally
            {
                try
                {
                    isp.Close();
                }
                catch (Exception)
                {
                }
            }
            return bytes;
        }

        public static PdfReader CreatePdfReader(Uri uri, ListenPasswordHandler passwordListener, bool requiresOwnerPermission)
        {
            var bytes = GetBytes(uri);
            return CreatePdfReader(bytes, passwordListener, requiresOwnerPermission);
        }

        internal static PdfReader CreatePdfReaderFromTiff(byte[] sourceBytes, Rectangle pageSize, Margins margins)
        {
            using (var document = new Document())
            {
                using (var stream = new MemoryStream())
                {
                    using (var writer = PdfWriter.GetInstance(document, stream))
                    {
                        var ra = new RandomAccessFileOrArray(sourceBytes);
                        int numberOfPages = TiffImage.GetNumberOfPages(ra);
                        for (int i = 1; i <= numberOfPages; i++)
                        {
                            var image = TiffImage.GetTiffImage(ra, i);
                            Rectangle currentPageSize = pageSize == null ? new Rectangle(image.ScaledWidth + margins.Left + margins.Right + 1, image.ScaledHeight + margins.Top + margins.Bottom + 1) : pageSize;
                            document.SetPageSize(currentPageSize);
                            document.SetMargins(margins.Left, margins.Right, margins.Top, margins.Bottom);
                            if (i == 1)
                            {
                                document.Open();
                            }
                            else
                            {
                                document.NewPage();
                            }
                            if (pageSize != null)
                            {
                                float width = pageSize.Width - (margins.Left + margins.Right + 1);
                                float height = pageSize.Height - (margins.Top + margins.Bottom + 1);
                                if (width <= 0 || height <= 0)
                                    throw new IOException("Margin is too big.");
                                image.ScaleToFit(width, height);
                            }
                            document.Add(image);
                        }
                        document.Close();
                        ra.Close();
                    }
                    var pdfArray = stream.ToArray();
                    return new PdfReader(pdfArray);
                }
            }
        }
               
        public static PdfReader CreatePdfReaderFromImage(byte[] sourceBytes, Rectangle pageSize, Margins margins)
        {
            Image image = Image.GetInstance(sourceBytes);
            if (pageSize == null)
            {
                pageSize = new Rectangle(image.ScaledWidth + margins.Left + margins.Right + 1, image.ScaledHeight + margins.Top + margins.Bottom + 1);
            }
            else
            {
                //}‚Ì‘å‚«‚³
                float width = pageSize.Width - (margins.Left + margins.Right + 1);
                float height = pageSize.Height - (margins.Top + margins.Bottom + 1);
                if (width <= 0 || height <= 0)
                    throw new IOException("Margin is too big.");
                image.ScaleToFit(width, height);
            }

            using (var document = new Document(pageSize, margins.Left, margins.Right, margins.Top, margins.Bottom))
            {
                using (var stream = new MemoryStream())
                {
                    using (var writer = PdfWriter.GetInstance(document, stream))
                    {
                        document.Open();
                        document.Add(image);
                        document.Close();
                    }
                    var pdfArray = stream.ToArray();
                    return new PdfReader(pdfArray);
                }
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
