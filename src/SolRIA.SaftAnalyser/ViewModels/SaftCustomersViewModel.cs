using Prism.Commands;
using Prism.Mvvm;
using SolRia.Erp.MobileApp.Models.SaftV4;
using SolRIA.SaftAnalyser.Interfaces;
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
	}
}
