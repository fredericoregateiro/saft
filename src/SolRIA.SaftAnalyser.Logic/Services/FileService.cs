using SolRIA.SaftAnalyser.Interfaces;
using System;
using System.IO;
using System.Text;

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

        public string[] ReadFileLines(string fileName)
        {
            if (File.Exists(fileName))
                return File.ReadAllLines(fileName);
            else
                return null;
        }

        public string GetLocalFileName(string name)
        {
            return Path.Combine(Environment.CurrentDirectory, name);
        }

        public string GenerateRandonFileName(string extension = ".xlsx")
        {
            return Path.Combine(Path.GetTempPath(), Path.GetRandomFileName() + extension);
        }

        public void WriteToFile(string fileName, string content)
        {
            File.WriteAllText(fileName, content, Encoding.UTF8);
        }
    }
}
