using OfficeOpenXml;
using OfficeOpenXml.Table;
using OfficeOpenXml.Table.PivotTable;
using Prism.Commands;
using Prism.Mvvm;
using SolRia.Erp.MobileApp.Models.SaftV4;
using SolRIA.SaftAnalyser.Interfaces;
using SolRIA.SaftAnalyser.Models;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace SolRIA.SaftAnalyser.ViewModels
{
    public class SaftInvoicesSummaryViewModel : BindableBase
    {
        INavigationService navService;
        IMessageService messageService;
        public SaftInvoicesSummaryViewModel(INavigationService navService, IMessageService messageService)
        {
            this.navService = navService;
            this.messageService = messageService;

            DoExportDocumentsCommand = new DelegateCommand(OnExportDocuments, CanExportDocuments);
            DoExportLinesCommand = new DelegateCommand(OnExportLines, CanExportLines);
            DoExportTaxesCommand = new DelegateCommand(OnExportTaxes, CanExportTaxes);

            navService.LoadCompleted += NavService_LoadCompleted;
        }

        private void NavService_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            LoadInvoices(OpenedFileInstance.Instance.SaftFile);
        }

        SourceDocumentsSalesInvoicesInvoiceLine[] allLines;
        SourceDocumentsSalesInvoicesInvoice[] allInvoices;

        private void LoadInvoices(AuditFile saft)
        {
            if (saft != null && saft.SourceDocuments != null && saft.SourceDocuments.SalesInvoices != null && saft.SourceDocuments.SalesInvoices.Invoice != null && saft.SourceDocuments.SalesInvoices.Invoice.Length > 0)
            {
                HasDocuments = true;
                allLines = saft.SourceDocuments.SalesInvoices.Invoice.SelectMany(i => i.Line).ToArray();
                allInvoices = saft.SourceDocuments.SalesInvoices.Invoice;

                TotalDebit = saft.SourceDocuments.SalesInvoices.TotalDebit;
                TotalCredit = saft.SourceDocuments.SalesInvoices.TotalCredit;
            }

            AgruparDocumentosDia = true;
            AgruparLinhasPorCodigo = true;
            InitResumo();
        }


        #region Binding properties
        bool hasDocuments;
        public bool HasDocuments
        {
            get => hasDocuments; set => SetProperty(ref hasDocuments, value);
        }

        bool processingData;
        public bool ProcessingData
        {
            get => processingData; set => SetProperty(ref processingData, value);
        }

        decimal totalDebit;
        public decimal TotalDebit
        {
            get => totalDebit; set => SetProperty(ref totalDebit, value);
        }

        decimal totalCredit;
        public decimal TotalCredit
        {
            get => totalCredit; set => SetProperty(ref totalCredit, value);
        }

        LinhasAgrupadas[] invoiceLines;
        public LinhasAgrupadas[] InvoiceLines
        {
            get => invoiceLines; set => SetProperty(ref invoiceLines, value);
        }

        bool agruparLinhasPorCodigo;
        public bool AgruparLinhasPorCodigo
        {
            get { return agruparLinhasPorCodigo; }
            set
            {
                SetProperty(ref agruparLinhasPorCodigo, value);

                if (agruparLinhasPorCodigo && allLines != null)
                {
                    BackgroundWorker bw = new BackgroundWorker();
                    bw.DoWork += bw_DoWorkGroupLinesCode;
                    bw.RunWorkerCompleted += bw_RunWorkerCompleted;
                    bw.RunWorkerAsync();
                }
            }
        }

        bool agruparLinhasPorDescricao;
        public bool AgruparLinhasPorDescricao
        {
            get => agruparLinhasPorDescricao;
            set
            {
                SetProperty(ref agruparLinhasPorDescricao, value);

                if (agruparLinhasPorDescricao && allLines != null)
                {
                    BackgroundWorker bw = new BackgroundWorker();
                    bw.DoWork += bw_DoWorkGroupLinesDescription;
                    bw.RunWorkerCompleted += bw_RunWorkerCompleted;
                    bw.RunWorkerAsync();
                }
            }
        }

        DocumentosAgrupados[] invoices;
        public DocumentosAgrupados[] Invoices
        {
            get => invoices; set => SetProperty(ref invoices, value);
        }

        bool agruparDocumentosMes;
        public bool AgruparDocumentosMes
        {
            get { return agruparDocumentosMes; }
            set
            {
                SetProperty(ref agruparDocumentosMes, value);

                if (agruparDocumentosMes && allInvoices != null)
                {
                    BackgroundWorker bw = new BackgroundWorker();
                    bw.DoWork += bw_DoWorkGroupDocumentsMonth;
                    bw.RunWorkerCompleted += bw_RunWorkerCompleted;
                    bw.RunWorkerAsync();
                }
            }
        }

        bool agruparDocumentosDia;
        public bool AgruparDocumentosDia
        {
            get { return agruparDocumentosDia; }
            set
            {
                SetProperty(ref agruparDocumentosDia, value);

                if (agruparDocumentosDia && allInvoices != null)
                {
                    BackgroundWorker bw = new BackgroundWorker();
                    bw.DoWork += bw_DoWorkGroupDocumentsDay;
                    bw.RunWorkerCompleted += bw_RunWorkerCompleted;
                    bw.RunWorkerAsync();
                }
            }
        }

        void InitResumo()
        {
            if (resumo == null && allLines != null)
            {
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += bw_DoWorkGroupTaxes;
                bw.RunWorkerCompleted += bw_RunWorkerCompleted;
                bw.RunWorkerAsync();
            }
        }
        ResumoIva[] resumo;
        public ResumoIva[] Resumo
        {
            get => resumo; set => SetProperty(ref resumo, value);
        }
        #endregion

        #region background workers
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProcessingData = false;
            DoExportTaxesCommand.RaiseCanExecuteChanged();
            DoExportLinesCommand.RaiseCanExecuteChanged();
            DoExportDocumentsCommand.RaiseCanExecuteChanged();
        }

        void bw_DoWorkGroupLinesCode(object sender, DoWorkEventArgs e)
        {
            ProcessingData = true;

            InvoiceLines =
                (from l in allLines
                 group l by new { l.ItemElementName, l.ProductCode, l.Tax.Item } into c
                 select new LinhasAgrupadas {
                     Tipo = c.Key.ItemElementName.ToString(),
                     ProdutoCodigo = c.Key.ProductCode,
                     TaxaImposto = c.Key.Item,
                     Incidencia = c.Sum(linha => linha.ItemElementName == ItemChoiceType4.CreditAmount ? linha.Item : -linha.Item) }).ToArray();
        }

        void bw_DoWorkGroupLinesDescription(object sender, DoWorkEventArgs e)
        {
            ProcessingData = true;

            InvoiceLines =
                (from l in allLines
                 group l by new { l.ItemElementName, l.Description, l.Tax.Item } into c
                 select new LinhasAgrupadas {
                     Tipo = c.Key.ItemElementName.ToString(),
                     ProdutoNome = c.Key.Description,
                     TaxaImposto = c.Key.Item,
                     Incidencia = c.Sum(linha => linha.ItemElementName == ItemChoiceType4.CreditAmount ? linha.Item: -linha.Item) }).ToArray();
        }

        void bw_DoWorkGroupDocumentsDay(object sender, DoWorkEventArgs e)
        {
            ProcessingData = true;

            Invoices = (from d in allInvoices
                        group d by new { d.InvoiceType, d.InvoiceDate.Year, d.InvoiceDate.Month, d.InvoiceDate.Day } into g
                        select new DocumentosAgrupados
                        {
                            Tipo = g.Key.InvoiceType.ToString(),
                            Data = new DateTime(g.Key.Year, g.Key.Month, g.Key.Day),
                            Total = g.Sum(doc => doc.InvoiceType == InvoiceType.NC ? -doc.DocumentTotals.GrossTotal : doc.DocumentTotals.GrossTotal),
                            Incidencia = g.Sum(doc => doc.InvoiceType == InvoiceType.NC ? -doc.DocumentTotals.NetTotal : doc.DocumentTotals.NetTotal),
                            Imposto = g.Sum(doc => doc.InvoiceType == InvoiceType.NC ? -doc.DocumentTotals.TaxPayable : doc.DocumentTotals.TaxPayable)
                        }).ToArray();
        }

        void bw_DoWorkGroupDocumentsMonth(object sender, DoWorkEventArgs e)
        {
            ProcessingData = true;

            Invoices = (from d in allInvoices
                        group d by new { d.InvoiceType, d.InvoiceDate.Year, d.InvoiceDate.Month } into g
                        select new DocumentosAgrupados
                        {
                            Tipo = g.Key.InvoiceType.ToString(),
                            Data = new DateTime(g.Key.Year, g.Key.Month, 1),
                            Total = g.Sum(doc => doc.InvoiceType == InvoiceType.NC ? -doc.DocumentTotals.GrossTotal : doc.DocumentTotals.GrossTotal),
                            Incidencia = g.Sum(doc => doc.InvoiceType == InvoiceType.NC ? -doc.DocumentTotals.NetTotal : doc.DocumentTotals.NetTotal),
                            Imposto = g.Sum(doc => doc.InvoiceType == InvoiceType.NC ? -doc.DocumentTotals.TaxPayable : doc.DocumentTotals.TaxPayable)
                        }).ToArray();
        }

        private void bw_DoWorkGroupTaxes(object sender, DoWorkEventArgs e)
        {
            processingData = true;
            Resumo =
                (from l in allLines
                 group l by new { l.Tax.TaxCode, l.Tax.Item } into g
                 select new ResumoIva
                 {
                     Codigo = g.Key.TaxCode,
                     Taxa = (g.Key.Item * 0.01m).ToString("p"),
                     Valor = g.Sum(linha => linha.Item * linha.Tax.Item * 0.01m),
                     Incidencia = g.Sum(linha => linha.Item)
                 }).ToArray();
        }
        #endregion

        #region Commands
        public DelegateCommand DoExportDocumentsCommand { get; private set; }
        private void OnExportDocuments()
        {
            ExcelPackage pck = new ExcelPackage();
            var wsEnum = pck.Workbook.Worksheets.Add("SAFT Invoices");

            //Load the collection starting from cell A1...
            ExcelRangeBase dataRange = wsEnum.Cells["A1"].LoadFromCollection<DocumentosAgrupados>(Invoices, true, TableStyles.Medium9);

            wsEnum.Column(2).Style.Numberformat.Format = "yyyy/dd/mm";
            wsEnum.Column(3).Style.Numberformat.Format = "#,##0.00";
            wsEnum.Column(4).Style.Numberformat.Format = "#,##0.00";
            wsEnum.Column(5).Style.Numberformat.Format = "#,##0.00";
            dataRange.AutoFitColumns();

            var pivotTable2 = wsEnum.PivotTables.Add(wsEnum.Cells["G1"], dataRange, "Invoices");
            pivotTable2.RowFields.Add(pivotTable2.Fields["Tipo"]);

            //Add a rowfield
            var rowField = pivotTable2.RowFields.Add(pivotTable2.Fields["Data"]);
            //This is a date field so we want to group by Years and quaters. This will create one additional field for years.
            if (agruparDocumentosMes)
                rowField.AddDateGrouping(eDateGroupBy.Months);
            else if (AgruparDocumentosDia)
                rowField.AddDateGrouping(eDateGroupBy.Days);

            var dataField = pivotTable2.DataFields.Add(pivotTable2.Fields["Total"]);
            dataField.Format = "#,##0.00";
            dataField = pivotTable2.DataFields.Add(pivotTable2.Fields["Incidencia"]);
            dataField.Format = "#,##0.00";
            dataField = pivotTable2.DataFields.Add(pivotTable2.Fields["Imposto"]);
            dataField.Format = "#,##0.00";

            //We want the datafields to appear in columns
            pivotTable2.DataOnRows = false;

            //...and save
            var fi = new FileInfo(Path.GetTempPath() + Path.GetRandomFileName() + ".xlsx");

            pck.SaveAs(fi);

            Process.Start(fi.FullName);
        }
        private bool CanExportDocuments()
        {
            return Invoices != null && Invoices.Length > 0;
        }

        public DelegateCommand DoExportLinesCommand { get; private set; }
        private void OnExportLines()
        {
            ExcelPackage pck = new ExcelPackage();
            var wsEnum = pck.Workbook.Worksheets.Add("SAFT Invoice Lines");

            var dataRange = wsEnum.Cells["A1"].LoadFromCollection(InvoiceLines, true, TableStyles.Medium9);
            wsEnum.Cells[wsEnum.Dimension.Address].AutoFitColumns();
            wsEnum.Column(3).Style.Numberformat.Format = "#,##0.00";

            var pivotTable2 = wsEnum.PivotTables.Add(wsEnum.Cells["F1"], dataRange, "Invoice Lines");
            pivotTable2.RowFields.Add(pivotTable2.Fields["Tipo"]);

            var dataField = pivotTable2.DataFields.Add(pivotTable2.Fields["Incidencia"]);
            dataField.Format = "#,##0.00";

            //We want the datafields to appear in columns
            pivotTable2.DataOnRows = false;

            //...and save
            var fi = new FileInfo(Path.GetTempPath() + Path.GetRandomFileName() + ".xlsx");

            pck.SaveAs(fi);

            Process.Start(fi.FullName);
        }
        private bool CanExportLines()
        {
            return InvoiceLines != null && InvoiceLines.Length > 0;
        }

        public DelegateCommand DoExportTaxesCommand { get; private set; }
        private void OnExportTaxes()
        {
            ExcelPackage pck = new ExcelPackage();
            var wsEnum = pck.Workbook.Worksheets.Add("SAFT Tax");

            var dataRange = wsEnum.Cells["A1"].LoadFromCollection(Resumo, true, TableStyles.Medium9);
            wsEnum.Cells[wsEnum.Dimension.Address].AutoFitColumns();
            wsEnum.Column(1).Style.Numberformat.Format = "#,##0.00";
            wsEnum.Column(3).Style.Numberformat.Format = "#,##0.00";

            var pivotTable2 = wsEnum.PivotTables.Add(wsEnum.Cells["E1"], dataRange, "Tax");
            pivotTable2.RowFields.Add(pivotTable2.Fields["Taxa"]);

            var dataField = pivotTable2.DataFields.Add(pivotTable2.Fields["Incidencia"]);
            dataField.Format = "#,##0.00";

            //We want the datafields to appear in columns
            pivotTable2.DataOnRows = false;

            //...and save
            var fi = new FileInfo(Path.GetTempPath() + Path.GetRandomFileName() + ".xlsx");

            pck.SaveAs(fi);

            Process.Start(fi.FullName);
        }
        private bool CanExportTaxes()
        {
            return Resumo != null && Resumo.Length > 0;
        }
        #endregion
    }
}
