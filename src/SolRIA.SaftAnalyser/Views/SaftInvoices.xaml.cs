using Syncfusion.SfSkinManager;
using System.Windows.Controls;

namespace SolRIA.SaftAnalyser.Views
{
    /// <summary>
    /// Interaction logic for SaftInvoices.xaml
    /// </summary>
    public partial class SaftInvoices : PageBase
    {
        public SaftInvoices()
        {
            InitializeComponent();
            SfSkinManager.SetVisualStyle(dataGridInvoices, VisualStyles.Blend);
            SfSkinManager.SetVisualStyle(dataGridInvoiceLines, VisualStyles.Blend);
        }

        private void dataGridInvoiceLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGridInvoices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
