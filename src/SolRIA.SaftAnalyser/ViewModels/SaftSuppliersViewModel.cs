using OfficeOpenXml;
using OfficeOpenXml.Table;
using Prism.Commands;
using Prism.Mvvm;
using SolRia.Erp.MobileApp.Models.SaftV4;
using SolRIA.SaftAnalyser.Interfaces;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace SolRIA.SaftAnalyser.ViewModels
{
    public class SaftSuppliersViewModel : BindableBase
    {
        INavigationService navService;
        IMessageService messageService;
        public SaftSuppliersViewModel(INavigationService navService, IMessageService messageService)
        {
            this.navService = navService;
            this.messageService = messageService;

            DoPrintCommand = new DelegateCommand(OnPrint);

            navService.LoadCompleted += NavService_LoadCompleted;
        }

        private void NavService_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (OpenedFileInstance.Instance.SaftFile.MasterFiles != null)
                suppliersBack = OpenedFileInstance.Instance.SaftFile.MasterFiles.Supplier;

            Suppliers = suppliersBack;
            messageService.CloseDialog();
        }

        Supplier[] suppliersBack;

        Supplier[] suppliers;
        public Supplier[] Suppliers
        {
            get => suppliers; set => SetProperty(ref suppliers, value);
        }

        string filter;
        public string Filter
        {
            get => filter;
            set
            {
                SetProperty(ref filter, value);

                if (string.IsNullOrEmpty(filter))
                    Suppliers = suppliersBack;
                else
                {
                    Suppliers = (from c in suppliersBack
                                 where !string.IsNullOrEmpty(c.AccountID) && c.AccountID.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 !string.IsNullOrEmpty(c.CompanyName) && c.CompanyName.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 !string.IsNullOrEmpty(c.Contact) && c.Contact.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 !string.IsNullOrEmpty(c.Email) && c.Email.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 !string.IsNullOrEmpty(c.Fax) && c.Fax.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 !string.IsNullOrEmpty(c.SupplierID) && c.SupplierID.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 !string.IsNullOrEmpty(c.SupplierTaxID) && c.SupplierTaxID.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 !string.IsNullOrEmpty(c.Telephone) && c.Telephone.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 !string.IsNullOrEmpty(c.Website) && c.Website.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0
                                select c).ToArray();
                }
            }
        }

        public DelegateCommand DoPrintCommand { get; private set; }
        private void OnPrint()
        {
            if (Suppliers != null && Suppliers.Length > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Código fornecedor", typeof(string));
                dt.Columns.Add("Nº conta", typeof(string));
                dt.Columns.Add("NIF", typeof(string));
                dt.Columns.Add("Nome", typeof(DateTime));
                dt.Columns.Add("Contacto", typeof(string));
                dt.Columns.Add("Telefone", typeof(string));
                dt.Columns.Add("Fax", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Website", typeof(string));
                dt.Columns.Add("Autofacturação", typeof(string));

                foreach (var p in Suppliers)
                {
                    dt.Rows.Add(p.SupplierID, p.AccountID, p.SupplierTaxID, p.CompanyName, p.Contact, p.Telephone, p.Fax, p.Email, p.Website, p.SelfBillingIndicator);
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
