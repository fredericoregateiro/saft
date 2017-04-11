namespace SolRIA.SaftAnalyser.Interfaces
{
	public interface IFileService
	{
		string ChooseFile(string folder);
		string ChooseFile(string folder, string filterName, string filter);
	}
}
