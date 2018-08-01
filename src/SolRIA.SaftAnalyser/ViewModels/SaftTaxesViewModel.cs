using OfficeOpenXml;
using OfficeOpenXml.Table;
using SolRia.Erp.MobileApp.Models.SaftV4;
using SolRIA.SaftAnalyser.Interfaces;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using SolRIA.SaftAnalyser.Mvvm;

namespace SolRIA.SaftAnalyser.ViewModels
{
    public class SaftTaxesViewModel : BindableBase
    {
        INavigationService navService;
        IMessageService messageService;
        public SaftTaxesViewModel(INavigationService navService, IMessageService messageService)
        {
            this.navService = navService;
            this.messageService = messageService;

            DoPrintCommand = new DelegateCommand(OnPrint);

            navService.LoadCompleted += NavService_LoadCompleted;
        }

        private void NavService_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (OpenedFileInstance.Instance.SaftFile.MasterFiles != null)
                taxesBack = OpenedFileInstance.Instance.SaftFile.MasterFiles.TaxTable;

            TaxTable = taxesBack;
            messageService.CloseDialog();
        }

        TaxTableEntry[] taxesBack;

        TaxTableEntry[] taxTable;
        public TaxTableEntry[] TaxTable
        {
            get => taxTable;
            set => SetProperty(ref taxTable, value);
        }

        TaxTableEntry tax;
        public TaxTableEntry Tax
        {
            get => tax;
            set => SetProperty(ref tax, value);
        }

        string filter;
        public string Filter
        {
            get { return filter; }
            set
            {
                filter = value;

                if (taxesBack != null)
                {
                    if (string.IsNullOrEmpty(filter))
                        TaxTable = taxesBack;
                    else
                    {
                        TaxTable =
                            (from c in taxesBack
                             where !string.IsNullOrEmpty(c.Description) && c.Description.IndexOf(filter, System.StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 !string.IsNullOrEmpty(c.TaxCode) && c.TaxCode.IndexOf(filter, System.StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 !string.IsNullOrEmpty(c.TaxCountryRegion) && c.TaxCountryRegion.IndexOf(filter, System.StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 c.TaxType.ToString().IndexOf(filter, System.StringComparison.OrdinalIgnoreCase) >= 0
                             select c).ToArray();
                    }
                }
            }
        }

        public DelegateCommand DoPrintCommand { get; private set; }
        private void OnPrint()
        {
            if (TaxTable != null && TaxTable.Length > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("País ou região imposto", typeof(string));
                dt.Columns.Add("Código", typeof(string));
                dt.Columns.Add("Descrição", typeof(string));
                dt.Columns.Add("Data fim", typeof(DateTime));
                dt.Columns.Add("Valor", typeof(string));
                dt.Columns.Add("Tipo", typeof(string));

                foreach (var p in TaxTable)
                {
                    dt.Rows.Add(p.TaxCountryRegion, p.TaxCode, p.Description, p.TaxExpirationDate, p.Item, p.ItemElementName);
                }

                ExcelPackage pck = new ExcelPackage();
                var wsEnum = pck.Workbook.Worksheets.Add("SolRIA | SAFT");
                //Load the collection starting from cell A1...
                wsEnum.Cells["A1"].LoadFromDataTable(dt, true, TableStyles.Medium9);
                wsEnum.Cells[wsEnum.Dimension.Address].AutoFitColumns();

                //...and save
                var fi = new FileInfo(Path.GetTempPath() + Path.GetRandomFileName() + ".xlsx");
                if (fi.Exists)
                    fi.Delete();

                pck.SaveAs(fi);

                Process.Start(fi.FullName);
            }
        }
    }
}
