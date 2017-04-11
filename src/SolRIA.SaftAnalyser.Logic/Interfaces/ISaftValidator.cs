using SolRia.Erp.MobileApp.Models.SaftV4;

namespace SolRIA.SaftAnalyser.Interfaces
{
	public interface ISaftValidator
	{
		void ValidateSaft(AuditFile file);
		void ValidateSaftHeader(Header header);
		void ValidateSaftProducts();
		void ValidateSaftCustomers();
		void ValidateSaftTaxes();
		void ValidateSaftInvoices();

		int GetSaftErrors();
		int GetSaftHeaderErrors();
	}
}
