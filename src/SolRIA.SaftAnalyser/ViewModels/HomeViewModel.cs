using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using SolRIA.SaftAnalyser.Interfaces;
using SolRIA.SaftAnalyser.Views;
using System;

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
		}

		public DelegateCommand OpenSaftFileCommand { get; private set; }
		public async virtual void OnOpenSaftFile()
		{
			string file = fileService.ChooseFile(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "Ficheiros XMl", "(*.xml)|*.xml");

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

		private void OpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
		{

		}

		private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
		{
			navService.Navigate(PagesIds.SAFT_HEADER);
		}
	}
}
