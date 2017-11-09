using System.Collections.Generic;

namespace SolRIA.SaftAnalyser.Logic.Models
{
    public class ZipCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ZipCodeExtension { get; set; }

        public static ZipCode[] ParseCsv(string[] lines)
        {
            if (lines == null || lines.Length == 0)
                return null;

            List<ZipCode> zipCodesList = new List<ZipCode>();
            foreach (var line in lines)
            {
                zipCodesList.Add(ParseModel(line));
            }

            return zipCodesList.ToArray();
        }

        public static ZipCode ParseModel(string modelLine)
        {
            ZipCode zc = new ZipCode();
            string[] values = modelLine.Split(';');

            zc.Id = int.Parse(values[0]);
            zc.Code = values[2];
            zc.ZipCodeExtension = values[3];
            
            return zc;
        }
    }
}
