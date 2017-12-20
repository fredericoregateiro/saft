using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolRIA.SaftAnalyser.Models
{
    public class FactemiCLIParams
    {
        public int Id { get; set; }
        public string JarPath { get; set; }
        public string ResumePath { get; set; }
        public string OutputPath { get; set; }

        public string Command { get; set; } = " java -jar {0} -n {1} -p {2} -a {3} -m {4} -op {5} -i {6} -r {7} -o {8}";
        public string CommandTest { get; set; } = "java -jar {0} -n {1} -p {2} -a {3} -m {4} -op {5} -i {6} -r {7} -o {8} -t";
    }

    public enum FactemiSendOption
    {
        enviar,
        validar
    }
}
