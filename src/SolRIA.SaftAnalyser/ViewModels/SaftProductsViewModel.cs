using OfficeOpenXml;
using OfficeOpenXml.Table;
using Prism.Commands;
using Prism.Mvvm;
using SolRia.Erp.MobileApp.Models.SaftV4;
using SolRIA.SaftAnalyser.Interfaces;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace SolRIA.SaftAnalyser.ViewModels
{
    public class SaftProductsViewModel : BindableBase
    {
        INavigationService navService;
        IMessageService messageService;
        public SaftProductsViewModel(INavigationService navService, IMessageService messageService)
        {
            this.navService = navService;
            this.messageService = messageService;

            DoPrintCommand = new DelegateCommand(OnPrint);

            navService.LoadCompleted += NavService_LoadCompleted;
        }

        private void NavService_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (OpenedFileInstance.Instance.SaftFile.MasterFiles != null)
                productsBack = OpenedFileInstance.Instance.SaftFile.MasterFiles.Product;

            Products = productsBack;
            messageService.CloseDialog();
        }

        Product[] productsBack;

        Product[] products;
        public Product[] Products
        {
            get => products;
            set => SetProperty(ref products, value);
        }

        Product product;
        public Product Product
        {
            get => product;
            set => SetProperty(ref product, value);
        }

        string filter;
        public string Filter
        {
            get { return filter; }
            set
            {
                SetProperty(ref filter, value);

                if (string.IsNullOrEmpty(filter))
                    Products = productsBack;
                else
                {
                    Products = (from c in productsBack
                                where !string.IsNullOrEmpty(c.ProductCode) && c.ProductCode.IndexOf(filter, System.StringComparison.OrdinalIgnoreCase) >= 0 ||
                                !string.IsNullOrEmpty(c.ProductDescription) && c.ProductDescription.IndexOf(filter, System.StringComparison.OrdinalIgnoreCase) >= 0 ||
                                !string.IsNullOrEmpty(c.ProductGroup) && c.ProductGroup.IndexOf(filter, System.StringComparison.OrdinalIgnoreCase) >= 0 ||
                                !string.IsNullOrEmpty(c.ProductNumberCode) && c.ProductNumberCode.IndexOf(filter, System.StringComparison.OrdinalIgnoreCase) >= 0 ||
                                c.ProductType.ToString().IndexOf(filter, System.StringComparison.OrdinalIgnoreCase) >= 0
                                select c).ToArray();
                }
            }
        }

        public DelegateCommand DoPrintCommand { get; private set; }
        private void OnPrint()
        {
            if (Products != null && Products.Length > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Tipo", typeof(string));
                dt.Columns.Add("Código", typeof(string));
                dt.Columns.Add("Grupo", typeof(string));
                dt.Columns.Add("Código barras", typeof(string));
                dt.Columns.Add("Descrição", typeof(string));
                foreach (var product in Products)
                {
                    dt.Rows.Add(product.ProductType, product.ProductCode, product.ProductGroup, product.ProductNumberCode, product.ProductDescription);
                }

                ExcelPackage pck = new ExcelPackage();
                var wsEnum = pck.Workbook.Worksheets.Add("SolRIA | SAFT");
                //Load the collection starting from cell A1...
                wsEnum.Cells["A1"].LoadFromDataTable(dt, true, TableStyles.Medium9);
                wsEnum.Cells[wsEnum.Dimension.Address].AutoFitColumns();

                //...and save
                var fi = new FileInfo(Path.GetTempPath() + Path.GetRandomFileName() + ".xlsx");
                if (fi.Exists)
                    fi.Delete();

                pck.SaveAs(fi);

                Process.Start(fi.FullName);
            }
        }
    }
}
