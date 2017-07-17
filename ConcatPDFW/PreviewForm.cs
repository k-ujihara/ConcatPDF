using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Ujihara.PDF;
using System.IO;
using System.Security;

namespace Ujihara.ConcatPDF
{
    public partial class PreviewForm : Form
    {
        PDFLibNet.PDFWrapper pdfDoc = new PDFLibNet.PDFWrapper("");
        string currentUrlOfPdf = null;
        public ListenPasswordWithFileNameHandler QueryPassword;

        public PreviewForm()
        {
            InitializeComponent();
        }

        public void LoadImage(string url, ref byte[] password)
        {
            if (currentUrlOfPdf == url)
                return;

            var bytes = LibPDFTools.GetBytes(url);
            var ms = new MemoryStream(bytes);

            Image pageBuffer;
            switch (LibPDFTools.GetImageFileType(bytes))
            {
                case ImageFileType.PDF:
                    byte[] newPassword = password;
                L100:
                    try
                    {
                        if (newPassword != null)
                            pdfDoc.OwnerPassword = Encoding.ASCII.GetString(newPassword);
                        pdfDoc.LoadPDF(url);
                        password = newPassword;
                    }
                    catch (SecurityException se)
                    {
                        if (QueryPassword == null)
                            throw se;
                        if (QueryPassword != null)
                        {
                            newPassword = QueryPassword(url);
                            if (newPassword == null)
                                throw se;
                            
                            goto L100;
                        }
                    }

                    pdfDoc.CurrentPage = 1;
                    pdfDoc.CurrentX = 0;
                    pdfDoc.CurrentY = 0;
                    pdfDoc.RenderDPI = 72;
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
                    break;
                default:
                    pageBuffer = System.Drawing.Image.FromStream(ms);
                    break;
            }
            LoadImage(pageBuffer, url);
            GC.Collect();
        }

        public void LoadImage(System.Drawing.Image image, string originalUrl)
        {
            pictureBox.Image = image;
            currentUrlOfPdf = originalUrl; //unknown
        }

        public void LoadImage(System.Drawing.Image image)
        {
            LoadImage(image, null);
        }

        private void PreviewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            pdfDoc.Dispose();
        }
    }
}
