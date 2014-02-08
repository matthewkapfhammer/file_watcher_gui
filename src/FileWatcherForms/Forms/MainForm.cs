#region File Header
// /////////////////////////////////////////////////////////////
// File: MainForm.cs	Class: Kennedy.FileWatcher.Forms.MainForm
// Date: 3/30/2004		Author: Michael Kennedy
// Language: C#			Framework: .NET
//
// Copyright: Copyright (c) Michael Kennedy, 2004
// /////////////////////////////////////////////////////////////
// License: See License.txt file included with application.
// /////////////////////////////////////////////////////////////
#endregion

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Kennedy.FileWatcher.Forms
{
	public class MainForm : System.Windows.Forms.Form
	{
		#region Member Variables

		private System.Windows.Forms.StatusBar statusBar;
		private Crownwood.Magic.Controls.TabControl tabControlMain;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemFile_Exit;
		private System.Windows.Forms.MenuItem menuItemHelp;
		private System.Windows.Forms.MenuItem menuItemHelp_About;
		private System.Windows.Forms.MenuItem menuItemFile_Load;
		private System.Windows.Forms.MenuItem menuItemFile_Sep1;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private Crownwood.Magic.Controls.TabPage tabPageActiveFiles;
		private Kennedy.FileWatcher.Controls.ActiveFilesControl activeFilesControl;
		private System.Windows.Forms.MenuItem menuItemFile_Close;
		private Kennedy.FileWatcher.Data.FileGroup fileGroup = new Kennedy.FileWatcher.Data.FileGroup();
		private System.Windows.Forms.MenuItem menuItemFile_LoadGroup;
		private System.Windows.Forms.MenuItem menuItemFile_SaveGroup;
		private System.Windows.Forms.MenuItem menuItemFile_Sep2;
		private System.Windows.Forms.MenuItem menuItemFile_SaveGroupAs;
		private System.Windows.Forms.SaveFileDialog saveFileDialogGroup;
		private System.Windows.Forms.OpenFileDialog openFileDialogGroup;
		private System.Windows.Forms.MenuItem menuItemView;
		private System.Windows.Forms.MenuItem menuItemWordWrap;

		private bool wordWrap = false;
		private ArrayList tabPageList = new ArrayList();

		#endregion

		#region Construction and Cleanup

		public MainForm()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.tabControlMain = new Crownwood.Magic.Controls.TabControl();
			this.tabPageActiveFiles = new Crownwood.Magic.Controls.TabPage();
			this.activeFilesControl = new Kennedy.FileWatcher.Controls.ActiveFilesControl();
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuItemFile = new System.Windows.Forms.MenuItem();
			this.menuItemFile_Load = new System.Windows.Forms.MenuItem();
			this.menuItemFile_Close = new System.Windows.Forms.MenuItem();
			this.menuItemFile_Sep1 = new System.Windows.Forms.MenuItem();
			this.menuItemFile_LoadGroup = new System.Windows.Forms.MenuItem();
			this.menuItemFile_SaveGroup = new System.Windows.Forms.MenuItem();
			this.menuItemFile_SaveGroupAs = new System.Windows.Forms.MenuItem();
			this.menuItemFile_Sep2 = new System.Windows.Forms.MenuItem();
			this.menuItemFile_Exit = new System.Windows.Forms.MenuItem();
			this.menuItemHelp = new System.Windows.Forms.MenuItem();
			this.menuItemHelp_About = new System.Windows.Forms.MenuItem();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialogGroup = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialogGroup = new System.Windows.Forms.OpenFileDialog();
			this.menuItemView = new System.Windows.Forms.MenuItem();
			this.menuItemWordWrap = new System.Windows.Forms.MenuItem();
			this.tabPageActiveFiles.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 527);
			this.statusBar.Name = "statusBar";
			this.statusBar.Size = new System.Drawing.Size(696, 22);
			this.statusBar.TabIndex = 0;
			// 
			// tabControlMain
			// 
			this.tabControlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlMain.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.ShowAlways;
			this.tabControlMain.HotTrack = true;
			this.tabControlMain.Location = new System.Drawing.Point(0, 0);
			this.tabControlMain.Name = "tabControlMain";
			this.tabControlMain.PositionTop = true;
			this.tabControlMain.SelectedIndex = 0;
			this.tabControlMain.SelectedTab = this.tabPageActiveFiles;
			this.tabControlMain.ShowArrows = true;
			this.tabControlMain.ShrinkPagesToFit = false;
			this.tabControlMain.Size = new System.Drawing.Size(696, 527);
			this.tabControlMain.TabIndex = 1;
			this.tabControlMain.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
																							 this.tabPageActiveFiles});
			this.tabControlMain.SelectionChanged += new System.EventHandler(this.tabControlMain_SelectionChanged);
			this.tabControlMain.ClosePressed += new System.EventHandler(this.tabControlMain_ClosePressed);
			// 
			// tabPageActiveFiles
			// 
			this.tabPageActiveFiles.Controls.Add(this.activeFilesControl);
			this.tabPageActiveFiles.Location = new System.Drawing.Point(0, 0);
			this.tabPageActiveFiles.Name = "tabPageActiveFiles";
			this.tabPageActiveFiles.Size = new System.Drawing.Size(696, 502);
			this.tabPageActiveFiles.TabIndex = 3;
			this.tabPageActiveFiles.Title = "All Files";
			// 
			// activeFilesControl
			// 
			this.activeFilesControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.activeFilesControl.Location = new System.Drawing.Point(0, 0);
			this.activeFilesControl.Name = "activeFilesControl";
			this.activeFilesControl.Size = new System.Drawing.Size(696, 502);
			this.activeFilesControl.TabIndex = 0;
			this.activeFilesControl.FileLoadRequest += new System.EventHandler(this.activeFilesControl_FileLoadRequest);
			this.activeFilesControl.FileSelected += new Kennedy.FileWatcher.Controls.FileActionHandler(this.activeFilesControl_FileSelected);
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuItemFile,
																					 this.menuItemView,
																					 this.menuItemHelp});
			// 
			// menuItemFile
			// 
			this.menuItemFile.Index = 0;
			this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItemFile_Load,
																						 this.menuItemFile_Close,
																						 this.menuItemFile_Sep1,
																						 this.menuItemFile_LoadGroup,
																						 this.menuItemFile_SaveGroup,
																						 this.menuItemFile_SaveGroupAs,
																						 this.menuItemFile_Sep2,
																						 this.menuItemFile_Exit});
			this.menuItemFile.Text = "&File";
			// 
			// menuItemFile_Load
			// 
			this.menuItemFile_Load.Index = 0;
			this.menuItemFile_Load.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.menuItemFile_Load.Text = "&Load File";
			this.menuItemFile_Load.Click += new System.EventHandler(this.menuItemFile_Load_Click);
			// 
			// menuItemFile_Close
			// 
			this.menuItemFile_Close.Enabled = false;
			this.menuItemFile_Close.Index = 1;
			this.menuItemFile_Close.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
			this.menuItemFile_Close.Text = "&Close File";
			this.menuItemFile_Close.Click += new System.EventHandler(this.menuItemFile_Close_Click);
			// 
			// menuItemFile_Sep1
			// 
			this.menuItemFile_Sep1.Index = 2;
			this.menuItemFile_Sep1.Text = "-";
			// 
			// menuItemFile_LoadGroup
			// 
			this.menuItemFile_LoadGroup.Index = 3;
			this.menuItemFile_LoadGroup.Text = "Load File &Group";
			this.menuItemFile_LoadGroup.Click += new System.EventHandler(this.menuItemFile_LoadGroup_Click);
			// 
			// menuItemFile_SaveGroup
			// 
			this.menuItemFile_SaveGroup.Index = 4;
			this.menuItemFile_SaveGroup.Text = "&Save File Group";
			this.menuItemFile_SaveGroup.Click += new System.EventHandler(this.menuItemFile_SaveGroup_Click);
			// 
			// menuItemFile_SaveGroupAs
			// 
			this.menuItemFile_SaveGroupAs.Index = 5;
			this.menuItemFile_SaveGroupAs.Text = "Save File Group &As ...";
			this.menuItemFile_SaveGroupAs.Click += new System.EventHandler(this.menuItemFile_SaveGroupAs_Click);
			// 
			// menuItemFile_Sep2
			// 
			this.menuItemFile_Sep2.Index = 6;
			this.menuItemFile_Sep2.Text = "-";
			// 
			// menuItemFile_Exit
			// 
			this.menuItemFile_Exit.Index = 7;
			this.menuItemFile_Exit.Text = "E&xit";
			this.menuItemFile_Exit.Click += new System.EventHandler(this.menuItemFile_Exit_Click);
			// 
			// menuItemHelp
			// 
			this.menuItemHelp.Index = 2;
			this.menuItemHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItemHelp_About});
			this.menuItemHelp.Text = "&Help";
			// 
			// menuItemHelp_About
			// 
			this.menuItemHelp_About.Index = 0;
			this.menuItemHelp_About.Text = "&About";
			this.menuItemHelp_About.Click += new System.EventHandler(this.menuItemHelp_About_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Log Files (*.log)|*.log|Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
			this.openFileDialog.Multiselect = true;
			this.openFileDialog.Title = "Open Text File";
			// 
			// saveFileDialogGroup
			// 
			this.saveFileDialogGroup.FileName = "File Watcher Group1.fwg";
			this.saveFileDialogGroup.Filter = "File Groups (*.fwg)|*.fwg|All Files (*.*)|*.*";
			this.saveFileDialogGroup.Title = "Save File Group";
			// 
			// openFileDialogGroup
			// 
			this.openFileDialogGroup.Filter = "File Groups (*.fwg)|*.fwg|All Files (*.*)|*.*";
			this.openFileDialogGroup.Title = "Load File Group";
			// 
			// menuItemView
			// 
			this.menuItemView.Index = 1;
			this.menuItemView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItemWordWrap});
			this.menuItemView.Text = "&View";
			this.menuItemView.Popup += new System.EventHandler(this.menuItemView_Popup);
			// 
			// menuItemWordWrap
			// 
			this.menuItemWordWrap.Index = 0;
			this.menuItemWordWrap.Text = "&Word Wrap";
			this.menuItemWordWrap.Click += new System.EventHandler(this.menuItemWordWrap_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(696, 549);
			this.Controls.Add(this.tabControlMain);
			this.Controls.Add(this.statusBar);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Menu = this.mainMenu;
			this.Name = "MainForm";
			this.Text = "File Contents Watcher";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
			this.tabPageActiveFiles.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region Windows Forms Event Handlers

		private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			bool confirmed = ConfirmExit();
			e.Cancel = !confirmed;
		}

		private void menuItemWordWrap_Click(object sender, System.EventArgs e)
		{
			SetWordWrap(!this.wordWrap);
		}

		private void menuItemView_Popup(object sender, System.EventArgs e)
		{
			menuItemWordWrap.Checked = this.wordWrap;
		}

		private void menuItemFile_Exit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void menuItemHelp_About_Click(object sender, System.EventArgs e)
		{
			new AboutForm().ShowDialog();
		}

		private void menuItemFile_Load_Click(object sender, System.EventArgs e)
		{
			LoadFile();
		}

		private void menuItemFile_Close_Click(object sender, System.EventArgs e)
		{
			ClosePage(tabControlMain.SelectedTab);
		}

		private void tabControlMain_ClosePressed(object sender, System.EventArgs e)
		{
			ClosePage(tabControlMain.SelectedTab);
		}

		private void tabControlMain_SelectionChanged(object sender, System.EventArgs e)
		{
			bool allowClose = tabControlMain.SelectedTab != tabPageActiveFiles;

			tabControlMain.ShowClose	= allowClose;
			menuItemFile_Close.Enabled	= allowClose;
		}

		private void menuItemFile_SaveGroupAs_Click(object sender, System.EventArgs e)
		{
			SaveGroup(true);
		}

		private void menuItemFile_LoadGroup_Click(object sender, System.EventArgs e)
		{
			LoadGroup();
		}

		private void menuItemFile_SaveGroup_Click(object sender, System.EventArgs e)
		{
			SaveGroup(false);
		}

		#endregion

		#region Custom User Controls Event Handlers
		
		private void fileControl_CloseRequest(object sender, EventArgs e)
		{
			ClosePage((Kennedy.FileWatcher.Controls.FileControl)sender);
		}

		private void fileControl_FileChanged(string filename)
		{
			activeFilesControl.UpdateFileInfo(filename);
		}

		private void activeFilesControl_FileSelected(string filename)
		{
			TabFilePair pair = GetFileControlPair(filename);
			if (pair == null)
			{
				return;
			}

			tabControlMain.SelectedTab = pair.PageControl;
		}

		private void activeFilesControl_FileLoadRequest(object sender, System.EventArgs e)
		{
			menuItemFile_Load_Click(sender, e);
		}

		#endregion

		#region File Operations and Related Code

		private void LoadFile()
		{
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}

			foreach(string file in openFileDialog.FileNames)
			{
				if (FileIsLoaded(file))
				{
					TabFilePair pair = GetFileControlPair(file);
					tabControlMain.SelectedTab = pair.PageControl;
				}
				else
				{
					AddFile(file);
				}
			}
		}

		private bool FileIsLoaded(string file)
		{
			string lowerCaseFile = file.ToLower();
			foreach (TabFilePair pair in tabPageList)
			{
				if (pair.FileControl.Filename.ToLower() == lowerCaseFile)
				{
					return true;
				}
			}

			return false;
		}

		private TabFilePair GetFileControlPair(string file)
		{
			string lowerCaseFile = file.ToLower();
			foreach (TabFilePair pair in tabPageList)
			{
				if (pair.FileControl.Filename.ToLower() == lowerCaseFile)
				{
					return pair;
				}
			}

			return null;
		}

		private void AddFile(string file)
		{
			string shortFile = System.IO.Path.GetFileName(file);
			if (shortFile.Length > 35)
			{
				shortFile = shortFile.Substring(0, 33) + "...";
			}

			Kennedy.FileWatcher.Controls.FileControl fileControl = null;
			Crownwood.Magic.Controls.TabPage pageControl = null;
			
			fileControl = new Kennedy.FileWatcher.Controls.FileControl();
			pageControl = new Crownwood.Magic.Controls.TabPage(shortFile);

			pageControl.Controls.Add(fileControl);
			fileControl.Dock = DockStyle.Fill;
			fileControl.WordWrapContents = this.wordWrap;

			TabFilePair pair = new TabFilePair(pageControl, fileControl);
			tabPageList.Add(pair);

			tabControlMain.TabPages.Add(pageControl);

			fileControl.FileChanged += new Kennedy.FileWatcher.Controls.FileActionHandler(fileControl_FileChanged);

			fileControl.Initialize(file);
			tabControlMain.SelectedTab = pair.PageControl;

			activeFilesControl.AddFile(file);
			fileGroup.Add(file);
		}

		private void ClosePage(Kennedy.FileWatcher.Controls.FileControl fileControl)
		{
			string lowerCaseFile = fileControl.Filename.ToLower();
			foreach (TabFilePair pair in tabPageList)
			{
				if (pair.FileControl.Filename.ToLower() == lowerCaseFile)
				{
					ClosePage(pair);
					return;
				}
			}
		}

		private void ClosePage(Crownwood.Magic.Controls.TabPage tabPageControl)
		{
			foreach (TabFilePair pair in tabPageList)
			{
				if (pair.PageControl == tabPageControl)
				{
					ClosePage(pair);
					return;
				}
			}
		}

		private void ClosePage(TabFilePair pair)
		{
			tabControlMain.TabPages.Remove(pair.PageControl);
			pair.PageControl.Dispose();
			tabPageList.Remove(pair);
			activeFilesControl.RemoveFile(pair.FileControl.Filename);
			fileGroup.Remove(pair.FileControl.Filename);
		}

		#endregion

		#region File Group Management Code

		private bool SaveGroup(bool queryFileName)
		{
			try
			{
				string file;
				if (fileGroup.File.Length == 0 || queryFileName)
				{
					if (saveFileDialogGroup.ShowDialog() != DialogResult.OK)
					{
						return false;
					}

					file = saveFileDialogGroup.FileName;
				}
				else
				{
					file = fileGroup.File;
				}

				fileGroup.Save(file);
			}
			catch (Exception x)
			{
				MessageBox.Show("Error saving file group: " + x.Message, "File Content Watcher", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			return true;
		}

		private void LoadGroup()
		{
			try
			{
				if (openFileDialogGroup.ShowDialog() != DialogResult.OK)
				{
					return;
				}

				Kennedy.FileWatcher.Data.FileGroup newfileGroup = 
					new Kennedy.FileWatcher.Data.FileGroup(openFileDialogGroup.FileName);

				TabFilePair[] pairs = new TabFilePair[tabPageList.Count];
				tabPageList.CopyTo(pairs);
				foreach (TabFilePair pair in pairs)
				{
					ClosePage(pair);
				}

				for (int i=0; i < newfileGroup.Count; i++)
				{
					AddFile(newfileGroup[i]);
				}
				this.fileGroup = newfileGroup;
			}
			catch (Exception x)
			{
				MessageBox.Show("Error loading file group: " + x.Message, "File Content Watcher", 
					MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		#region UI Event Handlers Helper Code

		private void SetWordWrap(bool wrap)
		{
			this.wordWrap = wrap;

			foreach (Crownwood.Magic.Controls.TabPage pageControl in tabControlMain.TabPages)
			{
				foreach (Control ctrl in pageControl.Controls)
				{
					if (ctrl is Kennedy.FileWatcher.Controls.FileControl)
					{
						Kennedy.FileWatcher.Controls.FileControl fileControl;
						fileControl = ctrl as Kennedy.FileWatcher.Controls.FileControl;

						fileControl.WordWrapContents = wrap;
					}
				}
			}
		}

		private bool ConfirmExit()
		{
			bool hasMultipleFiles = fileGroup.Count > 1;
			bool modified = fileGroup.Modified;
			bool exiting = Environment.HasShutdownStarted;

			if (!hasMultipleFiles || !modified || exiting)
			{
				return true;
			}

			string msg = "Do you want to save a file group for this group\n" + 
				"of files so that you can monitor them as a group more easily?";
			
			DialogResult dr = MessageBox.Show(msg, "File Content Monitor", 
				MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

			if (dr == DialogResult.Yes)
			{
				if (!SaveGroup(false))
				{
					return false;
				}
			}
			else if (dr == DialogResult.Cancel)
			{
				return false;
			}

			return true;
		}

		#endregion

	}
}
