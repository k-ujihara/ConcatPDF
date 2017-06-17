using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.IO;

namespace Ujihara.ConcatPDF
{
	public class PwdQueryDlg : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textFileDirectory;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textFileName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox textPassword;

		private System.ComponentModel.Container components = null;

		public PwdQueryDlg()
		{
			InitializeComponent();
		}

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

		#region
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PwdQueryDlg));
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textFileDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textFileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            resources.ApplyResources(this.buttonOK, "buttonOK");
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // textFileDirectory
            // 
            resources.ApplyResources(this.textFileDirectory, "textFileDirectory");
            this.textFileDirectory.BackColor = System.Drawing.SystemColors.Control;
            this.textFileDirectory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textFileDirectory.Name = "textFileDirectory";
            this.textFileDirectory.ReadOnly = true;
            this.textFileDirectory.TabStop = false;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // textFileName
            // 
            resources.ApplyResources(this.textFileName, "textFileName");
            this.textFileName.BackColor = System.Drawing.SystemColors.Control;
            this.textFileName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textFileName.Name = "textFileName";
            this.textFileName.ReadOnly = true;
            this.textFileName.TabStop = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // textPassword
            // 
            resources.ApplyResources(this.textPassword, "textPassword");
            this.textPassword.Name = "textPassword";
            // 
            // PwdQueryDlg
            // 
            this.AcceptButton = this.buttonOK;
            resources.ApplyResources(this, "$this");
            this.CancelButton = this.buttonCancel;
            this.ControlBox = false;
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textFileDirectory);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Name = "PwdQueryDlg";
            this.Load += new System.EventHandler(this.PwdQueryDlg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		public string FullName
		{
			get
			{
				return Path.Combine(textFileDirectory.Text, textFileName.Text);
			}

			set
			{
                if (string.IsNullOrEmpty(value))
                {
                    textFileName.Text = string.Empty;
                    textFileDirectory.Text = string.Empty;
                }

                textFileName.Text = Path.GetFileName(value);
                textFileDirectory.Text = Path.GetDirectoryName(value);
			}
		}

		public string Password
		{
			get
			{
				return textPassword.Text;
			}
			set
			{
				textPassword.Text = value;
			}
		}

        private void PwdQueryDlg_Load(object sender, EventArgs e)
        {

        }
	}
}
