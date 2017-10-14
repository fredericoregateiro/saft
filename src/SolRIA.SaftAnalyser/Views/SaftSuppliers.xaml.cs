using Syncfusion.SfSkinManager;

namespace SolRIA.SaftAnalyser.Views
{
    /// <summary>
    /// Interaction logic for SaftSuppliers.xaml
    /// </summary>
    public partial class SaftSuppliers : PageBase
	{
		public SaftSuppliers()
		{
			InitializeComponent();
            SfSkinManager.SetVisualStyle(dataGridSuppliers, VisualStyles.Blend);
        }
    }
}
