using Syncfusion.SfSkinManager;
using System.Windows.Controls;

namespace SolRIA.SaftAnalyser.Views
{
    /// <summary>
    /// Interaction logic for SaftInvoicesSummary.xaml
    /// </summary>
    public partial class SaftInvoicesSummary : PageBase
    {
        public SaftInvoicesSummary()
        {
            InitializeComponent();
            SfSkinManager.SetVisualStyle(dataGridInvoices, VisualStyles.Blend);
            SfSkinManager.SetVisualStyle(dataGridInvoiceLines, VisualStyles.Blend);
            SfSkinManager.SetVisualStyle(dataGridTaxes, VisualStyles.Blend);
        }

        private void dataGridInvoiceLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGridInvoices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
