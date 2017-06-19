/*
    Copyright (C) 2003, 2012 Kazuya Ujihara
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

using System.Linq;
using System.IO;
using System.Text;
using Microsoft.Win32;

using iTextSharp.text;
using iTextSharp.text.pdf;
using Ujihara.PDF;
using Ujihara.Lib;
using iTextSharp.text.pdf.codec;
using iTextSharp.text.exceptions;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace Ujihara.ConcatPDF
{
	public class MainWindow : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItemFileAdd;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.MenuItem menuItemSaveAs;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel2;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItemDocumentSecurity;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItemViewByAcrobat;
		private System.Windows.Forms.MenuItem menuItemViewThisItem;
		private System.Windows.Forms.ImageList imageListToolBar;
		private System.Windows.Forms.ToolBarButton toolBarButtonViewThisItem;
		private System.Windows.Forms.ToolBarButton toolBarButtonViewByAcrobat;
		private System.Windows.Forms.ToolBarButton toolBarButtonUp;
		private System.Windows.Forms.ToolBarButton toolBarButtonDown;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.MenuItem menuItemEdit;
		private System.Windows.Forms.MenuItem menuItemUp;
		private System.Windows.Forms.MenuItem menuItemDown;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItemRemove;
		private System.Windows.Forms.MenuItem menuItemSelectAll;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton toolBarButtonOpen;
		private System.Windows.Forms.ToolBarButton toolBarButtonRemove;
		private System.Windows.Forms.ToolBarButton toolBarButtonSave;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.MenuItem menuItemSplit;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MenuItem menuItemAbout;
		private System.Windows.Forms.MenuItem menuItemContents;
		private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem menuItemViewerPref;
        private Ujihara.ConcatPDF.FileListBox fileListBox1;
        private MenuItem menuItemPageSetting;
        private MenuItem menuItemImageSetting;
        private MenuItem menuItemPreviewWindow;
		private System.Windows.Forms.MenuItem menuItemOutline;

		public MainWindow() : this(new string[] {} )
		{
		}

		public MainWindow(string[] args)
		{
			//
			// Windows フォーム デザイナ サポートに必要です。
			//
			InitializeComponent();

			Arguments = args;
		}

		private static void DeleteFSO(string objectName)
		{
			try
			{
				if (System.IO.File.Exists(objectName)) 
					System.IO.File.Delete(objectName);
				else if (System.IO.Directory.Exists(objectName)) 
					System.IO.Directory.Delete(objectName, true);
			}
			catch 
			{
			}
		}

		protected override void Dispose(bool disposing)
		{
			RegistryKey software = Registry.CurrentUser.OpenSubKey("Software", true);
			RegistryKey ujihara = software.CreateSubKey("Ujihara");
			RegistryKey concatpdf = ujihara.CreateSubKey("ConcatPDF");
			concatpdf.SetValue("FileNameColumnWidth", this.fileListBox1.HeaderFileName.Width);
			concatpdf.SetValue("PagesColumnWidth", this.fileListBox1.HeaderPages.Width);
			concatpdf.SetValue("DirColumnWidth", this.fileListBox1.HeaderDirectory.Width);
			concatpdf.SetValue("WindowWidth", this.Width);
			concatpdf.SetValue("WindowHeight", this.Height);
			concatpdf.SetValue("AddOutlinesOption", this.concatenatorOption.AddOutlines);
			concatpdf.SetValue("CopyOutlinesOption", this.concatenatorOption.CopyOutlines);
			concatpdf.SetValue("OutlineDestinationStyle", this.concatenatorOption.FittingStyle);

			while (tempFSCol.Count > 0)
			{
				object fs = tempFSCol.Pop();
				if (fs is string)
				{
					DeleteFSO((string)fs);
				}
				else if (fs is string[])
				{
					string[] fss = (string[])fs;
					for (int i = 0; i < fss.Length; i++)
					{
						DeleteFSO(fss[i]);
					}
				}
			}

			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemFileAdd = new System.Windows.Forms.MenuItem();
            this.menuItemSaveAs = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItemOutline = new System.Windows.Forms.MenuItem();
            this.menuItemDocumentSecurity = new System.Windows.Forms.MenuItem();
            this.menuItemViewerPref = new System.Windows.Forms.MenuItem();
            this.menuItemPageSetting = new System.Windows.Forms.MenuItem();
            this.menuItemImageSetting = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemEdit = new System.Windows.Forms.MenuItem();
            this.menuItemSplit = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItemRemove = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItemUp = new System.Windows.Forms.MenuItem();
            this.menuItemDown = new System.Windows.Forms.MenuItem();
            this.menuItemSelectAll = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItemViewByAcrobat = new System.Windows.Forms.MenuItem();
            this.menuItemViewThisItem = new System.Windows.Forms.MenuItem();
            this.menuItemPreviewWindow = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItemContents = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItemAbout = new System.Windows.Forms.MenuItem();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.statusBarPanel2 = new System.Windows.Forms.StatusBarPanel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.toolBarButtonUp = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonDown = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonViewThisItem = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonViewByAcrobat = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonOpen = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonSave = new System.Windows.Forms.ToolBarButton();
            this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonRemove = new System.Windows.Forms.ToolBarButton();
            this.imageListToolBar = new System.Windows.Forms.ImageList(this.components);
            this.fileListBox1 = new Ujihara.ConcatPDF.FileListBox();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemEdit,
            this.menuItem1,
            this.menuItem5});
            // 
            // menuItemFile
            // 
            this.menuItemFile.Index = 0;
            this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFileAdd,
            this.menuItemSaveAs,
            this.menuItem2,
            this.menuItemOutline,
            this.menuItemDocumentSecurity,
            this.menuItemViewerPref,
            this.menuItemPageSetting,
            this.menuItemImageSetting,
            this.menuItem4,
            this.menuItemExit});
            resources.ApplyResources(this.menuItemFile, "menuItemFile");
            // 
            // menuItemFileAdd
            // 
            this.menuItemFileAdd.Index = 0;
            resources.ApplyResources(this.menuItemFileAdd, "menuItemFileAdd");
            this.menuItemFileAdd.Click += new System.EventHandler(this.menuItemFileAdd_Click);
            // 
            // menuItemSaveAs
            // 
            this.menuItemSaveAs.Index = 1;
            resources.ApplyResources(this.menuItemSaveAs, "menuItemSaveAs");
            this.menuItemSaveAs.Click += new System.EventHandler(this.menuItemSaveAs_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            resources.ApplyResources(this.menuItem2, "menuItem2");
            // 
            // menuItemOutline
            // 
            this.menuItemOutline.Index = 3;
            resources.ApplyResources(this.menuItemOutline, "menuItemOutline");
            this.menuItemOutline.Click += new System.EventHandler(this.menuItemOutline_Click);
            // 
            // menuItemDocumentSecurity
            // 
            this.menuItemDocumentSecurity.Index = 4;
            resources.ApplyResources(this.menuItemDocumentSecurity, "menuItemDocumentSecurity");
            this.menuItemDocumentSecurity.Click += new System.EventHandler(this.menuItemDocumentSecurity_Click);
            // 
            // menuItemViewerPref
            // 
            this.menuItemViewerPref.Index = 5;
            resources.ApplyResources(this.menuItemViewerPref, "menuItemViewerPref");
            this.menuItemViewerPref.Click += new System.EventHandler(this.menuItemViewerPref_Click);
            // 
            // menuItemPageSetting
            // 
            this.menuItemPageSetting.Index = 6;
            resources.ApplyResources(this.menuItemPageSetting, "menuItemPageSetting");
            this.menuItemPageSetting.Click += new System.EventHandler(this.menuItemPageSetting_Click);
            // 
            // menuItemImageSetting
            // 
            this.menuItemImageSetting.Index = 7;
            resources.ApplyResources(this.menuItemImageSetting, "menuItemImageSetting");
            this.menuItemImageSetting.Click += new System.EventHandler(this.menuItemImageSetting_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 8;
            resources.ApplyResources(this.menuItem4, "menuItem4");
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 9;
            resources.ApplyResources(this.menuItemExit, "menuItemExit");
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.Index = 1;
            this.menuItemEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemSplit,
            this.menuItem8,
            this.menuItemRemove,
            this.menuItem3,
            this.menuItemUp,
            this.menuItemDown,
            this.menuItemSelectAll});
            resources.ApplyResources(this.menuItemEdit, "menuItemEdit");
            // 
            // menuItemSplit
            // 
            this.menuItemSplit.Index = 0;
            resources.ApplyResources(this.menuItemSplit, "menuItemSplit");
            this.menuItemSplit.Click += new System.EventHandler(this.menuItemSplit_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 1;
            resources.ApplyResources(this.menuItem8, "menuItem8");
            // 
            // menuItemRemove
            // 
            this.menuItemRemove.Index = 2;
            resources.ApplyResources(this.menuItemRemove, "menuItemRemove");
            this.menuItemRemove.Click += new System.EventHandler(this.menuItemRemove_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 3;
            resources.ApplyResources(this.menuItem3, "menuItem3");
            // 
            // menuItemUp
            // 
            this.menuItemUp.Index = 4;
            resources.ApplyResources(this.menuItemUp, "menuItemUp");
            this.menuItemUp.Click += new System.EventHandler(this.menuItemUpOrDown_Click);
            // 
            // menuItemDown
            // 
            this.menuItemDown.Index = 5;
            resources.ApplyResources(this.menuItemDown, "menuItemDown");
            this.menuItemDown.Click += new System.EventHandler(this.menuItemUpOrDown_Click);
            // 
            // menuItemSelectAll
            // 
            this.menuItemSelectAll.Index = 6;
            resources.ApplyResources(this.menuItemSelectAll, "menuItemSelectAll");
            this.menuItemSelectAll.Click += new System.EventHandler(this.menuItemSelectAll_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemViewByAcrobat,
            this.menuItemViewThisItem,
            this.menuItemPreviewWindow});
            resources.ApplyResources(this.menuItem1, "menuItem1");
            // 
            // menuItemViewByAcrobat
            // 
            this.menuItemViewByAcrobat.Index = 0;
            resources.ApplyResources(this.menuItemViewByAcrobat, "menuItemViewByAcrobat");
            this.menuItemViewByAcrobat.Click += new System.EventHandler(this.menuItemViewByAcrobat_Click);
            // 
            // menuItemViewThisItem
            // 
            this.menuItemViewThisItem.Index = 1;
            resources.ApplyResources(this.menuItemViewThisItem, "menuItemViewThisItem");
            this.menuItemViewThisItem.Click += new System.EventHandler(this.menuItemViewThisItem_Click);
            // 
            // menuItemPreviewWindow
            // 
            this.menuItemPreviewWindow.Index = 2;
            resources.ApplyResources(this.menuItemPreviewWindow, "menuItemPreviewWindow");
            this.menuItemPreviewWindow.Click += new System.EventHandler(this.menuItemPreviewWindow_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 3;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemContents,
            this.menuItem7,
            this.menuItemAbout});
            resources.ApplyResources(this.menuItem5, "menuItem5");
            // 
            // menuItemContents
            // 
            this.menuItemContents.Index = 0;
            resources.ApplyResources(this.menuItemContents, "menuItemContents");
            this.menuItemContents.Click += new System.EventHandler(this.menuItemContents_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 1;
            resources.ApplyResources(this.menuItem7, "menuItem7");
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Index = 2;
            resources.ApplyResources(this.menuItemAbout, "menuItemAbout");
            this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
            // 
            // statusBar1
            // 
            resources.ApplyResources(this.statusBar1, "statusBar1");
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1,
            this.statusBarPanel2});
            this.statusBar1.ShowPanels = true;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            resources.ApplyResources(this.statusBarPanel1, "statusBarPanel1");
            // 
            // statusBarPanel2
            // 
            resources.ApplyResources(this.statusBarPanel2, "statusBarPanel2");
            this.statusBarPanel2.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
            // 
            // openFileDialog
            // 
            resources.ApplyResources(this.openFileDialog, "openFileDialog");
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.RestoreDirectory = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "pdf";
            resources.ApplyResources(this.saveFileDialog, "saveFileDialog");
            this.saveFileDialog.RestoreDirectory = true;
            // 
            // toolBar1
            // 
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButtonUp,
            this.toolBarButtonDown,
            this.toolBarButton1,
            this.toolBarButtonViewThisItem,
            this.toolBarButtonViewByAcrobat,
            this.toolBarButton2,
            this.toolBarButtonOpen,
            this.toolBarButtonSave,
            this.toolBarButton3,
            this.toolBarButtonRemove});
            resources.ApplyResources(this.toolBar1, "toolBar1");
            this.toolBar1.ImageList = this.imageListToolBar;
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // toolBarButtonUp
            // 
            resources.ApplyResources(this.toolBarButtonUp, "toolBarButtonUp");
            this.toolBarButtonUp.Name = "toolBarButtonUp";
            // 
            // toolBarButtonDown
            // 
            resources.ApplyResources(this.toolBarButtonDown, "toolBarButtonDown");
            this.toolBarButtonDown.Name = "toolBarButtonDown";
            // 
            // toolBarButton1
            // 
            this.toolBarButton1.Name = "toolBarButton1";
            this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButtonViewThisItem
            // 
            resources.ApplyResources(this.toolBarButtonViewThisItem, "toolBarButtonViewThisItem");
            this.toolBarButtonViewThisItem.Name = "toolBarButtonViewThisItem";
            // 
            // toolBarButtonViewByAcrobat
            // 
            resources.ApplyResources(this.toolBarButtonViewByAcrobat, "toolBarButtonViewByAcrobat");
            this.toolBarButtonViewByAcrobat.Name = "toolBarButtonViewByAcrobat";
            // 
            // toolBarButton2
            // 
            this.toolBarButton2.Name = "toolBarButton2";
            this.toolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButtonOpen
            // 
            resources.ApplyResources(this.toolBarButtonOpen, "toolBarButtonOpen");
            this.toolBarButtonOpen.Name = "toolBarButtonOpen";
            // 
            // toolBarButtonSave
            // 
            resources.ApplyResources(this.toolBarButtonSave, "toolBarButtonSave");
            this.toolBarButtonSave.Name = "toolBarButtonSave";
            // 
            // toolBarButton3
            // 
            this.toolBarButton3.Name = "toolBarButton3";
            this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButtonRemove
            // 
            resources.ApplyResources(this.toolBarButtonRemove, "toolBarButtonRemove");
            this.toolBarButtonRemove.Name = "toolBarButtonRemove";
            // 
            // imageListToolBar
            // 
            this.imageListToolBar.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListToolBar.ImageStream")));
            this.imageListToolBar.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListToolBar.Images.SetKeyName(0, "");
            this.imageListToolBar.Images.SetKeyName(1, "");
            this.imageListToolBar.Images.SetKeyName(2, "");
            this.imageListToolBar.Images.SetKeyName(3, "");
            this.imageListToolBar.Images.SetKeyName(4, "");
            this.imageListToolBar.Images.SetKeyName(5, "");
            this.imageListToolBar.Images.SetKeyName(6, "");
            // 
            // fileListBox1
            // 
            resources.ApplyResources(this.fileListBox1, "fileListBox1");
            this.fileListBox1.Name = "fileListBox1";
            this.fileListBox1.OnTouchContents += new System.EventHandler(this.fileListBox1_TouchContents);
            this.fileListBox1.SelectedIndexChanged += new System.EventHandler(this.fileListBox1_SelectedIndexChanged);
            // 
            // MainWindow
            // 
            resources.ApplyResources(this, "$this");
            this.CausesValidation = false;
            this.Controls.Add(this.fileListBox1);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.statusBar1);
            this.Menu = this.mainMenu1;
            this.Name = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.Resize += new System.EventHandler(this.MainWindow_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		[STAThread]
		static void Main(string[] args)
		{

			Application.Run(new MainWindow(args));
		}

		private string[] Arguments = null;
		private PdfEncryptInfo encryptInfo = new PdfEncryptInfo();
		private int viewerPreference = 0;
		private Stack tempFSCol = new Stack();
		private PdfConcatenatorOption concatenatorOption = new PdfConcatenatorOption();
        private float DPI = 300f;

        private void MainWindow_Load(object sender, System.EventArgs e)
		{
			RegistryKey software = Registry.CurrentUser.OpenSubKey("Software", true);
			RegistryKey ujihara = software.CreateSubKey("Ujihara");
			RegistryKey concatpdf = ujihara.CreateSubKey("ConcatPDF");
			try
			{
				this.fileListBox1.HeaderFileName.Width = (int)concatpdf.GetValue("FileNameColumnWidth");
				this.fileListBox1.HeaderPages.Width = (int)concatpdf.GetValue("PagesColumnWidth");
				this.fileListBox1.HeaderDirectory.Width = (int)concatpdf.GetValue("DirColumnWidth");
			}
			catch (Exception)
			{
				this.fileListBox1.HeaderFileName.Width = 100;
				this.fileListBox1.HeaderPages.Width = 60;
				this.fileListBox1.HeaderDirectory.Width = 120;
			}

			try
			{
				this.Width = (int)concatpdf.GetValue("WindowWidth");
				this.Height = (int)concatpdf.GetValue("WindowHeight");
			}
			catch (Exception)
			{
			}

			try
			{
				concatenatorOption.AddOutlines = bool.Parse((string)concatpdf.GetValue("AddOutlinesOption", false));
				concatenatorOption.CopyOutlines = (bool.Parse((string)concatpdf.GetValue("CopyOutlinesOption", true)));
				concatenatorOption.FittingStyle = ((string)concatpdf.GetValue("OutlineDestinationStyle", "/XYZ null null null"));
			}
			catch (Exception)
			{
			}

            foreach (var arg in Arguments)
            {
                this.fileListBox1.AddFile(arg.Trim());
            }

			openFileDialog.InitialDirectory =
			saveFileDialog.InitialDirectory =
				Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            SetupFileListBox();
        }

        static private string[] imageExts = new string[] 
        { 
            "PDF", ".pdf",
            "Bitmap", ".bmp;.dib", 
            "JPEG", ".jpg;.jpeg;.jpe;.jfif", 
            "GIF", ".gif", 
            "TIFF", ".tif;.tiff",
            "PNG", ".png", 
            "WMF", ".wmf", 
            "JPEG 2000", ".jp2;.j2c", 
        };
        private static void RegisterFileExtensions(StringBuilder sb, string name, string exts)
        {
            sb.Append(name).Append(" ").Append("|").Append(exts.Replace(".", "*.")).Append("|");
        }
        private void SetupFileListBox()
        {
            var pdfCounter = new PagesCounter(PdfPagesCounter);
            var onePagesCounter = new PagesCounter(OnePagesCounter);
            var tiffPagesCounter = new PagesCounter(TiffPagesCouter);

            var sb = new StringBuilder();
            for (int i = 0; i < imageExts.Length; i += 2)
            {
                var name = imageExts[i];
                var exts = imageExts[i + 1];
                RegisterFileExtensions(sb, name, exts);

                PagesCounter counter;
                switch (name)
                {
                    case "PDF":
                        counter = pdfCounter;
                        break;
                    case "TIFF":
                        counter = tiffPagesCounter;
                        break;
                    default:
                        counter = onePagesCounter;
                        break;
                }

                foreach (var ext in exts.Split(';'))
                {
                    fileListBox1.RegisterPagesCounter(ext, counter);
                }
            }
            sb.Append("All files|*.*");
            openFileDialog.Filter = sb.ToString();
        }

        private static int OnePagesCounter(string filename)
        {
            return 1;
        }

        private static int TiffPagesCouter(string filename)
        {
            var ra = new RandomAccessFileOrArray(filename);
            var n = TiffImage.GetNumberOfPages(ra);
            ra.Close();
            return n;
        }

        private static int PdfPagesCounter(string filename)
        {
            var r = LibPDFTools.CreatePdfReader(filename, new PasswordListener(filename).QueryPassword, false);
            return r.NumberOfPages;
        }

		private void menuItemExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void menuItemFileAdd_Click(object sender, System.EventArgs e)
		{
			if (openFileDialog.ShowDialog() == DialogResult.OK)
				this.fileListBox1.AddFiles(openFileDialog.FileNames);
		}

		private void menuItemSaveAs_Click(object sender, System.EventArgs e)
		{
			try
			{
                saveFileDialog.Filter = "PDF files|*.pdf|TIFF files|*.tif;*.tiff";
				if (saveFileDialog.ShowDialog() != DialogResult.OK) 
                    return;

				Cursor cursor = this.Cursor;
				this.Cursor = Cursors.WaitCursor;
				try
				{
                    switch (saveFileDialog.FilterIndex)
                    {
                        case 2:
                            ConcatenateAndSaveAsTiff(this.DPI);
                            File.Copy(concatTempFile, saveFileDialog.FileName, true); 
                            break;
                        default:
                            Concatenate();
                            File.Copy(concatTempFile, saveFileDialog.FileName, true);
                            dirty = false;
                            break;
                    }
				}
				catch (Exception ee)
				{
					throw ee;
				}
				finally 
				{
					this.Cursor = cursor;
				}
			}
			catch (Exception ee)
			{
				ErrorMessage.Show(ee);
			}
		}

        private void ConcatenateAndSaveAsTiff(float resolution)
        {
            if (concatTempFile != null) return;

            var files = this.fileListBox1.Files;
            if (files.Count < 1) 
                throw new Exception("No files are added.");
            string tempFilename = FileOperation.GetTempFile("", ".tif");

            tempFSCol.Push(tempFilename);

            using (var outStream = new FileStream(tempFilename, FileMode.Create, FileAccess.Write))
            {
                using (var con = new TiffConcatenator(outStream, this.DPI))
                {
                    foreach (string filename in files)
                    {
                        con.Append(filename);
                    }
                }
            }

            concatTempFile = tempFilename;
        }

		private void Concatenate()
		{
			if (concatTempFile != null) return; 

			var files = this.fileListBox1.Files;
			if (files.Count < 1) 
                throw new Exception("No files are added.");
			string fileName = FileOperation.GetTempFile("", ".pdf");

			tempFSCol.Push(fileName);

			var outStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
			PdfConcatenator con = new PdfConcatenator(outStream, encryptInfo, viewerPreference);
            var readers = new List<PdfReader>();
			try
			{
				foreach (string filename in files)
				{
                    con.QueryPassword = new PasswordListener(filename).QueryPassword;
                    PdfReader reader = con.CreatePdfReader(filename, concatenatorOption);
                    readers.Add(reader);
                    con.Append(reader, Path.GetFileNameWithoutExtension(filename), new[] { new PageRange(1, int.MaxValue) }, concatenatorOption);
				}
			}
			finally
			{
				con.Close();
				outStream.Close();
                foreach (PdfReader reader in readers)
                    reader.Close();
			}

			concatTempFile = fileName;
		}

		private string concatTempFile = null;
		private bool dirty = false;

		private void notifyTouch()
		{
			if (concatTempFile != null && System.IO.File.Exists(concatTempFile)) 
			{
				try
				{
					System.IO.File.Delete(concatTempFile);
				}
				catch (Exception)
				{
				}
			}
			concatTempFile = null;
			dirty = true;
		}
		
		private void menuItemDocumentSecurity_Click(object sender, System.EventArgs e)
		{
			EncryptOptionDialog dlg = new EncryptOptionDialog();
			dlg.EncryptionLength = encryptInfo.encryptionLength;
			dlg.UserPassword = encryptInfo.userPassword;
			dlg.MasterPassword = encryptInfo.ownerPassword;
			dlg.Permissions = encryptInfo.permissions;
			if (dlg.ShowDialog() == DialogResult.OK) 
			{
				notifyTouch();
			
				encryptInfo.ownerPassword = dlg.MasterPassword;
				encryptInfo.userPassword = dlg.UserPassword;
				encryptInfo.encryptionLength = dlg.EncryptionLength;
				encryptInfo.permissions = dlg.Permissions;
			}
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (false) {}
			else if (e.Button == this.toolBarButtonUp)
				this.menuItemUpOrDown_Click(menuItemUp, e);
			else if (e.Button == this.toolBarButtonDown)
				this.menuItemUpOrDown_Click(menuItemDown, e);
			else if (e.Button == this.toolBarButtonViewByAcrobat)
				this.menuItemViewByAcrobat_Click(sender, e);
			else if (e.Button == this.toolBarButtonViewByAcrobat)
				this.menuItemViewThisItem_Click(sender, e);
			else if (e.Button == this.toolBarButtonViewThisItem)
				this.menuItemViewThisItem_Click(sender, e);	
			else if (e.Button == this.toolBarButtonOpen)
				this.menuItemFileAdd_Click(sender, e);
			else if (e.Button == this.toolBarButtonSave)
				this.menuItemSaveAs_Click(sender, e);
			else if (e.Button == this.toolBarButtonRemove)
				this.menuItemRemove_Click(sender, e);
			else {}
		}

		private void menuItemViewByAcrobat_Click(object sender, System.EventArgs e)
		{
			try
			{
				Concatenate();
				FileOperation.ExecuteFile(concatTempFile);
			}
#if !DEBUG
            catch (Exception ee)
			{
				ErrorMessage.Show(ee);
			}
#endif
            finally
            {
            }
		}

		private void menuItemViewThisItem_Click(object sender, System.EventArgs e)
		{
			try
			{
                if (this.fileListBox1.FocusedItem != null) 
					FileOperation.ExecuteFile(this.fileListBox1.FocusedItem.FullPath);
			}
			catch (Exception ee)
			{
				ErrorMessage.Show(ee);
			}
		}

		private void MainWindow_Resize(object sender, System.EventArgs e)
		{
			this.fileListBox1.Width = this.ClientSize.Width - this.fileListBox1.Left;
			this.fileListBox1.Height = statusBar1.Top - this.fileListBox1.Top;
		}

		private void menuItemUpOrDown_Click(object sender, System.EventArgs e)
		{
            try
            {
				int direct = 0;
				if (sender == menuItemUp)
				{
					direct = -1;
				}
				else if (sender == menuItemDown)
				{
					direct = +1;
				}

				Debug.Assert(direct != 0, "Assertion failed.");

                this.fileListBox1.MoveSelectedItems(direct);
			}
#if !DEBUG
			catch (Exception ee) 
			{
				ErrorMessage.Show(ee);
			}			
#endif
            finally
            {
            }
        }

        private void menuItemSplit_Click(object sender, System.EventArgs e)
		{
			try 
			{
                PdfSplitter spliter = new PdfSplitter();
                foreach (FileListItem item in this.fileListBox1.SelectedItems)
                {
                    int itemIndex = item.Index;
                    string fullPath = item.FullPath;

                    spliter.QueryPassword = new PasswordListener(fullPath).QueryPassword;
                    string storeFolder = FileOperation.GetTempFile();
                    string[] splited = null;
                    try
                    {
                        splited = spliter.Split(fullPath, storeFolder, Path.GetFileName(fullPath) + ".");
                    }
                    catch (Exception)
                    {
                        // ignore
                    }
                    if (splited != null)
                    {
#if true
                        tempFSCol.Push(storeFolder);
                        tempFSCol.Push(splited);
#endif
                        for (int j = 0; j < splited.Length; j++)
                        {
                            this.fileListBox1.Insert(itemIndex + j + 1, splited[j]);
                        }
                        this.fileListBox1.Remove(item);
                    }
                }
			}
#if !DEBUG
			catch (Exception ee) 
			{
				ErrorMessage.Show(ee);
			}
#endif
			finally
			{
				notifyTouch();
			}
		}

		private void menuItemRemove_Click(object sender, System.EventArgs e)
		{
            fileListBox1.RemoveSelectedItems();
		}

		private void menuItemSelectAll_Click(object sender, System.EventArgs e)
		{
            foreach (ListViewItem item in fileListBox1.Items)
                item.Selected = true;
		}

		private void menuItemAbout_Click(object sender, System.EventArgs e)
		{
			About dlg = new About();
			dlg.Show();
		}

		private void menuItemContents_Click(object sender, System.EventArgs e)
		{
			FileOperation.ExecuteFile(Path.Combine(Application.StartupPath, "ConcatPDF-Help.html"));
		}

		private void menuItemViewerPref_Click(object sender, System.EventArgs e)
		{
			ViewerOptionDialog dlg = new ViewerOptionDialog();
			dlg.ViewerPreference = this.viewerPreference;
			if (dlg.ShowDialog() == DialogResult.OK) 
			{
				this.viewerPreference = dlg.ViewerPreference;
				notifyTouch();
			}
		}

		private void menuItemOutline_Click(object sender, System.EventArgs e)
		{
			DlgOutlineSetting dlg = new DlgOutlineSetting();
            dlg.SetSetting(concatenatorOption);
			if (dlg.ShowDialog() == DialogResult.OK) 
			{
                dlg.GetSetting(concatenatorOption);
				notifyTouch();
			}		
		}

        private void fileListBox1_TouchContents(object sender, System.EventArgs e)
        {
            notifyTouch();
        }

        private void fileListBox1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("fileListBox1_DragDrop");
        
        }

        private void fileListBox1_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("fileListBox1_DragOver");
        }

        private void menuItemPageSetting_Click(object sender, EventArgs e)
        {
            var dlg = new PageSetting();
            dlg.SetSetting(this.concatenatorOption);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dlg.GetSetting(this.concatenatorOption);
                notifyTouch();
            }
        }

        private void menuItemImageSetting_Click(object sender, EventArgs e)
        {
            var dlg = new ImageSettingDialog();
            dlg.DPI = DPI;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                DPI = dlg.DPI;
                notifyTouch();
            }
        }

        private PreviewForm currentPreviewForm = null;

        private void menuItemPreviewWindow_Click(object sender, EventArgs e)
        {
            if (currentPreviewForm == null)
            {
                var preview = new PreviewForm();
                preview.QueryPassword = QueryPassword;
                preview.FormClosed += new FormClosedEventHandler(preview_FormClosed);
                preview.Show();
                currentPreviewForm = preview;
            }
            else
            {
                currentPreviewForm.Close();
            }
        }

        void preview_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (currentPreviewForm != null)
            {
                currentPreviewForm = null;
            }
        }

        private void fileListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var focusedItem = fileListBox1.FocusedItem;
            if (focusedItem != null)
            {
                if (currentPreviewForm != null)
                {
                    byte[] password = focusedItem.Password;
                    try
                    {
                        currentPreviewForm.LoadImage(focusedItem.FullPath, ref password);
                        focusedItem.Password = password;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        static public byte[] QueryPassword(string filename)
        {
            PwdQueryDlg dlg = new PwdQueryDlg();
            dlg.FullName = Path.GetFullPath(filename);
            if (dlg.ShowDialog() != DialogResult.OK)
                return null;
            return Encoding.ASCII.GetBytes(dlg.Password);
        }
	}

    class PasswordListener
    {
        string fullName;

        public PasswordListener(string filename)
        {
            this.fullName = Path.GetFullPath(filename);
        }

        public byte[] QueryPassword()
        {
            return MainWindow.QueryPassword(fullName);
        }
    }
}
