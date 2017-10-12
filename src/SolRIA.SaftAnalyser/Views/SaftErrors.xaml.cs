using Syncfusion.SfSkinManager;

namespace SolRIA.SaftAnalyser.Views
{
    /// <summary>
    /// Interaction logic for SaftErrors.xaml
    /// </summary>
    public partial class SaftErrors : PageBase
	{
		public SaftErrors()
		{
			InitializeComponent();
            SfSkinManager.SetVisualStyle(dataGridErrors, VisualStyles.Blend);
        }
    }
}
