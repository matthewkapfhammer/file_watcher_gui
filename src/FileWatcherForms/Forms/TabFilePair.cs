#region File Header
// /////////////////////////////////////////////////////////////
// File: TabFilePair.cs	Class: Kennedy.FileWatcher.Forms.TabFilePair
// Date: 3/30/2004		Author: Michael Kennedy
// Language: C#			Framework: .NET
//
// Copyright: Copyright (c) Michael Kennedy, 2004
// /////////////////////////////////////////////////////////////
// License: See License.txt file included with application.
// /////////////////////////////////////////////////////////////
#endregion

using System;

using Crownwood.Magic.Controls;
using Kennedy.FileWatcher.Controls;

namespace Kennedy.FileWatcher.Forms
{
	public class TabFilePair
	{
		private TabPage pageControl = null;
		private FileControl fileControl = null;

		public TabFilePair(TabPage pageControl, FileControl fileControl)
		{
			this.pageControl = pageControl;
			this.fileControl = fileControl;
		}

		public FileControl FileControl
		{
			get
			{
				return fileControl;
			}
		}

		public TabPage PageControl
		{
			get
			{
				return pageControl;
			}
		}
	}
}
