using Syncfusion.SfSkinManager;

namespace SolRIA.SaftAnalyser.Views
{
    /// <summary>
    /// Interaction logic for SaftTaxes.xaml
    /// </summary>
    public partial class SaftTaxes : PageBase
	{
		public SaftTaxes()
		{
			InitializeComponent();
            SfSkinManager.SetVisualStyle(dataGridTaxes, VisualStyles.Blend);
        }
    }
}
