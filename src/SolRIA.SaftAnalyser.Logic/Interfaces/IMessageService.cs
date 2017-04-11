using MaterialDesignThemes.Wpf;

namespace SolRIA.SaftAnalyser.Interfaces
{
	public interface IMessageService
	{
		void ShowSnackBarMessage(string message);
		void ShowDialog(object content, DialogOpenedEventHandler openedEventHandler, DialogClosingEventHandler closingEventHandler);
	}
}
