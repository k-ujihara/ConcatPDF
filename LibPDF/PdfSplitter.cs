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

using System.IO;
using System.Collections.Generic;
using System;
using iText.Kernel.Pdf;
using static iText.Kernel.Utils.PdfSplitter;
using iText.IO.Source;

namespace Ujihara.PDF
{
    public class PdfSplitter
    {
        public PdfSplitter()
        {
        }

        public ListenPasswordHandler QueryPassword = null;

        public string[] Split(string url, string splittedFilesDirectoryName, string prefixOfFileName)
        {
            var bytes = LibPDFTools.GetBytes(url);
            switch (LibPDFTools.GetImageFileType(bytes))
            {
                case ImageFileType.PDF:
                    return SplitPdf(url, splittedFilesDirectoryName, prefixOfFileName);
                case ImageFileType.TIFF:
                    return SplitTiff(bytes, splittedFilesDirectoryName, prefixOfFileName);
                default:
                    throw new ArgumentException();
            }
        }

        private static string[] SplitTiff(byte[] bytes, string splittedFilesDirectoryName, string prefixOfFileName)
        {
            using (var byteStream = new MemoryStream(bytes))
            {
                var image = System.Drawing.Image.FromStream(byteStream);
                var fd = new System.Drawing.Imaging.FrameDimension(image.FrameDimensionsList[0]);
                int numberOfPages = image.GetFrameCount(fd);
                var splittedFiles = new string[numberOfPages];
                Directory.CreateDirectory(splittedFilesDirectoryName);

                for (int pageNum = 0; pageNum < numberOfPages; pageNum++)
                {
                    image.SelectActiveFrame(fd, pageNum);
                    string filename = Path.Combine(splittedFilesDirectoryName, prefixOfFileName + pageNum.ToString("D10") + ".tif");
                    image.Save(filename, System.Drawing.Imaging.ImageFormat.Tiff);
                    splittedFiles[pageNum] = filename;
                }

                return splittedFiles;
            }
        }

        private string[] SplitPdf(string url, string splittedFilesDirectoryName, string prefixOfFileName)
        {
            var bytes = LibPDFTools.GetBytes(url);

            PdfDocument reader = LibPDFTools.CreatePdfReader(bytes, QueryPassword, false);
            try
            {
                Directory.CreateDirectory(splittedFilesDirectoryName);
                var listener = new DocumentReadyListener(splittedFilesDirectoryName, prefixOfFileName);
                new iText.Kernel.Utils.PdfSplitter(reader).SplitByPageCount(1, listener);
                return listener.Files.ToArray();
            }
            finally
            {
                reader.Close();
            }
        }

        class DocumentReadyListener : IDocumentReadyListener
        {
            public string SplittedFilesDirectoryName { get; }
            public string PrefixOfFileName { get; }
            int i = 1;
            public List<string> Files { get; } = new List<string>();

            public DocumentReadyListener(string splittedFilesDirectoryName, string prefixOfFileName)
            {
                this.SplittedFilesDirectoryName = splittedFilesDirectoryName;
                this.PrefixOfFileName = prefixOfFileName;
            }

            public void DocumentReady(PdfDocument pdfDocument, iText.Kernel.Utils.PageRange pageRange)
            {
                var bytes = ((ByteArrayOutputStream)pdfDocument.GetWriter().GetOutputStream()).ToArray();
                string splittedFile = Path.Combine(SplittedFilesDirectoryName, PrefixOfFileName + i.ToString("D10") + ".pdf");
                using (var ms = new FileStream(splittedFile, FileMode.Create, FileAccess.Write))
                {
                    ms.Write(bytes, 0, bytes.Length);
                    Files.Add(splittedFile);
                }
            }
        }

        public string[] Split(string pdfFile, string splittedPdfFilesDir)
        {
            return Split(pdfFile, splittedPdfFilesDir, "");
        }
    }
}
