using Prism.Mvvm;
using SolRia.Erp.MobileApp.Models.SaftV4;
using SolRIA.SaftAnalyser.Interfaces;

namespace SolRIA.SaftAnalyser.ViewModels
{
	public class SaftHeaderViewModel : BindableBase
	{
		INavigationService navService;
		IMessageService messageService;
		public SaftHeaderViewModel(INavigationService navService, IMessageService messageService)
		{
			this.navService = navService;
			this.messageService = messageService;

			navService.LoadCompleted += NavService_LoadCompleted;
		}

		private void NavService_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
		{
			Cabecalho = OpenedFileInstance.Instance.SaftFile.Header;
			messageService.CloseDialog();
		}

		private Header cabecalho;
		public Header Cabecalho
		{
			get { return cabecalho; }
			set { SetProperty(ref cabecalho, value); }
		}
	}
}
