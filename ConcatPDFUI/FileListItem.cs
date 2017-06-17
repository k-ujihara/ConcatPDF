/*
     Copyright 2003, 2004, 2012 by Kazuya Ujihara.
 
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
using System.Collections.Generic;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.IO;

namespace Ujihara.ConcatPDF
{
    public class FileListItem : IDisposable
    {
        private const int ITEM_INDEX_FILENAME = 0;
        private const int ITEM_INDEX_NUMBER_OF_PAGES = 1;
        private const int ITEM_INDEX_DIRECTORY_NAME = 2;

        internal static FileListItem Create(string path)
        {
            string fullPath = Path.GetFullPath(path);

            ListViewItem item = new ListViewItem(Path.GetFileName(fullPath));
            item.SubItems.Add(string.Empty); // number of pages
            item.SubItems.Add(Path.GetDirectoryName(fullPath)); // directory name

            var fileListItem = new FileListItem(item);

            return fileListItem;
        }

        /// <summary>
        /// Get or set of the number of pages.
        /// -1 means the number of pages is unknown.
        /// </summary>
        public int NumberOfPages
        {
            get
            {
                var str = this.ListViewItem.SubItems[ITEM_INDEX_NUMBER_OF_PAGES].Text;
                if (str == null || str == string.Empty)
                    return -1;

                try
                {
                    return int.Parse(str);
                }
                catch (FormatException)
                {
                    return -1; // unknown
                }
            }

            internal set
            {
                this.ListViewItem.SubItems[ITEM_INDEX_NUMBER_OF_PAGES].Text = value.ToString();
            }
        }

        internal static FileListItem Get(ListViewItem listViewItem)
        {
            if (listViewItem == null)
                return null;
            if (listViewItem.Tag == null)
            {
                Trace.Assert(false, "FileListItem.Get(ListViewItem)");
                listViewItem.Tag = new FileListItem(listViewItem);
            }
            return (FileListItem)listViewItem.Tag;
        }

        internal ListViewItem ListViewItem
        {
            get;
            private set;
        }

        private FileListItem(ListViewItem listViewItem)
        {
            this.ListViewItem = listViewItem;
            listViewItem.Tag = this;
        }

        public string FullPath
        {
            get
            {
                return System.IO.Path.Combine(
                    this.ListViewItem.SubItems[ITEM_INDEX_DIRECTORY_NAME].Text, 
                    this.ListViewItem.SubItems[ITEM_INDEX_FILENAME].Text);
            }
        }

        public int Index
        {
            get
            {
                return this.ListViewItem.Index;
            }
        }

        public byte[] Password
        {
            get;
            set;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
