namespace SolRIA.SaftAnalyser.Interfaces
{
	public interface ISaftValidator
	{
		int GetSaftErrors();
		int GetSaftHeaderErrors();
		int GetSaftCustomersErrors();
        int GetSaftHashValidationNumber();
        int GetSaftHashValidationErrorNumber();
    }
}
