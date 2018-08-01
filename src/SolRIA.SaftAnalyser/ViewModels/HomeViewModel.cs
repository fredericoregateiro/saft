using MaterialDesignThemes.Wpf;
using SolRIA.SaftAnalyser.Interfaces;
using SolRIA.SaftAnalyser.Mvvm;
using SolRIA.SaftAnalyser.Views;
using System;
using System.IO;
using System.Linq;

namespace SolRIA.SaftAnalyser.ViewModels
{
    public class HomeViewModel : BindableBase
	{
		IFileService fileService;
		INavigationService navService;
		IMessageService messageService;
		ISaftValidator saftValidator;
		public HomeViewModel(IFileService fileService, INavigationService navService, IMessageService messageService, ISaftValidator saftValidator)
		{
			//injected properties
			this.fileService = fileService;
			this.navService = navService;
			this.messageService = messageService;
			this.saftValidator = saftValidator;

			//init commands
			OpenSaftFileCommand = new DelegateCommand(OnOpenSaftFile);
            OpenStockFileCommand = new DelegateCommand(OnOpenStockFile);
        }

		public DelegateCommand OpenSaftFileCommand { get; private set; }
		public async void OnOpenSaftFile()
		{
			string file = fileService.ChooseFile(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Ficheiros XMl", "(*.xml)|*.xml");

            if (string.IsNullOrWhiteSpace(file) || File.Exists(file) == false)
                return;

			await OpenedFileInstance.Instance.OpenSaftFile(file);

			if (OpenedFileInstance.Instance.SaftFile != null)
			{
				//init the view model
				SaftValidationResumeViewModel vm = new SaftValidationResumeViewModel(navService, saftValidator);
				vm.Init(OpenedFileInstance.Instance.SaftFile.Header);

				//init the view
				SaftValidationResume view = new SaftValidationResume
				{
					DataContext = vm
				};

				messageService.ShowDialog(view, OpenedEventHandler, ClosingEventHandler);
			}
			else
			{
				messageService.ShowSnackBarMessage("Não foi possível abrir o ficheiro seleccionado.");
			}
		}

        public DelegateCommand OpenStockFileCommand { get; private set; }
        public async void OnOpenStockFile()
        {
            string file = fileService.ChooseFile(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Ficheiros XMl", "(*.xml)|*.xml");

            if (string.IsNullOrWhiteSpace(file) || File.Exists(file) == false)
                return;

            await OpenedFileInstance.Instance.OpenStockFile(file);

            if(OpenedFileInstance.Instance.StockFile != null)
            {
                var sumProducts = OpenedFileInstance.Instance.StockFile.Stock.Sum(c => c.ClosingStockQuantity);
                var totalProducts = OpenedFileInstance.Instance.StockFile.Stock.Length;
                var totalDistinctProducts = OpenedFileInstance.Instance.StockFile.Stock.Distinct().Count();
            }
        }

        private void OpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
		{

		}

		private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
		{
			navService.Navigate(PagesIds.SAFT_HEADER);
		}
	}
}
