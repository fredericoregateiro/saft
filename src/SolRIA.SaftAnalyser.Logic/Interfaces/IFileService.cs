namespace SolRIA.SaftAnalyser.Interfaces
{
	public interface IFileService
	{
		string ChooseFile(string folder);
		string ChooseFile(string folder, string filterName, string filter);
        string[] ReadFileLines(string fileName);
        string GetLocalFileName(string name);
        string GenerateRandonFileName(string extension = ".xlsx");
        void WriteToFile(string fileName, string content);

    }
}
