using SolRIA.SaftAnalyser.Mvvm;
using System.Windows.Controls;

namespace SolRIA.SaftAnalyser
{
    public abstract partial class PageBase : Page
	{
		public PageBase()
		{
            ViewModelLocator.SetAutoWireViewModel(this, true);
        }
    }
}
