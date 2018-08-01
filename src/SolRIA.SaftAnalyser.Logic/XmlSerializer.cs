using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SolRIA.SaftAnalyser
{
	public static class XmlSerializer
	{
		public static async Task<T> Deserialize<T>(string xmlFileName)
		{
			TextReader tw = null;
			try
			{
				return await Task.Run<T>(() =>
				{
					tw = new StreamReader(xmlFileName, Encoding.GetEncoding("Windows-1252"));

					System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(T));
					T config = (T)x.Deserialize(tw);

					return config;
				});
			}
			catch (Exception)
			{
				return default(T);
			}
			finally
			{
				if (tw != null)
				{
					tw.Close();
					tw.Dispose();
				}
			}
		}
	}
}
