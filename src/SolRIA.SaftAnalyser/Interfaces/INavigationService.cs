using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace SolRIA.SaftAnalyser.Interfaces
{
	public interface INavigationService
	{
		bool CanGoBack();
		void ClearHistory();
		void GoBack();
		bool Navigate(string pageToken, object parameter);
		bool Navigate(string pageToken);
		void RestoreSavedNavigation();
		void Suspending();

		void ClearLoadCompletedInvocationList();
		void ClearNavigatingInvocationList();

		event LoadCompletedEventHandler LoadCompleted;
		event NavigatingCancelEventHandler Navigating;
	}
}
