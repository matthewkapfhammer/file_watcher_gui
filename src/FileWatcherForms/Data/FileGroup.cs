using System;
using System.Collections;
using System.IO;
using System.Xml;

namespace Kennedy.FileWatcher.Data
{
	public class FileGroup
	{
		private string file = string.Empty;
		private ArrayList filesList = new ArrayList();
		private bool modified = false;

		public FileGroup()
		{
		}

		public FileGroup(string file)
		{
			Load(file);
		}

		#region File Saving and Loading Code

		public void Load(string file)
		{
			XmlDocument doc = new XmlDocument();

			using (StreamReader sr = new StreamReader(file))
			{
				doc.Load(sr);
			}

			XmlNode filesNode = doc.SelectSingleNode("files");
			if (filesNode == null)
			{
				throw new Exception("Error in file format. \"files\" node could not be located.");
			}

			XmlNodeList nodes = filesNode.SelectNodes("file");
			string[] files = new string [nodes.Count];
			for (int i=0; i < nodes.Count; i++)
			{
				XmlNode fileNode = nodes[i];
				files[i] = fileNode.Attributes["name"].Value;
			}

			//
			// We loaded the file OK, so clear out the member variables
			// and copy the new values over.
			//
			Clear();
			this.file = file;
			filesList.AddRange(files);
		}

		public void Save(string file)
		{
			//
			// We could use XmlDocument and XmlNode as we did in the load method here,
			// but this Xml is so simple it's just as easy to use a StreamWriter.
			//
			using (StreamWriter sw = new StreamWriter(file, false, System.Text.Encoding.UTF8))
			{
				sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
				sw.WriteLine("<files>");

				foreach (string monitoredFile in filesList)
				{
					sw.WriteLine("   <file name=\"" + monitoredFile + "\" />");
				}

				sw.WriteLine("</files>");
				sw.Flush();
			}

			modified = false;
		}

		#endregion

		#region Collection Related Code

		public void Add(string file)
		{
			filesList.Add(file);
			modified = true;
		}

		public void Clear()
		{
			file = string.Empty;
			filesList.Clear();
			modified = false;
		}

		public void Remove(string file)
		{
			file = file.ToLower();
			foreach (string monitoredFile in filesList)
			{
				if (monitoredFile.ToLower() == file)
				{
					filesList.Remove(monitoredFile);
					modified = true;
					break;
				}
			}
		}

		public string this[int index]
		{
			get
			{
				return (string)filesList[index];
			}
		}

		public int Count
		{
			get
			{
				return filesList.Count;
			}
		}

		public bool Modified
		{
			get
			{
				return modified;
			}
		}
		
		public string File
		{
			get
			{
				return file;
			}
		}

		#endregion
	}
}
