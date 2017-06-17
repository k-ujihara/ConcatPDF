using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Ujihara.Lib;

namespace Ujihara.ConcatPDF
{
	/// <summary>
	/// About の概要の説明です。
	/// </summary>
	public class About : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Label labelProductName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.LinkLabel linkWebSite;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public About()
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
			//
		}

		/// <summary>
		/// 使用されているリソースに後処理を実行します。
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(About));
			this.buttonOK = new System.Windows.Forms.Button();
			this.labelProductName = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.linkWebSite = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// buttonOK
			// 
			this.buttonOK.AccessibleDescription = resources.GetString("buttonOK.AccessibleDescription");
			this.buttonOK.AccessibleName = resources.GetString("buttonOK.AccessibleName");
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("buttonOK.Anchor")));
			this.buttonOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonOK.BackgroundImage")));
			this.buttonOK.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("buttonOK.Dock")));
			this.buttonOK.Enabled = ((bool)(resources.GetObject("buttonOK.Enabled")));
			this.buttonOK.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("buttonOK.FlatStyle")));
			this.buttonOK.Font = ((System.Drawing.Font)(resources.GetObject("buttonOK.Font")));
			this.buttonOK.Image = ((System.Drawing.Image)(resources.GetObject("buttonOK.Image")));
			this.buttonOK.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("buttonOK.ImageAlign")));
			this.buttonOK.ImageIndex = ((int)(resources.GetObject("buttonOK.ImageIndex")));
			this.buttonOK.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("buttonOK.ImeMode")));
			this.buttonOK.Location = ((System.Drawing.Point)(resources.GetObject("buttonOK.Location")));
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("buttonOK.RightToLeft")));
			this.buttonOK.Size = ((System.Drawing.Size)(resources.GetObject("buttonOK.Size")));
			this.buttonOK.TabIndex = ((int)(resources.GetObject("buttonOK.TabIndex")));
			this.buttonOK.Text = resources.GetString("buttonOK.Text");
			this.buttonOK.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("buttonOK.TextAlign")));
			this.buttonOK.Visible = ((bool)(resources.GetObject("buttonOK.Visible")));
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// labelProductName
			// 
			this.labelProductName.AccessibleDescription = resources.GetString("labelProductName.AccessibleDescription");
			this.labelProductName.AccessibleName = resources.GetString("labelProductName.AccessibleName");
			this.labelProductName.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("labelProductName.Anchor")));
			this.labelProductName.AutoSize = ((bool)(resources.GetObject("labelProductName.AutoSize")));
			this.labelProductName.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("labelProductName.Dock")));
			this.labelProductName.Enabled = ((bool)(resources.GetObject("labelProductName.Enabled")));
			this.labelProductName.Font = ((System.Drawing.Font)(resources.GetObject("labelProductName.Font")));
			this.labelProductName.Image = ((System.Drawing.Image)(resources.GetObject("labelProductName.Image")));
			this.labelProductName.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("labelProductName.ImageAlign")));
			this.labelProductName.ImageIndex = ((int)(resources.GetObject("labelProductName.ImageIndex")));
			this.labelProductName.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("labelProductName.ImeMode")));
			this.labelProductName.Location = ((System.Drawing.Point)(resources.GetObject("labelProductName.Location")));
			this.labelProductName.Name = "labelProductName";
			this.labelProductName.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("labelProductName.RightToLeft")));
			this.labelProductName.Size = ((System.Drawing.Size)(resources.GetObject("labelProductName.Size")));
			this.labelProductName.TabIndex = ((int)(resources.GetObject("labelProductName.TabIndex")));
			this.labelProductName.Text = resources.GetString("labelProductName.Text");
			this.labelProductName.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("labelProductName.TextAlign")));
			this.labelProductName.Visible = ((bool)(resources.GetObject("labelProductName.Visible")));
			// 
			// label1
			// 
			this.label1.AccessibleDescription = resources.GetString("label1.AccessibleDescription");
			this.label1.AccessibleName = resources.GetString("label1.AccessibleName");
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label1.Anchor")));
			this.label1.AutoSize = ((bool)(resources.GetObject("label1.AutoSize")));
			this.label1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label1.Dock")));
			this.label1.Enabled = ((bool)(resources.GetObject("label1.Enabled")));
			this.label1.Font = ((System.Drawing.Font)(resources.GetObject("label1.Font")));
			this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
			this.label1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.ImageAlign")));
			this.label1.ImageIndex = ((int)(resources.GetObject("label1.ImageIndex")));
			this.label1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label1.ImeMode")));
			this.label1.Location = ((System.Drawing.Point)(resources.GetObject("label1.Location")));
			this.label1.Name = "label1";
			this.label1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label1.RightToLeft")));
			this.label1.Size = ((System.Drawing.Size)(resources.GetObject("label1.Size")));
			this.label1.TabIndex = ((int)(resources.GetObject("label1.TabIndex")));
			this.label1.Text = resources.GetString("label1.Text");
			this.label1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label1.TextAlign")));
			this.label1.Visible = ((bool)(resources.GetObject("label1.Visible")));
			// 
			// label2
			// 
			this.label2.AccessibleDescription = resources.GetString("label2.AccessibleDescription");
			this.label2.AccessibleName = resources.GetString("label2.AccessibleName");
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("label2.Anchor")));
			this.label2.AutoSize = ((bool)(resources.GetObject("label2.AutoSize")));
			this.label2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("label2.Dock")));
			this.label2.Enabled = ((bool)(resources.GetObject("label2.Enabled")));
			this.label2.Font = ((System.Drawing.Font)(resources.GetObject("label2.Font")));
			this.label2.Image = ((System.Drawing.Image)(resources.GetObject("label2.Image")));
			this.label2.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.ImageAlign")));
			this.label2.ImageIndex = ((int)(resources.GetObject("label2.ImageIndex")));
			this.label2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("label2.ImeMode")));
			this.label2.Location = ((System.Drawing.Point)(resources.GetObject("label2.Location")));
			this.label2.Name = "label2";
			this.label2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("label2.RightToLeft")));
			this.label2.Size = ((System.Drawing.Size)(resources.GetObject("label2.Size")));
			this.label2.TabIndex = ((int)(resources.GetObject("label2.TabIndex")));
			this.label2.Text = resources.GetString("label2.Text");
			this.label2.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("label2.TextAlign")));
			this.label2.Visible = ((bool)(resources.GetObject("label2.Visible")));
			// 
			// linkWebSite
			// 
			this.linkWebSite.AccessibleDescription = resources.GetString("linkWebSite.AccessibleDescription");
			this.linkWebSite.AccessibleName = resources.GetString("linkWebSite.AccessibleName");
			this.linkWebSite.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("linkWebSite.Anchor")));
			this.linkWebSite.AutoSize = ((bool)(resources.GetObject("linkWebSite.AutoSize")));
			this.linkWebSite.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("linkWebSite.Dock")));
			this.linkWebSite.Enabled = ((bool)(resources.GetObject("linkWebSite.Enabled")));
			this.linkWebSite.Font = ((System.Drawing.Font)(resources.GetObject("linkWebSite.Font")));
			this.linkWebSite.Image = ((System.Drawing.Image)(resources.GetObject("linkWebSite.Image")));
			this.linkWebSite.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("linkWebSite.ImageAlign")));
			this.linkWebSite.ImageIndex = ((int)(resources.GetObject("linkWebSite.ImageIndex")));
			this.linkWebSite.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("linkWebSite.ImeMode")));
			this.linkWebSite.LinkArea = ((System.Windows.Forms.LinkArea)(resources.GetObject("linkWebSite.LinkArea")));
			this.linkWebSite.Location = ((System.Drawing.Point)(resources.GetObject("linkWebSite.Location")));
			this.linkWebSite.Name = "linkWebSite";
			this.linkWebSite.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("linkWebSite.RightToLeft")));
			this.linkWebSite.Size = ((System.Drawing.Size)(resources.GetObject("linkWebSite.Size")));
			this.linkWebSite.TabIndex = ((int)(resources.GetObject("linkWebSite.TabIndex")));
			this.linkWebSite.TabStop = true;
			this.linkWebSite.Text = resources.GetString("linkWebSite.Text");
			this.linkWebSite.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("linkWebSite.TextAlign")));
			this.linkWebSite.Visible = ((bool)(resources.GetObject("linkWebSite.Visible")));
			this.linkWebSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkWebSite_LinkClicked);
			// 
			// About
			// 
			this.AcceptButton = this.buttonOK;
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.ControlBox = false;
			this.Controls.Add(this.linkWebSite);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.labelProductName);
			this.Controls.Add(this.buttonOK);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "About";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.ShowInTaskbar = false;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.Load += new System.EventHandler(this.About_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void About_Load(object sender, System.EventArgs e)
		{
			System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
			System.Reflection.AssemblyName an = a.GetName();
			Version v = an.Version;
			labelProductName.Text = Application.ProductName + " " + an.Version.ToString();
		}

		private void linkWebSite_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			FileOperation.ExecuteFile(linkWebSite.Text);
		}
	}
}
