using SolRIA.SaftAnalyser.Interfaces;
using System.IO;

namespace SolRIA.SaftAnalyser.Services
{
	public class FileService : IFileService
	{
		public string ChooseFile(string folder)
		{
			return ChooseFile(folder, null, null);
		}

		public string ChooseFile(string folder, string filterName, string filter)
		{
			System.Windows.Forms.OpenFileDialog folderBrowser = new System.Windows.Forms.OpenFileDialog();
			folderBrowser.CheckFileExists = true;
			if (string.IsNullOrEmpty(filter) == false)
				folderBrowser.Filter = filter;

			if (string.IsNullOrWhiteSpace(folder) == false && Directory.Exists(folder))
				folderBrowser.InitialDirectory = folder;

			if (folderBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				return folderBrowser.FileName;

			return string.Empty;
		}
	}
}
