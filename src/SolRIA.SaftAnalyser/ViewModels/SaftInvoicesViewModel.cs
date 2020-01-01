using SolRia.Erp.MobileApp.Models.SaftV4;
using SolRIA.SaftAnalyser.Interfaces;
using System;
using System.Linq;
using SolRIA.SaftAnalyser.Mvvm;

namespace SolRIA.SaftAnalyser.ViewModels
{
    public class SaftInvoicesViewModel : BindableBase
    {
        readonly IMessageService messageService;
        public SaftInvoicesViewModel(INavigationService navService, IMessageService messageService)
        {
            this.messageService = messageService;

            navService.LoadCompleted += NavService_LoadCompleted;
        }

        private void NavService_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (OpenedFileInstance.Instance.SaftFile.SourceDocuments != null && OpenedFileInstance.Instance.SaftFile.SourceDocuments.SalesInvoices != null)
            {
                SalesInvoices = OpenedFileInstance.Instance.SaftFile.SourceDocuments.SalesInvoices;

                FiltroDataInicio = OpenedFileInstance.Instance.SaftFile.Header.StartDate;
                FiltroDataFim = OpenedFileInstance.Instance.SaftFile.Header.EndDate;
            }
            else
            {
                FiltroDataInicio = new DateTime(DateTime.Now.Year, 1, 1);
                FiltroDataFim = new DateTime(DateTime.Now.Year, 12, 31, 23, 59, 59);
            }
        }

        SourceDocumentsSalesInvoices salesInvoices;
        public SourceDocumentsSalesInvoices SalesInvoices
        {
            get
            {
                if (salesInvoices == null && OpenedFileInstance.Instance.SaftFile != null)
                    salesInvoices = OpenedFileInstance.Instance.SaftFile.SourceDocuments.SalesInvoices;

                return salesInvoices;
            }
            set
            {
                SetProperty(ref salesInvoices, value);

                if (salesInvoices != null && string.IsNullOrWhiteSpace(FilterInvoices))
                {
                    DocNumberOfEntries = salesInvoices.Invoice.Length;
                    DocTotalCredit = salesInvoices.Invoice
                        .Where(c => c.DocumentStatus.InvoiceStatus != InvoiceStatus.A && c.DocumentStatus.InvoiceStatus != InvoiceStatus.F)
                        .Sum(c => c.Line.Sum(l => l.ItemElementName == ItemChoiceType4.CreditAmount ? l.Item : 0))
                        .ToString("c");

                    DocTotalDebit = salesInvoices.Invoice
                        .Where(c => c.DocumentStatus.InvoiceStatus != InvoiceStatus.A && c.DocumentStatus.InvoiceStatus != InvoiceStatus.F)
                        .Sum(c => c.Line.Sum(l => l.ItemElementName == ItemChoiceType4.DebitAmount ? l.Item : 0))
                        .ToString("c");

                    NumberOfEntries = salesInvoices.NumberOfEntries;
                    TotalCredit = salesInvoices.TotalCredit.ToString("c");
                    TotalDebit = salesInvoices.TotalDebit.ToString("c");

                    filtroDataInicio = salesInvoices.Invoice.Min(i => i.InvoiceDate);
                    filtroDataFim = salesInvoices.Invoice.Max(i => i.InvoiceDate);

                    Invoices = salesInvoices.Invoice;
                }
            }
        }

        SourceDocumentsSalesInvoicesInvoice[] invoices;
        public SourceDocumentsSalesInvoicesInvoice[] Invoices
        {
            get { return invoices; }
            set { SetProperty(ref invoices, value); }
        }

        SourceDocumentsSalesInvoicesInvoice currentInvoice;
        public SourceDocumentsSalesInvoicesInvoice CurrentInvoice
        {
            get { return currentInvoice; }
            set
            {
                SetProperty(ref currentInvoice, value);

                if (currentInvoice != null && string.IsNullOrEmpty(FilterLines))
                {
                    DocGrossTotal = currentInvoice.Line.Sum(c => c.UnitPrice * (1 + c.Tax.Item * 0.01m) * c.Quantity * Operation(currentInvoice, c)).ToString("c");
                    DocNetTotal = currentInvoice.Line.Sum(c => c.UnitPrice * c.Quantity * Operation(currentInvoice, c)).ToString("c");
                    DocTaxPayable = currentInvoice.Line.Sum(c => c.UnitPrice * c.Tax.Item * 0.01m * c.Quantity * Operation(currentInvoice, c)).ToString("c");

                    GrossTotal = currentInvoice.DocumentTotals.GrossTotal.ToString("c");
                    NetTotal = currentInvoice.DocumentTotals.NetTotal.ToString("c");
                    TaxPayable = currentInvoice.DocumentTotals.TaxPayable.ToString("c");

                    if (!ShowAllLines)
                        CurrentInvoiceLines = currentInvoice.Line;
                }
            }
        }

        SourceDocumentsSalesInvoicesInvoiceLine[] currentInvoiceLines;
        public SourceDocumentsSalesInvoicesInvoiceLine[] CurrentInvoiceLines
        {
            get { return currentInvoiceLines; }
            set { SetProperty(ref currentInvoiceLines, value); }
        }

        SourceDocumentsSalesInvoicesInvoiceLine currentInvoiceLine;
        public SourceDocumentsSalesInvoicesInvoiceLine CurrentInvoiceLine
        {
            get { return currentInvoiceLine; }
            set { SetProperty(ref currentInvoiceLine, value); }
        }

        bool showAllLines;
        public bool ShowAllLines
        {
            get { return showAllLines; }
            set
            {
                SetProperty(ref showAllLines, value);

                if (showAllLines)
                    CurrentInvoiceLines = SalesInvoices.Invoice.SelectMany(i => i.Line).ToArray();
                else
                    CurrentInvoiceLines = CurrentInvoice.Line;
            }
        }

        DateTime filtroDataInicio;
        public DateTime FiltroDataInicio
        {
            get => filtroDataInicio;
            set
            {
                SetProperty(ref filtroDataInicio, value);
                FilterInvoicesByDate();
            }
        }
        DateTime filtroDataFim;
        public DateTime FiltroDataFim
        {
            get => filtroDataFim;
            set
            {
                SetProperty(ref filtroDataFim, value);
                FilterInvoicesByDate();
            }
        }

        private void FilterInvoicesByDate()
        {
            if (OpenedFileInstance.Instance.SaftFile != null && OpenedFileInstance.Instance.SaftFile.SourceDocuments.SalesInvoices != null)
            {
                var inv = from i in OpenedFileInstance.Instance.SaftFile.SourceDocuments.SalesInvoices.Invoice
                          where i.InvoiceDate >= filtroDataInicio && i.InvoiceDate <= FiltroDataFim
                          select i;

                Invoices = inv.ToArray();
            }
        }

        string filterInvoices;
        public string FilterInvoices
        {
            get { return filterInvoices; }
            set
            {
                filterInvoices = value;

                if (string.IsNullOrEmpty(filterInvoices))
                    Invoices = OpenedFileInstance.Instance.SaftFile.SourceDocuments.SalesInvoices.Invoice;
                else
                {
                    var inv = from i in OpenedFileInstance.Instance.SaftFile.SourceDocuments.SalesInvoices.Invoice
                              where i.InvoiceNo.IndexOf(filterInvoices, StringComparison.OrdinalIgnoreCase) >= 0 ||
                              i.CustomerID.IndexOf(filterInvoices, StringComparison.OrdinalIgnoreCase) >= 0
                              select i;

                    Invoices = inv.ToArray();
                }
            }
        }

        string filterLines;
        public string FilterLines
        {
            get { return filterLines; }
            set
            {
                filterLines = value;

                if (string.IsNullOrEmpty(filterLines))
                    CurrentInvoiceLines = CurrentInvoice.Line;
                else
                {
                    var lines = from l in CurrentInvoice.Line
                                where l.ProductDescription.IndexOf(filterLines, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                        l.ProductCode.IndexOf(filterLines, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                        l.Description.IndexOf(filterLines, StringComparison.OrdinalIgnoreCase) >= 0
                                select l;

                    CurrentInvoiceLines = lines.ToArray();
                }
            }
        }

        string docGrossTotal;
        string docNetTotal;
        string docTaxPayable;
        int docNumberOfEntries;
        string docTotalCredit;
        string docTotalDebit;
        string grossTotal;
        string netTotal;
        string taxPayable;
        string numberOfEntries;
        string totalCredit;
        string totalDebit;

        public string DocGrossTotal { get => docGrossTotal; set => SetProperty(ref docGrossTotal, value); }
        public string DocNetTotal { get => docNetTotal; set => SetProperty(ref docNetTotal, value); }
        public string DocTaxPayable { get => docTaxPayable; set => SetProperty(ref docTaxPayable, value); }
        public int DocNumberOfEntries { get => docNumberOfEntries; set => SetProperty(ref docNumberOfEntries, value); }
        public string DocTotalCredit { get => docTotalCredit; set => SetProperty(ref docTotalCredit, value); }
        public string DocTotalDebit { get => docTotalDebit; set => SetProperty(ref docTotalDebit, value); }
        public string GrossTotal { get => grossTotal; set => SetProperty(ref grossTotal, value); }
        public string NetTotal { get => netTotal; set => SetProperty(ref netTotal, value); }
        public string TaxPayable { get => taxPayable; set => SetProperty(ref taxPayable, value); }
        public string NumberOfEntries { get => numberOfEntries; set => SetProperty(ref numberOfEntries, value); }
        public string TotalCredit { get => totalCredit; set => SetProperty(ref totalCredit, value); }
        public string TotalDebit { get => totalDebit; set => SetProperty(ref totalDebit, value); }

        public DelegateCommand TestHashCommand { get; set; }
        private void DoTestHash(object obj)
        {
            string hashDocumentoAnterior = null;

            //fazer parse do campo InvoiceNo, descobrir o nº do documento actual e obter o documento anterior
            string[] invoiceNo = CurrentInvoice.InvoiceNo.Split('/');
            if (invoiceNo != null && invoiceNo.Length == 2)
            {
                int.TryParse(invoiceNo[1], out int num);
                num = num - 1;

                if (num > 0)
                {
                    SourceDocumentsSalesInvoicesInvoice invoice
                        = Invoices.Where(i => i.InvoiceNo.IndexOf(string.Format("{0}/{1}", invoiceNo[0], num), StringComparison.OrdinalIgnoreCase) == 0).FirstOrDefault();

                    //encontramos um documento, vamos obter a hash
                    if (invoice != null)
                        hashDocumentoAnterior = invoice.Hash;
                }
            }

            //Workspace.Workspace.Instance.ShowCreateHashTool(this.CurrentInvoice, hashDocumentoAnterior);
        }
        private bool CanTestHash(object arg)
        {
            return CurrentInvoice != null;
        }

        public DelegateCommand DoOpenExcelCommand { get; private set; }
        private void OpenExcel(object args)
        {
            //InvoiceViewModel.OpenInvoiceInExcel(this.CurrentInvoice, this.ShowAllLines ? this.SalesInvoices.Invoice.SelectMany(i => i.Line).ToArray() : this.CurrentInvoiceLines);
        }
        private bool CanOpenExcel(object args)
        {
            if (CurrentInvoice != null)
                return true;
            else
                return false;
        }

        public DelegateCommand ShowInvoiceDetailsCommand { get; private set; }
        private void DoShowInvoiceDetails(object args)
        {

        }
        private bool CanShowInvoiceDetails(object args)
        {
            return CurrentInvoice != null;
        }

        public DelegateCommand ShowCustomerCommand { get; private set; }
        private void DoShowCustomer(object args)
        {

        }
        private bool CanShowCustomer(object args)
        {
            return CurrentInvoice != null;
        }

        private int Operation(SourceDocumentsSalesInvoicesInvoice i, SourceDocumentsSalesInvoicesInvoiceLine l)
        {
            return OpenedFileInstance.Instance.Operation(i, l);
        }
    }
}
