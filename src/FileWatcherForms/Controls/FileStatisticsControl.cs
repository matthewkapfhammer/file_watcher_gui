#region File Header
// /////////////////////////////////////////////////////////////
// File: FileStatisticsControl.cs	Class: Kennedy.FileWatcher.Controls.FileStatisticsControl
// Date: 3/30/2004					Author: Michael Kennedy
// Language: C#						Framework: .NET
//
// Copyright: Copyright (c) Michael Kennedy, 2004
// /////////////////////////////////////////////////////////////
// License: See License.txt file included with application.
// /////////////////////////////////////////////////////////////
#endregion

using System;
using System.IO;

namespace Kennedy.FileWatcher.Controls
{
	public class FileStatisticsControl : System.Windows.Forms.UserControl
	{
		#region Member Variables

		private System.Windows.Forms.GroupBox groupBoxStats;
		private System.Windows.Forms.Label labelSize;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label labelModified;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label labelCreated;
		private System.ComponentModel.Container components = null;

		#endregion

		#region Construction and Cleanup

		public FileStatisticsControl()
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
			this.groupBoxStats = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.labelCreated = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.labelModified = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.labelSize = new System.Windows.Forms.Label();
			this.groupBoxStats.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxStats
			// 
			this.groupBoxStats.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxStats.Controls.Add(this.label5);
			this.groupBoxStats.Controls.Add(this.labelCreated);
			this.groupBoxStats.Controls.Add(this.label4);
			this.groupBoxStats.Controls.Add(this.labelModified);
			this.groupBoxStats.Controls.Add(this.label2);
			this.groupBoxStats.Controls.Add(this.labelSize);
			this.groupBoxStats.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBoxStats.Location = new System.Drawing.Point(4, 4);
			this.groupBoxStats.Name = "groupBoxStats";
			this.groupBoxStats.Size = new System.Drawing.Size(496, 36);
			this.groupBoxStats.TabIndex = 0;
			this.groupBoxStats.TabStop = false;
			this.groupBoxStats.Text = "File Statistics";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(316, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(51, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "Created:";
			// 
			// labelCreated
			// 
			this.labelCreated.Location = new System.Drawing.Point(372, 16);
			this.labelCreated.Name = "labelCreated";
			this.labelCreated.Size = new System.Drawing.Size(120, 16);
			this.labelCreated.TabIndex = 4;
			this.labelCreated.Text = "CREATED";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(136, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Modified:";
			// 
			// labelModified
			// 
			this.labelModified.Location = new System.Drawing.Point(192, 16);
			this.labelModified.Name = "labelModified";
			this.labelModified.Size = new System.Drawing.Size(120, 16);
			this.labelModified.TabIndex = 2;
			this.labelModified.Text = "MODIFIED";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "File Size:";
			// 
			// labelSize
			// 
			this.labelSize.Location = new System.Drawing.Point(64, 16);
			this.labelSize.Name = "labelSize";
			this.labelSize.Size = new System.Drawing.Size(72, 16);
			this.labelSize.TabIndex = 0;
			this.labelSize.Text = "SIZE";
			// 
			// FileStatisticsControl
			// 
			this.Controls.Add(this.groupBoxStats);
			this.Name = "FileStatisticsControl";
			this.Size = new System.Drawing.Size(504, 44);
			this.groupBoxStats.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region File Management Code

		public void UpdateFileInfo(string file)
		{
			FileInfo fi = new FileInfo(file);
			if (!fi.Exists)
			{
				throw new FileNotFoundException("The file does not exist.", file);
			}

			labelCreated.Text = fi.CreationTime.ToShortDateString() + " " + fi.CreationTime.ToShortTimeString();
			labelModified.Text = fi.LastWriteTime.ToShortDateString() + " " + fi.LastWriteTime.ToShortTimeString();
			labelSize.Text = (fi.Length/1024.0).ToString("N2") + " KB";
		}

		#endregion

	}
}
