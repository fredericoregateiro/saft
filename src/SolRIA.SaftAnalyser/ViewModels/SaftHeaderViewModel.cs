using Prism.Mvvm;
using SolRia.Erp.MobileApp.Models.SaftV4;
using SolRIA.SaftAnalyser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolRIA.SaftAnalyser.ViewModels
{
	public class SaftHeaderViewModel : BindableBase
	{
		INavigationService navService;
		public SaftHeaderViewModel(INavigationService navService)
		{
			this.navService = navService;

			navService.LoadCompleted += NavService_LoadCompleted;
		}

		private void NavService_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
		{
			Cabecalho = OpenedFileInstance.SaftFile.Header;
		}

		private Header cabecalho;
		public Header Cabecalho
		{
			get { return cabecalho; }
			set { SetProperty(ref cabecalho, value); }
		}
	}
}
