/*
    Copyright 2003, 2004, 2012, 2017 by Kazuya Ujihara. 
  
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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;
using System.Collections.Generic;
using System;

namespace Ujihara.PDF
{
    public class PdfConcatenator : PdfConcatenatorBase
    {
        public ListenPasswordHandler QueryPassword = null;
        private bool opened = false;
        private PdfCopy writer = null;
        private int currPageNum = 1;
        private IList<Dictionary<string, object>> bookmarks = null;

        public PdfConcatenator(Stream outStream)
            : this(outStream, (PdfEncryptInfo)null, 0)
        {
        }

        public PdfConcatenator(Stream outStream, PdfEncryptInfo encryptInfo)
            : this(outStream, encryptInfo, 0)
        {
        }

        public PdfConcatenator(Stream outStream, int viewerPreference)
            : this(outStream, (PdfEncryptInfo)null, viewerPreference)
        {
        }

        public PdfConcatenator(Stream outStream, PdfEncryptInfo encryptInfo, int viewerPreference)
        {
            if (encryptInfo == null)
                Setup(outStream, 0, null, null, 0, viewerPreference);
            else
                Setup(outStream, encryptInfo.encryptionLength, encryptInfo.userPassword, encryptInfo.ownerPassword, encryptInfo.permissions, viewerPreference);
        }

        public void Append(string url, PageRange[] pageRanges, PdfConcatenatorOption option)
        {
            PdfReader reader = CreatePdfReader(url, option);
            try
            {
                Append(reader, Path.GetFileNameWithoutExtension(url), pageRanges, option);
            }
            finally
            {
                reader.Close();
            }
        }

        public void Append(PdfReader reader, string title, PageRange[] pageRanges, PdfConcatenatorOption option)
        {
            reader.ConsolidateNamedDestinations();
            pageRanges = NormalizePageRanges(reader, pageRanges);

            var thePageRangess = new List<PageRange[]>();
            for (int i = 0; i < pageRanges.Length; i++)
            {
                var thePageRanges = new List<PageRange>();
                var prev = new PageRange(0, 0);
                int j;
                for (j = i; j < pageRanges.Length; j++)
                {
                    if (prev.EndPage < pageRanges[j].StartPage)
                    {
                        thePageRanges.Add(prev = pageRanges[j]);
                    }
                    else
                    {
                        j--;
                        break;
                    }
                }
                i = j;
                thePageRangess.Add(thePageRanges.ToArray());
            }
            foreach (var prs in thePageRangess)
            {
                AppendMain(reader, title, prs, option);
            }
        }

        private static PageRange[] NormalizePageRanges(PdfReader reader, PageRange[] pageRanges)
        {
            if (pageRanges == null)
            {
                pageRanges = new[] { new PageRange(1, reader.NumberOfPages), };
            }
            else
            {
                var newPageRanges = new List<PageRange>();
                for (int i = 0; i < pageRanges.Length; i++)
                {
                    var start = NormalizePageNumber(reader, pageRanges[i].StartPage);
                    var end = NormalizePageNumber(reader, pageRanges[i].EndPage);
                    if (start > end)
                    {
                        var temp = start;
                        end = start;
                        start = temp;
                    }
                    newPageRanges.Add(new PageRange(start, end));
                }
                pageRanges = newPageRanges.ToArray();
            }
            return pageRanges;
        }

        private static int NormalizePageNumber(PdfReader reader, int start)
        {
            if (start == 0)
                start = 1;
            else if (start < 0)
                start = reader.NumberOfPages + 1 + start;
            else if (start > reader.NumberOfPages)
                start = reader.NumberOfPages;
            return start;
        }

        private void AppendMain(PdfReader reader, string title, PageRange[] pageRanges, PdfConcatenatorOption option)
        {
            bool addOutlines = option.AddOutlines;
            bool copyOutlines = option.CopyOutlines;

            int i;

            bool[] appendOrNots = new bool[reader.NumberOfPages + 1];
            foreach (var pr in pageRanges)
            {
                for (int j = pr.StartPage; j <= pr.EndPage; j++)
                    appendOrNots[j] = true;
            }

            int theFirstPage = 0;
            for (i = 1; i <= reader.NumberOfPages; i++)
            {
                if (appendOrNots[i])
                {
                    theFirstPage = i;
                    break;
                }
            }
            if (theFirstPage == 0)
            {
                // There is no append paes.
                return;
            }

            if (!opened)
            {
                opened = true;
                document = new Document(reader.GetPageSizeWithRotation(theFirstPage));
                writer = new PdfCopy(document, outStream);
                writer.SetMergeFields();

                if (ownerPassword != null)
                {
                    byte[] bytesUserPassword = userPassword == null ? null : Encoding.ASCII.GetBytes(userPassword);
                    writer.SetEncryption(bytesUserPassword, Encoding.ASCII.GetBytes(ownerPassword), permissions, encryptionStrength);
                }
                writer.ViewerPreferences = this.viewerPreference;

                document.Open();
            }

            if (bookmarks == null)
                if (addOutlines || copyOutlines)
                    bookmarks = new List<Dictionary<string, object>>();
            if (bookmarks != null)
            {
                Dictionary<string, object> m = null;
                if (addOutlines)
                {
                    m = new Dictionary<string, object>();
                    m["Title"] = title;
                    m["Action"] = "GoTo";
                    m["Page"] = currPageNum.ToString() + " " + option.FittingStyle;
                }
                if (copyOutlines)
                {
                    var cpbookmarks = SimpleBookmark.GetBookmark(reader);

                    if (cpbookmarks != null)
                    {
                        int[] elimPages = new int[2];
                        int[] shiftPages = new int[2];
                        shiftPages[1] = reader.NumberOfPages;
                        for (int pageIndex = reader.NumberOfPages; pageIndex > 0; --pageIndex)
                        {
                            if (!appendOrNots[pageIndex])
                            {
                                elimPages[0] = elimPages[1] = pageIndex;
                                shiftPages[0] = pageIndex + 1;
                                SimpleBookmark.EliminatePages(cpbookmarks, elimPages);
                                SimpleBookmark.ShiftPageNumbers(cpbookmarks, -1, shiftPages);
                            }
                        }
                        SimpleBookmark.ShiftPageNumbers(cpbookmarks, currPageNum - 1, null);

                        if (m == null)
                        {
                            foreach (var c in cpbookmarks)
                                bookmarks.Add(c);
                        }
                        else
                            m["Kids"] = cpbookmarks;
                    }
                }
                if (m != null)
                    bookmarks.Add(m);
            }

            {
                var pages = new List<int>();
                for (int ii = 1; ii < appendOrNots.Length; ii++)
                    if (appendOrNots[ii])
                        pages.Add(ii);
                reader.SelectPages(pages);
                writer.AddDocument(reader);
            }
        }

        public PdfReader CreatePdfReader(string url, PdfConcatenatorOption option)
        {
            var bytes = LibPDFTools.GetBytes(LibPDFTools.ToUri(url));
            return CreatePdfReader(bytes, option);
        }

        public PdfReader CreatePdfReader(byte[] bytes, PdfConcatenatorOption option)
        {
            PdfReader reader;
            switch (LibPDFTools.GetImageFileType(bytes))
            {
                case ImageFileType.PDF:
                    reader = LibPDFTools.CreatePdfReader(bytes, QueryPassword, true);
                    break;
                case ImageFileType.TIFF:
                    reader = LibPDFTools.CreatePdfReaderFromTiff(bytes, option.GetBounds(), option.Margins);
                    break;
                default:
                    reader = LibPDFTools.CreatePdfReaderFromImage(bytes, option.GetBounds(), option.Margins);
                    break;
            }
            return reader;
        }

        public override void Dispose()
        {
            if (bookmarks != null)
                writer.Outlines = bookmarks;
            if (writer != null)
            {
                try
                {
                    writer.Close();
                }
                catch (Exception)
                { }
            }
            base.Dispose();
        }
    }
}