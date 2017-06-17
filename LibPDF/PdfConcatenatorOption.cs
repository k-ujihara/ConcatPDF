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

namespace Ujihara.PDF
{
    public class PdfConcatenatorOption
    {
        public bool AddOutlines { get; set; }
        public bool CopyOutlines { get; set; }
        public string FittingStyle { get; set; }
        public Margins Margins { get; set; }
        public Font Font { get; set; }
        public string Charset { get; set; }
        //private Color backgroundColor = null;
        //private WatermarkIdent watermark = null;
        private string paperName = null;
        private Rectangle pageSize = null; // not defined
        public bool Landscape { get; set; }

        public PdfConcatenatorOption()
            : this(false, false, "/XYZ null null null")
        {
        }

        public PdfConcatenatorOption(bool addOutlines, bool copyOutlines, string fittingStyle)
        {
            this.Margins = new Margins();

            this.AddOutlines = addOutlines;
            this.CopyOutlines = copyOutlines;
            this.FittingStyle = fittingStyle;
        }

        public Rectangle PageSize
        {
            get
            {
                return pageSize;
            }
        }

        public void SetPageSize(Rectangle pageSize)
        {
            if (pageSize == null)
            {
                SetPageSize(null, null);
            }
            else
            {
                SetPageSize(pageSize.Width + " " + pageSize.Height, pageSize);
            }
        }

        public void SetPageSize(string paperName, Rectangle pageSize)
        {
            this.paperName = paperName;
            this.pageSize = pageSize;
        }

        public string PaperName
        {
            get
            {
                return this.paperName;
            }
        }

        public Rectangle GetBounds()
        {
            Rectangle pageSize = this.pageSize;
            if (this.Landscape)
                pageSize = pageSize.Rotate();
            return pageSize;
        }
    }
}
