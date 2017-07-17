using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Ujihara.ConcatPDF
{
    public partial class ImageSettingDialog : Form
    {
        public ImageSettingDialog()
        {
            InitializeComponent();
        }

        public float DPI
        {
            get
            {
                return float.Parse(textResolution.Text);
            }

            set
            {
                textResolution.Text = value.ToString();
            }
        }

        private void textResolution_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            var text = textBox.Text.Trim();
            float v;
            if (float.TryParse(text, out v) && v > 1f)
            {
                textBox.Text = v.ToString();
                floatErrorProvider.SetError((Control)sender, string.Empty);
            }
            else
            {
                this.floatErrorProvider.SetError(textBox, "Illegal value.");
            }
        }
    }
}
