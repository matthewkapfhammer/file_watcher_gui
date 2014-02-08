#region File Header
// /////////////////////////////////////////////////////////////
// File: FileControl.cs	Class: Kennedy.FileWatcher.Controls.FileControl
// Date: 3/30/2004				Author: Michael Kennedy
// Language: C#					Framework: .NET
//
// Copyright: Copyright (c) Michael Kennedy, 2004
// /////////////////////////////////////////////////////////////
// License: See License.txt file included with application.
// /////////////////////////////////////////////////////////////
#endregion

using System;
using System.Runtime.CompilerServices;

namespace Kennedy.FileWatcher.Controls
{
	public delegate void FileActionHandler(string filename);

	public class FileControl : System.Windows.Forms.UserControl
	{	
		#region Member Variables and Events

		public event FileActionHandler FileChanged;

		private Kennedy.FileWatcher.Controls.FileContentsControl fileContentsControl;
		private Kennedy.FileWatcher.Controls.FileStatisticsControl fileStatisticsControl;
		private System.Windows.Forms.Label labelFileName;
		private System.IO.FileSystemWatcher fileSystemWatcher;
		private System.Windows.Forms.Label labelFileTitle;
		private System.ComponentModel.IContainer components = null;
		private string filename = string.Empty;
		
		#endregion

		#region Construction and Cleanup

		public FileControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// Add any initialization after the InitializeComponent call
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
			this.fileContentsControl = new Kennedy.FileWatcher.Controls.FileContentsControl();
			this.fileStatisticsControl = new Kennedy.FileWatcher.Controls.FileStatisticsControl();
			this.labelFileTitle = new System.Windows.Forms.Label();
			this.labelFileName = new System.Windows.Forms.Label();
			this.fileSystemWatcher = new System.IO.FileSystemWatcher();
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).BeginInit();
			this.SuspendLayout();
			// 
			// fileContentsControl
			// 
			this.fileContentsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.fileContentsControl.Location = new System.Drawing.Point(0, 60);
			this.fileContentsControl.Name = "fileContentsControl";
			this.fileContentsControl.Size = new System.Drawing.Size(216, 208);
			this.fileContentsControl.TabIndex = 0;
			// 
			// fileStatisticsControl
			// 
			this.fileStatisticsControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.fileStatisticsControl.Location = new System.Drawing.Point(0, 20);
			this.fileStatisticsControl.Name = "fileStatisticsControl";
			this.fileStatisticsControl.Size = new System.Drawing.Size(216, 44);
			this.fileStatisticsControl.TabIndex = 1;
			// 
			// labelFileTitle
			// 
			this.labelFileTitle.ForeColor = System.Drawing.SystemColors.ControlText;
			this.labelFileTitle.Location = new System.Drawing.Point(8, 4);
			this.labelFileTitle.Name = "labelFileTitle";
			this.labelFileTitle.Size = new System.Drawing.Size(28, 16);
			this.labelFileTitle.TabIndex = 2;
			this.labelFileTitle.Text = "File:";
			// 
			// labelFileName
			// 
			this.labelFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.labelFileName.ForeColor = System.Drawing.SystemColors.ControlText;
			this.labelFileName.Location = new System.Drawing.Point(36, 4);
			this.labelFileName.Name = "labelFileName";
			this.labelFileName.Size = new System.Drawing.Size(176, 16);
			this.labelFileName.TabIndex = 3;
			this.labelFileName.Text = "C:\\Program Files\\App\\ThisFile.txt";
			// 
			// fileSystemWatcher
			// 
			this.fileSystemWatcher.EnableRaisingEvents = true;
			this.fileSystemWatcher.SynchronizingObject = this;
			this.fileSystemWatcher.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher_Changed);
			// 
			// FileControl
			// 
			this.Controls.Add(this.labelFileName);
			this.Controls.Add(this.labelFileTitle);
			this.Controls.Add(this.fileStatisticsControl);
			this.Controls.Add(this.fileContentsControl);
			this.Name = "FileControl";
			this.Size = new System.Drawing.Size(216, 268);
			((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region User Control Event Handlers

		[MethodImpl(MethodImplOptions.Synchronized)]
		private void fileSystemWatcher_Changed(object sender, System.IO.FileSystemEventArgs e)
		{
			//
			// Some programs don't share well. Give them a chance
			// to finish writing the file.
			//
			System.Threading.Thread.Sleep(250);

			fileStatisticsControl.UpdateFileInfo(filename);
			fileContentsControl.UpdateFileInfo(filename);
			
			Fire_FileChanged(filename);
		}

		#endregion

		#region File Management Code

		public void Initialize(string file)
		{
			filename = file;
			labelFileName.Text = file;
			fileSystemWatcher.Filter = System.IO.Path.GetFileName(file);
			fileSystemWatcher.Path = System.IO.Path.GetDirectoryName(file);

			fileContentsControl.UpdateFileInfo(file);
			fileStatisticsControl.UpdateFileInfo(file);
		}

		public string Filename
		{
			get
			{
				return filename;
			}
		}

		#endregion

		#region Custom Event Firing Code

		private void Fire_FileChanged(string file)
		{
			if (FileChanged != null)
			{
				FileChanged(file);
			}
		}

		#endregion

		#region Properties

		public bool WordWrapContents
		{
			get
			{
				return fileContentsControl.WordWrapContents;
			}
			set
			{
				fileContentsControl.WordWrapContents = value;
			}
		}

		#endregion

	}
}
