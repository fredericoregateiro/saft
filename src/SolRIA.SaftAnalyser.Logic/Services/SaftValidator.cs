using SolRia.Erp.MobileApp.Models.SaftV4;
using SolRIA.SaftAnalyser.Interfaces;
using System.Linq;

namespace SolRIA.SaftAnalyser.Services
{
    public class SaftValidator : ISaftValidator
	{
		public int GetSaftErrors()
		{
			return OpenedFileInstance.Instance.MensagensErro.Count();
		}

		public int GetSaftHeaderErrors()
		{
			return OpenedFileInstance.Instance.MensagensErro.Where(c => c.TypeofError == typeof(Header)).Count();
		}

		public int GetSaftCustomersErrors()
		{
			return OpenedFileInstance.Instance.MensagensErro.Where(c => c.TypeofError == typeof(Customer)).Count();
		}

        public int GetSaftHashValidationNumber()
        {
            return OpenedFileInstance.Instance.SaftHashValidationNumber;
        }

        public int GetSaftHashValidationErrorNumber()
        {
            return OpenedFileInstance.Instance.SaftHashValidationErrorNumber;
        }
    }
}
