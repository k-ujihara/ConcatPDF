using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using static iText.Kernel.Pdf.PdfViewerPreferences;
using Ujihara.PDF;

namespace Ujihara.ConcatPDF
{
	/// <summary>
	/// ViewerOptionDialog の概要の説明です。
	/// </summary>
	public class ViewerOptionDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radioSinglePage;
		private System.Windows.Forms.RadioButton radioContinuous;
		private System.Windows.Forms.RadioButton radioContinuousLeft;
		private System.Windows.Forms.RadioButton radioContinuousRight;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.CheckBox checkPMShowNone;
		private System.Windows.Forms.CheckBox checkShowOutlines;
		private System.Windows.Forms.CheckBox checkShowThumbs;
		private System.Windows.Forms.CheckBox checkFullScreen;
		private System.Windows.Forms.CheckBox checkHideToolbar;
		private System.Windows.Forms.CheckBox checkHideMenubar;
		private System.Windows.Forms.CheckBox checkHideWindowUI;
		private System.Windows.Forms.CheckBox checkFitWindow;
		private System.Windows.Forms.CheckBox checkCenterWindow;
		private System.Windows.Forms.RadioButton radioDontTouch;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ViewerOptionDialog()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ViewerOptionDialog));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioDontTouch = new System.Windows.Forms.RadioButton();
			this.radioContinuousRight = new System.Windows.Forms.RadioButton();
			this.radioContinuousLeft = new System.Windows.Forms.RadioButton();
			this.radioContinuous = new System.Windows.Forms.RadioButton();
			this.radioSinglePage = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.checkFullScreen = new System.Windows.Forms.CheckBox();
			this.checkShowThumbs = new System.Windows.Forms.CheckBox();
			this.checkShowOutlines = new System.Windows.Forms.CheckBox();
			this.checkPMShowNone = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.checkHideWindowUI = new System.Windows.Forms.CheckBox();
			this.checkHideMenubar = new System.Windows.Forms.CheckBox();
			this.checkHideToolbar = new System.Windows.Forms.CheckBox();
			this.checkFitWindow = new System.Windows.Forms.CheckBox();
			this.checkCenterWindow = new System.Windows.Forms.CheckBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.AccessibleDescription = resources.GetString("groupBox1.AccessibleDescription");
			this.groupBox1.AccessibleName = resources.GetString("groupBox1.AccessibleName");
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox1.Anchor")));
			this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
			this.groupBox1.Controls.Add(this.radioDontTouch);
			this.groupBox1.Controls.Add(this.radioContinuousRight);
			this.groupBox1.Controls.Add(this.radioContinuousLeft);
			this.groupBox1.Controls.Add(this.radioContinuous);
			this.groupBox1.Controls.Add(this.radioSinglePage);
			this.groupBox1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox1.Dock")));
			this.groupBox1.Enabled = ((bool)(resources.GetObject("groupBox1.Enabled")));
			this.groupBox1.Font = ((System.Drawing.Font)(resources.GetObject("groupBox1.Font")));
			this.groupBox1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox1.ImeMode")));
			this.groupBox1.Location = ((System.Drawing.Point)(resources.GetObject("groupBox1.Location")));
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox1.RightToLeft")));
			this.groupBox1.Size = ((System.Drawing.Size)(resources.GetObject("groupBox1.Size")));
			this.groupBox1.TabIndex = ((int)(resources.GetObject("groupBox1.TabIndex")));
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = resources.GetString("groupBox1.Text");
			this.groupBox1.Visible = ((bool)(resources.GetObject("groupBox1.Visible")));
			// 
			// radioDontTouch
			// 
			this.radioDontTouch.AccessibleDescription = resources.GetString("radioDontTouch.AccessibleDescription");
			this.radioDontTouch.AccessibleName = resources.GetString("radioDontTouch.AccessibleName");
			this.radioDontTouch.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("radioDontTouch.Anchor")));
			this.radioDontTouch.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("radioDontTouch.Appearance")));
			this.radioDontTouch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioDontTouch.BackgroundImage")));
			this.radioDontTouch.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioDontTouch.CheckAlign")));
			this.radioDontTouch.Checked = true;
			this.radioDontTouch.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("radioDontTouch.Dock")));
			this.radioDontTouch.Enabled = ((bool)(resources.GetObject("radioDontTouch.Enabled")));
			this.radioDontTouch.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("radioDontTouch.FlatStyle")));
			this.radioDontTouch.Font = ((System.Drawing.Font)(resources.GetObject("radioDontTouch.Font")));
			this.radioDontTouch.Image = ((System.Drawing.Image)(resources.GetObject("radioDontTouch.Image")));
			this.radioDontTouch.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioDontTouch.ImageAlign")));
			this.radioDontTouch.ImageIndex = ((int)(resources.GetObject("radioDontTouch.ImageIndex")));
			this.radioDontTouch.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("radioDontTouch.ImeMode")));
			this.radioDontTouch.Location = ((System.Drawing.Point)(resources.GetObject("radioDontTouch.Location")));
			this.radioDontTouch.Name = "radioDontTouch";
			this.radioDontTouch.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("radioDontTouch.RightToLeft")));
			this.radioDontTouch.Size = ((System.Drawing.Size)(resources.GetObject("radioDontTouch.Size")));
			this.radioDontTouch.TabIndex = ((int)(resources.GetObject("radioDontTouch.TabIndex")));
			this.radioDontTouch.TabStop = true;
			this.radioDontTouch.Text = resources.GetString("radioDontTouch.Text");
			this.radioDontTouch.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioDontTouch.TextAlign")));
			this.radioDontTouch.Visible = ((bool)(resources.GetObject("radioDontTouch.Visible")));
			// 
			// radioContinuousRight
			// 
			this.radioContinuousRight.AccessibleDescription = resources.GetString("radioContinuousRight.AccessibleDescription");
			this.radioContinuousRight.AccessibleName = resources.GetString("radioContinuousRight.AccessibleName");
			this.radioContinuousRight.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("radioContinuousRight.Anchor")));
			this.radioContinuousRight.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("radioContinuousRight.Appearance")));
			this.radioContinuousRight.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioContinuousRight.BackgroundImage")));
			this.radioContinuousRight.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioContinuousRight.CheckAlign")));
			this.radioContinuousRight.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("radioContinuousRight.Dock")));
			this.radioContinuousRight.Enabled = ((bool)(resources.GetObject("radioContinuousRight.Enabled")));
			this.radioContinuousRight.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("radioContinuousRight.FlatStyle")));
			this.radioContinuousRight.Font = ((System.Drawing.Font)(resources.GetObject("radioContinuousRight.Font")));
			this.radioContinuousRight.Image = ((System.Drawing.Image)(resources.GetObject("radioContinuousRight.Image")));
			this.radioContinuousRight.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioContinuousRight.ImageAlign")));
			this.radioContinuousRight.ImageIndex = ((int)(resources.GetObject("radioContinuousRight.ImageIndex")));
			this.radioContinuousRight.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("radioContinuousRight.ImeMode")));
			this.radioContinuousRight.Location = ((System.Drawing.Point)(resources.GetObject("radioContinuousRight.Location")));
			this.radioContinuousRight.Name = "radioContinuousRight";
			this.radioContinuousRight.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("radioContinuousRight.RightToLeft")));
			this.radioContinuousRight.Size = ((System.Drawing.Size)(resources.GetObject("radioContinuousRight.Size")));
			this.radioContinuousRight.TabIndex = ((int)(resources.GetObject("radioContinuousRight.TabIndex")));
			this.radioContinuousRight.Text = resources.GetString("radioContinuousRight.Text");
			this.radioContinuousRight.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioContinuousRight.TextAlign")));
			this.radioContinuousRight.Visible = ((bool)(resources.GetObject("radioContinuousRight.Visible")));
			// 
			// radioContinuousLeft
			// 
			this.radioContinuousLeft.AccessibleDescription = resources.GetString("radioContinuousLeft.AccessibleDescription");
			this.radioContinuousLeft.AccessibleName = resources.GetString("radioContinuousLeft.AccessibleName");
			this.radioContinuousLeft.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("radioContinuousLeft.Anchor")));
			this.radioContinuousLeft.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("radioContinuousLeft.Appearance")));
			this.radioContinuousLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioContinuousLeft.BackgroundImage")));
			this.radioContinuousLeft.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioContinuousLeft.CheckAlign")));
			this.radioContinuousLeft.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("radioContinuousLeft.Dock")));
			this.radioContinuousLeft.Enabled = ((bool)(resources.GetObject("radioContinuousLeft.Enabled")));
			this.radioContinuousLeft.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("radioContinuousLeft.FlatStyle")));
			this.radioContinuousLeft.Font = ((System.Drawing.Font)(resources.GetObject("radioContinuousLeft.Font")));
			this.radioContinuousLeft.Image = ((System.Drawing.Image)(resources.GetObject("radioContinuousLeft.Image")));
			this.radioContinuousLeft.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioContinuousLeft.ImageAlign")));
			this.radioContinuousLeft.ImageIndex = ((int)(resources.GetObject("radioContinuousLeft.ImageIndex")));
			this.radioContinuousLeft.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("radioContinuousLeft.ImeMode")));
			this.radioContinuousLeft.Location = ((System.Drawing.Point)(resources.GetObject("radioContinuousLeft.Location")));
			this.radioContinuousLeft.Name = "radioContinuousLeft";
			this.radioContinuousLeft.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("radioContinuousLeft.RightToLeft")));
			this.radioContinuousLeft.Size = ((System.Drawing.Size)(resources.GetObject("radioContinuousLeft.Size")));
			this.radioContinuousLeft.TabIndex = ((int)(resources.GetObject("radioContinuousLeft.TabIndex")));
			this.radioContinuousLeft.Text = resources.GetString("radioContinuousLeft.Text");
			this.radioContinuousLeft.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioContinuousLeft.TextAlign")));
			this.radioContinuousLeft.Visible = ((bool)(resources.GetObject("radioContinuousLeft.Visible")));
			// 
			// radioContinuous
			// 
			this.radioContinuous.AccessibleDescription = resources.GetString("radioContinuous.AccessibleDescription");
			this.radioContinuous.AccessibleName = resources.GetString("radioContinuous.AccessibleName");
			this.radioContinuous.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("radioContinuous.Anchor")));
			this.radioContinuous.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("radioContinuous.Appearance")));
			this.radioContinuous.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioContinuous.BackgroundImage")));
			this.radioContinuous.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioContinuous.CheckAlign")));
			this.radioContinuous.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("radioContinuous.Dock")));
			this.radioContinuous.Enabled = ((bool)(resources.GetObject("radioContinuous.Enabled")));
			this.radioContinuous.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("radioContinuous.FlatStyle")));
			this.radioContinuous.Font = ((System.Drawing.Font)(resources.GetObject("radioContinuous.Font")));
			this.radioContinuous.Image = ((System.Drawing.Image)(resources.GetObject("radioContinuous.Image")));
			this.radioContinuous.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioContinuous.ImageAlign")));
			this.radioContinuous.ImageIndex = ((int)(resources.GetObject("radioContinuous.ImageIndex")));
			this.radioContinuous.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("radioContinuous.ImeMode")));
			this.radioContinuous.Location = ((System.Drawing.Point)(resources.GetObject("radioContinuous.Location")));
			this.radioContinuous.Name = "radioContinuous";
			this.radioContinuous.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("radioContinuous.RightToLeft")));
			this.radioContinuous.Size = ((System.Drawing.Size)(resources.GetObject("radioContinuous.Size")));
			this.radioContinuous.TabIndex = ((int)(resources.GetObject("radioContinuous.TabIndex")));
			this.radioContinuous.Text = resources.GetString("radioContinuous.Text");
			this.radioContinuous.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioContinuous.TextAlign")));
			this.radioContinuous.Visible = ((bool)(resources.GetObject("radioContinuous.Visible")));
			// 
			// radioSinglePage
			// 
			this.radioSinglePage.AccessibleDescription = resources.GetString("radioSinglePage.AccessibleDescription");
			this.radioSinglePage.AccessibleName = resources.GetString("radioSinglePage.AccessibleName");
			this.radioSinglePage.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("radioSinglePage.Anchor")));
			this.radioSinglePage.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("radioSinglePage.Appearance")));
			this.radioSinglePage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioSinglePage.BackgroundImage")));
			this.radioSinglePage.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioSinglePage.CheckAlign")));
			this.radioSinglePage.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("radioSinglePage.Dock")));
			this.radioSinglePage.Enabled = ((bool)(resources.GetObject("radioSinglePage.Enabled")));
			this.radioSinglePage.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("radioSinglePage.FlatStyle")));
			this.radioSinglePage.Font = ((System.Drawing.Font)(resources.GetObject("radioSinglePage.Font")));
			this.radioSinglePage.Image = ((System.Drawing.Image)(resources.GetObject("radioSinglePage.Image")));
			this.radioSinglePage.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioSinglePage.ImageAlign")));
			this.radioSinglePage.ImageIndex = ((int)(resources.GetObject("radioSinglePage.ImageIndex")));
			this.radioSinglePage.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("radioSinglePage.ImeMode")));
			this.radioSinglePage.Location = ((System.Drawing.Point)(resources.GetObject("radioSinglePage.Location")));
			this.radioSinglePage.Name = "radioSinglePage";
			this.radioSinglePage.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("radioSinglePage.RightToLeft")));
			this.radioSinglePage.Size = ((System.Drawing.Size)(resources.GetObject("radioSinglePage.Size")));
			this.radioSinglePage.TabIndex = ((int)(resources.GetObject("radioSinglePage.TabIndex")));
			this.radioSinglePage.Text = resources.GetString("radioSinglePage.Text");
			this.radioSinglePage.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioSinglePage.TextAlign")));
			this.radioSinglePage.Visible = ((bool)(resources.GetObject("radioSinglePage.Visible")));
			// 
			// groupBox2
			// 
			this.groupBox2.AccessibleDescription = resources.GetString("groupBox2.AccessibleDescription");
			this.groupBox2.AccessibleName = resources.GetString("groupBox2.AccessibleName");
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox2.Anchor")));
			this.groupBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox2.BackgroundImage")));
			this.groupBox2.Controls.Add(this.checkFullScreen);
			this.groupBox2.Controls.Add(this.checkShowThumbs);
			this.groupBox2.Controls.Add(this.checkShowOutlines);
			this.groupBox2.Controls.Add(this.checkPMShowNone);
			this.groupBox2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox2.Dock")));
			this.groupBox2.Enabled = ((bool)(resources.GetObject("groupBox2.Enabled")));
			this.groupBox2.Font = ((System.Drawing.Font)(resources.GetObject("groupBox2.Font")));
			this.groupBox2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox2.ImeMode")));
			this.groupBox2.Location = ((System.Drawing.Point)(resources.GetObject("groupBox2.Location")));
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox2.RightToLeft")));
			this.groupBox2.Size = ((System.Drawing.Size)(resources.GetObject("groupBox2.Size")));
			this.groupBox2.TabIndex = ((int)(resources.GetObject("groupBox2.TabIndex")));
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = resources.GetString("groupBox2.Text");
			this.groupBox2.Visible = ((bool)(resources.GetObject("groupBox2.Visible")));
			// 
			// checkFullScreen
			// 
			this.checkFullScreen.AccessibleDescription = resources.GetString("checkFullScreen.AccessibleDescription");
			this.checkFullScreen.AccessibleName = resources.GetString("checkFullScreen.AccessibleName");
			this.checkFullScreen.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("checkFullScreen.Anchor")));
			this.checkFullScreen.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("checkFullScreen.Appearance")));
			this.checkFullScreen.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkFullScreen.BackgroundImage")));
			this.checkFullScreen.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkFullScreen.CheckAlign")));
			this.checkFullScreen.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("checkFullScreen.Dock")));
			this.checkFullScreen.Enabled = ((bool)(resources.GetObject("checkFullScreen.Enabled")));
			this.checkFullScreen.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("checkFullScreen.FlatStyle")));
			this.checkFullScreen.Font = ((System.Drawing.Font)(resources.GetObject("checkFullScreen.Font")));
			this.checkFullScreen.Image = ((System.Drawing.Image)(resources.GetObject("checkFullScreen.Image")));
			this.checkFullScreen.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkFullScreen.ImageAlign")));
			this.checkFullScreen.ImageIndex = ((int)(resources.GetObject("checkFullScreen.ImageIndex")));
			this.checkFullScreen.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("checkFullScreen.ImeMode")));
			this.checkFullScreen.Location = ((System.Drawing.Point)(resources.GetObject("checkFullScreen.Location")));
			this.checkFullScreen.Name = "checkFullScreen";
			this.checkFullScreen.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("checkFullScreen.RightToLeft")));
			this.checkFullScreen.Size = ((System.Drawing.Size)(resources.GetObject("checkFullScreen.Size")));
			this.checkFullScreen.TabIndex = ((int)(resources.GetObject("checkFullScreen.TabIndex")));
			this.checkFullScreen.Text = resources.GetString("checkFullScreen.Text");
			this.checkFullScreen.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkFullScreen.TextAlign")));
			this.checkFullScreen.Visible = ((bool)(resources.GetObject("checkFullScreen.Visible")));
			// 
			// checkShowThumbs
			// 
			this.checkShowThumbs.AccessibleDescription = resources.GetString("checkShowThumbs.AccessibleDescription");
			this.checkShowThumbs.AccessibleName = resources.GetString("checkShowThumbs.AccessibleName");
			this.checkShowThumbs.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("checkShowThumbs.Anchor")));
			this.checkShowThumbs.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("checkShowThumbs.Appearance")));
			this.checkShowThumbs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkShowThumbs.BackgroundImage")));
			this.checkShowThumbs.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkShowThumbs.CheckAlign")));
			this.checkShowThumbs.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("checkShowThumbs.Dock")));
			this.checkShowThumbs.Enabled = ((bool)(resources.GetObject("checkShowThumbs.Enabled")));
			this.checkShowThumbs.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("checkShowThumbs.FlatStyle")));
			this.checkShowThumbs.Font = ((System.Drawing.Font)(resources.GetObject("checkShowThumbs.Font")));
			this.checkShowThumbs.Image = ((System.Drawing.Image)(resources.GetObject("checkShowThumbs.Image")));
			this.checkShowThumbs.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkShowThumbs.ImageAlign")));
			this.checkShowThumbs.ImageIndex = ((int)(resources.GetObject("checkShowThumbs.ImageIndex")));
			this.checkShowThumbs.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("checkShowThumbs.ImeMode")));
			this.checkShowThumbs.Location = ((System.Drawing.Point)(resources.GetObject("checkShowThumbs.Location")));
			this.checkShowThumbs.Name = "checkShowThumbs";
			this.checkShowThumbs.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("checkShowThumbs.RightToLeft")));
			this.checkShowThumbs.Size = ((System.Drawing.Size)(resources.GetObject("checkShowThumbs.Size")));
			this.checkShowThumbs.TabIndex = ((int)(resources.GetObject("checkShowThumbs.TabIndex")));
			this.checkShowThumbs.Text = resources.GetString("checkShowThumbs.Text");
			this.checkShowThumbs.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkShowThumbs.TextAlign")));
			this.checkShowThumbs.Visible = ((bool)(resources.GetObject("checkShowThumbs.Visible")));
			// 
			// checkShowOutlines
			// 
			this.checkShowOutlines.AccessibleDescription = resources.GetString("checkShowOutlines.AccessibleDescription");
			this.checkShowOutlines.AccessibleName = resources.GetString("checkShowOutlines.AccessibleName");
			this.checkShowOutlines.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("checkShowOutlines.Anchor")));
			this.checkShowOutlines.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("checkShowOutlines.Appearance")));
			this.checkShowOutlines.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkShowOutlines.BackgroundImage")));
			this.checkShowOutlines.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkShowOutlines.CheckAlign")));
			this.checkShowOutlines.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("checkShowOutlines.Dock")));
			this.checkShowOutlines.Enabled = ((bool)(resources.GetObject("checkShowOutlines.Enabled")));
			this.checkShowOutlines.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("checkShowOutlines.FlatStyle")));
			this.checkShowOutlines.Font = ((System.Drawing.Font)(resources.GetObject("checkShowOutlines.Font")));
			this.checkShowOutlines.Image = ((System.Drawing.Image)(resources.GetObject("checkShowOutlines.Image")));
			this.checkShowOutlines.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkShowOutlines.ImageAlign")));
			this.checkShowOutlines.ImageIndex = ((int)(resources.GetObject("checkShowOutlines.ImageIndex")));
			this.checkShowOutlines.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("checkShowOutlines.ImeMode")));
			this.checkShowOutlines.Location = ((System.Drawing.Point)(resources.GetObject("checkShowOutlines.Location")));
			this.checkShowOutlines.Name = "checkShowOutlines";
			this.checkShowOutlines.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("checkShowOutlines.RightToLeft")));
			this.checkShowOutlines.Size = ((System.Drawing.Size)(resources.GetObject("checkShowOutlines.Size")));
			this.checkShowOutlines.TabIndex = ((int)(resources.GetObject("checkShowOutlines.TabIndex")));
			this.checkShowOutlines.Text = resources.GetString("checkShowOutlines.Text");
			this.checkShowOutlines.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkShowOutlines.TextAlign")));
			this.checkShowOutlines.Visible = ((bool)(resources.GetObject("checkShowOutlines.Visible")));
			// 
			// checkPMShowNone
			// 
			this.checkPMShowNone.AccessibleDescription = resources.GetString("checkPMShowNone.AccessibleDescription");
			this.checkPMShowNone.AccessibleName = resources.GetString("checkPMShowNone.AccessibleName");
			this.checkPMShowNone.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("checkPMShowNone.Anchor")));
			this.checkPMShowNone.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("checkPMShowNone.Appearance")));
			this.checkPMShowNone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkPMShowNone.BackgroundImage")));
			this.checkPMShowNone.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkPMShowNone.CheckAlign")));
			this.checkPMShowNone.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("checkPMShowNone.Dock")));
			this.checkPMShowNone.Enabled = ((bool)(resources.GetObject("checkPMShowNone.Enabled")));
			this.checkPMShowNone.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("checkPMShowNone.FlatStyle")));
			this.checkPMShowNone.Font = ((System.Drawing.Font)(resources.GetObject("checkPMShowNone.Font")));
			this.checkPMShowNone.Image = ((System.Drawing.Image)(resources.GetObject("checkPMShowNone.Image")));
			this.checkPMShowNone.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkPMShowNone.ImageAlign")));
			this.checkPMShowNone.ImageIndex = ((int)(resources.GetObject("checkPMShowNone.ImageIndex")));
			this.checkPMShowNone.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("checkPMShowNone.ImeMode")));
			this.checkPMShowNone.Location = ((System.Drawing.Point)(resources.GetObject("checkPMShowNone.Location")));
			this.checkPMShowNone.Name = "checkPMShowNone";
			this.checkPMShowNone.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("checkPMShowNone.RightToLeft")));
			this.checkPMShowNone.Size = ((System.Drawing.Size)(resources.GetObject("checkPMShowNone.Size")));
			this.checkPMShowNone.TabIndex = ((int)(resources.GetObject("checkPMShowNone.TabIndex")));
			this.checkPMShowNone.Text = resources.GetString("checkPMShowNone.Text");
			this.checkPMShowNone.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkPMShowNone.TextAlign")));
			this.checkPMShowNone.Visible = ((bool)(resources.GetObject("checkPMShowNone.Visible")));
			// 
			// groupBox3
			// 
			this.groupBox3.AccessibleDescription = resources.GetString("groupBox3.AccessibleDescription");
			this.groupBox3.AccessibleName = resources.GetString("groupBox3.AccessibleName");
			this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox3.Anchor")));
			this.groupBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox3.BackgroundImage")));
			this.groupBox3.Controls.Add(this.checkHideWindowUI);
			this.groupBox3.Controls.Add(this.checkHideMenubar);
			this.groupBox3.Controls.Add(this.checkHideToolbar);
			this.groupBox3.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("groupBox3.Dock")));
			this.groupBox3.Enabled = ((bool)(resources.GetObject("groupBox3.Enabled")));
			this.groupBox3.Font = ((System.Drawing.Font)(resources.GetObject("groupBox3.Font")));
			this.groupBox3.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("groupBox3.ImeMode")));
			this.groupBox3.Location = ((System.Drawing.Point)(resources.GetObject("groupBox3.Location")));
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("groupBox3.RightToLeft")));
			this.groupBox3.Size = ((System.Drawing.Size)(resources.GetObject("groupBox3.Size")));
			this.groupBox3.TabIndex = ((int)(resources.GetObject("groupBox3.TabIndex")));
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = resources.GetString("groupBox3.Text");
			this.groupBox3.Visible = ((bool)(resources.GetObject("groupBox3.Visible")));
			// 
			// checkHideWindowUI
			// 
			this.checkHideWindowUI.AccessibleDescription = resources.GetString("checkHideWindowUI.AccessibleDescription");
			this.checkHideWindowUI.AccessibleName = resources.GetString("checkHideWindowUI.AccessibleName");
			this.checkHideWindowUI.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("checkHideWindowUI.Anchor")));
			this.checkHideWindowUI.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("checkHideWindowUI.Appearance")));
			this.checkHideWindowUI.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkHideWindowUI.BackgroundImage")));
			this.checkHideWindowUI.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkHideWindowUI.CheckAlign")));
			this.checkHideWindowUI.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("checkHideWindowUI.Dock")));
			this.checkHideWindowUI.Enabled = ((bool)(resources.GetObject("checkHideWindowUI.Enabled")));
			this.checkHideWindowUI.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("checkHideWindowUI.FlatStyle")));
			this.checkHideWindowUI.Font = ((System.Drawing.Font)(resources.GetObject("checkHideWindowUI.Font")));
			this.checkHideWindowUI.Image = ((System.Drawing.Image)(resources.GetObject("checkHideWindowUI.Image")));
			this.checkHideWindowUI.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkHideWindowUI.ImageAlign")));
			this.checkHideWindowUI.ImageIndex = ((int)(resources.GetObject("checkHideWindowUI.ImageIndex")));
			this.checkHideWindowUI.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("checkHideWindowUI.ImeMode")));
			this.checkHideWindowUI.Location = ((System.Drawing.Point)(resources.GetObject("checkHideWindowUI.Location")));
			this.checkHideWindowUI.Name = "checkHideWindowUI";
			this.checkHideWindowUI.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("checkHideWindowUI.RightToLeft")));
			this.checkHideWindowUI.Size = ((System.Drawing.Size)(resources.GetObject("checkHideWindowUI.Size")));
			this.checkHideWindowUI.TabIndex = ((int)(resources.GetObject("checkHideWindowUI.TabIndex")));
			this.checkHideWindowUI.Text = resources.GetString("checkHideWindowUI.Text");
			this.checkHideWindowUI.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkHideWindowUI.TextAlign")));
			this.checkHideWindowUI.Visible = ((bool)(resources.GetObject("checkHideWindowUI.Visible")));
			// 
			// checkHideMenubar
			// 
			this.checkHideMenubar.AccessibleDescription = resources.GetString("checkHideMenubar.AccessibleDescription");
			this.checkHideMenubar.AccessibleName = resources.GetString("checkHideMenubar.AccessibleName");
			this.checkHideMenubar.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("checkHideMenubar.Anchor")));
			this.checkHideMenubar.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("checkHideMenubar.Appearance")));
			this.checkHideMenubar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkHideMenubar.BackgroundImage")));
			this.checkHideMenubar.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkHideMenubar.CheckAlign")));
			this.checkHideMenubar.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("checkHideMenubar.Dock")));
			this.checkHideMenubar.Enabled = ((bool)(resources.GetObject("checkHideMenubar.Enabled")));
			this.checkHideMenubar.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("checkHideMenubar.FlatStyle")));
			this.checkHideMenubar.Font = ((System.Drawing.Font)(resources.GetObject("checkHideMenubar.Font")));
			this.checkHideMenubar.Image = ((System.Drawing.Image)(resources.GetObject("checkHideMenubar.Image")));
			this.checkHideMenubar.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkHideMenubar.ImageAlign")));
			this.checkHideMenubar.ImageIndex = ((int)(resources.GetObject("checkHideMenubar.ImageIndex")));
			this.checkHideMenubar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("checkHideMenubar.ImeMode")));
			this.checkHideMenubar.Location = ((System.Drawing.Point)(resources.GetObject("checkHideMenubar.Location")));
			this.checkHideMenubar.Name = "checkHideMenubar";
			this.checkHideMenubar.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("checkHideMenubar.RightToLeft")));
			this.checkHideMenubar.Size = ((System.Drawing.Size)(resources.GetObject("checkHideMenubar.Size")));
			this.checkHideMenubar.TabIndex = ((int)(resources.GetObject("checkHideMenubar.TabIndex")));
			this.checkHideMenubar.Text = resources.GetString("checkHideMenubar.Text");
			this.checkHideMenubar.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkHideMenubar.TextAlign")));
			this.checkHideMenubar.Visible = ((bool)(resources.GetObject("checkHideMenubar.Visible")));
			// 
			// checkHideToolbar
			// 
			this.checkHideToolbar.AccessibleDescription = resources.GetString("checkHideToolbar.AccessibleDescription");
			this.checkHideToolbar.AccessibleName = resources.GetString("checkHideToolbar.AccessibleName");
			this.checkHideToolbar.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("checkHideToolbar.Anchor")));
			this.checkHideToolbar.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("checkHideToolbar.Appearance")));
			this.checkHideToolbar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkHideToolbar.BackgroundImage")));
			this.checkHideToolbar.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkHideToolbar.CheckAlign")));
			this.checkHideToolbar.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("checkHideToolbar.Dock")));
			this.checkHideToolbar.Enabled = ((bool)(resources.GetObject("checkHideToolbar.Enabled")));
			this.checkHideToolbar.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("checkHideToolbar.FlatStyle")));
			this.checkHideToolbar.Font = ((System.Drawing.Font)(resources.GetObject("checkHideToolbar.Font")));
			this.checkHideToolbar.Image = ((System.Drawing.Image)(resources.GetObject("checkHideToolbar.Image")));
			this.checkHideToolbar.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkHideToolbar.ImageAlign")));
			this.checkHideToolbar.ImageIndex = ((int)(resources.GetObject("checkHideToolbar.ImageIndex")));
			this.checkHideToolbar.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("checkHideToolbar.ImeMode")));
			this.checkHideToolbar.Location = ((System.Drawing.Point)(resources.GetObject("checkHideToolbar.Location")));
			this.checkHideToolbar.Name = "checkHideToolbar";
			this.checkHideToolbar.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("checkHideToolbar.RightToLeft")));
			this.checkHideToolbar.Size = ((System.Drawing.Size)(resources.GetObject("checkHideToolbar.Size")));
			this.checkHideToolbar.TabIndex = ((int)(resources.GetObject("checkHideToolbar.TabIndex")));
			this.checkHideToolbar.Text = resources.GetString("checkHideToolbar.Text");
			this.checkHideToolbar.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkHideToolbar.TextAlign")));
			this.checkHideToolbar.Visible = ((bool)(resources.GetObject("checkHideToolbar.Visible")));
			// 
			// checkFitWindow
			// 
			this.checkFitWindow.AccessibleDescription = resources.GetString("checkFitWindow.AccessibleDescription");
			this.checkFitWindow.AccessibleName = resources.GetString("checkFitWindow.AccessibleName");
			this.checkFitWindow.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("checkFitWindow.Anchor")));
			this.checkFitWindow.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("checkFitWindow.Appearance")));
			this.checkFitWindow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkFitWindow.BackgroundImage")));
			this.checkFitWindow.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkFitWindow.CheckAlign")));
			this.checkFitWindow.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("checkFitWindow.Dock")));
			this.checkFitWindow.Enabled = ((bool)(resources.GetObject("checkFitWindow.Enabled")));
			this.checkFitWindow.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("checkFitWindow.FlatStyle")));
			this.checkFitWindow.Font = ((System.Drawing.Font)(resources.GetObject("checkFitWindow.Font")));
			this.checkFitWindow.Image = ((System.Drawing.Image)(resources.GetObject("checkFitWindow.Image")));
			this.checkFitWindow.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkFitWindow.ImageAlign")));
			this.checkFitWindow.ImageIndex = ((int)(resources.GetObject("checkFitWindow.ImageIndex")));
			this.checkFitWindow.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("checkFitWindow.ImeMode")));
			this.checkFitWindow.Location = ((System.Drawing.Point)(resources.GetObject("checkFitWindow.Location")));
			this.checkFitWindow.Name = "checkFitWindow";
			this.checkFitWindow.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("checkFitWindow.RightToLeft")));
			this.checkFitWindow.Size = ((System.Drawing.Size)(resources.GetObject("checkFitWindow.Size")));
			this.checkFitWindow.TabIndex = ((int)(resources.GetObject("checkFitWindow.TabIndex")));
			this.checkFitWindow.Text = resources.GetString("checkFitWindow.Text");
			this.checkFitWindow.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkFitWindow.TextAlign")));
			this.checkFitWindow.Visible = ((bool)(resources.GetObject("checkFitWindow.Visible")));
			// 
			// checkCenterWindow
			// 
			this.checkCenterWindow.AccessibleDescription = resources.GetString("checkCenterWindow.AccessibleDescription");
			this.checkCenterWindow.AccessibleName = resources.GetString("checkCenterWindow.AccessibleName");
			this.checkCenterWindow.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("checkCenterWindow.Anchor")));
			this.checkCenterWindow.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("checkCenterWindow.Appearance")));
			this.checkCenterWindow.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkCenterWindow.BackgroundImage")));
			this.checkCenterWindow.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkCenterWindow.CheckAlign")));
			this.checkCenterWindow.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("checkCenterWindow.Dock")));
			this.checkCenterWindow.Enabled = ((bool)(resources.GetObject("checkCenterWindow.Enabled")));
			this.checkCenterWindow.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("checkCenterWindow.FlatStyle")));
			this.checkCenterWindow.Font = ((System.Drawing.Font)(resources.GetObject("checkCenterWindow.Font")));
			this.checkCenterWindow.Image = ((System.Drawing.Image)(resources.GetObject("checkCenterWindow.Image")));
			this.checkCenterWindow.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkCenterWindow.ImageAlign")));
			this.checkCenterWindow.ImageIndex = ((int)(resources.GetObject("checkCenterWindow.ImageIndex")));
			this.checkCenterWindow.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("checkCenterWindow.ImeMode")));
			this.checkCenterWindow.Location = ((System.Drawing.Point)(resources.GetObject("checkCenterWindow.Location")));
			this.checkCenterWindow.Name = "checkCenterWindow";
			this.checkCenterWindow.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("checkCenterWindow.RightToLeft")));
			this.checkCenterWindow.Size = ((System.Drawing.Size)(resources.GetObject("checkCenterWindow.Size")));
			this.checkCenterWindow.TabIndex = ((int)(resources.GetObject("checkCenterWindow.TabIndex")));
			this.checkCenterWindow.Text = resources.GetString("checkCenterWindow.Text");
			this.checkCenterWindow.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkCenterWindow.TextAlign")));
			this.checkCenterWindow.Visible = ((bool)(resources.GetObject("checkCenterWindow.Visible")));
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
			// buttonCancel
			// 
			this.buttonCancel.AccessibleDescription = resources.GetString("buttonCancel.AccessibleDescription");
			this.buttonCancel.AccessibleName = resources.GetString("buttonCancel.AccessibleName");
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("buttonCancel.Anchor")));
			this.buttonCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCancel.BackgroundImage")));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("buttonCancel.Dock")));
			this.buttonCancel.Enabled = ((bool)(resources.GetObject("buttonCancel.Enabled")));
			this.buttonCancel.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("buttonCancel.FlatStyle")));
			this.buttonCancel.Font = ((System.Drawing.Font)(resources.GetObject("buttonCancel.Font")));
			this.buttonCancel.Image = ((System.Drawing.Image)(resources.GetObject("buttonCancel.Image")));
			this.buttonCancel.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("buttonCancel.ImageAlign")));
			this.buttonCancel.ImageIndex = ((int)(resources.GetObject("buttonCancel.ImageIndex")));
			this.buttonCancel.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("buttonCancel.ImeMode")));
			this.buttonCancel.Location = ((System.Drawing.Point)(resources.GetObject("buttonCancel.Location")));
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("buttonCancel.RightToLeft")));
			this.buttonCancel.Size = ((System.Drawing.Size)(resources.GetObject("buttonCancel.Size")));
			this.buttonCancel.TabIndex = ((int)(resources.GetObject("buttonCancel.TabIndex")));
			this.buttonCancel.Text = resources.GetString("buttonCancel.Text");
			this.buttonCancel.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("buttonCancel.TextAlign")));
			this.buttonCancel.Visible = ((bool)(resources.GetObject("buttonCancel.Visible")));
			// 
			// ViewerOptionDialog
			// 
			this.AcceptButton = this.buttonOK;
			this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
			this.AccessibleName = resources.GetString("$this.AccessibleName");
			this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
			this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
			this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
			this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.CancelButton = this.buttonCancel;
			this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
			this.ControlBox = false;
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.checkCenterWindow);
			this.Controls.Add(this.checkFitWindow);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "ViewerOptionDialog";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.ShowInTaskbar = false;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

        public PdfName PageLayout
        {
            get
            {
                PdfName pageLayout = null;
                if (radioSinglePage.Checked) pageLayout = PdfName.SinglePage;
                if (radioContinuous.Checked) pageLayout = PdfName.OneColumn;
                if (radioContinuousLeft.Checked) pageLayout = PdfName.TwoColumnLeft;
                if (radioContinuousRight.Checked) pageLayout = PdfName.TwoColumnRight;
                return pageLayout;
            }

            set
            {
                radioDontTouch.Checked = true;
                radioSinglePage.Checked = value == PdfName.SinglePage;
                radioContinuous.Checked = value == PdfName.OneColumn;
                radioContinuousLeft.Checked = value  == PdfName.TwoColumnLeft;
                radioContinuousRight.Checked = value == PdfName.TwoColumnRight;
            }
        }

        public PageViewerPreferences ViewerPreference
		{
			get
			{
                PageViewerPreferences viewerPreference = new PageViewerPreferences();

                if (radioSinglePage.Checked) viewerPreference.PageLayout = PdfName.SinglePage;
                if (radioContinuous.Checked) viewerPreference.PageLayout = PdfName.OneColumn;
                if (radioContinuousLeft.Checked) viewerPreference.PageLayout = PdfName.TwoColumnLeft;
                if (radioContinuousRight.Checked) viewerPreference.PageLayout = PdfName.TwoColumnRight;

                if (checkFullScreen.Checked)
                {
                    viewerPreference.PageMode = PdfName.FullScreen;
                    if (checkPMShowNone.Checked) viewerPreference.NonFullScreenPageMode = PdfViewerPreferencesConstants.USE_NONE;
                    if (checkShowOutlines.Checked) viewerPreference.NonFullScreenPageMode = PdfViewerPreferencesConstants.USE_OUTLINES;
                    if (checkShowThumbs.Checked) viewerPreference.NonFullScreenPageMode = PdfViewerPreferencesConstants.USE_THUMBS;
                }

                if (checkHideToolbar.Checked) viewerPreference.HideToolbar = true;
                if (checkHideMenubar.Checked) viewerPreference.HideMenubar = true; 
                if (checkHideWindowUI.Checked) viewerPreference.HideWindowUI = true;
                if (checkFitWindow.Checked) viewerPreference.FitWindow = true;
                if (checkCenterWindow.Checked) viewerPreference.CenterWindow = true;
                return viewerPreference;
			}

			set
			{
                radioDontTouch.Checked = true;
                radioSinglePage.Checked = value.PageLayout == PdfName.SinglePage;
                radioContinuous.Checked = value.PageLayout == PdfName.OneColumn;
                radioContinuousLeft.Checked = value.PageLayout == PdfName.TwoColumnLeft;
                radioContinuousRight.Checked = value.PageLayout == PdfName.TwoColumnRight;

                checkPMShowNone.Checked = value.NonFullScreenPageMode == PdfViewerPreferencesConstants.USE_NONE;
                checkShowOutlines.Checked = value.NonFullScreenPageMode == PdfViewerPreferencesConstants.USE_OUTLINES;
                checkShowThumbs.Checked = value.NonFullScreenPageMode == PdfViewerPreferencesConstants.USE_THUMBS;

                checkHideToolbar.Checked = value.HideToolbar;
                checkHideMenubar.Checked = value.HideMenubar;
                checkHideWindowUI.Checked = value.HideWindowUI;
                checkFitWindow.Checked = value.FitWindow;
                checkCenterWindow.Checked = value.CenterWindow;
			}
		}
	}
}
