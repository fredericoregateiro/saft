using System;
using System.Windows;

namespace SolRIA.SaftAnalyser
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		protected override void OnInitialized(EventArgs e)
		{
			//init the navigation service
			App.ConfigureUnityContainer(navigationFrame.NavigationService, MainSnackbar);

			base.OnInitialized(e);
		}

		private void Card_DropSAFT(object sender, DragEventArgs e)
		{

		}

		private void Card_DropStocks(object sender, DragEventArgs e)
		{

		}

		private void Card_DropTransport(object sender, DragEventArgs e)
		{

		}
	}
}
