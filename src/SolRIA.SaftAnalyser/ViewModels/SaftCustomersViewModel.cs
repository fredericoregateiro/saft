using OfficeOpenXml;
using OfficeOpenXml.Table;
using Prism.Commands;
using Prism.Mvvm;
using SolRia.Erp.MobileApp.Models.SaftV4;
using SolRIA.SaftAnalyser.Interfaces;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace SolRIA.SaftAnalyser.ViewModels
{
    public class SaftCustomersViewModel : BindableBase
    {
		INavigationService navService;
		IMessageService messageService;
		public SaftCustomersViewModel(INavigationService navService, IMessageService messageService)
		{
			this.navService = navService;
			this.messageService = messageService;

			SearchCommand = new DelegateCommand(OnSearch);
            DoPrintCommand = new DelegateCommand(OnPrint);

            navService.LoadCompleted += NavService_LoadCompleted;
		}

		private void NavService_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
		{
			if (OpenedFileInstance.Instance.SaftFile.MasterFiles != null)
				Customers = OpenedFileInstance.Instance.SaftFile.MasterFiles.Customer;

			messageService.CloseDialog();
		}

		private Customer[] customers;
		public Customer[] Customers
		{
			get { return customers; }
			set { SetProperty(ref customers, value); }
		}

		private string filter;
		public string Filter
		{
			get { return filter; }
			set { SetProperty(ref filter, value); }
		}

		//SearchCommand
		public DelegateCommand SearchCommand { get; private set; }
		public virtual void OnSearch()
		{
			FilterCustomers();
		}

		private void FilterCustomers()
		{
			if (Customers != null)
			{
				if (string.IsNullOrEmpty(filter))
					Customers = OpenedFileInstance.Instance.SaftFile.MasterFiles.Customer;
				else
				{
					Customers = (
						from c in OpenedFileInstance.Instance.SaftFile.MasterFiles.Customer
						where (!string.IsNullOrEmpty(c.CompanyName) && c.CompanyName.IndexOf(filter, System.StringComparison.OrdinalIgnoreCase) >= 0) ||
						(!string.IsNullOrEmpty(c.CustomerID) && c.CustomerID.IndexOf(filter, System.StringComparison.OrdinalIgnoreCase) >= 0) ||
						(!string.IsNullOrEmpty(c.CustomerTaxID) && c.CustomerTaxID.IndexOf(filter, System.StringComparison.OrdinalIgnoreCase) >= 0) ||
						(!string.IsNullOrEmpty(c.Email) && c.Email.IndexOf(filter, System.StringComparison.OrdinalIgnoreCase) >= 0) ||
						(!string.IsNullOrEmpty(c.Telephone) && c.Telephone.IndexOf(filter, System.StringComparison.OrdinalIgnoreCase) >= 0) ||
						(!string.IsNullOrEmpty(c.Website) && c.Website.IndexOf(filter, System.StringComparison.OrdinalIgnoreCase) >= 0) ||
						(!string.IsNullOrEmpty(c.Contact) && c.Contact.IndexOf(filter, System.StringComparison.OrdinalIgnoreCase) >= 0)
						select c).ToArray();
				}
			}
		}

        public DelegateCommand DoPrintCommand { get; private set; }
        private void OnPrint()
        {
            if (Customers != null && Customers.Length > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Código", typeof(string));
                dt.Columns.Add("Nº conta", typeof(string));
                dt.Columns.Add("NIF", typeof(string));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("Contacto", typeof(string));
                dt.Columns.Add("Telefone", typeof(string));
                dt.Columns.Add("Fax", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Website", typeof(string));
                dt.Columns.Add("Autofacturação", typeof(string));
                foreach (var c in Customers)
                {
                    dt.Rows.Add(c.CustomerID, c.AccountID, c.CustomerTaxID, c.CompanyName, c.Contact, c.Telephone, c.Fax, c.Email, c.Website, c.SelfBillingIndicator);
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
