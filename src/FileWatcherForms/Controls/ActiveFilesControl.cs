#region File Header
// /////////////////////////////////////////////////////////////
// File: ActiveFilesControl.cs	Class: Kennedy.FileWatcher.Controls.ActiveFilesControl
// Date: 3/30/2004				Author: Michael Kennedy
// Language: C#					Framework: .NET
//
// Copyright: Copyright (c) Michael Kennedy, 2004
// /////////////////////////////////////////////////////////////
// License: See License.txt file included with application.
// /////////////////////////////////////////////////////////////
#endregion

using System;
using System.IO;
using System.Collections;
using System.Windows.Forms;

namespace Kennedy.FileWatcher.Controls
{
	public class ActiveFilesControl : System.Windows.Forms.UserControl
	{
		#region private class ListViewSorter
		
		private class ListViewSorter : IComparer
		{
			#region IComparer Members

			public int Compare(object x, object y)
			{
				bool canCompare = x is ListViewItem && y is ListViewItem;
				if (!canCompare)
				{
					return 0;
				}

				ListViewItem leftItem = (ListViewItem)x;
				ListViewItem rightItem = (ListViewItem)y;

				string leftModified = leftItem.SubItems[1].Text;
				string rightModified = rightItem.SubItems[1].Text;

				DateTime leftTime = Convert.ToDateTime(leftModified);
				DateTime rightTime = Convert.ToDateTime(rightModified);

				// TODO: Convert to date times and then sort.
				
				return rightTime.CompareTo(leftTime);
			}

			#endregion
		}

		#endregion

		#region Member Variables

		public event FileActionHandler FileSelected;
		public event EventHandler FileLoadRequest;

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView listViewActiveFiles;
		private System.Windows.Forms.ColumnHeader columnHeaderFile;
		private System.Windows.Forms.ColumnHeader columnHeaderModified;
		private System.Windows.Forms.ColumnHeader columnHeaderSize;
		private System.Windows.Forms.ColumnHeader columnHeaderPath;
		private System.Windows.Forms.Button buttonLoadFile;
		private System.ComponentModel.Container components = null;

		#endregion

		#region Construction and Cleanup

		public ActiveFilesControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// Add any initialization after the InitializeComponent call
			listViewActiveFiles.ListViewItemSorter = new ListViewSorter();
		}

		/// <summary> 
		/// Clean up any resources being used.
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

		#endregion

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.listViewActiveFiles = new System.Windows.Forms.ListView();
			this.columnHeaderFile = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderModified = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderSize = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderPath = new System.Windows.Forms.ColumnHeader();
			this.buttonLoadFile = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(4, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(184, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "Files Currently Being Monitored";
			// 
			// listViewActiveFiles
			// 
			this.listViewActiveFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listViewActiveFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								  this.columnHeaderFile,
																								  this.columnHeaderModified,
																								  this.columnHeaderSize,
																								  this.columnHeaderPath});
			this.listViewActiveFiles.FullRowSelect = true;
			this.listViewActiveFiles.GridLines = true;
			this.listViewActiveFiles.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewActiveFiles.Location = new System.Drawing.Point(4, 28);
			this.listViewActiveFiles.Name = "listViewActiveFiles";
			this.listViewActiveFiles.Size = new System.Drawing.Size(232, 164);
			this.listViewActiveFiles.TabIndex = 1;
			this.listViewActiveFiles.View = System.Windows.Forms.View.Details;
			this.listViewActiveFiles.ItemActivate += new System.EventHandler(this.listViewActiveFiles_ItemActivate);
			// 
			// columnHeaderFile
			// 
			this.columnHeaderFile.Text = "File";
			this.columnHeaderFile.Width = 200;
			// 
			// columnHeaderModified
			// 
			this.columnHeaderModified.Text = "Modified";
			this.columnHeaderModified.Width = 125;
			// 
			// columnHeaderSize
			// 
			this.columnHeaderSize.Text = "Size";
			this.columnHeaderSize.Width = 100;
			// 
			// columnHeaderPath
			// 
			this.columnHeaderPath.Text = "Path";
			this.columnHeaderPath.Width = 250;
			// 
			// buttonLoadFile
			// 
			this.buttonLoadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonLoadFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonLoadFile.Location = new System.Drawing.Point(196, 4);
			this.buttonLoadFile.Name = "buttonLoadFile";
			this.buttonLoadFile.Size = new System.Drawing.Size(40, 20);
			this.buttonLoadFile.TabIndex = 5;
			this.buttonLoadFile.Text = "...";
			this.buttonLoadFile.Click += new System.EventHandler(this.buttonLoadFile_Click);
			// 
			// ActiveFilesControl
			// 
			this.Controls.Add(this.buttonLoadFile);
			this.Controls.Add(this.listViewActiveFiles);
			this.Controls.Add(this.label1);
			this.Name = "ActiveFilesControl";
			this.Size = new System.Drawing.Size(240, 196);
			this.ResumeLayout(false);

		}
		#endregion
	
		#region User Control Event Handlers
		
		private void listViewActiveFiles_ItemActivate(object sender, System.EventArgs e)
		{
			int index = listViewActiveFiles.SelectedIndices[0];
			if (index < 0)
			{
				return;
			}

			ListViewItem item = listViewActiveFiles.SelectedItems[0];

			string file = Path.Combine(item.SubItems[3].Text, item.SubItems[0].Text);
			Fire_FileSelected(file);
		}

		private void buttonLoadFile_Click(object sender, System.EventArgs e)
		{
			if (FileLoadRequest == null)
			{
				return;
			}

			FileLoadRequest(this, e);
		}

		#endregion

		#region File Management Code

		public void AddFile(string file)
		{
			if (FileIsLoaded(file))
			{
				return;
			}

			FileInfo fi = new FileInfo(file);
			if (!fi.Exists)
			{
				throw new FileNotFoundException("The file does not exist.", file);
			}

			string size = (fi.Length/1024.0).ToString("N2") + " KB";
			string path = Path.GetDirectoryName(file);
			string name = Path.GetFileName(file);
			string modified = fi.LastWriteTime.ToShortDateString() + " " + fi.LastWriteTime.ToShortTimeString();

			string[] itemValues = {name, modified, size, path};
			ListViewItem item = new ListViewItem(itemValues);
			listViewActiveFiles.Items.Insert(0, item);

			listViewActiveFiles.Sort();
		}

		public void RemoveFile(string file)
		{
			string path = Path.GetDirectoryName(file).ToLower();
			string name = Path.GetFileName(file).ToLower();

			foreach (ListViewItem item in listViewActiveFiles.Items)
			{
				if (item.SubItems[0].Text.ToLower() == name &&
					item.SubItems[3].Text.ToLower() == path)
				{
					listViewActiveFiles.Items.Remove(item);
					return;
				}
			}
		}

		public bool FileIsLoaded(string file)
		{
			string path = Path.GetDirectoryName(file).ToLower();
			string name = Path.GetFileName(file).ToLower();

			foreach (ListViewItem item in listViewActiveFiles.Items)
			{
				if (item.SubItems[0].Text.ToLower() == name &&
					item.SubItems[3].Text.ToLower() == path)
				{
					return true;
				}
			}

			return false;
		}

		public void UpdateFileInfo(string file)
		{
			if (!FileIsLoaded(file))
			{
				throw new Exception("The file " + file + " is not loaded.");
			}

			FileInfo fi = new FileInfo(file);
			if (!fi.Exists)
			{
				throw new FileNotFoundException("The file does not exist.", file);
			}

			string size = (fi.Length/1024.0).ToString("N2") + " KB";
			string modified = fi.LastWriteTime.ToShortDateString() + " " + fi.LastWriteTime.ToShortTimeString();

			string path = Path.GetDirectoryName(file).ToLower();
			string name = Path.GetFileName(file).ToLower();

			foreach (ListViewItem item in listViewActiveFiles.Items)
			{
				if (item.SubItems[0].Text.ToLower() == name &&
					item.SubItems[3].Text.ToLower() == path)
				{
					item.SubItems[1].Text = modified;
					item.SubItems[2].Text = size;
				}
			}

			listViewActiveFiles.Sort();
		}

		#endregion

		#region Custom Event Firing Code

		private void Fire_FileSelected(string file)
		{
			if (FileSelected != null)
			{
				FileSelected(file);
			}
		}

		#endregion
	}
}
