using Prism.Commands;
using Prism.Mvvm;
using SolRia.Erp.MobileApp.Models.SaftV4;
using SolRIA.SaftAnalyser.Interfaces;

namespace SolRIA.SaftAnalyser.ViewModels
{
	public class SaftValidationResumeViewModel : BindableBase
	{
		INavigationService navService;
		ISaftValidator saftValidator;
		public SaftValidationResumeViewModel(INavigationService navService, ISaftValidator saftValidator)
		{
			//injected properties
			this.navService = navService;
			this.saftValidator = saftValidator;

			OpenHeaderCommand = new DelegateCommand(OnOpenHeader);
		}

		public void Init(Header header)
		{
			Header = header;

			TotalErrors = saftValidator.GetSaftErrors();
			HeaderErrors = saftValidator.GetSaftHeaderErrors();
		}

		private Header header;
		public Header Header
		{
			get { return header; }
			set { SetProperty(ref header, value); }
		}

		private int totalerrors;
		public int TotalErrors
		{
			get { return totalerrors; }
			set { SetProperty(ref totalerrors, value); }
		}

		private int headerErrors;
		public int HeaderErrors
		{
			get { return headerErrors; }
			set { SetProperty(ref headerErrors, value); }
		}

		public DelegateCommand OpenHeaderCommand { get; private set; }
		public virtual void OnOpenHeader()
		{
			navService.Navigate(PagesIds.SAFT_HEADER);
		}
	}
}
