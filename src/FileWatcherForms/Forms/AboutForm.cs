#region File Header
// /////////////////////////////////////////////////////////////
// File: AboutForm.cs	Class: Kennedy.FileWatcher.Forms.AboutForm
// Date: 3/30/2004		Author: Michael Kennedy
// Language: C#			Framework: .NET
//
// Copyright: Copyright (c) Michael Kennedy, 2004
// /////////////////////////////////////////////////////////////
// License: See License.txt file included with application.
// /////////////////////////////////////////////////////////////
#endregion

using System;
using System.Diagnostics;
using System.IO;

namespace Kennedy.FileWatcher.Forms
{
	public class AboutForm : System.Windows.Forms.Form
	{
		#region Member Variables

		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Label labelOwner;
		private System.Windows.Forms.Label labelDescription;
		private System.Windows.Forms.Label labelDesc2;
		private System.Windows.Forms.LinkLabel linkLabelUB;
		private System.Windows.Forms.LinkLabel linkLabelEmail;
		private System.Windows.Forms.Label labelCopyright;
		private System.ComponentModel.Container components = null;

		#endregion

		#region Construction and Cleanup

		public AboutForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// Add any constructor code after InitializeComponent call
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.labelTitle = new System.Windows.Forms.Label();
			this.labelOwner = new System.Windows.Forms.Label();
			this.buttonOK = new System.Windows.Forms.Button();
			this.labelDescription = new System.Windows.Forms.Label();
			this.labelDesc2 = new System.Windows.Forms.Label();
			this.linkLabelUB = new System.Windows.Forms.LinkLabel();
			this.linkLabelEmail = new System.Windows.Forms.LinkLabel();
			this.labelCopyright = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// labelTitle
			// 
			this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.labelTitle.Location = new System.Drawing.Point(4, 12);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(318, 32);
			this.labelTitle.TabIndex = 0;
			this.labelTitle.Text = "File Contents Watcher";
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// labelOwner
			// 
			this.labelOwner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.labelOwner.Location = new System.Drawing.Point(4, 48);
			this.labelOwner.Name = "labelOwner";
			this.labelOwner.Size = new System.Drawing.Size(314, 16);
			this.labelOwner.TabIndex = 1;
			this.labelOwner.Text = "by Michael Kennedy";
			this.labelOwner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonOK
			// 
			this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.buttonOK.Location = new System.Drawing.Point(124, 208);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.TabIndex = 2;
			this.buttonOK.Text = "&OK";
			// 
			// labelDescription
			// 
			this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.labelDescription.Location = new System.Drawing.Point(8, 96);
			this.labelDescription.Name = "labelDescription";
			this.labelDescription.Size = new System.Drawing.Size(304, 40);
			this.labelDescription.TabIndex = 3;
			this.labelDescription.Text = "This application allows you to monitor multiple text files for changes. It is ide" +
				"al for monitoring log files from applications or websites.";
			// 
			// labelDesc2
			// 
			this.labelDesc2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.labelDesc2.Location = new System.Drawing.Point(8, 144);
			this.labelDesc2.Name = "labelDesc2";
			this.labelDesc2.Size = new System.Drawing.Size(304, 32);
			this.labelDesc2.TabIndex = 4;
			this.labelDesc2.Text = "For more .NET programs and goodies, visit Michael\'s company\'s website:";
			// 
			// linkLabelUB
			// 
			this.linkLabelUB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabelUB.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkLabelUB.Location = new System.Drawing.Point(8, 180);
			this.linkLabelUB.Name = "linkLabelUB";
			this.linkLabelUB.Size = new System.Drawing.Size(304, 16);
			this.linkLabelUB.TabIndex = 5;
			this.linkLabelUB.TabStop = true;
			this.linkLabelUB.Text = "http://www.unitedbinary.com";
			this.linkLabelUB.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.linkLabelUB.VisitedLinkColor = System.Drawing.Color.Blue;
			this.linkLabelUB.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelUB_LinkClicked);
			// 
			// linkLabelEmail
			// 
			this.linkLabelEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.linkLabelEmail.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.linkLabelEmail.Location = new System.Drawing.Point(9, 64);
			this.linkLabelEmail.Name = "linkLabelEmail";
			this.linkLabelEmail.Size = new System.Drawing.Size(304, 16);
			this.linkLabelEmail.TabIndex = 6;
			this.linkLabelEmail.TabStop = true;
			this.linkLabelEmail.Text = "mkennedy@unitedbinary.com";
			this.linkLabelEmail.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.linkLabelEmail.VisitedLinkColor = System.Drawing.Color.Blue;
			this.linkLabelEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelEmail_LinkClicked);
			// 
			// labelCopyright
			// 
			this.labelCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.labelCopyright.Location = new System.Drawing.Point(9, 240);
			this.labelCopyright.Name = "labelCopyright";
			this.labelCopyright.Size = new System.Drawing.Size(304, 16);
			this.labelCopyright.TabIndex = 7;
			this.labelCopyright.Text = "Copyright (C) 2004 Michael Kennedy";
			this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// AboutForm
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.buttonOK;
			this.ClientSize = new System.Drawing.Size(322, 260);
			this.Controls.Add(this.labelCopyright);
			this.Controls.Add(this.linkLabelEmail);
			this.Controls.Add(this.linkLabelUB);
			this.Controls.Add(this.labelDesc2);
			this.Controls.Add(this.labelDescription);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.labelOwner);
			this.Controls.Add(this.labelTitle);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "File Contents Watcher - [About]";
			this.ResumeLayout(false);

		}
		#endregion

		#region Link Event Management

		private void linkLabelUB_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			LaunchUrl(linkLabelUB.Text);
		}

		private void linkLabelEmail_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			LaunchUrl("mailto:" + linkLabelEmail.Text);
		}

		private void LaunchUrl(string address)
		{
			string path = Environment.GetFolderPath(System.Environment.SpecialFolder.System);
			string app = Path.Combine(path, "rundll32.exe");
			string arguments = "url.dll,FileProtocolHandler \"" + address + "\"";
			
			ProcessStartInfo startInfo = new ProcessStartInfo(app, arguments);
			Process.Start(startInfo);
		}

		#endregion

	}
}
