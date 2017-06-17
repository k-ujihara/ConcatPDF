/*
 * Copyright (C) 2012 Kazuya Ujihara
 * This library is free software; you can redistribute it and/or modify it under the terms of the GNU Lesser General Public License as published by the Free Software Foundation; either version 2.1 of the License, or (at your option) any later version.
 * This library is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more details.
 * You should have received a copy of the GNU Lesser General Public License along with this library; if not, write to the Free Software Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
 */

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Ujihara.PDF;
using iTextSharp.text;

namespace Ujihara.ConcatPDF
{
	/// <summary>
	/// </summary>
	public class PageSetting : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textMBottom;
		private System.Windows.Forms.TextBox textMRight;
		private System.Windows.Forms.TextBox textMLeft;
		private System.Windows.Forms.TextBox textMTop;
		private System.Windows.Forms.ComboBox comboPageSize;
        private System.Windows.Forms.CheckBox checkLandscape;
        private ErrorProvider floatErrorProvider;
        private ErrorProvider pagesizeErrorProvider;
        private IContainer components;

		public PageSetting()
		{
			InitializeComponent();
		}

		/// <summary>
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows フォーム デザイナで生成されたコード 
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageSetting));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textMBottom = new System.Windows.Forms.TextBox();
            this.textMRight = new System.Windows.Forms.TextBox();
            this.textMLeft = new System.Windows.Forms.TextBox();
            this.textMTop = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboPageSize = new System.Windows.Forms.ComboBox();
            this.checkLandscape = new System.Windows.Forms.CheckBox();
            this.floatErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pagesizeErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.floatErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagesizeErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textMBottom);
            this.groupBox1.Controls.Add(this.textMRight);
            this.groupBox1.Controls.Add(this.textMLeft);
            this.groupBox1.Controls.Add(this.textMTop);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // textMBottom
            // 
            resources.ApplyResources(this.textMBottom, "textMBottom");
            this.textMBottom.Name = "textMBottom";
            this.textMBottom.Validated += new System.EventHandler(this.textMerginValue_Validated);
            // 
            // textMRight
            // 
            resources.ApplyResources(this.textMRight, "textMRight");
            this.textMRight.Name = "textMRight";
            this.textMRight.Validated += new System.EventHandler(this.textMerginValue_Validated);
            // 
            // textMLeft
            // 
            resources.ApplyResources(this.textMLeft, "textMLeft");
            this.textMLeft.Name = "textMLeft";
            this.textMLeft.Validated += new System.EventHandler(this.textMerginValue_Validated);
            // 
            // textMTop
            // 
            resources.ApplyResources(this.textMTop, "textMTop");
            this.textMTop.Name = "textMTop";
            this.textMTop.Validated += new System.EventHandler(this.textMerginValue_Validated);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.Name = "buttonCancel";
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // comboPageSize
            // 
            resources.ApplyResources(this.comboPageSize, "comboPageSize");
            this.comboPageSize.Items.AddRange(new object[] {
            resources.GetString("comboPageSize.Items"),
            resources.GetString("comboPageSize.Items1"),
            resources.GetString("comboPageSize.Items2"),
            resources.GetString("comboPageSize.Items3"),
            resources.GetString("comboPageSize.Items4"),
            resources.GetString("comboPageSize.Items5"),
            resources.GetString("comboPageSize.Items6"),
            resources.GetString("comboPageSize.Items7"),
            resources.GetString("comboPageSize.Items8"),
            resources.GetString("comboPageSize.Items9"),
            resources.GetString("comboPageSize.Items10"),
            resources.GetString("comboPageSize.Items11"),
            resources.GetString("comboPageSize.Items12"),
            resources.GetString("comboPageSize.Items13"),
            resources.GetString("comboPageSize.Items14"),
            resources.GetString("comboPageSize.Items15"),
            resources.GetString("comboPageSize.Items16"),
            resources.GetString("comboPageSize.Items17")});
            this.comboPageSize.Name = "comboPageSize";
            this.comboPageSize.Validated += new System.EventHandler(this.comboPageSize_Validated);
            // 
            // checkLandscape
            // 
            resources.ApplyResources(this.checkLandscape, "checkLandscape");
            this.checkLandscape.Name = "checkLandscape";
            // 
            // floatErrorProvider
            // 
            this.floatErrorProvider.ContainerControl = this;
            // 
            // pagesizeErrorProvider
            // 
            this.pagesizeErrorProvider.ContainerControl = this;
            // 
            // PageSetting
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.buttonCancel;
            this.ControlBox = false;
            this.Controls.Add(this.checkLandscape);
            this.Controls.Add(this.comboPageSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PageSetting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PageSetting_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.floatErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagesizeErrorProvider)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


        public void GetSetting(PdfConcatenatorOption setting)
        {
            setting.Margins.Left = float.Parse(this.textMLeft.Text);
            setting.Margins.Right = float.Parse(this.textMRight.Text);
            setting.Margins.Top = float.Parse(this.textMTop.Text);
            setting.Margins.Bottom = float.Parse(this.textMBottom.Text);
            var pageSize = ToPageSize(this.comboPageSize.Text);
            setting.SetPageSize(this.comboPageSize.Text, pageSize);
            setting.Landscape = checkLandscape.Checked;
        }

        public void SetSetting(PdfConcatenatorOption value)
        {
            this.textMLeft.Text = value.Margins.Left.ToString();
            this.textMRight.Text = value.Margins.Right.ToString();
            this.textMTop.Text = value.Margins.Top.ToString();
            this.textMBottom.Text = value.Margins.Bottom.ToString();
            this.comboPageSize.Text = value.PaperName;
            this.checkLandscape.Checked = value.Landscape;
        }

        private void textMerginValue_Validated(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            var text = textBox.Text.Trim();
            float v;
            if (float.TryParse(text, out v))
            {
                textBox.Text = v.ToString();
                floatErrorProvider.SetError((Control)sender, string.Empty);
            }
            else
            {
                this.floatErrorProvider.SetError(textBox, "Illegal value.");
            }
        }

        private iTextSharp.text.Rectangle ToPageSize(string text)
        {
            if (text == null || text == string.Empty)
                return null;
            return PageSize.GetRectangle(text);
        }

        private void comboPageSize_Validated(object sender, EventArgs e)
        {
            var errorMessage = string.Empty;
            try
            {
                var text = ((Control)sender).Text.Trim();
                ToPageSize(text);
            }
            catch (ArgumentException)
            {
                errorMessage = "Illegal page size. \"width\" height\" for free size.";
            }
            pagesizeErrorProvider.SetError((Control)sender, errorMessage);
        }

        private void PageSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.None && this.DialogResult == DialogResult.OK)
            {
                var dummy = new PdfConcatenatorOption();
                try
                {
                    GetSetting(dummy); // check all values are correct.
                }
                catch (Exception)
                {
                    e.Cancel = true;
                }
            }
        }
	}
}
