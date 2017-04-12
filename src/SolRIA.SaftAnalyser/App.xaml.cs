using MaterialDesignThemes.Wpf;
using Microsoft.Practices.Unity;
using NLog;
using Prism.Mvvm;
using SolRIA.SaftAnalyser.Interfaces;
using SolRIA.SaftAnalyser.Services;
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

		public static readonly IUnityContainer container = new UnityContainer();

		protected override void OnStartup(StartupEventArgs e)
		{
			Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-PT");
			Thread.CurrentThread.CurrentUICulture = new CultureInfo("pt-PT");
			FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(
						XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

			Application.Current.DispatcherUnhandledException += Current_DispatcherUnhandledException;

			//resolve the viewmodels
			ViewModelLocationProvider.SetDefaultViewModelFactory((type) => container.Resolve(type));

			App.Current.MainWindow = new MainWindow();
			//show the main window
			App.Current.MainWindow.Show();

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

			container.RegisterInstance<ILogService>(logService);
			container.RegisterInstance<IDataRepository>(new DataRepository(logService));

			container.RegisterInstance<INavigationService>(navigationService);
			container.RegisterInstance<IFileService>(new FileService());
			container.RegisterInstance<IMessageService>(new MessageService(mainSnackbar, dialogHost));
			container.RegisterInstance<ISaftValidator>(new SaftValidator());

			//go to home
			navigationService.Navigate(PagesIds.HOME);
		}
	}
}
