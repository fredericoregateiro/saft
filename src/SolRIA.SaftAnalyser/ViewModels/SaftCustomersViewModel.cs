using Prism.Mvvm;
using SolRia.Erp.MobileApp.Models.SaftV4;
using SolRIA.SaftAnalyser.Interfaces;

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
	}
}
