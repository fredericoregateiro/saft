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

			//init commands
			OpenInvoicesCommand = new DelegateCommand(OnOpenInvoices);
		}

		public void Init(Header header)
		{
			Header = header;

			Errors = saftValidator.GetSaftErrors();
		}

		private Header header;
		public Header Header
		{
			get { return header; }
			set { SetProperty(ref header, value); }
		}

		private int errors;
		public int Errors
		{
			get { return errors; }
			set { SetProperty(ref errors, value); }
		}

		public DelegateCommand OpenInvoicesCommand { get; private set; }
		public virtual void OnOpenInvoices()
		{
			
		}
	}
}
