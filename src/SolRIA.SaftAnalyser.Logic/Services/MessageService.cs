using MaterialDesignThemes.Wpf;
using SolRIA.SaftAnalyser.Interfaces;
using System;

namespace SolRIA.SaftAnalyser.Services
{
	public class MessageService : IMessageService
	{
		Snackbar mainSnackbar;
		DialogHost dialogHost;
		public MessageService(Snackbar mainSnackbar, DialogHost dialogHost)
		{
			this.mainSnackbar = mainSnackbar;
			this.dialogHost = dialogHost;
		}

		public void ShowSnackBarMessage(string message)
		{
			mainSnackbar.MessageQueue.Enqueue(message);
		}

		public void ShowDialog(object content, DialogOpenedEventHandler openedEventHandler, DialogClosingEventHandler closingEventHandler)
		{
			DialogHost.Show(content, "RootDialog", openedEventHandler, closingEventHandler);
		}

		public void CloseDialog()
		{
			dialogHost.IsOpen = false;
		}

		public Action<object> ClosingDialog { get; set; }

		private void OpenedEventHandler(object sender, DialogOpenedEventArgs eventargs)
		{
			
		}

		private void ClosingEventHandler(object sender, DialogClosingEventArgs eventArgs)
		{
			ClosingDialog?.Invoke(eventArgs.Parameter);
		}
	}
}
