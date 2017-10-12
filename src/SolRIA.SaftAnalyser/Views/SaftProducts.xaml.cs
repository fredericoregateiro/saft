using Syncfusion.SfSkinManager;

namespace SolRIA.SaftAnalyser.Views
{
    /// <summary>
    /// Interaction logic for SaftProducts.xaml
    /// </summary>
    public partial class SaftProducts : PageBase
	{
		public SaftProducts()
		{
			InitializeComponent();
            SfSkinManager.SetVisualStyle(dataGridProducts, VisualStyles.Blend);
        }
    }
}
