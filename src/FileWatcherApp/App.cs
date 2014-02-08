#region File Header
// /////////////////////////////////////////////////////////////
// File: App.cs		Class: Kennedy.FileWatcher.App.FileWatcherApplication
// Date: 3/30/2004	Author: Michael Kennedy
// Language: C#		Framework: .NET
//
// Copyright: Copyright (c) Michael Kennedy, 2004
// /////////////////////////////////////////////////////////////
// License: See License.txt file included with application.
// /////////////////////////////////////////////////////////////
#endregion

using System;
using System.Windows.Forms;

using Kennedy.FileWatcher.Forms;

namespace Kennedy.FileWatcher.App
{
	public class FileWatcherApplication
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.EnableVisualStyles();
			Application.DoEvents();

			Application.Run(new MainForm());
		}
	}
}
