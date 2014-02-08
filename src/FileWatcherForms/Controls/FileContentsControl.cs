#region File Header
// /////////////////////////////////////////////////////////////
// File: FileContentsControl.cs	Class: Kennedy.FileWatcher.Controls.FileContentsControl
// Date: 3/30/2004				Author: Michael Kennedy
// Language: C#					Framework: .NET
//
// Copyright: Copyright (c) Michael Kennedy, 2004
// /////////////////////////////////////////////////////////////
// License: See License.txt file included with application.
// /////////////////////////////////////////////////////////////
#endregion

using System;

namespace Kennedy.FileWatcher.Controls
{
	public class FileContentsControl : System.Windows.Forms.UserControl
	{
		#region Member Variables

		private System.Windows.Forms.GroupBox groupBoxContainer;
		private System.Windows.Forms.TextBox textBoxContents;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Timer timerUIUpdate;
		private bool replaceTabs = true;
		private bool needsScroll = true;

		#endregion

		#region Construction and Cleanup

		public FileContentsControl()
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
			this.components = new System.ComponentModel.Container();
			this.groupBoxContainer = new System.Windows.Forms.GroupBox();
			this.textBoxContents = new System.Windows.Forms.TextBox();
			this.timerUIUpdate = new System.Windows.Forms.Timer(this.components);
			this.groupBoxContainer.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxContainer
			// 
			this.groupBoxContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxContainer.Controls.Add(this.textBoxContents);
			this.groupBoxContainer.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.groupBoxContainer.Location = new System.Drawing.Point(4, 4);
			this.groupBoxContainer.Name = "groupBoxContainer";
			this.groupBoxContainer.Size = new System.Drawing.Size(168, 112);
			this.groupBoxContainer.TabIndex = 0;
			this.groupBoxContainer.TabStop = false;
			this.groupBoxContainer.Text = "File Contents";
			// 
			// textBoxContents
			// 
			this.textBoxContents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxContents.BackColor = System.Drawing.Color.White;
			this.textBoxContents.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.textBoxContents.ForeColor = System.Drawing.Color.Black;
			this.textBoxContents.HideSelection = false;
			this.textBoxContents.Location = new System.Drawing.Point(8, 20);
			this.textBoxContents.MaxLength = 250000;
			this.textBoxContents.Multiline = true;
			this.textBoxContents.Name = "textBoxContents";
			this.textBoxContents.ReadOnly = true;
			this.textBoxContents.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxContents.Size = new System.Drawing.Size(156, 88);
			this.textBoxContents.TabIndex = 0;
			this.textBoxContents.Text = "";
			this.textBoxContents.WordWrap = false;
			// 
			// timerUIUpdate
			// 
			this.timerUIUpdate.Enabled = true;
			this.timerUIUpdate.Tick += new System.EventHandler(this.timerUIUpdate_Tick);
			// 
			// FileContentsControl
			// 
			this.Controls.Add(this.groupBoxContainer);
			this.Name = "FileContentsControl";
			this.Size = new System.Drawing.Size(176, 120);
			this.groupBoxContainer.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region File Management Code

		public void UpdateFileInfo(string file)
		{
			System.IO.StreamReader sr = null;
			System.IO.FileStream fs = null;
			try
			{	
				fs = new System.IO.FileStream(file, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite);
				sr = new System.IO.StreamReader(fs);
                string contents = sr.ReadToEnd();
				if (replaceTabs)
				{
					contents = contents.Replace("\t", "    ");
				}

				int indexOfFullLineFeeds = contents.IndexOf("\r\n");
				int indexOfPartialLineFeeds = contents.IndexOf("\n");
				bool test1 = indexOfFullLineFeeds < 0 && indexOfPartialLineFeeds >= 0;
				bool test2 = indexOfFullLineFeeds > indexOfPartialLineFeeds && indexOfPartialLineFeeds >= 0;
				if (test1 || test2)
				{
					contents = contents.Replace("\n", "\r\n");
				}

				if (contents.Length >= textBoxContents.MaxLength)
				{
					int startIndex = contents.Length - textBoxContents.MaxLength;
					contents = contents.Substring(startIndex, textBoxContents.MaxLength);
				}

				textBoxContents.Text = contents;

				needsScroll = true;
			}
			catch (Exception x)
			{
				throw new Exception("Error reading file", x);
			}
			finally
			{
				if (sr != null)
				{
					sr.Close();
				}

				if (fs != null)
				{
					fs.Close();
				}
			}
		}

		public bool ReplaceTabs
		{
			get
			{
				return replaceTabs;
			}
			set
			{
				replaceTabs = value;
			}
		}

		private void timerUIUpdate_Tick(object sender, System.EventArgs e)
		{
			if (needsScroll)
			{
				needsScroll = false;
				textBoxContents.Select(textBoxContents.Text.Length, 0);
				textBoxContents.ScrollToCaret();
			}
		}

		#endregion

		#region Properties

		public bool WordWrapContents
		{
			get
			{
				return textBoxContents.WordWrap;
			}
			set
			{
				textBoxContents.WordWrap = value;
			}
		}

		#endregion

	}
}
