using OfficeOpenXml;
using OfficeOpenXml.Table;
using Prism.Commands;
using Prism.Mvvm;
using SolRia.Erp.MobileApp.Models.SaftV4;
using SolRIA.SaftAnalyser.Interfaces;
using SolRIA.SaftAnalyser.Logic.Models;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace SolRIA.SaftAnalyser.ViewModels
{
    public class SaftCustomersViewModel : BindableBase
    {
        INavigationService navService;
        IMessageService messageService;
        IFileService fileService;
        public SaftCustomersViewModel(INavigationService navService, IMessageService messageService, IFileService fileService)
        {
            this.navService = navService;
            this.messageService = messageService;
            this.fileService = fileService;

            SearchCommand = new DelegateCommand(OnSearch);
            DoPrintCommand = new DelegateCommand(OnPrint);
            GenerateScriptCommand = new DelegateCommand(OnGenerateScript);

            navService.LoadCompleted += NavService_LoadCompleted;
        }

        private void NavService_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (OpenedFileInstance.Instance.SaftFile.MasterFiles != null)
                Customers = OpenedFileInstance.Instance.SaftFile.MasterFiles.Customer;

            messageService.CloseDialog();
        }

        private Customer[] customers;
        public Customer[] Customers
        {
            get => customers; set => SetProperty(ref customers, value);
        }

        private string filter;
        public string Filter
        {
            get => filter; set => SetProperty(ref filter, value, FilterCustomers);
        }

        //SearchCommand
        public DelegateCommand SearchCommand { get; private set; }
        public virtual void OnSearch()
        {
            FilterCustomers();
        }

        private void FilterCustomers()
        {
            if (Customers != null)
            {
                if (string.IsNullOrEmpty(filter))
                    Customers = OpenedFileInstance.Instance.SaftFile.MasterFiles.Customer;
                else
                {
                    Customers = (
                        from c in OpenedFileInstance.Instance.SaftFile.MasterFiles.Customer
                        where (!string.IsNullOrEmpty(c.CompanyName) && c.CompanyName.IndexOf(filter, System.StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (!string.IsNullOrEmpty(c.CustomerID) && c.CustomerID.IndexOf(filter, System.StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (!string.IsNullOrEmpty(c.CustomerTaxID) && c.CustomerTaxID.IndexOf(filter, System.StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (!string.IsNullOrEmpty(c.Email) && c.Email.IndexOf(filter, System.StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (!string.IsNullOrEmpty(c.Telephone) && c.Telephone.IndexOf(filter, System.StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (!string.IsNullOrEmpty(c.Website) && c.Website.IndexOf(filter, System.StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (!string.IsNullOrEmpty(c.Contact) && c.Contact.IndexOf(filter, System.StringComparison.OrdinalIgnoreCase) >= 0)
                        select c).ToArray();
                }
            }
        }

        public DelegateCommand GenerateScriptCommand { get; private set; }
        private void OnGenerateScript()
        {
            //read the zip codes if the local file exists
            ZipCode[] zipcodes = ZipCode.ParseCsv(fileService.ReadFileLines(fileService.GetLocalFileName("zipcodes.csv")));
            int customerZipCodeId = 1;

            int idCustomer = 10;
            int idAddress = 10;
            int idContact = 10;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("--Script gerado para SolRIA POS");
            sql.AppendLine("--Este script precisa de ser editado por um funcionário da SolRIA");
            foreach (var customer in Customers)
            {
                //find the customer address zip code
                if (zipcodes != null && zipcodes.Length > 0 && customer.BillingAddress != null && string.IsNullOrWhiteSpace(customer.BillingAddress.PostalCode) == false)
                {
                    var postalCode = customer.BillingAddress.PostalCode.Split('-');
                    if (postalCode != null && postalCode.Length == 2)
                    {
                        var customerZipCodes = zipcodes.Where(c => c.Code == customer.BillingAddress.PostalCode);

                        if (customerZipCodes == null || customerZipCodes.Count() == 0)
                            customerZipCodeId = 1;
                        else if (customerZipCodes.Count() == 1)
                            customerZipCodeId = customerZipCodes.First().Id;
                        else
                        {
                            sql.AppendLine("--multiple zip codes: " + string.Join(",", customerZipCodes.Select(z => z.Id)));
                            customerZipCodeId = 1;
                        }
                    }
                }
                else
                    customerZipCodeId = 1;

                sql.AppendLine(
                    $"INSERT INTO Address (Id,DeviceId,ZipCodeId,BuildingNumber) VALUES ({idAddress},$DeviceId,{customerZipCodeId},{customer.BillingAddress?.BuildingNumber ?? "''"});");

                sql.AppendLine(
                    $"INSERT INTO Contact (Id,DeviceId,Email,BuildingNumber,Fax,Telephone,Website) VALUES ({idContact},$DeviceId,{customer.Email ?? "''"},{customer.Fax ?? "''"},{customer.Telephone ?? "''"},{customer.Website ?? "''"});");

                sql.AppendLine(
                    $"INSERT INTO Customer (Id,DeviceId,TaxRegistrationNumber,Name,BillingAddressId,BillingAddressDeviceId,ContactId,ContactDeviceId) VALUES ({idCustomer},$DeviceId,{customer.CustomerTaxID},{customer.CompanyName},{idAddress},$DeviceId,{idContact},$DeviceId);");

                sql.AppendLine();
                idCustomer++;
                idAddress++;
                idContact++;
            }

            string file = fileService.GenerateRandonFileName(".txt");
            fileService.WriteToFile(file, sql.ToString());

            Process.Start(file);
        }

        public DelegateCommand DoPrintCommand { get; private set; }
        private void OnPrint()
        {
            if (Customers != null && Customers.Length > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Código", typeof(string));
                dt.Columns.Add("Nº conta", typeof(string));
                dt.Columns.Add("NIF", typeof(string));
                dt.Columns.Add("Nome", typeof(string));
                dt.Columns.Add("Contacto", typeof(string));
                dt.Columns.Add("Telefone", typeof(string));
                dt.Columns.Add("Fax", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Website", typeof(string));
                dt.Columns.Add("Autofacturação", typeof(string));
                foreach (var c in Customers)
                {
                    dt.Rows.Add(c.CustomerID, c.AccountID, c.CustomerTaxID, c.CompanyName, c.Contact, c.Telephone, c.Fax, c.Email, c.Website, c.SelfBillingIndicator);
                }

                ExcelPackage pck = new ExcelPackage();
                var wsEnum = pck.Workbook.Worksheets.Add("SolRIA | SAFT");
                //Load the collection starting from cell A1...
                wsEnum.Cells["A1"].LoadFromDataTable(dt, true, TableStyles.Medium9);
                wsEnum.Cells[wsEnum.Dimension.Address].AutoFitColumns();

                //...and save
                var fi = new FileInfo(fileService.GenerateRandonFileName());
                if (fi.Exists)
                    fi.Delete();

                pck.SaveAs(fi);

                Process.Start(fi.FullName);
            }
        }
    }
}
