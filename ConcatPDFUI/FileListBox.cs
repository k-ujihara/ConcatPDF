/*
     Copyright 2004, 2012 by Kazuya Ujihara.
 
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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

using System.IO;
using System.Collections.Generic;

namespace Ujihara.ConcatPDF
{
    public delegate int PagesCounter(string filename);

    public class FileListBox : System.Windows.Forms.UserControl
    {
        private System.ComponentModel.Container components = null;

        public FileListBox()
        {
            InitializeComponent();

			//
			//
			//

			ClearSortMode();
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

        #region コンポーネント デザイナで生成されたコード 
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileListBox));
            this.listView = new System.Windows.Forms.ListView();
            this.headerFileName = new System.Windows.Forms.ColumnHeader();
            this.headerPages = new System.Windows.Forms.ColumnHeader();
            this.headerDir = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.AccessibleDescription = null;
            this.listView.AccessibleName = null;
            resources.ApplyResources(this.listView, "listView");
            this.listView.AllowDrop = true;
            this.listView.BackgroundImage = null;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.headerFileName,
            this.headerPages,
            this.headerDir});
            this.listView.Font = null;
            this.listView.Name = "listView";
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView_DragDrop);
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.listView.DragOver += new System.Windows.Forms.DragEventHandler(this.listView_DragOver);
            // 
            // headerFileName
            // 
            resources.ApplyResources(this.headerFileName, "headerFileName");
            // 
            // headerPages
            // 
            resources.ApplyResources(this.headerPages, "headerPages");
            // 
            // headerDir
            // 
            resources.ApplyResources(this.headerDir, "headerDir");
            // 
            // FileListBox
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.BackgroundImage = null;
            this.Controls.Add(this.listView);
            this.Font = null;
            this.Name = "FileListBox";
            this.ResumeLayout(false);

		}
        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader headerFileName;
        private System.Windows.Forms.ColumnHeader headerPages;
        private System.Windows.Forms.ColumnHeader headerDir;

        public event EventHandler OnTouchContents;
        public event EventHandler SelectedIndexChanged;
        protected IDictionary<string, PagesCounter> pagesCounters = new Dictionary<string, PagesCounter>();

		private const int NO_COLUMN_SELECTED = -1;
		private int sortColumn;
		private bool isAssent;

		private void ClearSortMode()
		{
			sortColumn = NO_COLUMN_SELECTED;
			isAssent = false;
		}

		private void TouchContents(object sender, EventArgs e)
		{
			ClearSortMode();
            if (OnTouchContents != null)
    			OnTouchContents(sender, e);
		}

        /// <summary>
        /// Move selected items up or down. 
        /// </summary>
        /// <param name="direction">-1:Up<br />1:Down<br /></param>
        public void MoveSelectedItems(int direction)
        {
            if (direction != 1 && direction != -1)
                throw new ArgumentException();

            int ItemsCount = this.listView.Items.Count;
            ListViewItem item = null;
            for (int x = 0; x < this.listView.SelectedItems.Count; x++)
            {
                int nl = 0;
                int nh = ItemsCount;
                if (direction > 0)
                {
                    item = this.listView.SelectedItems[this.listView.SelectedItems.Count - 1 - x];
                    nh = nh - x;
                }
                else
                {
                    item = this.listView.SelectedItems[x];
                    nl = x;
                }
                int index = item.Index;
                int newIndex = index + direction;
                if (nl <= newIndex && newIndex < nh) 
                {
                    TouchContents(this, EventArgs.Empty);
		
                    item.Remove();
                    this.listView.Items.Insert(newIndex, item);
                    item.Selected = true;
                }
            }
            if (item != null) 
                item.Focused = true;
        }

		private void SwapItem(int indexA, int indexB)
		{
			if (indexA == indexB)
				return;
			if (indexA > indexB)
			{
				int temp = indexA;
				indexA = indexB;
				indexB = temp;
			}

			ListViewItem itemA = this.listView.Items[indexA];
			ListViewItem itemB = this.listView.Items[indexB];
		}

        public virtual ListView.ListViewItemCollection Items
        {
            get
            {
                return this.listView.Items;
            }
        }

        public class FileListItemCollection : IEnumerable
        {
            ListView.ListViewItemCollection collection;

            internal FileListItemCollection(ListView.ListViewItemCollection collection)
            {
                this.collection = collection;
            }

            public IEnumerator GetEnumerator()
            {
                return new FileListItemEnumerator(collection.GetEnumerator());
            }
        }

        public virtual SelectedFileListItemCollection SelectedItems
        {
            get
            {
                return new SelectedFileListItemCollection(this.listView.SelectedItems);
            }
        }
        
        public class SelectedFileListItemCollection : IEnumerable<FileListItem>
        {
            ListView.SelectedListViewItemCollection collection;

            internal SelectedFileListItemCollection(ListView.SelectedListViewItemCollection collection)
            {
                this.collection = collection;
            }

            IEnumerator<FileListItem> IEnumerable<FileListItem>.GetEnumerator()
            {
                return new FileListItemEnumerator(collection.GetEnumerator());
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable<FileListItem>)this).GetEnumerator();
            }
        }

        private class FileListItemEnumerator : IEnumerator<FileListItem>
        {
            IEnumerator enumerator;

            public FileListItemEnumerator(IEnumerator enumerator)
            {
                this.enumerator = enumerator;
            }

            public void Reset()
            {
                enumerator.Reset();
            }

            public FileListItem Current
            {
                get
                {
                    return FileListItem.Get((ListViewItem)enumerator.Current);
                }
            }

            public bool MoveNext()
            {
                return enumerator.MoveNext();
            }

            public void Dispose()
            {
            }

            object IEnumerator.Current
            {
                get { return this.Current; }
            }
        }

        private void listBox_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) 
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listBox_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            object o = e.Data.GetData(DataFormats.FileDrop);
            if (o == null) 
            {
                //do nothing
            } 
            else 
            {
                string[] files = o as string[];
                if (files != null)
                    AddFiles(files);
            }
        }

        public virtual void AddFiles(string[] filenames)
        {
            foreach (string filename in filenames)
            {
                AddFile(filename);
            }
        }

        public virtual void RegisterPagesCounter(string extension, PagesCounter counter)
        {
            pagesCounters.Add(extension, counter);
        }

        public virtual void AddFile(string filename)
        {
            TouchContents(this, EventArgs.Empty);
            var item = MakeItemFromPath(filename);
            this.listView.Items.Add(item.ListViewItem);
        }

        private FileListItem MakeItemFromPath(string path)
        {
            var fileListItem = FileListItem.Create(path);
            var fullpath = fileListItem.FullPath;
            var counter = pagesCounters[Path.GetExtension(fullpath).ToLower()];
            if (counter != null)
            {
                Cursor cursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;

                try 
                {
                    fileListItem.NumberOfPages = counter(fullpath);
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

            return fileListItem;
        }

        public IList<string> Files
        {
            get
            {
                var files = new List<string>();
                foreach (ListViewItem item in listView.Items)
                {
                    files.Add(FileListItem.Get(item).FullPath);
                }
                return files;
            }
        }

        public virtual void Insert(int index, string path)
        {
            var item = MakeItemFromPath(path);
            listView.Items.Insert(index, item.ListViewItem);
        }

        public virtual void Remove(FileListItem item)
        {
            listView.Items.Remove(item.ListViewItem);
        }

        public virtual void RemoveSelectedItems()
        {
            IList items = listView.SelectedItems;
            foreach (ListViewItem item in items)
            {
                this.TouchContents(this, EventArgs.Empty);
                item.Remove();
            }
        }

		private void RemoveItems(IList items)
		{
			foreach (ListViewItem item in items)
			{
				this.TouchContents(this, EventArgs.Empty);
				item.Remove();
			}
		}

        public virtual void Clear()
        {
			RemoveItems(listView.Items);
        }

        private void listView_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(System.Windows.Forms.DataFormats.FileDrop)) 
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void listView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            object o = e.Data.GetData(System.Windows.Forms.DataFormats.FileDrop);
            if (o == null) 
            {
                //do nothing
            } 
            else 
            {
                AddFiles((String[])o);
            }
        }

		private void listView_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			if (this.listView.Columns.Count <= e.Column)
				return;
			if (this.sortColumn != e.Column)
			{
				this.ClearSortMode();
			}
			this.sortColumn = e.Column;
			this.isAssent = !this.isAssent;
			this.listView.ListViewItemSorter = new ListViewItemComparer(this, e.Column, this.isAssent);
			this.listView.ListViewItemSorter = null;
		}

		private class ListViewItemComparer : IComparer
		{
			private FileListBox box;
			private int column;
			private bool isAssent;
			public ListViewItemComparer(FileListBox box, int column, bool isAssent)
			{
				this.box = box;
				this.column = column;
				this.isAssent = isAssent;
			}
			public int Compare(object x, object y)
			{
				string p0 = ((ListViewItem)x).SubItems[column].Text;
				string p1 = ((ListViewItem)y).SubItems[column].Text;
				int b;
				if (column == box.HeaderPages.Index)
				{
					try
					{
						int a0 = System.Convert.ToInt32(p0);
						int a1 = System.Convert.ToInt32(p1);
						b = a0 - a1;
					}
					catch (Exception)
					{
						b = 0;
					}
				}
				else
				{
					b = String.Compare(p0, p1);
				}
				if (!isAssent)
					b = -b;
				return b;
			}
		}

        public virtual ColumnHeader HeaderFileName
        {
            get
            {
                return this.headerFileName;
            }
        }

        public virtual ColumnHeader HeaderPages
        {
            get
            {
                return this.headerPages;
            }
        }

        public virtual ColumnHeader HeaderDirectory
        {
            get
            {
                return this.headerDir;
            }
        }

        public virtual FileListItem FocusedItem
        {
            get
            {
                return FileListItem.Get(listView.FocusedItem);
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectedIndexChanged != null)
                SelectedIndexChanged(sender, e);
        }
	}
}
