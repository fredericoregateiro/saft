using DryIoc;
using MaterialDesignThemes.Wpf;
using NLog;
using SolRIA.SaftAnalyser.Interfaces;
using SolRIA.SaftAnalyser.Mvvm;
using SolRIA.SaftAnalyser.Services;
using SolRIA.SaftAnalyser.ViewModels;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Navigation;

namespace SolRIA.SaftAnalyser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
	{
		static Logger logger = LogManager.GetCurrentClassLogger();

		public static readonly Container container = new Container();

		protected override void OnStartup(StartupEventArgs e)
		{
			Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-PT");
			Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-PT");
			FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(
						XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;

            //resolve all the viewmodels
            container.RegisterMany(new[] {
                typeof(HomeViewModel),
                typeof(SaftCustomersViewModel),
                typeof(SaftErrorsViewModel),
                typeof(SaftHeaderViewModel),
                typeof(SaftInvoicesSummaryViewModel),
                typeof(SaftInvoicesViewModel),
                typeof(SaftProductsViewModel),
                typeof(SaftSuppliersViewModel),
                typeof(SaftTaxesViewModel),
                typeof(SaftValidationResumeViewModel),
            });

            //resolve the viewmodels
            ViewModelLocationProvider.SetDefaultViewModelFactory((type) => container.Resolve(type));

            Current.MainWindow = new MainWindow();
            //show the main window
            Current.MainWindow.Show();

			base.OnStartup(e);
		}

		private void Current_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
		{
			logger.Error(e.Exception);
			Exception inner = e.Exception.InnerException;
			while (inner != null)
			{
				logger.Error(inner);
				inner = inner.InnerException;
			}

			e.Handled = true;
		}

		internal static void ConfigureUnityContainer(NavigationService navService, Snackbar mainSnackbar, DialogHost dialogHost)
		{
			ILogService logService = new LogService(logger);
			INavigationService navigationService = new SimpleNavigationService(navService);

			container.UseInstance(logService);
			container.UseInstance<IDataRepository>(new DataRepository(logService));

			container.UseInstance(navigationService);
			container.UseInstance<IFileService>(new FileService());
			container.UseInstance<IMessageService>(new MessageService(mainSnackbar, dialogHost));
			container.UseInstance<ISaftValidator>(new SaftValidator());

			//go to home
			navigationService.Navigate(PagesIds.HOME);
		}
	}
}
