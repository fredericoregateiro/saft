using SolRIA.SaftAnalyser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolRIA.SaftAnalyser.Services
{
	public class DataRepository : IDataRepository
	{
		ILogService log;
		public DataRepository(ILogService log)
		{
			this.log = log;
		}
	}
}
