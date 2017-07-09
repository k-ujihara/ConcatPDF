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
using System.Text;
using System.Collections.Generic;
using System;
using iText.Kernel.Utils;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Navigation;

namespace Ujihara.PDF
{
    public class PdfConcatenator : PdfConcatenatorBase
    {
        public ListenPasswordHandler QueryPassword = null;
        private bool opened = false;
        private PdfMerger merger = null;
        private PdfWriter writer = null;
        private int currPageNum = 1;
        private IList<Dictionary<string, object>> bookmarks = null;

        public PdfConcatenator(Stream outStream)
            : this(outStream, (PdfEncryptInfo)null)
        {
        }

        public PdfConcatenator(Stream outStream, PdfEncryptInfo encryptInfo)
            : this(outStream, encryptInfo, null)
        {
        }

        public PdfConcatenator(Stream outStream, PdfEncryptInfo encryptInfo, PageViewerPreferences viewerPreference)
        {
            Setup(outStream, encryptInfo, viewerPreference);
        }

        public void Append(string url, PageRange[] pageRanges, PdfConcatenatorOption option)
        {
            PdfDocument reader = CreatePdfReader(url, option);
            try
            {
                Append(reader, Path.GetFileNameWithoutExtension(url), pageRanges, option);
            }
            finally
            {
                reader.Close();
            }
        }

        public void Append(PdfDocument reader, string title, PageRange[] pageRanges, PdfConcatenatorOption option)
        {
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

        private static PageRange[] NormalizePageRanges(PdfDocument reader, PageRange[] pageRanges)
        {
            if (pageRanges == null)
            {
                pageRanges = new[] { new PageRange(1, reader.GetNumberOfPages()), };
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

        private static int NormalizePageNumber(PdfDocument reader, int start)
        {
            if (start == 0)
                start = 1;
            else if (start < 0) 
                 start = reader.GetNumberOfPages() + 1 + start;
            else if (start > reader.GetNumberOfPages())
                start = reader.GetNumberOfPages();
            return start;
        }

        private void AppendMain(PdfDocument reader, string title, PageRange[] pageRanges, PdfConcatenatorOption option)
        {
            bool addOutlines = option.AddOutlines;
            bool copyOutlines = option.CopyOutlines;

            int i;

            int numberOfPages = reader.GetNumberOfPages();
            bool[] appendOrNots = new bool[numberOfPages + 1];
            foreach (var pr in pageRanges)
            {
                for (int j = pr.StartPage; j <= pr.EndPage; j++)
                    appendOrNots[j] = true;
            }

            int theFirstPage = 0;
            for (i = 1; i <= numberOfPages; i++)
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

            PdfOutline rootOutline = null;
            if (!opened)
            {
                opened = true;
                var prop = new WriterProperties();
                if (EncryptInfo.OwnerPassword != null)
                {
                    byte[] bytesUserPassword = EncryptInfo.UserPassword == null ? null : Encoding.ASCII.GetBytes(EncryptInfo.UserPassword);
                    prop.SetStandardEncryption(bytesUserPassword, Encoding.ASCII.GetBytes(EncryptInfo.OwnerPassword), EncryptInfo.Permission,  EncryptInfo.Encryption);
                }
                writer = new PdfWriter(outStream, prop);
                document = new PdfDocument(writer);
                rootOutline = document.GetOutlines(false);
                merger = new PdfMerger(document, true, copyOutlines);

                if (PageLayout != null)
                    document.GetCatalog().SetPageLayout(PageLayout);
                if (PageMode != null)
                    document.GetCatalog().SetPageMode(PageMode);
                if (ViewerPreference != null)
                   document.GetCatalog().SetViewerPreferences(ViewerPreference);
            }

            if (addOutlines)
            {
                PdfOutline outline = rootOutline.AddOutline(title);
                var styleOption = option.FittingStyle.Split(' ');
                var type = styleOption[0];
                PdfExplicitDestination dest;
                switch (type)
                {
                    case "Fit":
                        dest = PdfExplicitDestination.CreateFit(currPageNum);
                        break;
                    case "FitB":
                        dest = PdfExplicitDestination.CreateFitB(currPageNum);
                        break;
                    case "FitBH":
                        dest = PdfExplicitDestination.CreateFitBH(currPageNum, float.Parse(styleOption[1]));
                        break;
                    case "FitBV":
                        dest = PdfExplicitDestination.CreateFitBV(currPageNum, float.Parse(styleOption[1]));
                        break;
                    case "FitH":
                        dest = PdfExplicitDestination.CreateFitH(currPageNum, float.Parse(styleOption[1]));
                        break;
                    case "FitR":
                        dest = PdfExplicitDestination.CreateFitR(currPageNum, float.Parse(styleOption[1]), float.Parse(styleOption[2]), float.Parse(styleOption[3]), float.Parse(styleOption[4]));
                        break;
                    case "FitV":
                        dest = PdfExplicitDestination.CreateFitV(currPageNum, float.Parse(styleOption[1]));
                        break;
                    case "XYZ":
                        dest = PdfExplicitDestination.CreateXYZ(currPageNum, float.Parse(styleOption[1]), float.Parse(styleOption[2]), float.Parse(styleOption[3]));
                        break;
                    default:
                        dest = null;
                        break;
                }

                if (dest != null)
                    outline.AddDestination(dest);
            }

            {
                var pages = new List<int>();
                for (int ii = 1; ii < appendOrNots.Length; ii++)
                    if (appendOrNots[ii])
                        pages.Add(ii);
                merger.Merge(reader, pages);
            }
        }

        public PdfDocument CreatePdfReader(string url, PdfConcatenatorOption option)
        {
            var bytes = LibPDFTools.GetBytes(LibPDFTools.ToUri(url));
            return CreatePdfReader(bytes, option);
        }

        public PdfDocument CreatePdfReader(byte[] bytes, PdfConcatenatorOption option)
        {
            PdfDocument reader;
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