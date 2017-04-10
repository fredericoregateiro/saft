using SolRia.Erp.MobileApp.Models.SaftV4;
using System.Threading.Tasks;

namespace SolRIA.SaftAnalyser
{
	public class OpenedFileInstance
	{
		public static AuditFile SaftFile { get; set; }

		public static async Task OpenSaftFile(string filename)
		{
			SaftFile = await XmlSerializer.Deserialize<AuditFile>(filename);
		}
	}
}
