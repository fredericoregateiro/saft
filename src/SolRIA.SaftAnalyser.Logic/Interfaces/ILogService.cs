using System;

namespace SolRIA.SaftAnalyser.Interfaces
{
	public interface ILogService
	{
		void LogException(Exception ex);

		void LogInfo(string message);
	}
}
