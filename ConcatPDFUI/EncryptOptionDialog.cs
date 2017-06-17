using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using iTextSharp.text.pdf;

namespace Ujihara.ConcatPDF
{
	/// <summary>
	/// EncryptOptionDialog の概要の説明です。
	/// </summary>
	public class EncryptOptionDialog : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox editUserPassword;
		private System.Windows.Forms.TextBox editMasterPassword;
		private System.Windows.Forms.RadioButton radioNoSecurity;
		private System.Windows.Forms.RadioButton radio40bitRC4;
		private System.Windows.Forms.RadioButton radio128bitRC4;
		private System.Windows.Forms.CheckBox checkPrinting;
		private System.Windows.Forms.CheckBox checkModifyContent;
		private System.Windows.Forms.CheckBox checkCopy;
		private System.Windows.Forms.CheckBox checkModifyAnnotations;
		private System.Windows.Forms.CheckBox checkDocumentAssembly;
		private System.Windows.Forms.CheckBox checkFillIn;
		private System.Windows.Forms.CheckBox checkScreenReaders;
		private System.Windows.Forms.CheckBox checkLowPrint;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Button buttonCancel;
		/// <summary>
		/// 必要なデザイナ変数です。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EncryptOptionDialog()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(EncryptOptionDialog));
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.editUserPassword = new System.Windows.Forms.TextBox();
			this.editMasterPassword = new System.Windows.Forms.TextBox();
			this.radioNoSecurity = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radio128bitRC4 = new System.Windows.Forms.RadioButton();
			this.radio40bitRC4 = new System.Windows.Forms.RadioButton();
			this.checkPrinting = new System.Windows.Forms.CheckBox();
			this.checkModifyContent = new System.Windows.Forms.CheckBox();
			this.checkCopy = new System.Windows.Forms.CheckBox();
			this.checkModifyAnnotations = new System.Windows.Forms.CheckBox();
			this.checkDocumentAssembly = new System.Windows.Forms.CheckBox();
			this.checkFillIn = new System.Windows.Forms.CheckBox();
			this.checkScreenReaders = new System.Windows.Forms.CheckBox();
			this.checkLowPrint = new System.Windows.Forms.CheckBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
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
			// editUserPassword
			// 
			this.editUserPassword.AccessibleDescription = resources.GetString("editUserPassword.AccessibleDescription");
			this.editUserPassword.AccessibleName = resources.GetString("editUserPassword.AccessibleName");
			this.editUserPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("editUserPassword.Anchor")));
			this.editUserPassword.AutoSize = ((bool)(resources.GetObject("editUserPassword.AutoSize")));
			this.editUserPassword.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("editUserPassword.BackgroundImage")));
			this.editUserPassword.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("editUserPassword.Dock")));
			this.editUserPassword.Enabled = ((bool)(resources.GetObject("editUserPassword.Enabled")));
			this.editUserPassword.Font = ((System.Drawing.Font)(resources.GetObject("editUserPassword.Font")));
			this.editUserPassword.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("editUserPassword.ImeMode")));
			this.editUserPassword.Location = ((System.Drawing.Point)(resources.GetObject("editUserPassword.Location")));
			this.editUserPassword.MaxLength = ((int)(resources.GetObject("editUserPassword.MaxLength")));
			this.editUserPassword.Multiline = ((bool)(resources.GetObject("editUserPassword.Multiline")));
			this.editUserPassword.Name = "editUserPassword";
			this.editUserPassword.PasswordChar = ((char)(resources.GetObject("editUserPassword.PasswordChar")));
			this.editUserPassword.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("editUserPassword.RightToLeft")));
			this.editUserPassword.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("editUserPassword.ScrollBars")));
			this.editUserPassword.Size = ((System.Drawing.Size)(resources.GetObject("editUserPassword.Size")));
			this.editUserPassword.TabIndex = ((int)(resources.GetObject("editUserPassword.TabIndex")));
			this.editUserPassword.Text = resources.GetString("editUserPassword.Text");
			this.editUserPassword.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("editUserPassword.TextAlign")));
			this.editUserPassword.Visible = ((bool)(resources.GetObject("editUserPassword.Visible")));
			this.editUserPassword.WordWrap = ((bool)(resources.GetObject("editUserPassword.WordWrap")));
			// 
			// editMasterPassword
			// 
			this.editMasterPassword.AccessibleDescription = resources.GetString("editMasterPassword.AccessibleDescription");
			this.editMasterPassword.AccessibleName = resources.GetString("editMasterPassword.AccessibleName");
			this.editMasterPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("editMasterPassword.Anchor")));
			this.editMasterPassword.AutoSize = ((bool)(resources.GetObject("editMasterPassword.AutoSize")));
			this.editMasterPassword.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("editMasterPassword.BackgroundImage")));
			this.editMasterPassword.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("editMasterPassword.Dock")));
			this.editMasterPassword.Enabled = ((bool)(resources.GetObject("editMasterPassword.Enabled")));
			this.editMasterPassword.Font = ((System.Drawing.Font)(resources.GetObject("editMasterPassword.Font")));
			this.editMasterPassword.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("editMasterPassword.ImeMode")));
			this.editMasterPassword.Location = ((System.Drawing.Point)(resources.GetObject("editMasterPassword.Location")));
			this.editMasterPassword.MaxLength = ((int)(resources.GetObject("editMasterPassword.MaxLength")));
			this.editMasterPassword.Multiline = ((bool)(resources.GetObject("editMasterPassword.Multiline")));
			this.editMasterPassword.Name = "editMasterPassword";
			this.editMasterPassword.PasswordChar = ((char)(resources.GetObject("editMasterPassword.PasswordChar")));
			this.editMasterPassword.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("editMasterPassword.RightToLeft")));
			this.editMasterPassword.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("editMasterPassword.ScrollBars")));
			this.editMasterPassword.Size = ((System.Drawing.Size)(resources.GetObject("editMasterPassword.Size")));
			this.editMasterPassword.TabIndex = ((int)(resources.GetObject("editMasterPassword.TabIndex")));
			this.editMasterPassword.Text = resources.GetString("editMasterPassword.Text");
			this.editMasterPassword.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("editMasterPassword.TextAlign")));
			this.editMasterPassword.Visible = ((bool)(resources.GetObject("editMasterPassword.Visible")));
			this.editMasterPassword.WordWrap = ((bool)(resources.GetObject("editMasterPassword.WordWrap")));
			// 
			// radioNoSecurity
			// 
			this.radioNoSecurity.AccessibleDescription = resources.GetString("radioNoSecurity.AccessibleDescription");
			this.radioNoSecurity.AccessibleName = resources.GetString("radioNoSecurity.AccessibleName");
			this.radioNoSecurity.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("radioNoSecurity.Anchor")));
			this.radioNoSecurity.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("radioNoSecurity.Appearance")));
			this.radioNoSecurity.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radioNoSecurity.BackgroundImage")));
			this.radioNoSecurity.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioNoSecurity.CheckAlign")));
			this.radioNoSecurity.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("radioNoSecurity.Dock")));
			this.radioNoSecurity.Enabled = ((bool)(resources.GetObject("radioNoSecurity.Enabled")));
			this.radioNoSecurity.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("radioNoSecurity.FlatStyle")));
			this.radioNoSecurity.Font = ((System.Drawing.Font)(resources.GetObject("radioNoSecurity.Font")));
			this.radioNoSecurity.Image = ((System.Drawing.Image)(resources.GetObject("radioNoSecurity.Image")));
			this.radioNoSecurity.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioNoSecurity.ImageAlign")));
			this.radioNoSecurity.ImageIndex = ((int)(resources.GetObject("radioNoSecurity.ImageIndex")));
			this.radioNoSecurity.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("radioNoSecurity.ImeMode")));
			this.radioNoSecurity.Location = ((System.Drawing.Point)(resources.GetObject("radioNoSecurity.Location")));
			this.radioNoSecurity.Name = "radioNoSecurity";
			this.radioNoSecurity.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("radioNoSecurity.RightToLeft")));
			this.radioNoSecurity.Size = ((System.Drawing.Size)(resources.GetObject("radioNoSecurity.Size")));
			this.radioNoSecurity.TabIndex = ((int)(resources.GetObject("radioNoSecurity.TabIndex")));
			this.radioNoSecurity.Text = resources.GetString("radioNoSecurity.Text");
			this.radioNoSecurity.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radioNoSecurity.TextAlign")));
			this.radioNoSecurity.Visible = ((bool)(resources.GetObject("radioNoSecurity.Visible")));
			this.radioNoSecurity.CheckedChanged += new System.EventHandler(this.radioSecurityRC4_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.AccessibleDescription = resources.GetString("groupBox1.AccessibleDescription");
			this.groupBox1.AccessibleName = resources.GetString("groupBox1.AccessibleName");
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("groupBox1.Anchor")));
			this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
			this.groupBox1.Controls.Add(this.radio128bitRC4);
			this.groupBox1.Controls.Add(this.radio40bitRC4);
			this.groupBox1.Controls.Add(this.radioNoSecurity);
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
			// radio128bitRC4
			// 
			this.radio128bitRC4.AccessibleDescription = resources.GetString("radio128bitRC4.AccessibleDescription");
			this.radio128bitRC4.AccessibleName = resources.GetString("radio128bitRC4.AccessibleName");
			this.radio128bitRC4.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("radio128bitRC4.Anchor")));
			this.radio128bitRC4.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("radio128bitRC4.Appearance")));
			this.radio128bitRC4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radio128bitRC4.BackgroundImage")));
			this.radio128bitRC4.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radio128bitRC4.CheckAlign")));
			this.radio128bitRC4.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("radio128bitRC4.Dock")));
			this.radio128bitRC4.Enabled = ((bool)(resources.GetObject("radio128bitRC4.Enabled")));
			this.radio128bitRC4.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("radio128bitRC4.FlatStyle")));
			this.radio128bitRC4.Font = ((System.Drawing.Font)(resources.GetObject("radio128bitRC4.Font")));
			this.radio128bitRC4.Image = ((System.Drawing.Image)(resources.GetObject("radio128bitRC4.Image")));
			this.radio128bitRC4.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radio128bitRC4.ImageAlign")));
			this.radio128bitRC4.ImageIndex = ((int)(resources.GetObject("radio128bitRC4.ImageIndex")));
			this.radio128bitRC4.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("radio128bitRC4.ImeMode")));
			this.radio128bitRC4.Location = ((System.Drawing.Point)(resources.GetObject("radio128bitRC4.Location")));
			this.radio128bitRC4.Name = "radio128bitRC4";
			this.radio128bitRC4.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("radio128bitRC4.RightToLeft")));
			this.radio128bitRC4.Size = ((System.Drawing.Size)(resources.GetObject("radio128bitRC4.Size")));
			this.radio128bitRC4.TabIndex = ((int)(resources.GetObject("radio128bitRC4.TabIndex")));
			this.radio128bitRC4.Text = resources.GetString("radio128bitRC4.Text");
			this.radio128bitRC4.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radio128bitRC4.TextAlign")));
			this.radio128bitRC4.Visible = ((bool)(resources.GetObject("radio128bitRC4.Visible")));
			this.radio128bitRC4.CheckedChanged += new System.EventHandler(this.radioSecurityRC4_CheckedChanged);
			// 
			// radio40bitRC4
			// 
			this.radio40bitRC4.AccessibleDescription = resources.GetString("radio40bitRC4.AccessibleDescription");
			this.radio40bitRC4.AccessibleName = resources.GetString("radio40bitRC4.AccessibleName");
			this.radio40bitRC4.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("radio40bitRC4.Anchor")));
			this.radio40bitRC4.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("radio40bitRC4.Appearance")));
			this.radio40bitRC4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("radio40bitRC4.BackgroundImage")));
			this.radio40bitRC4.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radio40bitRC4.CheckAlign")));
			this.radio40bitRC4.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("radio40bitRC4.Dock")));
			this.radio40bitRC4.Enabled = ((bool)(resources.GetObject("radio40bitRC4.Enabled")));
			this.radio40bitRC4.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("radio40bitRC4.FlatStyle")));
			this.radio40bitRC4.Font = ((System.Drawing.Font)(resources.GetObject("radio40bitRC4.Font")));
			this.radio40bitRC4.Image = ((System.Drawing.Image)(resources.GetObject("radio40bitRC4.Image")));
			this.radio40bitRC4.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radio40bitRC4.ImageAlign")));
			this.radio40bitRC4.ImageIndex = ((int)(resources.GetObject("radio40bitRC4.ImageIndex")));
			this.radio40bitRC4.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("radio40bitRC4.ImeMode")));
			this.radio40bitRC4.Location = ((System.Drawing.Point)(resources.GetObject("radio40bitRC4.Location")));
			this.radio40bitRC4.Name = "radio40bitRC4";
			this.radio40bitRC4.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("radio40bitRC4.RightToLeft")));
			this.radio40bitRC4.Size = ((System.Drawing.Size)(resources.GetObject("radio40bitRC4.Size")));
			this.radio40bitRC4.TabIndex = ((int)(resources.GetObject("radio40bitRC4.TabIndex")));
			this.radio40bitRC4.Text = resources.GetString("radio40bitRC4.Text");
			this.radio40bitRC4.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("radio40bitRC4.TextAlign")));
			this.radio40bitRC4.Visible = ((bool)(resources.GetObject("radio40bitRC4.Visible")));
			this.radio40bitRC4.CheckedChanged += new System.EventHandler(this.radioSecurityRC4_CheckedChanged);
			// 
			// checkPrinting
			// 
			this.checkPrinting.AccessibleDescription = resources.GetString("checkPrinting.AccessibleDescription");
			this.checkPrinting.AccessibleName = resources.GetString("checkPrinting.AccessibleName");
			this.checkPrinting.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("checkPrinting.Anchor")));
			this.checkPrinting.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("checkPrinting.Appearance")));
			this.checkPrinting.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkPrinting.BackgroundImage")));
			this.checkPrinting.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkPrinting.CheckAlign")));
			this.checkPrinting.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("checkPrinting.Dock")));
			this.checkPrinting.Enabled = ((bool)(resources.GetObject("checkPrinting.Enabled")));
			this.checkPrinting.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("checkPrinting.FlatStyle")));
			this.checkPrinting.Font = ((System.Drawing.Font)(resources.GetObject("checkPrinting.Font")));
			this.checkPrinting.Image = ((System.Drawing.Image)(resources.GetObject("checkPrinting.Image")));
			this.checkPrinting.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkPrinting.ImageAlign")));
			this.checkPrinting.ImageIndex = ((int)(resources.GetObject("checkPrinting.ImageIndex")));
			this.checkPrinting.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("checkPrinting.ImeMode")));
			this.checkPrinting.Location = ((System.Drawing.Point)(resources.GetObject("checkPrinting.Location")));
			this.checkPrinting.Name = "checkPrinting";
			this.checkPrinting.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("checkPrinting.RightToLeft")));
			this.checkPrinting.Size = ((System.Drawing.Size)(resources.GetObject("checkPrinting.Size")));
			this.checkPrinting.TabIndex = ((int)(resources.GetObject("checkPrinting.TabIndex")));
			this.checkPrinting.Text = resources.GetString("checkPrinting.Text");
			this.checkPrinting.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkPrinting.TextAlign")));
			this.checkPrinting.Visible = ((bool)(resources.GetObject("checkPrinting.Visible")));
			// 
			// checkModifyContent
			// 
			this.checkModifyContent.AccessibleDescription = resources.GetString("checkModifyContent.AccessibleDescription");
			this.checkModifyContent.AccessibleName = resources.GetString("checkModifyContent.AccessibleName");
			this.checkModifyContent.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("checkModifyContent.Anchor")));
			this.checkModifyContent.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("checkModifyContent.Appearance")));
			this.checkModifyContent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkModifyContent.BackgroundImage")));
			this.checkModifyContent.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkModifyContent.CheckAlign")));
			this.checkModifyContent.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("checkModifyContent.Dock")));
			this.checkModifyContent.Enabled = ((bool)(resources.GetObject("checkModifyContent.Enabled")));
			this.checkModifyContent.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("checkModifyContent.FlatStyle")));
			this.checkModifyContent.Font = ((System.Drawing.Font)(resources.GetObject("checkModifyContent.Font")));
			this.checkModifyContent.Image = ((System.Drawing.Image)(resources.GetObject("checkModifyContent.Image")));
			this.checkModifyContent.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkModifyContent.ImageAlign")));
			this.checkModifyContent.ImageIndex = ((int)(resources.GetObject("checkModifyContent.ImageIndex")));
			this.checkModifyContent.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("checkModifyContent.ImeMode")));
			this.checkModifyContent.Location = ((System.Drawing.Point)(resources.GetObject("checkModifyContent.Location")));
			this.checkModifyContent.Name = "checkModifyContent";
			this.checkModifyContent.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("checkModifyContent.RightToLeft")));
			this.checkModifyContent.Size = ((System.Drawing.Size)(resources.GetObject("checkModifyContent.Size")));
			this.checkModifyContent.TabIndex = ((int)(resources.GetObject("checkModifyContent.TabIndex")));
			this.checkModifyContent.Text = resources.GetString("checkModifyContent.Text");
			this.checkModifyContent.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkModifyContent.TextAlign")));
			this.checkModifyContent.Visible = ((bool)(resources.GetObject("checkModifyContent.Visible")));
			// 
			// checkCopy
			// 
			this.checkCopy.AccessibleDescription = resources.GetString("checkCopy.AccessibleDescription");
			this.checkCopy.AccessibleName = resources.GetString("checkCopy.AccessibleName");
			this.checkCopy.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("checkCopy.Anchor")));
			this.checkCopy.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("checkCopy.Appearance")));
			this.checkCopy.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkCopy.BackgroundImage")));
			this.checkCopy.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkCopy.CheckAlign")));
			this.checkCopy.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("checkCopy.Dock")));
			this.checkCopy.Enabled = ((bool)(resources.GetObject("checkCopy.Enabled")));
			this.checkCopy.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("checkCopy.FlatStyle")));
			this.checkCopy.Font = ((System.Drawing.Font)(resources.GetObject("checkCopy.Font")));
			this.checkCopy.Image = ((System.Drawing.Image)(resources.GetObject("checkCopy.Image")));
			this.checkCopy.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkCopy.ImageAlign")));
			this.checkCopy.ImageIndex = ((int)(resources.GetObject("checkCopy.ImageIndex")));
			this.checkCopy.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("checkCopy.ImeMode")));
			this.checkCopy.Location = ((System.Drawing.Point)(resources.GetObject("checkCopy.Location")));
			this.checkCopy.Name = "checkCopy";
			this.checkCopy.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("checkCopy.RightToLeft")));
			this.checkCopy.Size = ((System.Drawing.Size)(resources.GetObject("checkCopy.Size")));
			this.checkCopy.TabIndex = ((int)(resources.GetObject("checkCopy.TabIndex")));
			this.checkCopy.Text = resources.GetString("checkCopy.Text");
			this.checkCopy.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkCopy.TextAlign")));
			this.checkCopy.Visible = ((bool)(resources.GetObject("checkCopy.Visible")));
			// 
			// checkModifyAnnotations
			// 
			this.checkModifyAnnotations.AccessibleDescription = resources.GetString("checkModifyAnnotations.AccessibleDescription");
			this.checkModifyAnnotations.AccessibleName = resources.GetString("checkModifyAnnotations.AccessibleName");
			this.checkModifyAnnotations.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("checkModifyAnnotations.Anchor")));
			this.checkModifyAnnotations.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("checkModifyAnnotations.Appearance")));
			this.checkModifyAnnotations.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkModifyAnnotations.BackgroundImage")));
			this.checkModifyAnnotations.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkModifyAnnotations.CheckAlign")));
			this.checkModifyAnnotations.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("checkModifyAnnotations.Dock")));
			this.checkModifyAnnotations.Enabled = ((bool)(resources.GetObject("checkModifyAnnotations.Enabled")));
			this.checkModifyAnnotations.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("checkModifyAnnotations.FlatStyle")));
			this.checkModifyAnnotations.Font = ((System.Drawing.Font)(resources.GetObject("checkModifyAnnotations.Font")));
			this.checkModifyAnnotations.Image = ((System.Drawing.Image)(resources.GetObject("checkModifyAnnotations.Image")));
			this.checkModifyAnnotations.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkModifyAnnotations.ImageAlign")));
			this.checkModifyAnnotations.ImageIndex = ((int)(resources.GetObject("checkModifyAnnotations.ImageIndex")));
			this.checkModifyAnnotations.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("checkModifyAnnotations.ImeMode")));
			this.checkModifyAnnotations.Location = ((System.Drawing.Point)(resources.GetObject("checkModifyAnnotations.Location")));
			this.checkModifyAnnotations.Name = "checkModifyAnnotations";
			this.checkModifyAnnotations.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("checkModifyAnnotations.RightToLeft")));
			this.checkModifyAnnotations.Size = ((System.Drawing.Size)(resources.GetObject("checkModifyAnnotations.Size")));
			this.checkModifyAnnotations.TabIndex = ((int)(resources.GetObject("checkModifyAnnotations.TabIndex")));
			this.checkModifyAnnotations.Text = resources.GetString("checkModifyAnnotations.Text");
			this.checkModifyAnnotations.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkModifyAnnotations.TextAlign")));
			this.checkModifyAnnotations.Visible = ((bool)(resources.GetObject("checkModifyAnnotations.Visible")));
			// 
			// checkDocumentAssembly
			// 
			this.checkDocumentAssembly.AccessibleDescription = resources.GetString("checkDocumentAssembly.AccessibleDescription");
			this.checkDocumentAssembly.AccessibleName = resources.GetString("checkDocumentAssembly.AccessibleName");
			this.checkDocumentAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("checkDocumentAssembly.Anchor")));
			this.checkDocumentAssembly.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("checkDocumentAssembly.Appearance")));
			this.checkDocumentAssembly.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkDocumentAssembly.BackgroundImage")));
			this.checkDocumentAssembly.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkDocumentAssembly.CheckAlign")));
			this.checkDocumentAssembly.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("checkDocumentAssembly.Dock")));
			this.checkDocumentAssembly.Enabled = ((bool)(resources.GetObject("checkDocumentAssembly.Enabled")));
			this.checkDocumentAssembly.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("checkDocumentAssembly.FlatStyle")));
			this.checkDocumentAssembly.Font = ((System.Drawing.Font)(resources.GetObject("checkDocumentAssembly.Font")));
			this.checkDocumentAssembly.Image = ((System.Drawing.Image)(resources.GetObject("checkDocumentAssembly.Image")));
			this.checkDocumentAssembly.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkDocumentAssembly.ImageAlign")));
			this.checkDocumentAssembly.ImageIndex = ((int)(resources.GetObject("checkDocumentAssembly.ImageIndex")));
			this.checkDocumentAssembly.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("checkDocumentAssembly.ImeMode")));
			this.checkDocumentAssembly.Location = ((System.Drawing.Point)(resources.GetObject("checkDocumentAssembly.Location")));
			this.checkDocumentAssembly.Name = "checkDocumentAssembly";
			this.checkDocumentAssembly.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("checkDocumentAssembly.RightToLeft")));
			this.checkDocumentAssembly.Size = ((System.Drawing.Size)(resources.GetObject("checkDocumentAssembly.Size")));
			this.checkDocumentAssembly.TabIndex = ((int)(resources.GetObject("checkDocumentAssembly.TabIndex")));
			this.checkDocumentAssembly.Text = resources.GetString("checkDocumentAssembly.Text");
			this.checkDocumentAssembly.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkDocumentAssembly.TextAlign")));
			this.checkDocumentAssembly.Visible = ((bool)(resources.GetObject("checkDocumentAssembly.Visible")));
			// 
			// checkFillIn
			// 
			this.checkFillIn.AccessibleDescription = resources.GetString("checkFillIn.AccessibleDescription");
			this.checkFillIn.AccessibleName = resources.GetString("checkFillIn.AccessibleName");
			this.checkFillIn.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("checkFillIn.Anchor")));
			this.checkFillIn.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("checkFillIn.Appearance")));
			this.checkFillIn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkFillIn.BackgroundImage")));
			this.checkFillIn.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkFillIn.CheckAlign")));
			this.checkFillIn.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("checkFillIn.Dock")));
			this.checkFillIn.Enabled = ((bool)(resources.GetObject("checkFillIn.Enabled")));
			this.checkFillIn.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("checkFillIn.FlatStyle")));
			this.checkFillIn.Font = ((System.Drawing.Font)(resources.GetObject("checkFillIn.Font")));
			this.checkFillIn.Image = ((System.Drawing.Image)(resources.GetObject("checkFillIn.Image")));
			this.checkFillIn.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkFillIn.ImageAlign")));
			this.checkFillIn.ImageIndex = ((int)(resources.GetObject("checkFillIn.ImageIndex")));
			this.checkFillIn.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("checkFillIn.ImeMode")));
			this.checkFillIn.Location = ((System.Drawing.Point)(resources.GetObject("checkFillIn.Location")));
			this.checkFillIn.Name = "checkFillIn";
			this.checkFillIn.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("checkFillIn.RightToLeft")));
			this.checkFillIn.Size = ((System.Drawing.Size)(resources.GetObject("checkFillIn.Size")));
			this.checkFillIn.TabIndex = ((int)(resources.GetObject("checkFillIn.TabIndex")));
			this.checkFillIn.Text = resources.GetString("checkFillIn.Text");
			this.checkFillIn.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkFillIn.TextAlign")));
			this.checkFillIn.Visible = ((bool)(resources.GetObject("checkFillIn.Visible")));
			// 
			// checkScreenReaders
			// 
			this.checkScreenReaders.AccessibleDescription = resources.GetString("checkScreenReaders.AccessibleDescription");
			this.checkScreenReaders.AccessibleName = resources.GetString("checkScreenReaders.AccessibleName");
			this.checkScreenReaders.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("checkScreenReaders.Anchor")));
			this.checkScreenReaders.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("checkScreenReaders.Appearance")));
			this.checkScreenReaders.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkScreenReaders.BackgroundImage")));
			this.checkScreenReaders.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkScreenReaders.CheckAlign")));
			this.checkScreenReaders.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("checkScreenReaders.Dock")));
			this.checkScreenReaders.Enabled = ((bool)(resources.GetObject("checkScreenReaders.Enabled")));
			this.checkScreenReaders.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("checkScreenReaders.FlatStyle")));
			this.checkScreenReaders.Font = ((System.Drawing.Font)(resources.GetObject("checkScreenReaders.Font")));
			this.checkScreenReaders.Image = ((System.Drawing.Image)(resources.GetObject("checkScreenReaders.Image")));
			this.checkScreenReaders.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkScreenReaders.ImageAlign")));
			this.checkScreenReaders.ImageIndex = ((int)(resources.GetObject("checkScreenReaders.ImageIndex")));
			this.checkScreenReaders.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("checkScreenReaders.ImeMode")));
			this.checkScreenReaders.Location = ((System.Drawing.Point)(resources.GetObject("checkScreenReaders.Location")));
			this.checkScreenReaders.Name = "checkScreenReaders";
			this.checkScreenReaders.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("checkScreenReaders.RightToLeft")));
			this.checkScreenReaders.Size = ((System.Drawing.Size)(resources.GetObject("checkScreenReaders.Size")));
			this.checkScreenReaders.TabIndex = ((int)(resources.GetObject("checkScreenReaders.TabIndex")));
			this.checkScreenReaders.Text = resources.GetString("checkScreenReaders.Text");
			this.checkScreenReaders.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkScreenReaders.TextAlign")));
			this.checkScreenReaders.Visible = ((bool)(resources.GetObject("checkScreenReaders.Visible")));
			// 
			// checkLowPrint
			// 
			this.checkLowPrint.AccessibleDescription = resources.GetString("checkLowPrint.AccessibleDescription");
			this.checkLowPrint.AccessibleName = resources.GetString("checkLowPrint.AccessibleName");
			this.checkLowPrint.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("checkLowPrint.Anchor")));
			this.checkLowPrint.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("checkLowPrint.Appearance")));
			this.checkLowPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("checkLowPrint.BackgroundImage")));
			this.checkLowPrint.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkLowPrint.CheckAlign")));
			this.checkLowPrint.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("checkLowPrint.Dock")));
			this.checkLowPrint.Enabled = ((bool)(resources.GetObject("checkLowPrint.Enabled")));
			this.checkLowPrint.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("checkLowPrint.FlatStyle")));
			this.checkLowPrint.Font = ((System.Drawing.Font)(resources.GetObject("checkLowPrint.Font")));
			this.checkLowPrint.Image = ((System.Drawing.Image)(resources.GetObject("checkLowPrint.Image")));
			this.checkLowPrint.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkLowPrint.ImageAlign")));
			this.checkLowPrint.ImageIndex = ((int)(resources.GetObject("checkLowPrint.ImageIndex")));
			this.checkLowPrint.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("checkLowPrint.ImeMode")));
			this.checkLowPrint.Location = ((System.Drawing.Point)(resources.GetObject("checkLowPrint.Location")));
			this.checkLowPrint.Name = "checkLowPrint";
			this.checkLowPrint.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("checkLowPrint.RightToLeft")));
			this.checkLowPrint.Size = ((System.Drawing.Size)(resources.GetObject("checkLowPrint.Size")));
			this.checkLowPrint.TabIndex = ((int)(resources.GetObject("checkLowPrint.TabIndex")));
			this.checkLowPrint.Text = resources.GetString("checkLowPrint.Text");
			this.checkLowPrint.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("checkLowPrint.TextAlign")));
			this.checkLowPrint.Visible = ((bool)(resources.GetObject("checkLowPrint.Visible")));
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
			// EncryptOptionDialog
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
			this.Controls.Add(this.checkDocumentAssembly);
			this.Controls.Add(this.checkFillIn);
			this.Controls.Add(this.checkScreenReaders);
			this.Controls.Add(this.checkLowPrint);
			this.Controls.Add(this.checkCopy);
			this.Controls.Add(this.checkModifyAnnotations);
			this.Controls.Add(this.checkModifyContent);
			this.Controls.Add(this.checkPrinting);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.editMasterPassword);
			this.Controls.Add(this.editUserPassword);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
			this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
			this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
			this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
			this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
			this.Name = "EncryptOptionDialog";
			this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
			this.ShowInTaskbar = false;
			this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
			this.Text = resources.GetString("$this.Text");
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			if (EncryptionLength > 0 && editMasterPassword.Text == "") 
			{
				MessageBox.Show("Master password is required.");
				editMasterPassword.Focus();
			}
			else
			{
				this.DialogResult = DialogResult.OK;
			}
		}

		private void radioSecurityRC4_CheckedChanged(object sender, System.EventArgs e)
		{
			bool b = !radioNoSecurity.Checked;
			checkDocumentAssembly.Visible= b;
			checkFillIn.Visible= b;
			checkScreenReaders.Visible= b;
			checkLowPrint.Visible= b;
			checkPrinting.Visible= b;
			checkModifyContent.Visible= b;
			checkCopy.Visible= b;
			checkModifyAnnotations.Visible= b;
		}

		public String UserPassword
		{
			get 
			{
				return editUserPassword.Text;
			}
			set
			{
				editUserPassword.Text = (value == null ? "" : value);
			}
		}
	
		public String MasterPassword
		{
			get
			{
				return editMasterPassword.Text;
			}
			set
			{
				editMasterPassword.Text = (value == null ? "" : value);
			}
		}

		public int EncryptionLength
		{
			get 
			{
				if (radio40bitRC4.Checked) return 40;
				if (radio128bitRC4.Checked) return 128; 
				return 0;
			}
			set
			{
				switch (value)
				{
					case 0:
						radioNoSecurity.Checked = true;
						break;
					case 40:
						radio40bitRC4.Checked = true;
						break;
					case 128:
						radio128bitRC4.Checked = true;
						break;
					default:
						throw new ArgumentException();
				}
			}
		}
	
		public int Permissions
		{
			get
			{
				int perm = 0;
				if (checkPrinting.Checked) perm |= PdfWriter.AllowPrinting;
				if (checkModifyContent.Checked) perm |= PdfWriter.AllowModifyContents;
				if (checkCopy.Checked) perm |= PdfWriter.AllowCopy;
				if (checkModifyAnnotations.Checked) perm |= PdfWriter.AllowModifyAnnotations;
				if (checkDocumentAssembly.Checked) perm |= PdfWriter.AllowAssembly;
				if (checkFillIn.Checked) perm |= PdfWriter.AllowFillIn;
				if (checkScreenReaders.Checked) perm |= PdfWriter.AllowScreenReaders;
				if (checkLowPrint.Checked) perm |= PdfWriter.AllowDegradedPrinting;
				return perm;
			}
			set
			{
				checkPrinting.Checked = ((value & PdfWriter.AllowPrinting) == PdfWriter.AllowPrinting);
				checkModifyContent.Checked = ((value & PdfWriter.AllowModifyContents) == PdfWriter.AllowModifyContents);
				checkCopy.Checked = ((value & PdfWriter.AllowCopy) == PdfWriter.AllowCopy);
				checkModifyAnnotations.Checked = ((value & PdfWriter.AllowModifyAnnotations) == PdfWriter.AllowModifyAnnotations);
				checkDocumentAssembly.Checked = ((value & PdfWriter.AllowAssembly) == PdfWriter.AllowAssembly);
				checkFillIn.Checked = ((value & PdfWriter.AllowFillIn) == PdfWriter.AllowFillIn);
				checkScreenReaders.Checked = ((value & PdfWriter.AllowScreenReaders) == PdfWriter.AllowScreenReaders);
				checkLowPrint.Checked = ((value & PdfWriter.AllowDegradedPrinting) == PdfWriter.AllowDegradedPrinting);
			}
		}

	}
}
