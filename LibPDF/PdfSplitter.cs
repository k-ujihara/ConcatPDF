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

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Collections.Generic;
using System;

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
            PdfReader reader = LibPDFTools.CreatePdfReader(url, QueryPassword, false);
            try
            {
                reader.ConsolidateNamedDestinations();
                IList<Dictionary<string, object>> bookmarks = SimpleBookmark.GetBookmark(reader);
                int numberOfPages = reader.NumberOfPages;
                string[] splittedFiles = new string[numberOfPages];
                Directory.CreateDirectory(splittedFilesDirectoryName);

                for (int i = 1; i <= numberOfPages; i++)
                {
                    string splittedFile = Path.Combine(splittedFilesDirectoryName, prefixOfFileName + i.ToString("D10") + ".pdf");
                    splittedFiles[i - 1] = splittedFile;

                    //extract bookmarks on the page
                    IList<Dictionary<string, object>> bookmark = null;
                    if (bookmarks != null)
                    {
                        bookmark = new List<Dictionary<string, object>>(bookmarks);
                        int[] rs;
                        rs = new int[4];
                        rs[0] = 1;
                        rs[1] = i - 1;
                        rs[2] = i + 1;
                        rs[3] = numberOfPages;
                        SimpleBookmark.EliminatePages(bookmark, rs);
                        rs = new int[2];
                        rs[0] = rs[1] = i;
                        SimpleBookmark.ShiftPageNumbers(bookmark, 1 - i, rs);
                    }

                    using (var document = new Document(reader.GetPageSizeWithRotation(i)))
                    {
                        using (var outStream = new FileStream(splittedFile, FileMode.Create, FileAccess.Write))
                        {
                            using (var writer = new PdfCopy(document, outStream))
                            {
                                document.Open();
                                PdfImportedPage page = writer.GetImportedPage(reader, i);
                                writer.AddPage(page);
                                if (bookmark != null)
                                    writer.Outlines = bookmark;
                                writer.Close();
                            }
                            outStream.Close();
                        }
                        document.Close();
                    }
                }
                return splittedFiles;
            }
            finally
            {
                reader.Close();
            }
        }

        public string[] Split(string pdfFile, string splittedPdfFilesDir)
        {
            return Split(pdfFile, splittedPdfFilesDir, "");
        }
    }
}
