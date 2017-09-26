using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SolRIA.SaftAnalyser.Views
{
    /// <summary>
    /// Interaction logic for SaftInvoices.xaml
    /// </summary>
    public partial class SaftInvoices : Page
    {
        public SaftInvoices()
        {
            InitializeComponent();
        }

        private void dataGridInvoiceLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGridInvoices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
