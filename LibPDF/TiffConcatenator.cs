/*
    Copyright 2012 by Kazuya Ujihara. 
  
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
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Drawing;

namespace Ujihara.PDF
{
    public class TiffConcatenator : IDisposable
    {
        private static ImageCodecInfo codec;
        private static EncoderParameters encoderParameters_MultiFrame;
        private static EncoderParameters encoderParameters_FrameDimensionPage;
        private static EncoderParameters encoderParameters_Flush;

        static TiffConcatenator()
        {
            foreach (var codecInfo in ImageCodecInfo.GetImageEncoders())
                if (codecInfo.MimeType == "image/tiff")
                    codec = codecInfo;

            encoderParameters_MultiFrame = new EncoderParameters(1);
            encoderParameters_MultiFrame.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.MultiFrame);
            encoderParameters_FrameDimensionPage = new EncoderParameters(1);
            encoderParameters_FrameDimensionPage.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.FrameDimensionPage);
            encoderParameters_Flush = new EncoderParameters(1);
            encoderParameters_Flush.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)EncoderValue.Flush);
        }

        protected Stream outStream;
        private int currPageNum;
        private double resolution;
        System.Drawing.Image backbuffer;

        public TiffConcatenator(Stream outStream, double resolution)
        {
            if (codec == null)
                throw new ApplicationException("TIFF Codec is not installd.");

            this.outStream = outStream;
            currPageNum = 0;
            this.resolution = resolution;
        }

        public void Append(byte[] bytes)
        {
            using (var ms = new MemoryStream(bytes))
            {
                switch (LibPDFTools.GetImageFileType(bytes))
                {
                    case ImageFileType.PDF:
                        using (var pdfDoc = new PDFLibNet.PDFWrapper(""))
                        {
                            pdfDoc.LoadPDF(ms);
                            for (var i = 1; i <= pdfDoc.PageCount; i++)
                            {
                                pdfDoc.CurrentPage = i;
                                pdfDoc.CurrentX = 0;
                                pdfDoc.CurrentY = 0;
                                pdfDoc.RenderDPI = this.resolution;

                                Bitmap pageBuffer = null;
                                using (var oPictureBox = new PictureBox())
                                {
                                    pdfDoc.RenderPage(oPictureBox.Handle);
                                    pageBuffer = new Bitmap(pdfDoc.PageWidth, pdfDoc.PageHeight);
                                    pdfDoc.ClientBounds = new System.Drawing.Rectangle(0, 0, pdfDoc.PageWidth, pdfDoc.PageHeight);
                                    using (var g = Graphics.FromImage(pageBuffer))
                                    {
                                        var hdc = g.GetHdc();
                                        pdfDoc.DrawPageHDC(hdc);
                                        g.ReleaseHdc();
                                    }
                                }
                                SaveAddTiffPage(pageBuffer);
                                pageBuffer.Dispose();

                                currPageNum++;
                            }
                        }
                        break;
                    case ImageFileType.TIFF:
                        {
                            using (var image = System.Drawing.Image.FromStream(ms))
                            {
                                var fd = new System.Drawing.Imaging.FrameDimension(image.FrameDimensionsList[0]);
                                int numberOfPages = image.GetFrameCount(fd);

                                for (int pageNum = 0; pageNum < numberOfPages; pageNum++)
                                {
                                    image.SelectActiveFrame(fd, pageNum);
                                    if (currPageNum == 0)
                                    {
                                        backbuffer = (System.Drawing.Image)image.Clone();
                                        backbuffer.Save(outStream, codec, encoderParameters_MultiFrame);
                                    }
                                    else
                                    {
                                        backbuffer.SaveAdd(image, encoderParameters_FrameDimensionPage);
                                    }
                                    currPageNum++;
                                }
                            }
                        }
                        break;
                    default:
                        {
                            var pageBuffer = System.Drawing.Image.FromStream(ms);
                            SaveAddTiffPage(pageBuffer);
                        }
                        currPageNum++;
                        break;
                }
            }
        }

        private void SaveAddTiffPage(System.Drawing.Image backbuffer2)
        {
            if (currPageNum == 0)
            {
                backbuffer = backbuffer2;
                backbuffer.Save(outStream, codec, encoderParameters_MultiFrame);
            }
            else
            {
                backbuffer.SaveAdd(backbuffer2, encoderParameters_FrameDimensionPage);
                backbuffer2.Dispose();
            }
        }

        public void Append(string url)
        {
            Append(LibPDFTools.GetBytes(url));
        }

        public virtual void Close()
        {
            backbuffer.SaveAdd(encoderParameters_Flush);
        }

        public void Dispose()
        {
            this.Close();
        }
    }
}
