using System;

namespace SolRIA.SaftAnalyser.Models
{
    public class LinhasAgrupadas
    {
        public string Tipo { get; set; }
        public string ProdutoCodigo { get; set; }
        public string ProdutoNome { get; set; }
        public decimal Incidencia { get; set; }
        public decimal TaxaImposto { get; set; }
    }

    public class DocumentosAgrupados
    {
        public string Tipo { get; set; }
        public DateTime Data { get; set; }
        public decimal Total { get; set; }
        public decimal Incidencia { get; set; }
        public decimal Imposto { get; set; }
    }

    public class ResumoIva
    {
        public decimal Incidencia { get; set; }
        public string Taxa { get; set; }
        public string Codigo { get; set; }
        public decimal Valor { get; set; }
    }
}
