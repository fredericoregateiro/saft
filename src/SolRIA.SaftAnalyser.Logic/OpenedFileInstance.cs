using SolRia.Erp.MobileApp.Models.SaftV4;
using SolRIA.SaftAnalyser.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Linq;

namespace SolRIA.SaftAnalyser
{
    public class OpenedFileInstance
    {
        #region singleton

        private static volatile OpenedFileInstance instance;
        private static object syncRoot = new Object();
        public static OpenedFileInstance Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new OpenedFileInstance();
                    }
                }

                return instance;
            }
        }

        #endregion

        System.Globalization.CultureInfo enCulture = new System.Globalization.CultureInfo("en-US");

        public string SaftFileName { get; set; }
        public AuditFile SaftFile { get; set; }

        List<Error> mensagensErro;
        public List<Error> MensagensErro
        {
            get
            {
                if (mensagensErro == null)
                    mensagensErro = new List<Error>();
                return mensagensErro;
            }
            set { mensagensErro = value; }
        }

        /// <summary>
        /// Loads the SAFT file
        /// </summary>
        public async Task OpenSaftFile(string filename)
        {
            SaftFileName = filename;

            //deserialize the xml file
            SaftFile = await XmlSerializer.Deserialize<AuditFile>(SaftFileName);

            //init custom navigation properties validations
            if (SaftFile != null)
            {
                if (SaftFile.SourceDocuments != null && SaftFile.SourceDocuments.SalesInvoices != null && SaftFile.SourceDocuments.SalesInvoices.Invoice != null)
                {
                    //add the link from the line to the correspondent invoice
                    foreach (var invoice in SaftFile.SourceDocuments.SalesInvoices.Invoice)
                    {
                        foreach (var line in invoice.Line)
                        {
                            line.InvoiceNo = invoice.InvoiceNo;
                        }
                    }
                }

                if (SaftFile.SourceDocuments != null && SaftFile.SourceDocuments.MovementOfGoods != null && SaftFile.SourceDocuments.MovementOfGoods.StockMovement != null)
                {
                    //add the link from the line to the correspondent movement
                    foreach (var doc in SaftFile.SourceDocuments.MovementOfGoods.StockMovement)
                    {
                        foreach (var line in doc.Line)
                        {
                            line.DocNo = doc.DocumentNumber;
                        }
                    }
                }

                if (SaftFile.SourceDocuments != null && SaftFile.SourceDocuments.Payments != null && SaftFile.SourceDocuments.Payments.Payment != null)
                {
                    //add the link from the line to the correspondent payment
                    foreach (var payment in SaftFile.SourceDocuments.Payments.Payment)
                    {
                        foreach (var line in payment.Line)
                        {
                            line.DocNo = payment.PaymentRefNo;
                        }
                    }
                }

                if (SaftFile.SourceDocuments != null && SaftFile.SourceDocuments.WorkingDocuments != null && SaftFile.SourceDocuments.WorkingDocuments.WorkDocument != null)
                {
                    //add the link from the line to the correspondent invoice
                    foreach (var doc in SaftFile.SourceDocuments.WorkingDocuments.WorkDocument)
                    {
                        foreach (var line in doc.Line)
                        {
                            line.DocNo = doc.DocumentNumber;
                        }
                    }
                }

                //Do validations on fields
                ValidateHeader(SaftFile.Header);
                if (SaftFile.MasterFiles != null)
                {
                    ValidateCustomers(SaftFile.MasterFiles.Customer);
                    ValidateProducts(SaftFile.MasterFiles.Product);
                    ValidateSupplier(SaftFile.MasterFiles.Supplier);
                    ValidateTax(SaftFile.MasterFiles.TaxTable);
                }
                if (SaftFile.SourceDocuments != null && SaftFile.SourceDocuments.SalesInvoices != null)
                    ValidateInvoices(SaftFile.SourceDocuments.SalesInvoices);

                if (SaftFile.SourceDocuments != null && SaftFile.SourceDocuments.Payments != null)
                    ValidatePayments(SaftFile.SourceDocuments.Payments);

                if (SaftFile.SourceDocuments != null && SaftFile.SourceDocuments.MovementOfGoods != null)
                    ValidateMovementOfGoods(SaftFile.SourceDocuments.MovementOfGoods);

                if (SaftFile.SourceDocuments != null && SaftFile.SourceDocuments.WorkingDocuments != null)
                    ValidateWorkDocument(SaftFile.SourceDocuments.WorkingDocuments);

                //remove empty messages
                MensagensErro.RemoveAll(c => c == null || string.IsNullOrEmpty(c.Description));
            }
            else
            {
                //show error open file
                MensagensErro.Add(new Error { Description = "Erro ao abrir o ficheiro" });
            }
        }

        /// <summary>
        /// Validate the hashes in the file for the sales invoices
        /// </summary>
        public void ValidateHash()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += bw_DoWorkHash;
            bw.RunWorkerCompleted += bw_RunWorkerCompletedHash;
            bw.RunWorkerAsync(SaftFile);
        }
        /// <summary>
        /// Validate the hashes in the file for the working documents
        /// </summary>
        public void ValidateHashWD()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += bw_DoWorkHashWD;
            bw.RunWorkerCompleted += bw_RunWorkerCompletedHash;
            bw.RunWorkerAsync(SaftFile);
        }
        /// <summary>
        /// Validate the hashes in the file for the movement of goods
        /// </summary>
        public void ValidateHashMG()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += bw_DoWorkHashMG;
            bw.RunWorkerCompleted += bw_RunWorkerCompletedHash;
            bw.RunWorkerAsync(SaftFile);
        }

        /// <summary>
        /// Validate the saft file against the schema file
        /// </summary>
        public void ValidateSchema()
        {
            if (SaftFile != null && SaftFile.Header != null)
                ValidateSchema(SaftFile.Header.AuditFileVersion);
        }
        /// <summary>
        /// Validate the saft file against a specific schema file
        /// </summary>
        public void ValidateSchema(string fileversion)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += bw_DoWorkSchema;
            bw.RunWorkerCompleted += bw_RunWorkerCompletedSchema;
            bw.RunWorkerAsync(SaftFile);
        }


        /// <summary>
        /// Generate the hash with the provided private key for the sales invoices
        /// </summary>
        public void GenerateInvoiceHash()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += bw_DoWorkGenerateHash;
            bw.RunWorkerCompleted += bw_RunWorkerCompletedGenerateHash;
            bw.RunWorkerAsync(SaftFile);
        }
        /// <summary>
        /// Generate the hash with the provided private key for the working documents
        /// </summary>
        public void GenerateHashWD()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += bw_DoWorkGenerateHashWD;
            bw.RunWorkerCompleted += bw_RunWorkerCompletedGenerateHash;
            bw.RunWorkerAsync(SaftFile);
        }
        /// <summary>
        /// Generate the hash with the provided private key for the movement of goods
        /// </summary>
        public void GenerateHashMG()
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += bw_DoWorkGenerateHashMG;
            bw.RunWorkerCompleted += bw_RunWorkerCompletedGenerateHash;
            bw.RunWorkerAsync(SaftFile);
        }

        #region BackgroundWorker events
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (e.Cancelled == false && SaftFile != null)
            //	Mediator.Instance.NotifyColleaguesAsync<AuditFile>(MessageType.SAFT_FILE_OPENED, SaftFile);

            //if (MensagensErro != null && e.Cancelled == false)
            //	Mediator.Instance.NotifyColleaguesAsync<Error[]>(MessageType.ERROR_FOUND, MensagensErro.ToArray());
        }

        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            MensagensErro.Clear();

            //if (File.Exists(e.Argument.ToString()))
            //{
            //	SaftFile = XmlSerializer.Deserialize<AuditFile>(e.Argument.ToString());
            //	FileVersion = SaftFileVersion.V10301;

            //	if (SaftFile == null)
            //	{
            //		//try to open the old version
            //		Model.V2.AuditFile oldSaftFile = XmlSerializer.Deserialize<Model.V2.AuditFile>(e.Argument.ToString());
            //		//convert the old to the new version
            //		SaftFile = ConvertV2ToV3.Convert(oldSaftFile);
            //		FileVersion = SaftFileVersion.V10201;
            //	}
            //	if (SaftFile == null)
            //	{
            //		//try to open the old version
            //		Model.V1.AuditFile oldSaftFile = XmlSerializer.Deserialize<Model.V1.AuditFile>(e.Argument.ToString());
            //		//convert the old to the new version
            //		SaftFile = ConvertV1ToV3.Convert(oldSaftFile);
            //		FileVersion = SaftFileVersion.V10101;
            //	}
            //}
        }

        void bw_RunWorkerCompletedHash(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (MensagensErro != null && e.Cancelled == false)
            //	Mediator.Instance.NotifyColleaguesAsync<Error[]>(MessageType.SAFT_HASH_RESULTS, MensagensErro.ToArray());
        }

        void bw_DoWorkHash(object sender, DoWorkEventArgs e)
        {
            AuditFile auditFile = e.Argument as AuditFile;

            if (auditFile != null)
                ValidateSaftHash(auditFile);
        }
        void bw_DoWorkHashWD(object sender, DoWorkEventArgs e)
        {
            AuditFile auditFile = e.Argument as AuditFile;

            if (auditFile != null)
                ValidateSaftHashWD(auditFile);
        }
        void bw_DoWorkHashMG(object sender, DoWorkEventArgs e)
        {
            AuditFile auditFile = e.Argument as AuditFile;

            if (auditFile != null)
                ValidateSaftHashMG(auditFile);
        }

        void bw_RunWorkerCompletedSchema(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (e.Cancelled == false)
            //	Mediator.Instance.NotifyColleaguesAsync<Error[]>(MessageType.SAFT_SCHEMA_RESULTS, MensagensErro.ToArray());
        }

        void bw_DoWorkSchema(object sender, DoWorkEventArgs e)
        {
            ValidaEstruturaXSD(e.Argument.ToString());
        }

        void bw_RunWorkerCompletedGenerateHash(object sender, RunWorkerCompletedEventArgs e)
        {
            //if (e.Cancelled == false)
            //	Mediator.Instance.NotifyColleaguesAsync<AuditFile>(MessageType.INVOICE_LIST_CHANGED, SaftFile);
        }

        void bw_DoWorkGenerateHash(object sender, DoWorkEventArgs e)
        {
            GenerateHash(SaftFile);
        }
        void bw_DoWorkGenerateHashWD(object sender, DoWorkEventArgs e)
        {
            GenerateHashWD(SaftFile);
        }
        void bw_DoWorkGenerateHashMG(object sender, DoWorkEventArgs e)
        {
            GenerateHashMG(SaftFile);
        }
        #endregion BackgroundWorker events

        #region metodos privados

        /// <summary>
        /// Generate the hash filed for the sales invoices, base in a AuditFile object, the hash will be stored in HashTest field.
        /// </summary>
        void GenerateHash(AuditFile saftfile)
        {
            if (saftfile == null || saftfile.SourceDocuments == null || saftfile.SourceDocuments.SalesInvoices == null || saftfile.SourceDocuments.SalesInvoices.Invoice == null)
                return;

            object hasher = SHA1.Create();

            using (RSACryptoServiceProvider rsaCryptokey = new RSACryptoServiceProvider(1024))
            {
                rsaCryptokey.FromXmlString(GetRSAPrivateKey());

                StringBuilder toHash = new StringBuilder();

                var invoices =
                    (from i in saftfile.SourceDocuments.SalesInvoices.Invoice
                     orderby i.InvoiceNo
                     select i).ToArray();

                for (int i = 0; i < invoices.Length; i++)
                {
                    SourceDocumentsSalesInvoicesInvoice invoice = invoices[i];

                    bool usaHashAnterior = true;
                    if (i == 0 || invoice.InvoiceType != invoices[i - 1].InvoiceType || Convert.ToInt32(invoice.InvoiceNo.Split('/')[1]) != Convert.ToInt32(invoices[i - 1].InvoiceNo.Split('/')[1]) + 1)
                        usaHashAnterior = false;

                    FormatStringToHash(ref toHash, invoice, usaHashAnterior ? invoices[i - 1].Hash : "");

                    byte[] stringToHashBuffer = Encoding.UTF8.GetBytes(toHash.ToString());
                    byte[] r = rsaCryptokey.SignData(stringToHashBuffer, hasher);

                    invoice.HashTest = Convert.ToBase64String(r);
                }
            }
        }
        /// <summary>
        /// Generate the hash filed for the working documents, base in a AuditFile object, the hash will be stored in HashTest field.
        /// </summary>
        void GenerateHashWD(AuditFile saftfile)
        {
            if (saftfile == null || saftfile.SourceDocuments == null || saftfile.SourceDocuments.WorkingDocuments == null || saftfile.SourceDocuments.WorkingDocuments.WorkDocument == null)
                return;

            object hasher = SHA1.Create();

            using (RSACryptoServiceProvider rsaCryptokey = new RSACryptoServiceProvider(1024))
            {
                rsaCryptokey.FromXmlString(GetRSAPrivateKey());

                StringBuilder toHash = new StringBuilder();

                var workingDocs =
                   (from i in saftfile.SourceDocuments.WorkingDocuments.WorkDocument
                    orderby i.DocumentNumber
                    select i).ToArray();

                for (int i = 0; i < workingDocs.Length; i++)
                {
                    SourceDocumentsWorkingDocumentsWorkDocument doc = workingDocs[i];

                    bool usaHashAnterior = true;
                    if (i == 0 || doc.WorkType != workingDocs[i - 1].WorkType || Convert.ToInt32(doc.DocumentNumber.Split('/')[1]) != Convert.ToInt32(workingDocs[i - 1].DocumentNumber.Split('/')[1]) + 1)
                        usaHashAnterior = false;

                    FormatStringToHash(ref toHash, doc, usaHashAnterior ? workingDocs[i - 1].Hash : "");

                    byte[] stringToHashBuffer = Encoding.UTF8.GetBytes(toHash.ToString());
                    byte[] r = rsaCryptokey.SignData(stringToHashBuffer, hasher);

                    doc.HashTest = Convert.ToBase64String(r);
                }
            }
        }
        /// <summary>
        /// Generate the hash filed for the Movement of goods, base in a AuditFile object, the hash will be stored in HashTest field.
        /// </summary>
        void GenerateHashMG(AuditFile saftfile)
        {
            if (saftfile == null || saftfile.SourceDocuments == null || saftfile.SourceDocuments.MovementOfGoods == null || saftfile.SourceDocuments.MovementOfGoods.StockMovement == null)
                return;

            object hasher = SHA1.Create();

            using (RSACryptoServiceProvider rsaCryptokey = new RSACryptoServiceProvider(1024))
            {
                rsaCryptokey.FromXmlString(GetRSAPrivateKey());

                StringBuilder toHash = new StringBuilder();

                var movements =
                    (from i in saftfile.SourceDocuments.MovementOfGoods.StockMovement
                     orderby i.DocumentNumber
                     select i).ToArray();

                for (int i = 0; i < movements.Length; i++)
                {
                    SourceDocumentsMovementOfGoodsStockMovement doc = movements[i];

                    bool usaHashAnterior = true;
                    if (i == 0 || doc.MovementType != movements[i - 1].MovementType || Convert.ToInt32(doc.DocumentNumber.Split('/')[1]) != Convert.ToInt32(movements[i - 1].DocumentNumber.Split('/')[1]) + 1)
                        usaHashAnterior = false;

                    FormatStringToHash(ref toHash, doc, usaHashAnterior ? movements[i - 1].Hash : "");

                    byte[] stringToHashBuffer = Encoding.UTF8.GetBytes(toHash.ToString());
                    byte[] r = rsaCryptokey.SignData(stringToHashBuffer, hasher);

                    doc.HashTest = Convert.ToBase64String(r);
                }
            }
        }

        /// <summary>
        /// Format the correct invoice fields to the spesification of the hash field.
        /// </summary>
        /// <param name="toHash">StringBuilder that will contain the formated string.</param>
        /// <param name="invoice">The invoice.</param>
        /// <param name="hashAnterior">The string hash generated of the last invoice.</param>
        void FormatStringToHash(ref StringBuilder toHash, SourceDocumentsSalesInvoicesInvoice invoice, string hashAnterior)
        {
            toHash.Clear();
            toHash.AppendFormat("{0};{1};{2};{3};{4}"
                        , invoice.InvoiceDate.ToString("yyyy-MM-dd")
                        , invoice.SystemEntryDate.ToString("yyyy-MM-ddTHH:mm:ss")
                        , invoice.InvoiceNo
                        , invoice.DocumentTotals.GrossTotal.ToString("0.00", enCulture)
                        , hashAnterior);
        }
        void FormatStringToHash(ref StringBuilder toHash, SourceDocumentsWorkingDocumentsWorkDocument doc, string hashAnterior)
        {
            toHash.Clear();
            toHash.AppendFormat("{0};{1};{2};{3};{4}"
                        , doc.WorkDate.ToString("yyyy-MM-dd")
                        , doc.SystemEntryDate.ToString("yyyy-MM-ddTHH:mm:ss")
                        , doc.DocumentNumber
                        , doc.DocumentTotals.GrossTotal.ToString("0.00", enCulture)
                        , hashAnterior);
        }
        void FormatStringToHash(ref StringBuilder toHash, SourceDocumentsMovementOfGoodsStockMovement doc, string hashAnterior)
        {
            toHash.Clear();
            toHash.AppendFormat("{0};{1};{2};{3};{4}"
                        , doc.MovementDate.ToString("yyyy-MM-dd")
                        , doc.SystemEntryDate.ToString("yyyy-MM-ddTHH:mm:ss")
                        , doc.DocumentNumber
                        , doc.DocumentTotals.GrossTotal.ToString("0.00", enCulture)
                        , hashAnterior);
        }

        /// <summary>
        /// Reads the content of the saft file.
        /// </summary>
        /// <returns></returns>
        string GetSAFTContent()
        {
            if (!string.IsNullOrEmpty(SaftFileName) || !File.Exists(SaftFileName))
                File.ReadAllText(SaftFileName);

            return null;
        }

        /// <summary>
        /// Reads the public key file and returns the RSA public key
        /// </summary>
        /// <returns></returns>
        public string GetRSAPublicKey()
        {
            //if (File.Exists(PublicKeyFileName))
            //{
            //	string publickey = File.ReadAllText(PublicKeyFileName).Trim();

            //	if (publickey.StartsWith(RSAKeys.PEM_PUB_HEADER) && publickey.EndsWith(RSAKeys.PEM_PUB_FOOTER))
            //	{
            //		//this is a pem file
            //		RSAKeys rsa = new RSAKeys();
            //		rsa.DecodePEMKey(publickey);

            //		return rsa.PublicKey;
            //	}
            //	else
            //	{
            //		return publickey;
            //	}
            //}

            return string.Empty;
        }

        /// <summary>
        /// Reads the public key file and returns the RSA private key
        /// </summary>
        /// <returns></returns>
        public string GetRSAPrivateKey()
        {
            //if (File.Exists(PrivateKeyFileName))
            //{
            //	string privatekey = File.ReadAllText(PrivateKeyFileName).Trim();

            //	if (privatekey.StartsWith(RSAKeys.PEM_PRIV_HEADER) && privatekey.EndsWith(RSAKeys.PEM_PRIV_FOOTER))
            //	{
            //		//this is a pem file
            //		RSAKeys rsa = new RSAKeys();
            //		rsa.DecodePEMKey(privatekey);

            //		return rsa.PrivateKey;
            //	}
            //	else
            //	{
            //		return privatekey;
            //	}
            //}

            return string.Empty;
        }

        void ValidateSaftHash(AuditFile auditFile)
        {
            if (!File.Exists(SaftFileName) || auditFile == null || auditFile.SourceDocuments == null || auditFile.SourceDocuments.SalesInvoices == null || auditFile.SourceDocuments.SalesInvoices.Invoice == null)
                return;

            object hasher = SHA1.Create();

            using (RSACryptoServiceProvider rsaCryptokey = new RSACryptoServiceProvider(1024))
            {
                StringBuilder toHash = new StringBuilder();

                try
                {
                    rsaCryptokey.FromXmlString(GetRSAPublicKey());
                }
                catch (Exception ex)
                {
                    MensagensErro.Add(new Error { Description = string.Format("Não foi possível ler o ficheiro com a chave pública. {0}", ex.Message), TypeofError = typeof(HashResults) });
                    return;
                }

                var invoices =
                    (from i in auditFile.SourceDocuments.SalesInvoices.Invoice
                     orderby i.InvoiceNo
                     select i).ToArray();

                for (int i = 0; i < invoices.Length; i++)
                {
                    SourceDocumentsSalesInvoicesInvoice invoice = invoices[i];

                    bool usaHashAnterior = true;
                    if (i == 0 || invoice.InvoiceType != invoices[i - 1].InvoiceType || Convert.ToInt32(invoice.InvoiceNo.Split('/')[1]) != Convert.ToInt32(invoices[i - 1].InvoiceNo.Split('/')[1]) + 1)
                        usaHashAnterior = false;

                    FormatStringToHash(ref toHash, invoice, usaHashAnterior ? auditFile.SourceDocuments.SalesInvoices.Invoice[i - 1].Hash : "");

                    byte[] stringToHashBuffer = Encoding.UTF8.GetBytes(toHash.ToString());
                    byte[] hashBuffer = Convert.FromBase64String(invoice.Hash);

                    if (rsaCryptokey.VerifyData(stringToHashBuffer, hasher, hashBuffer) == false)
                        MensagensErro.Add(new Error { Value = invoice.InvoiceNo, TypeofError = typeof(SourceDocumentsSalesInvoicesInvoice), Field = "Hash", Description = string.Format("A assinatura do documento {0} é inválida.{1}", invoice.InvoiceNo, Environment.NewLine) });
                }
            }
        }
        void ValidateSaftHashWD(AuditFile auditFile)
        {
            if (!File.Exists(SaftFileName) || auditFile == null || auditFile.SourceDocuments == null || auditFile.SourceDocuments.WorkingDocuments == null || auditFile.SourceDocuments.WorkingDocuments.WorkDocument == null)
                return;

            object hasher = SHA1.Create();

            using (RSACryptoServiceProvider rsaCryptokey = new RSACryptoServiceProvider(1024))
            {
                StringBuilder toHash = new StringBuilder();

                try
                {
                    rsaCryptokey.FromXmlString(GetRSAPublicKey());
                }
                catch (Exception ex)
                {
                    MensagensErro.Add(new Error { Description = string.Format("Não foi possível ler o ficheiro com a chave pública. {0}", ex.Message), TypeofError = typeof(HashResults) });
                    return;
                }

                var workingDocs =
                    (from i in auditFile.SourceDocuments.WorkingDocuments.WorkDocument
                     orderby i.DocumentNumber
                     select i).ToArray();

                for (int i = 0; i < workingDocs.Length; i++)
                {
                    SourceDocumentsWorkingDocumentsWorkDocument doc = workingDocs[i];

                    bool usaHashAnterior = true;
                    if (i == 0 || doc.WorkType != workingDocs[i - 1].WorkType || Convert.ToInt32(doc.DocumentNumber.Split('/')[1]) != Convert.ToInt32(workingDocs[i - 1].DocumentNumber.Split('/')[1]) + 1)
                        usaHashAnterior = false;

                    FormatStringToHash(ref toHash, doc, usaHashAnterior ? workingDocs[i - 1].Hash : "");

                    byte[] stringToHashBuffer = Encoding.UTF8.GetBytes(toHash.ToString());
                    byte[] hashBuffer = Convert.FromBase64String(doc.Hash);

                    if (rsaCryptokey.VerifyData(stringToHashBuffer, hasher, hashBuffer) == false)
                        MensagensErro.Add(new Error { Value = doc.DocumentNumber, TypeofError = typeof(SourceDocumentsWorkingDocumentsWorkDocument), Field = "Hash", Description = string.Format("A assinatura do documento {0} é inválida.{1}", doc.DocumentNumber, Environment.NewLine) });
                }
            }
        }
        void ValidateSaftHashMG(AuditFile auditFile)
        {
            if (!File.Exists(SaftFileName) || auditFile == null || auditFile.SourceDocuments == null || auditFile.SourceDocuments.MovementOfGoods == null || auditFile.SourceDocuments.MovementOfGoods.StockMovement == null)
                return;

            object hasher = SHA1.Create();

            using (RSACryptoServiceProvider rsaCryptokey = new RSACryptoServiceProvider(1024))
            {
                StringBuilder toHash = new StringBuilder();

                try
                {
                    rsaCryptokey.FromXmlString(GetRSAPublicKey());
                }
                catch (Exception ex)
                {
                    MensagensErro.Add(new Error { Description = string.Format("Não foi possível ler o ficheiro com a chave pública. {0}", ex.Message), TypeofError = typeof(HashResults) });
                    return;
                }

                var movements =
                    (from i in auditFile.SourceDocuments.MovementOfGoods.StockMovement
                     orderby i.DocumentNumber
                     select i).ToArray();

                for (int i = 0; i < movements.Length; i++)
                {
                    SourceDocumentsMovementOfGoodsStockMovement doc = movements[i];

                    bool usaHashAnterior = true;
                    if (i == 0 || doc.MovementType != movements[i - 1].MovementType || Convert.ToInt32(doc.DocumentNumber.Split('/')[1]) != Convert.ToInt32(movements[i - 1].DocumentNumber.Split('/')[1]) + 1)
                        usaHashAnterior = false;

                    FormatStringToHash(ref toHash, doc, usaHashAnterior ? movements[i - 1].Hash : "");

                    byte[] stringToHashBuffer = Encoding.UTF8.GetBytes(toHash.ToString());
                    byte[] hashBuffer = Convert.FromBase64String(doc.Hash);

                    if (rsaCryptokey.VerifyData(stringToHashBuffer, hasher, hashBuffer) == false)
                        MensagensErro.Add(new Error { Value = doc.DocumentNumber, TypeofError = typeof(SourceDocumentsMovementOfGoodsStockMovement), Field = "Hash", Description = string.Format("A assinatura do documento {0} é inválida.{1}", doc.DocumentNumber, Environment.NewLine) });
                }
            }
        }

        void ValidaEstruturaXSD(string fileversion)
        {
            try
            {
                XmlSchemaSet schemas = new XmlSchemaSet();
                //if (fileversion == SaftFileVersion.V10301)
                //	schemas.Add(null, XmlReader.Create(new StringReader(Properties.Resources.SAFTPT1_03_01)));
                //else if (fileversion == SaftFileVersion.V10201)
                //	schemas.Add(null, XmlReader.Create(new StringReader(Properties.Resources.SAFTPT1_02_01)));
                //else if (fileversion == SaftFileVersion.V10101)
                //	schemas.Add(null, XmlReader.Create(new StringReader(Properties.Resources.SAFTPT_1_01)));

                XDocument doc = XDocument.Load(SaftFileName);
                doc.Validate(schemas, (o, e) =>
                {
                    MensagensErro.Add(new Error { Description = e.Message, TypeofError = typeof(SchemaResults) });
                });
            }
            catch (Exception error)
            {
                // XML Validation failed
                MensagensErro.Add(new Error { Description = string.Format("Mensagem de erro: {0}", error.Message), TypeofError = typeof(SchemaResults) });
            }
        }

        void ValidateHeader(Header header)
        {
            MensagensErro.Add(header.ValidateTaxRegistrationNumber());
            MensagensErro.Add(header.ValidateAuditFileVersion());
            MensagensErro.Add(header.ValidateBusinessName());
            MensagensErro.Add(header.ValidateEmail());
            MensagensErro.Add(header.ValidateAddressDetail());
            MensagensErro.Add(header.ValidateBuildingNumber());
            MensagensErro.Add(header.ValidateCity());
            MensagensErro.Add(header.ValidateCountry());
            MensagensErro.Add(header.ValidatePostalCode());
            MensagensErro.Add(header.ValidateRegion());
            MensagensErro.Add(header.ValidateStreetName());
            MensagensErro.Add(header.ValidateCompanyID());
            MensagensErro.Add(header.ValidateCompanyName());
            MensagensErro.Add(header.ValidateCurrencyCode());
            MensagensErro.Add(header.ValidateDateCreated());
            MensagensErro.Add(header.ValidateEndDate());
            MensagensErro.Add(header.ValidateFax());
            MensagensErro.Add(header.ValidateFiscalYear());
            MensagensErro.Add(header.ValidateHeaderComment());
            MensagensErro.Add(header.ValidateProductCompanyTaxID());
            MensagensErro.Add(header.ValidateProductID());
            MensagensErro.Add(header.ValidateProductVersion());
            MensagensErro.Add(header.ValidateSoftwareCertificateNumber());
            MensagensErro.Add(header.ValidateStartDate());
            MensagensErro.Add(header.ValidateTaxAccountingBasis());
            MensagensErro.Add(header.ValidateTaxEntity());
            MensagensErro.Add(header.ValidateTelephone());
            MensagensErro.Add(header.ValidateWebsite());
        }

        void ValidateCustomers(Customer[] customers)
        {
            if (customers != null && customers.Length > 0)
            {
                var duplicated = from p in customers
                                 group p by p.CustomerID into ci
                                 where ci.Count() > 1
                                 select new { codigo = ci.Key, quantidade = ci.Count() };

                foreach (var d in duplicated)
                {
                    string pk = (from p in customers where p.CustomerID.IndexOf(d.codigo, StringComparison.OrdinalIgnoreCase) >= 0 select p.Pk).FirstOrDefault();
                    MensagensErro.Add(new Error { Value = d.codigo, Field = "CustomerID", Description = string.Format("O código {0} está repetido {1} vezes.", d.codigo, d.quantidade), TypeofError = typeof(Product), UID = pk });
                }

                foreach (Customer customer in customers)
                {
                    MensagensErro.Add(customer.ValidateAccountID());
                    MensagensErro.Add(customer.ValidateCompanyName());
                    MensagensErro.Add(customer.ValidateContact());
                    MensagensErro.Add(customer.ValidateCustomerID());
                    MensagensErro.Add(customer.ValidateCustomerTaxID());
                    MensagensErro.Add(customer.ValidateEmail());
                    MensagensErro.Add(customer.ValidateFax());
                    MensagensErro.Add(customer.ValidateSelfBillingIndicator());
                    MensagensErro.Add(customer.ValidateTelephone());
                    MensagensErro.Add(customer.ValidateWebsite());
                    MensagensErro.AddRange(customer.ValidateBillingAddress());
                    MensagensErro.AddRange(customer.ValidateShipToAddress());
                }
            }
        }

        void ValidateProducts(Product[] products)
        {
            if (products != null && products.Length > 0)
            {
                var duplicated = from p in products
                                 group p by p.ProductCode into pc
                                 where pc.Count() > 1
                                 select new { codigo = pc.Key, quantidade = pc.Count() };

                foreach (var d in duplicated)
                {
                    string pk = (from p in products where p.ProductCode.IndexOf(d.codigo, StringComparison.OrdinalIgnoreCase) >= 0 select p.Pk).FirstOrDefault();

                    MensagensErro.Add(new Error { Value = d.codigo, Field = "ProductCode", Description = string.Format("O código {0} está repetido {1} vezes.", d.codigo, d.quantidade), TypeofError = typeof(Product), UID = pk });
                }

                foreach (Product product in products)
                {
                    MensagensErro.Add(product.ValidateProductCode());
                    MensagensErro.Add(product.ValidateProductDescription());
                    MensagensErro.Add(product.ValidateProductGroup());
                    MensagensErro.Add(product.ValidateProductNumberCode());
                }
            }
        }

        void ValidateTax(TaxTableEntry[] taxs)
        {
            if (taxs != null && taxs.Length > 0)
            {
                foreach (TaxTableEntry tax in taxs)
                {
                    MensagensErro.Add(tax.ValidateTaxCode());
                    MensagensErro.Add(tax.ValidateTaxCountryRegion());
                }
            }
        }

        void ValidateSupplier(Supplier[] suppliers)
        {
            if (suppliers != null && suppliers.Length > 0)
            {
                var duplicated = from p in suppliers
                                 group p by p.SupplierID into ci
                                 where ci.Count() > 1
                                 select new { codigo = ci.Key, quantidade = ci.Count() };

                foreach (var d in duplicated)
                {
                    string pk = (from p in suppliers where p.SupplierID.IndexOf(d.codigo, StringComparison.OrdinalIgnoreCase) >= 0 select p.Pk).FirstOrDefault();
                    MensagensErro.Add(new Error { Value = d.codigo, Field = "SupplierID", Description = string.Format("O código {0} está repetido {1} vezes.", d.codigo, d.quantidade), TypeofError = typeof(Supplier), UID = pk });
                }

                foreach (Supplier supplier in suppliers)
                {
                    MensagensErro.Add(supplier.ValidateAccountID());
                    MensagensErro.Add(supplier.ValidateCompanyName());
                    MensagensErro.Add(supplier.ValidateContact());
                    MensagensErro.Add(supplier.ValidateCustomerID());
                    MensagensErro.Add(supplier.ValidateSupplierTaxID());
                    MensagensErro.Add(supplier.ValidateEmail());
                    MensagensErro.Add(supplier.ValidateFax());
                    MensagensErro.Add(supplier.ValidateSelfBillingIndicator());
                    MensagensErro.Add(supplier.ValidateTelephone());
                    MensagensErro.Add(supplier.ValidateWebsite());
                    MensagensErro.AddRange(supplier.ValidateBillingAddress());
                    MensagensErro.AddRange(supplier.ValidateShipFromAddress());
                }
            }
        }

        void ValidateGeneralLedger()
        {
        }

        void ValidateGeneralLedgerEntriesJournal()
        {
        }

        void ValidateGeneralLedgerEntriesJournalTransaction()
        {
        }

        void ValidateGeneralLedgerEntriesJournalTransactionLine()
        {
        }

        void ValidateWorkDocument(SourceDocumentsWorkingDocuments workDocuments)
        {
            int numberOfLines = workDocuments.WorkDocument.Length;
            if (Convert.ToInt32(workDocuments.NumberOfEntries) != numberOfLines)
                MensagensErro.Add(new Error { Value = workDocuments.NumberOfEntries, Field = "WorkingDocuments", TypeofError = typeof(SourceDocumentsWorkingDocuments), Description = string.Format("Nº de registos incorrecto. Documento: {0}, esperado: {1}", workDocuments.NumberOfEntries, numberOfLines) });

            foreach (var workDocument in workDocuments.WorkDocument)
            {
                MensagensErro.Add(workDocument.ValidateDocumentNumber());
                MensagensErro.Add(workDocument.ValidateHash());
                MensagensErro.Add(workDocument.ValidateHashControl());
                MensagensErro.Add(workDocument.ValidatePeriod());
                MensagensErro.Add(workDocument.ValidateSystemEntryDate());
                MensagensErro.Add(workDocument.ValidateWorkDate());
                MensagensErro.AddRange(workDocument.ValidateDocumentStatus());
                MensagensErro.AddRange(workDocument.ValidateDocumentTotals());

                //verificar os totais do documento
                decimal netTotal, grossTotal, taxPayable;
                netTotal = workDocument.Line.Sum(l => l.Item);
                grossTotal = workDocument.Line.Where(l => l.Tax != null && l.Tax.ItemElementName == ItemChoiceType1.TaxPercentage)
                                        .Sum(l => l.Item * (1 + l.Tax.Item * 0.01m));
                taxPayable = workDocument.Line.Where(l => l.Tax != null && l.Tax.ItemElementName == ItemChoiceType1.TaxPercentage)
                                        .Sum(l => l.Item * l.Tax.Item * 0.01m);
                grossTotal += workDocument.Line.Where(l => l.Tax != null && l.Tax.ItemElementName == ItemChoiceType1.TaxAmount)
                                        .Sum(l => l.Item + l.Tax.Item);
                taxPayable += workDocument.Line.Where(l => l.Tax != null && l.Tax.ItemElementName == ItemChoiceType1.TaxAmount)
                                        .Sum(l => l.Item + l.Tax.Item);
                grossTotal += workDocument.Line.Where(l => l.Tax == null)
                                        .Sum(l => l.Item);
                taxPayable += workDocument.Line.Where(l => l.Tax == null)
                                        .Sum(l => l.Item);

                int numCasasDecimais = 6;// Workspace.Instance.Config.NumCasasDecimaisValidacoes;

                if (netTotal != workDocument.DocumentTotals.NetTotal && Math.Round(netTotal, numCasasDecimais, MidpointRounding.AwayFromZero) != workDocument.DocumentTotals.NetTotal)
                    MensagensErro.Add(new Error { Value = workDocument.DocumentTotals.NetTotal.ToString(), Field = "NetTotal", TypeofError = typeof(SourceDocumentsWorkingDocumentsWorkDocument), Description = string.Format("Total de incidência incorrecto. Documento: {0}, esperado: {1}", workDocument.DocumentTotals.NetTotal, netTotal) });
                if (grossTotal != workDocument.DocumentTotals.GrossTotal && Math.Round(grossTotal, numCasasDecimais, MidpointRounding.AwayFromZero) != workDocument.DocumentTotals.GrossTotal)
                    MensagensErro.Add(new Error { Value = workDocument.DocumentTotals.GrossTotal.ToString(), Field = "GrossTotal", TypeofError = typeof(SourceDocumentsWorkingDocumentsWorkDocument), Description = string.Format("Total incorrecto. Documento: {0}, esperado: {1}", workDocument.DocumentTotals.GrossTotal, grossTotal) });
                if (taxPayable != workDocument.DocumentTotals.TaxPayable && Math.Round(taxPayable, numCasasDecimais, MidpointRounding.AwayFromZero) != workDocument.DocumentTotals.TaxPayable)
                    MensagensErro.Add(new Error { Value = workDocument.DocumentTotals.TaxPayable.ToString(), Field = "TaxPayable", TypeofError = typeof(SourceDocumentsWorkingDocumentsWorkDocument), Description = string.Format("Total de imposto incorrecto. Documento: {0}, esperado: {1}", workDocument.DocumentTotals.TaxPayable, taxPayable) });

                foreach (var line in workDocument.Line)
                {
                    ValidateWorkDocumentLine(line, workDocument);
                }
            }
        }

        void ValidateWorkDocumentLine(SourceDocumentsWorkingDocumentsWorkDocumentLine line, SourceDocumentsWorkingDocumentsWorkDocument workDocument)
        {
            MensagensErro.Add(line.ValidateLineNumber(SupPk: workDocument.Pk, workingDocument: workDocument.DocumentNumber));
            MensagensErro.Add(line.ValidateProductCode(SupPk: workDocument.Pk, workingDocument: workDocument.DocumentNumber));
            MensagensErro.Add(line.ValidateProductDescription(SupPk: workDocument.Pk, workingDocument: workDocument.DocumentNumber));
            MensagensErro.Add(line.ValidateQuantity(SupPk: workDocument.Pk, workingDocument: workDocument.DocumentNumber));
            MensagensErro.Add(line.ValidateTaxPointDate(SupPk: workDocument.Pk, workingDocument: workDocument.DocumentNumber));
            MensagensErro.Add(line.ValidateUnitOfMeasure(SupPk: workDocument.Pk, workingDocument: workDocument.DocumentNumber));
            MensagensErro.Add(line.ValidateUnitPrice(SupPk: workDocument.Pk, workingDocument: workDocument.DocumentNumber));
            MensagensErro.AddRange(line.ValidateOrderReferences(SupPk: workDocument.Pk, workingDocument: workDocument.DocumentNumber));
            MensagensErro.AddRange(line.ValidateTax(SupPk: workDocument.Pk, workingDocument: workDocument.DocumentNumber));

            int numCasasDecimais = 6;// Workspace.Instance.Config.NumCasasDecimaisValidacoes;

            if (line.UnitPrice * line.Quantity != line.Item && Math.Round(line.UnitPrice * line.Quantity, numCasasDecimais, MidpointRounding.AwayFromZero) != Math.Round(line.Item, numCasasDecimais, MidpointRounding.AwayFromZero))
                MensagensErro.Add(new Error { Value = line.Item.ToString(), Field = "Item", TypeofError = typeof(SourceDocumentsMovementOfGoodsStockMovementLine), Description = string.Format("Valor da linha incorrecto. Valor: {0}, esperado: {1}", line.Item, line.UnitPrice * line.Quantity), UID = line.Pk, SupUID = workDocument.Pk });
        }

        void ValidateMovementOfGoods(SourceDocumentsMovementOfGoods movements)
        {
            int numberOfLines = movements.StockMovement.Sum(m => m.Line.Length);
            if (Convert.ToInt32(movements.NumberOfMovementLines) != numberOfLines)
                MensagensErro.Add(new Error { Value = movements.NumberOfMovementLines, Field = "MovementOfGoods", TypeofError = typeof(SourceDocumentsMovementOfGoods), Description = string.Format("Nº de registos incorrecto. Documento: {0}, esperado: {1}", movements.NumberOfMovementLines, numberOfLines) });

            decimal quantity = 0;
            foreach (var movement in movements.StockMovement)
            {
                MensagensErro.Add(movement.ValidateDocumentNumber());
                MensagensErro.Add(movement.ValidateHash());
                MensagensErro.Add(movement.ValidateHashControl());
                MensagensErro.Add(movement.ValidatePeriod());
                MensagensErro.Add(movement.ValidateSystemEntryDate());
                MensagensErro.Add(movement.ValidateMovementDate());
                MensagensErro.Add(movement.ValidateMovementEndTime());
                MensagensErro.Add(movement.ValidateMovementStartTime());
                MensagensErro.Add(movement.ValidateTransactionID());
                MensagensErro.AddRange(movement.ValidateDocumentStatus());
                MensagensErro.AddRange(movement.ValidateDocumentTotals());
                MensagensErro.AddRange(movement.ValidateShipFrom());
                MensagensErro.AddRange(movement.ValidateShipTo());

                //verificar a quantidade
                quantity += movement.Line.Sum(l => l.Quantity);

                //verificar os totais do documento
                decimal netTotal = movement.Line.Sum(l => l.Item);
                decimal grossTotal = movement.Line.Sum(l => l.Item * (1 + (l.Tax != null ? l.Tax.TaxPercentage : 0) * 0.01m));
                decimal taxPayable = movement.Line.Sum(l => l.Item * (l.Tax != null ? l.Tax.TaxPercentage : 0) * 0.01m);

                int numCasasDecimais = 6;// Workspace.Instance.Config.NumCasasDecimaisValidacoes;

                if (netTotal != movement.DocumentTotals.NetTotal && Math.Round(netTotal, numCasasDecimais, MidpointRounding.AwayFromZero) != movement.DocumentTotals.NetTotal)
                    MensagensErro.Add(new Error { Value = movement.DocumentTotals.NetTotal.ToString(), Field = "NetTotal", TypeofError = typeof(SourceDocumentsMovementOfGoods), Description = string.Format("Total de incidência incorrecto. Documento: {0}, esperado: {1}", movement.DocumentTotals.NetTotal, netTotal) });
                if (grossTotal != movement.DocumentTotals.GrossTotal && Math.Round(grossTotal, numCasasDecimais, MidpointRounding.AwayFromZero) != movement.DocumentTotals.GrossTotal)
                    MensagensErro.Add(new Error { Value = movement.DocumentTotals.GrossTotal.ToString(), Field = "GrossTotal", TypeofError = typeof(SourceDocumentsMovementOfGoods), Description = string.Format("Total incorrecto. Documento: {0}, esperado: {1}", movement.DocumentTotals.GrossTotal, grossTotal) });
                if (taxPayable != movement.DocumentTotals.TaxPayable && Math.Round(taxPayable, numCasasDecimais, MidpointRounding.AwayFromZero) != movement.DocumentTotals.TaxPayable)
                    MensagensErro.Add(new Error { Value = movement.DocumentTotals.TaxPayable.ToString(), Field = "TaxPayable", TypeofError = typeof(SourceDocumentsMovementOfGoods), Description = string.Format("Total de imposto incorrecto. Documento: {0}, esperado: {1}", movement.DocumentTotals.TaxPayable, taxPayable) });

                //verificar as linhas
                foreach (var line in movement.Line)
                {
                    ValidateMovementOfGoodsStockMovementLine(line, movement);
                }
            }

            if (quantity != movements.TotalQuantityIssued)
                MensagensErro.Add(new Error { Value = movements.TotalQuantityIssued.ToString(), Field = "MovementOfGoods", TypeofError = typeof(SourceDocumentsMovementOfGoods), Description = string.Format("Total da quantidade incorrecto. Documento: {0}, esperado: {1}", movements.TotalQuantityIssued, quantity) });
        }

        void ValidateMovementOfGoodsStockMovementLine(SourceDocumentsMovementOfGoodsStockMovementLine line, SourceDocumentsMovementOfGoodsStockMovement movement)
        {
            MensagensErro.Add(line.ValidateLineNumber(SupPk: movement.Pk, movement: movement.DocumentNumber));
            MensagensErro.Add(line.ValidateProductCode(SupPk: movement.Pk, movement: movement.DocumentNumber));
            MensagensErro.Add(line.ValidateProductDescription(SupPk: movement.Pk, movement: movement.DocumentNumber));
            MensagensErro.Add(line.ValidateQuantity(SupPk: movement.Pk, movement: movement.DocumentNumber));
            MensagensErro.Add(line.ValidateUnitOfMeasure(SupPk: movement.Pk, movement: movement.DocumentNumber));
            MensagensErro.Add(line.ValidateUnitPrice(SupPk: movement.Pk, movement: movement.DocumentNumber));
            MensagensErro.AddRange(line.ValidateOrderReferences(SupPk: movement.Pk, movement: movement.DocumentNumber));
            MensagensErro.AddRange(line.ValidateTax(SupPk: movement.Pk, movement: movement.DocumentNumber));

            int numCasasDecimais = 6;// Workspace.Instance.Config.NumCasasDecimaisValidacoes;

            if (line.UnitPrice * line.Quantity != line.Item && Math.Round(line.UnitPrice * line.Quantity, numCasasDecimais, MidpointRounding.AwayFromZero) != Math.Round(line.Item, numCasasDecimais, MidpointRounding.AwayFromZero))
                MensagensErro.Add(new Error { Value = line.Item.ToString(), Field = "Item", TypeofError = typeof(SourceDocumentsMovementOfGoodsStockMovementLine), Description = string.Format("Valor da linha incorrecto. Valor: {0}, esperado: {1}", line.Item, line.UnitPrice * line.Quantity), UID = line.Pk, SupUID = movement.Pk });
        }

        void ValidateInvoices(SourceDocumentsSalesInvoices invoices)
        {
            if (Convert.ToInt32(invoices.NumberOfEntries) != invoices.Invoice.Length)
                MensagensErro.Add(new Error { Value = invoices.NumberOfEntries, Field = "SalesInvoices", TypeofError = typeof(SourceDocumentsSalesInvoices), Description = string.Format("Nº de registos de documentos comerciais incorrecto. Documento: {0}, esperado: {1}", invoices.NumberOfEntries, invoices.Invoice.Length) });

            foreach (var invoice in invoices.Invoice)
            {
                MensagensErro.Add(invoice.ValidateInvoiceNo());
                MensagensErro.Add(invoice.ValidateHash());
                MensagensErro.Add(invoice.ValidateHashControl());
                MensagensErro.Add(invoice.ValidatePeriod());
                MensagensErro.Add(invoice.ValidateInvoiceDate());
                MensagensErro.Add(invoice.ValidateSystemEntryDate());
                MensagensErro.Add(invoice.ValidateTransactionID());
                MensagensErro.Add(invoice.ValidateCustomerID());
                MensagensErro.Add(invoice.ValidateSourceID());
                MensagensErro.Add(invoice.ValidateMovementEndTime());
                MensagensErro.Add(invoice.ValidateMovementStartTime());
                MensagensErro.AddRange(invoice.ValidateSpecialRegimes());
                MensagensErro.AddRange(invoice.ValidateDocumentStatus());
                MensagensErro.AddRange(invoice.ValidateShipTo());
                MensagensErro.AddRange(invoice.ValidateShipFrom());
                MensagensErro.AddRange(invoice.ValidateDocumentTotals());

                decimal total = 0, incidencia = 0, iva = 0;
                decimal totalArred = 0, incidenciaArred = 0, ivaArred = 0;
                int numLinha = 1, num = -1;
                foreach (var line in invoice.Line)
                {
                    if (!string.IsNullOrEmpty(line.LineNumber))
                        Int32.TryParse(line.LineNumber, out num);

                    if (numLinha != num)
                        mensagensErro.Add(new Error { Value = line.LineNumber, Field = "LineNumber", TypeofError = typeof(SourceDocumentsSalesInvoicesInvoiceLine), Description = string.Format("Número de linha incorrecto, Documento: {0}, esperado: {1}, valor: {2}", invoice.InvoiceNo, numLinha, line.LineNumber), UID = line.Pk, SupUID = invoice.Pk });
                    numLinha++;

                    ValidateInvoiceLine(line, invoice.Pk, invoice.InvoiceNo);

                    if (string.IsNullOrEmpty(line.UnitOfMeasure))
                        MensagensErro.Add(new Error { Value = invoice.InvoiceNo, Field = "UnitOfMeasure", TypeofError = typeof(SourceDocumentsSalesInvoicesInvoiceLine), Description = string.Format("Unidade de medida não preenchida. Documento: {0}, linha nº: ", invoice.InvoiceNo, line.LineNumber), UID = invoice.Pk });
                    if (line.Tax.Item == 0 && string.IsNullOrEmpty(line.TaxExemptionReason))
                        MensagensErro.Add(new Error { Value = invoice.InvoiceNo, Field = "TaxExemptionReason", TypeofError = typeof(SourceDocumentsSalesInvoicesInvoiceLine), Description = string.Format("Motivo de isenção do imposto não preenchido. Documento: {0}, linha nº: ", invoice.InvoiceNo, line.LineNumber), UID = invoice.Pk });

                    total += line.Item * (1 + line.Tax.Item * 0.01m) * Operation(invoice, line);
                    incidencia += line.Item * Operation(invoice, line);
                    iva += line.Item * line.Tax.Item * 0.01m * Operation(invoice, line);

                    totalArred += Math.Round(line.Item * (1 + line.Tax.Item * 0.01m) * Operation(invoice, line), 2, MidpointRounding.AwayFromZero);
                    incidenciaArred += Math.Round(line.Item * Operation(invoice, line), 2, MidpointRounding.AwayFromZero);
                    ivaArred += Math.Round(line.Item * line.Tax.Item * 0.01m * Operation(invoice, line), 2, MidpointRounding.AwayFromZero);
                }
                //arredondar o valor a 2 casas decimais
                incidencia = Math.Round(incidencia, 2, MidpointRounding.AwayFromZero);
                iva = Math.Round(iva, 2, MidpointRounding.AwayFromZero);
                total = Math.Round(total, 2, MidpointRounding.AwayFromZero);

                if (total != invoice.DocumentTotals.GrossTotal && totalArred != invoice.DocumentTotals.GrossTotal)
                    MensagensErro.Add(new Error { Value = invoice.InvoiceNo, Field = "GrossTotal", TypeofError = typeof(SourceDocumentsSalesInvoicesInvoice), Description = string.Format("Total errado. Documento: {0}, total: {1} esperado: {2}", invoice.InvoiceNo, invoice.DocumentTotals.GrossTotal, total), UID = invoice.Pk });
                if (incidencia != invoice.DocumentTotals.NetTotal && incidenciaArred != invoice.DocumentTotals.NetTotal)
                    MensagensErro.Add(new Error { Value = invoice.InvoiceNo, Field = "NetTotal", TypeofError = typeof(SourceDocumentsSalesInvoicesInvoice), Description = string.Format("Incidencia errada. Documento {0}, incidencia:{1} esperado:{2}", invoice.InvoiceNo, invoice.DocumentTotals.NetTotal, incidencia), UID = invoice.Pk });
                if (iva != invoice.DocumentTotals.TaxPayable && ivaArred != invoice.DocumentTotals.TaxPayable)
                    MensagensErro.Add(new Error { Value = invoice.InvoiceNo, Field = "TaxPayable", TypeofError = typeof(SourceDocumentsSalesInvoicesInvoice), Description = string.Format("Iva errado. Documento: {0}, iva: {1} esperado: {2}", invoice.InvoiceNo, invoice.DocumentTotals.TaxPayable, iva), UID = invoice.Pk });
                if (invoice.DocumentTotals.TaxPayable != invoice.DocumentTotals.GrossTotal - invoice.DocumentTotals.NetTotal)
                    MensagensErro.Add(new Error { Value = invoice.InvoiceNo, Field = "TaxPayable", TypeofError = typeof(SourceDocumentsSalesInvoicesInvoice), Description = string.Format("Iva errado. Documento: {0}, iva: {1} esperado: {2}", invoice.InvoiceNo, invoice.DocumentTotals.TaxPayable, invoice.DocumentTotals.GrossTotal - invoice.DocumentTotals.NetTotal), UID = invoice.Pk });
                if (invoice.DocumentTotals.GrossTotal != invoice.DocumentTotals.NetTotal + invoice.DocumentTotals.TaxPayable)
                    MensagensErro.Add(new Error { Value = invoice.InvoiceNo, Field = "DocumentTotals", TypeofError = typeof(SourceDocumentsSalesInvoicesInvoice), Description = string.Format("Total errado. Documento: {0}, NetTotal + TaxPayable = {1} != GrossTotal", invoice.InvoiceNo, invoice.DocumentTotals.NetTotal + invoice.DocumentTotals.TaxPayable, invoice.DocumentTotals.GrossTotal), UID = invoice.Pk });
            }
        }

        void ValidateInvoiceLine(SourceDocumentsSalesInvoicesInvoiceLine line, string supPk, string invoiceNo)
        {
            MensagensErro.Add(line.ValidateLineNumber(SupPk: supPk, invoiceNo: invoiceNo));
            MensagensErro.Add(line.ValidateProductCode(SupPk: supPk, invoiceNo: invoiceNo));
            MensagensErro.Add(line.ValidateProductDescription(SupPk: supPk, invoiceNo: invoiceNo));
            MensagensErro.Add(line.ValidateQuantity(SupPk: supPk, invoiceNo: invoiceNo));
            MensagensErro.Add(line.ValidateTaxPointDate(SupPk: supPk, invoiceNo: invoiceNo));
            MensagensErro.Add(line.ValidateUnitOfMeasure(SupPk: supPk, invoiceNo: invoiceNo));
            MensagensErro.Add(line.ValidateUnitPrice(SupPk: supPk, invoiceNo: invoiceNo));
            MensagensErro.AddRange(line.ValidateOrderReferences(SupPk: supPk, invoiceNo: invoiceNo));
            MensagensErro.AddRange(line.ValidateReferences(SupPk: supPk, invoiceNo: invoiceNo));
            MensagensErro.AddRange(line.ValidateTax(SupPk: supPk, invoiceNo: invoiceNo));

            int numCasasDecimais = 6;// Workspace.Instance.Config.NumCasasDecimaisValidacoes;
            bool incidendia = Math.Abs(Math.Round(line.UnitPrice * line.Quantity, numCasasDecimais, MidpointRounding.AwayFromZero) - Math.Round(line.Item, numCasasDecimais, MidpointRounding.AwayFromZero)) > 0.01m;
            if (incidendia == true)
            {
                MensagensErro.Add(new Error
                {
                    Value = line.Item.ToString(),
                    Field = line.ItemElementName.ToString(),
                    TypeofError = typeof(SourceDocumentsSalesInvoicesInvoice),
                    Description = $"Total de linha diferente do valor unitário * quantidade ({line.UnitPrice} * {line.Quantity} <> {line.Item}). Documento: {line.InvoiceNo}",
                    UID = line.Pk,
                    SupUID = supPk
                });
            }
        }

        private void ValidatePayments(SourceDocumentsPayments payments)
        {
            if (Convert.ToInt32(payments.NumberOfEntries) != payments.Payment.Length)
                MensagensErro.Add(new Error { Value = payments.NumberOfEntries, Field = "Payments", TypeofError = typeof(SourceDocumentsPayments), Description = string.Format("Nº de registos dos recibos incorrecto. Documento: {0}, esperado: {1}", payments.NumberOfEntries, payments.Payment.Length) });

            foreach (var payment in payments.Payment)
            {
                MensagensErro.Add(payment.ValidateCustomerID());
                MensagensErro.Add(payment.ValidateDescription());
                MensagensErro.Add(payment.ValidateDocumentStatusSourceID());
                MensagensErro.Add(payment.ValidatePaymentRefNo());
                MensagensErro.Add(payment.ValidatePaymentStatusDate());
                MensagensErro.Add(payment.ValidatePeriod());
                MensagensErro.Add(payment.ValidateReason());
                MensagensErro.Add(payment.ValidateSourceID());
                MensagensErro.Add(payment.ValidateSystemEntryDate());
                MensagensErro.Add(payment.ValidateSystemID());
                MensagensErro.Add(payment.ValidateTransactionDate());
                MensagensErro.Add(payment.ValidateTransactionID());
                MensagensErro.AddRange(payment.ValidatePaymentMethod());

                int numLinha = 1, num = -1;
                foreach (var line in payment.Line)
                {
                    if (!string.IsNullOrEmpty(line.LineNumber))
                        Int32.TryParse(line.LineNumber, out num);

                    if (numLinha != num)
                        mensagensErro.Add(new Error { Value = line.LineNumber, Field = "LineNumber", TypeofError = typeof(SourceDocumentsPaymentsPaymentLine), Description = string.Format("Número de linha incorrecto, Documento: {0}, esperado: {1}, valor: {2}", payment.PaymentRefNo, numLinha, line.LineNumber), UID = line.Pk, SupUID = payment.Pk });
                    numLinha++;

                    ValidatePaymentLine(line, payment.Pk, payment.PaymentRefNo);
                }
            }
        }

        private void ValidatePaymentLine(SourceDocumentsPaymentsPaymentLine line, string supPk, string paymentRefNo)
        {
            MensagensErro.Add(line.ValidateItem(SupPk: supPk, paymentNo: paymentRefNo));
            MensagensErro.Add(line.ValidateLineNumber(SupPk: supPk, paymentNo: paymentRefNo));
            MensagensErro.Add(line.ValidateSettlementAmount(SupPk: supPk, paymentNo: paymentRefNo));
            MensagensErro.Add(line.ValidateTaxExemptionReason(SupPk: supPk, paymentNo: paymentRefNo));
            MensagensErro.AddRange(line.ValidateSourceDocumentID(SupPk: supPk, paymentNo: paymentRefNo));
            MensagensErro.AddRange(line.ValidateTax(SupPk: supPk, paymentNo: paymentRefNo));
        }

        public int Operation(SourceDocumentsSalesInvoicesInvoice i, SourceDocumentsSalesInvoicesInvoiceLine l)
        {
            if (i.InvoiceType == InvoiceType.FT || i.InvoiceType == InvoiceType.VD || i.InvoiceType == InvoiceType.ND || i.InvoiceType == InvoiceType.FR || i.InvoiceType == InvoiceType.FS || i.InvoiceType == InvoiceType.TV || i.InvoiceType == InvoiceType.AA)
                return l.ItemElementName == ItemChoiceType4.CreditAmount ? 1 : -1;
            else if (i.InvoiceType == InvoiceType.NC || i.InvoiceType == InvoiceType.TD || i.InvoiceType == InvoiceType.DA || i.InvoiceType == InvoiceType.RE)
                return l.ItemElementName == ItemChoiceType4.DebitAmount ? 1 : -1;

            return 1;
        }

        #endregion
    }
}
