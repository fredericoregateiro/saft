using SolRIA.SaftAnalyser.Interfaces;
using System;
using System.Windows.Navigation;

namespace SolRIA.SaftAnalyser.Services
{
	public class SimpleNavigationService : INavigationService
	{
		private NavigationService navigationService;
		//private IMainWindow mainWindow;

		public SimpleNavigationService(NavigationService nativeService/*, IMainWindow mainWindow*/)
		{
			navigationService = nativeService;
			//this.mainWindow = mainWindow;
			navigationService.LoadCompleted += NavigationService_LoadCompleted;
			navigationService.Navigating += NavigationService_Navigating;
		}

		private void NavigationService_Navigating(object sender, NavigatingCancelEventArgs e)
		{
			Navigating?.Invoke(sender, e);
		}

		private void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
		{
			LoadCompleted?.Invoke(sender, e);
		}

		public event LoadCompletedEventHandler LoadCompleted;
		public event NavigatingCancelEventHandler Navigating;

		public void ClearLoadCompletedInvocationList()
		{
			if (LoadCompleted != null)
			{
				Delegate[] associatedDelegates = LoadCompleted.GetInvocationList();

				foreach (var d in associatedDelegates)
					LoadCompleted -= (d as LoadCompletedEventHandler);
			}
		}

		public void ClearNavigatingInvocationList()
		{
			if (Navigating != null)
			{
				Delegate[] associatedDelegates = Navigating.GetInvocationList();

				foreach (var d in associatedDelegates)
					Navigating -= (d as NavigatingCancelEventHandler);
			}
		}

		public bool CanGoBack()
		{
			return navigationService.CanGoBack;
		}

		public void ClearHistory()
		{
			throw new NotImplementedException();
		}

		public void GoBack()
		{			
			navigationService.GoBack();
		}

		public bool Navigate(string pageToken, object parameter)
		{
			return navigationService.Navigate(new Uri($"Views/{pageToken}.xaml", UriKind.Relative), parameter);
		}

		public bool Navigate(string pageToken)
		{
			return Navigate(pageToken, null);
		}

		public void RestoreSavedNavigation()
		{
			throw new NotImplementedException();
		}

		public void Suspending()
		{
			throw new NotImplementedException();
		}
	}
}
