using Syncfusion.SfSkinManager;

namespace SolRIA.SaftAnalyser.Views
{
	/// <summary>
	/// Interaction logic for SaftCustomers.xaml
	/// </summary>
	public partial class SaftCustomers : PageBase
	{
		public SaftCustomers()
		{
			InitializeComponent();
            SfSkinManager.SetVisualStyle(dataGridCustomers, VisualStyles.Blend);
        }
    }
}
