using OfficeOpenXml;
using OfficeOpenXml.Table;
using SolRia.Erp.MobileApp.Models.SaftV4;
using SolRIA.SaftAnalyser.Interfaces;
using SolRIA.SaftAnalyser.Logic.Models;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using SolRIA.SaftAnalyser.Mvvm;

namespace SolRIA.SaftAnalyser.ViewModels
{
    public class SaftSuppliersViewModel : BindableBase
    {
        INavigationService navService;
        IMessageService messageService;
        IFileService fileService;
        public SaftSuppliersViewModel(INavigationService navService, IMessageService messageService, IFileService fileService)
        {
            this.navService = navService;
            this.messageService = messageService;
            this.fileService = fileService;

            DoPrintCommand = new DelegateCommand(OnPrint);
            GenerateScriptCommand = new DelegateCommand(OnGenerateScript);

            navService.LoadCompleted += NavService_LoadCompleted;
        }

        private void NavService_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (OpenedFileInstance.Instance.SaftFile.MasterFiles != null)
                suppliersBack = OpenedFileInstance.Instance.SaftFile.MasterFiles.Supplier;

            Suppliers = suppliersBack;
            messageService.CloseDialog();
        }

        Supplier[] suppliersBack;
        Supplier[] suppliers;
        public Supplier[] Suppliers
        {
            get => suppliers; set => SetProperty(ref suppliers, value);
        }

        string filter;
        public string Filter
        {
            get => filter;
            set
            {
                SetProperty(ref filter, value);

                if (string.IsNullOrEmpty(filter))
                    Suppliers = suppliersBack;
                else
                {
                    Suppliers = (from c in suppliersBack
                                 where !string.IsNullOrEmpty(c.AccountID) && c.AccountID.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 !string.IsNullOrEmpty(c.CompanyName) && c.CompanyName.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 !string.IsNullOrEmpty(c.Contact) && c.Contact.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 !string.IsNullOrEmpty(c.Email) && c.Email.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 !string.IsNullOrEmpty(c.Fax) && c.Fax.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 !string.IsNullOrEmpty(c.SupplierID) && c.SupplierID.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 !string.IsNullOrEmpty(c.SupplierTaxID) && c.SupplierTaxID.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 !string.IsNullOrEmpty(c.Telephone) && c.Telephone.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0 ||
                                 !string.IsNullOrEmpty(c.Website) && c.Website.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0
                                select c).ToArray();
                }
            }
        }

        public DelegateCommand GenerateScriptCommand { get; private set; }
        private void OnGenerateScript()
        {
            //read the zip codes if the local file exists
            ZipCode[] zipcodes = ZipCode.ParseCsv(fileService.ReadFileLines(fileService.GetLocalFileName("zipcodes.csv")));
            int supplierZipCodeId = 1;

            int idsupplier = 10;
            int idAddress = 1000;
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("--Script gerado para SolRIA POS");
            sql.AppendLine("--Este script precisa de ser editado por um funcionário da SolRIA");
            foreach (var supplier in Suppliers)
            {
                //find the customer address zip code
                if (zipcodes != null && zipcodes.Length > 0 && supplier.BillingAddress != null && string.IsNullOrWhiteSpace(supplier.BillingAddress.PostalCode) == false)
                {
                    var postalCode = supplier.BillingAddress.PostalCode.Split('-');
                    if (postalCode != null && postalCode.Length == 2)
                    {
                        var supplierZipCodes = zipcodes.Where(c => c.Code == supplier.BillingAddress.PostalCode);

                        if (supplierZipCodes == null || supplierZipCodes.Count() == 0)
                            supplierZipCodeId = 1;
                        else if (supplierZipCodes.Count() == 1)
                            supplierZipCodeId = supplierZipCodes.First().Id;
                        else
                        {
                            sql.AppendLine("--multiple zip codes: " + string.Join(",", supplierZipCodes.Select(z => z.Id)));
                            supplierZipCodeId = 1;
                        }
                    }
                }
                else
                    supplierZipCodeId = 1;

                sql.AppendLine(
                    $"INSERT INTO Address (Id,DeviceId,ZipCodeId,BuildingNumber) VALUES ({idAddress},$DeviceId,{supplierZipCodeId},{supplier.BillingAddress?.BuildingNumber ?? "''"});");

                sql.AppendLine(
                    $"INSERT INTO Supplier (Id,DeviceId,SupplierTaxID,Name,IsActive,AddressId,AddressDeviceId) VALUES ({idsupplier},$DeviceId,{supplier.SupplierTaxID},{supplier.CompanyName},1,{idAddress},$DeviceId);");

                idAddress++;
                idsupplier++;
            }

            string file = fileService.GenerateRandonFileName(".txt");
            fileService.WriteToFile(file, sql.ToString());

            Process.Start(file);
        }

        public DelegateCommand DoPrintCommand { get; private set; }
        private void OnPrint()
        {
            if (Suppliers != null && Suppliers.Length > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Código fornecedor", typeof(string));
                dt.Columns.Add("Nº conta", typeof(string));
                dt.Columns.Add("NIF", typeof(string));
                dt.Columns.Add("Nome", typeof(DateTime));
                dt.Columns.Add("Contacto", typeof(string));
                dt.Columns.Add("Telefone", typeof(string));
                dt.Columns.Add("Fax", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Website", typeof(string));
                dt.Columns.Add("Autofacturação", typeof(string));

                foreach (var p in Suppliers)
                {
                    dt.Rows.Add(p.SupplierID, p.AccountID, p.SupplierTaxID, p.CompanyName, p.Contact, p.Telephone, p.Fax, p.Email, p.Website, p.SelfBillingIndicator);
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
