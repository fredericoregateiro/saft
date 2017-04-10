using NLog;
using SolRIA.SaftAnalyser.Interfaces;
using System;

namespace SolRIA.SaftAnalyser.Services
{
	public class LogService : ILogService
	{
		Logger logger;
		public LogService(Logger logger)
		{
			this.logger = logger;
		}

		public void LogException(Exception ex)
		{
			logger.Error<Exception>(ex);

			Exception innerEx = ex.InnerException;
			while (innerEx != null)
			{
				logger.Error<Exception>(innerEx);

				innerEx = innerEx.InnerException;
			}
		}

		public void LogInfo(string message)
		{
			logger.Info(message);
		}
	}
}
