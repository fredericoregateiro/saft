using SolRIA.SaftAnalyser;
using SolRIA.SaftAnalyser.Models;
using SolRIA.SaftAnalyser.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SolRia.Erp.MobileApp.Models.SaftV4
{
	public partial class BaseData
	{
		string pk;
		/// <summary>
		/// Primary key of the registry
		/// </summary>
		[System.Xml.Serialization.XmlIgnore]
		public string Pk
		{
			get
			{
				if (string.IsNullOrEmpty(pk))
					pk = Guid.NewGuid().ToString();
				return pk;
			}
			private set { pk = value; }
		}
	}

	public partial class SourceDocumentsPaymentsPayment : BaseData, IDataErrorInfo
	{
		//SourceDocumentsPaymentsPaymentToolTipService tooltip;
		//public SourceDocumentsPaymentsPaymentToolTipService Tooltip
		//{
		//    get
		//    {
		//        if (tooltip == null)
		//            tooltip = new SourceDocumentsPaymentsPaymentToolTipService();
		//        return tooltip;
		//    }
		//    set { tooltip = value; }
		//}

		public string Error
		{
			get
			{
				StringBuilder error = new StringBuilder();

				// iterate over all of the properties
				// of this object - aggregating any validation errors
				PropertyDescriptorCollection props = TypeDescriptor.GetProperties(this);
				foreach (PropertyDescriptor prop in props)
				{
					String propertyError = this[prop.Name];
					if (propertyError != string.Empty)
						error.Append((error.Length != 0 ? ", " : "") + propertyError);
				}

				return error.Length == 0 ? null : error.ToString();
			}
		}

		public string this[string columnName]
		{
			get
			{
				Error erro = null;
				if (columnName == "PaymentRefNo")
				{
					erro = ValidatePaymentRefNo(appendError: true);
				}
				else if (columnName == "SourceID")
				{
					erro = ValidateSourceID(appendError: true);
				}
				else if (columnName == "Period")
				{
					erro = ValidatePeriod(appendError: true);
				}
				else if (columnName == "TransactionDate")
				{
					erro = ValidateTransactionDate(appendError: true);
				}
				else if (columnName == "SystemID")
				{
					erro = ValidateSystemID(appendError: true);
				}
				else if (columnName == "SystemEntryDate")
				{
					erro = ValidateSystemEntryDate(appendError: true);
				}
				else if (columnName == "TransactionID")
				{
					erro = ValidateTransactionID(appendError: true);
				}
				else if (columnName == "CustomerID")
				{
					erro = ValidateCustomerID(appendError: true);
				}
				else if (columnName == "Description")
				{
					erro = ValidateDescription(appendError: true);
				}

				return erro?.Description;
			}
		}

		#region Validation
		public Error ValidatePaymentRefNo(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(PaymentRefNo) || PaymentRefNo.Length > 60)
			{
				erro = new Error { Description = "Identificação única com tamanho incorrecto.", Field = "PaymentRefNo", TypeofError = GetType(), Value = PaymentRefNo, UID = Pk };
				//if (appendError)
				//    Tooltip.PaymentRefNo = Tooltip.PaymentRefNo.FormatTooltipWithError(erro.Description);
			}
			else if (!Regex.IsMatch(PaymentRefNo, "[^ ]+ [^/^ ]+/[0-9]+"))
			{
				erro = new Error { Description = "Identificação única com caracteres não permitidos.", Field = "PaymentRefNo", TypeofError = GetType(), Value = PaymentRefNo, UID = Pk };
				//if (appendError)
				//    Tooltip.PaymentRefNo = Tooltip.PaymentRefNo.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidatePeriod(bool appendError = false)
		{
			Error erro = null;

			if (string.IsNullOrEmpty(Period) == false)
			{
				int periodo = -1;
				Int32.TryParse(Period, out periodo);

				if (periodo < 1 || periodo > 12)
				{
					erro = new Error { Description = string.Format("Mês do período de tributação do documento {0} incorrecto.", PaymentRefNo), Field = "Period", TypeofError = GetType(), Value = Period, UID = Pk };
					//if (appendError)
					//    Tooltip.Period = Tooltip.Period.FormatTooltipWithError(erro.Description);
				}
			}

			return erro;
		}
		public Error ValidateTransactionID(bool appendError = false)
		{
			Error erro = null;

			if (!string.IsNullOrEmpty(TransactionID) && TransactionID.Length > 70)
			{
				erro = new Error { Description = string.Format("Identificador da transacção do documento {0} incorrecto.", PaymentRefNo), Field = "TransactionID", TypeofError = GetType(), Value = TransactionID, UID = Pk };
				//if (appendError)
				//    Tooltip.TransactionID = Tooltip.TransactionID.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateTransactionDate(bool appendError = false)
		{
			Error erro = null;

			if (TransactionDate > DateTime.Now)
			{
				erro = new Error { Description = string.Format("Data de emissão do documento {0} incorrecta.", PaymentRefNo), Field = "TransactionDate", TypeofError = GetType(), Value = TransactionDate.ToString(), UID = Pk };
				//if (appendError)
				//    Tooltip.TransactionDate = Tooltip.TransactionDate.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateDescription(bool appendError = false)
		{
			Error erro = null;

			if (!string.IsNullOrEmpty(Description) && Description.Length > 200)
			{
				erro = new Error { Description = string.Format("Tamanho da descrição do recibo {0} incorrecto.", PaymentRefNo), Field = "Description", TypeofError = GetType(), Value = Description, UID = Pk };
				//if (appendError)
				//    Tooltip.Description = Tooltip.Description.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidatePaymentStatusDate(bool appendError = false)
		{
			Error erro = null;

			if (DocumentStatus.PaymentStatusDate > DateTime.Now)
			{
				erro = new Error { Description = string.Format("Data e hora do estado atual do recibo {0} incorrecta.", PaymentRefNo), Field = "PaymentStatusDate", TypeofError = GetType(), Value = DocumentStatus.PaymentStatusDate.ToString(), UID = Pk };
				//if (appendError)
				//    Tooltip.PaymentStatusDate = Tooltip.PaymentStatusDate.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateReason(bool appendError = false)
		{
			Error erro = null;

			if (!string.IsNullOrEmpty(DocumentStatus.Reason) && DocumentStatus.Reason.Length > 50)
			{
				erro = new Error { Description = string.Format("Tamanho do motivo da alteração de estado do recibo {0} incorrecto.", PaymentRefNo), Field = "Reason", TypeofError = GetType(), Value = DocumentStatus.Reason, UID = Pk };
				//if (appendError)
				//    Tooltip.Reason = Tooltip.Reason.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateDocumentStatusSourceID(bool appendError = false)
		{
			Error erro = null;

			if (string.IsNullOrEmpty(DocumentStatus.SourceID) || DocumentStatus.SourceID.Length > 30)
			{
				erro = new Error { Description = string.Format("Utilizador responsável pelo estado atual do recibo {0} incorrecto.", DocumentStatus.SourceID), Field = "SourceID", TypeofError = GetType(), Value = DocumentStatus.SourceID, UID = Pk };
				//if (appendError)
				//    Tooltip.ResponsableUserSourceID = Tooltip.ResponsableUserSourceID.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateSystemID(bool appendError = false)
		{
			Error erro = null;

			if (string.IsNullOrEmpty(SystemID) == false && SystemID.Length > 35)
			{
				erro = new Error { Description = string.Format("Tamanho do número único do recibo {0} incorrecto.", PaymentRefNo), Field = "SystemID", TypeofError = GetType(), Value = SystemID, UID = Pk };
				//if (appendError)
				//    Tooltip.SystemID = Tooltip.SystemID.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateSourceID(bool appendError = false)
		{
			Error erro = null;

			if (string.IsNullOrEmpty(SourceID) || SourceID.Length > 30)
			{
				erro = new Error { Description = string.Format("Utilizador que gerou o documento {0} incorrecto.", SourceID), Field = "SourceID", TypeofError = GetType(), Value = SourceID, UID = Pk };
				//if (appendError)
				//    Tooltip.GeneratedDocumentUserSourceID = Tooltip.GeneratedDocumentUserSourceID.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateSystemEntryDate(bool appendError = false)
		{
			Error erro = null;

			if (SystemEntryDate > DateTime.Now)
			{
				erro = new Error { Description = string.Format("Data da gravação do documento {0} incorrecta.", PaymentRefNo), Field = "SystemEntryDate", TypeofError = GetType(), Value = SystemEntryDate.ToString(), UID = Pk };
				//if (appendError)
				//    Tooltip.SystemEntryDate = Tooltip.SystemEntryDate.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateCustomerID(bool appendError = false)
		{
			Error erro = null;

			if (string.IsNullOrEmpty(CustomerID) || CustomerID.Length > 30)
			{
				erro = new Error { Description = string.Format("Chave única da tabela de clientes no documento {0} incorrecta.", PaymentRefNo), Field = "CustomerID", TypeofError = GetType(), Value = CustomerID, UID = Pk };
				//if (appendError)
				//    Tooltip.CustomerID = Tooltip.CustomerID.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}

		public Error[] ValidatePaymentMethod(bool appendError = false)
		{
			List<Error> listErro = new List<Error>();

			if (PaymentMethod != null && PaymentMethod.Length > 0)
			{
				foreach (var pay in PaymentMethod)
				{
					if (pay.PaymentAmount < 0)
					{
						Error erro = new Error { Description = string.Format("Utilizador que gerou o documento {0} incorrecto.", PaymentRefNo), Field = "PaymentAmount", TypeofError = GetType(), Value = pay.PaymentAmount.ToString(), UID = Pk };
						listErro.Add(erro);
						//if (appendError)
						//    Tooltip.PaymentMechanism = Tooltip.PaymentMechanism.FormatTooltipWithError(erro.Description);
					}

					if (pay.PaymentDate > DateTime.Now)
					{
						Error erro = new Error { Description = string.Format("Data do pagamento do documento {0} incorrecta.", PaymentRefNo), Field = "PaymentDate", TypeofError = GetType(), Value = pay.PaymentDate.ToString(), UID = Pk };
						listErro.Add(erro);
						//if (appendError)
						//    Tooltip.PaymentMechanism = Tooltip.PaymentMechanism.FormatTooltipWithError(erro.Description);
					}
				}
			}
			return listErro.ToArray();
		}
		#endregion
	}

	public partial class SourceDocumentsPaymentsPaymentLine : BaseData, IDataErrorInfo
	{
		/// <summary>
		/// Link to the Payment
		/// </summary>
		public string DocNo { get; set; }

		//SourceDocumentsPaymentsPaymentLineToolTipService tooltip;
		//public SourceDocumentsPaymentsPaymentLineToolTipService Tooltip
		//{
		//    get
		//    {
		//        if (tooltip == null)
		//            tooltip = new SourceDocumentsPaymentsPaymentLineToolTipService();
		//        return tooltip;
		//    }
		//    set { tooltip = value; }
		//}

		public string Error
		{
			get { return string.Empty; }
		}

		[System.Runtime.CompilerServices.IndexerName("Items")]
		public string this[string columnName]
		{
			get
			{
				Error erro = null;
				if (columnName == "LineNumber")
				{
					erro = ValidateLineNumber(appendError: true);
				}
				else if (columnName == "SettlementAmount")
				{
					erro = ValidateSettlementAmount(appendError: true);
				}
				else if (columnName == "TaxExemptionReason")
				{
					erro = ValidateTaxExemptionReason(appendError: true);
				}
				else if (columnName == "Item")
				{
					erro = ValidateItem(appendError: true);
				}

				return erro?.Description;
			}
		}

		#region
		public Error ValidateLineNumber(bool appendError = false, string SupPk = "", string paymentNo = "")
		{
			Error erro = null;
			int num = -1;
			if (!string.IsNullOrEmpty(LineNumber))
				Int32.TryParse(LineNumber, out num);

			if (string.IsNullOrEmpty(LineNumber) || num == -1)
			{
				if (!string.IsNullOrEmpty(paymentNo))
					paymentNo = string.Format(", documento {0}", paymentNo);

				erro = new Error { Description = string.Format("Número de linha incorrecto{0}.", paymentNo), Field = "LineNumber", TypeofError = GetType(), Value = LineNumber, UID = Pk, SupUID = SupPk };
				//if (appendError)
				//    Tooltip.LineNumber = Tooltip.LineNumber.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateSettlementAmount(bool appendError = false, string SupPk = "", string paymentNo = "")
		{
			Error erro = null;
			if (SettlementAmount < 0)
			{
				if (!string.IsNullOrEmpty(paymentNo))
					paymentNo = string.Format(" documento {0}", paymentNo);

				erro = new Error { Description = string.Format("Montante do desconto, {0} linha {1}.", paymentNo, LineNumber), Field = "SettlementAmount", TypeofError = GetType(), Value = SettlementAmount.ToString(), UID = Pk, SupUID = SupPk };
				//if (appendError)
				//    Tooltip.LineSettlementAmount = Tooltip.LineSettlementAmount.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateItem(bool appendError = false, string SupPk = "", string paymentNo = "")
		{
			Error erro = null;
			if (Item < 0)
			{
				if (!string.IsNullOrEmpty(paymentNo))
					paymentNo = string.Format(" documento {0}", paymentNo);

				if (ItemElementName == ItemChoiceType8.CreditAmount)
					erro = new Error { Description = string.Format("Valor a crédito incorrecta, {0} linha {1}.", paymentNo, LineNumber), Field = "CreditAmount", TypeofError = GetType(), Value = Item.ToString(), UID = Pk, SupUID = SupPk };
				if (ItemElementName == ItemChoiceType8.DebitAmount)
					erro = new Error { Description = string.Format("Valor a débito incorrecto, {0} linha {1}.", paymentNo, LineNumber), Field = "DebitAmount", TypeofError = GetType(), Value = Item.ToString(), UID = Pk, SupUID = SupPk };

				//if (appendError && ItemElementName == ItemChoiceType9.CreditAmount)
				//    Tooltip.CreditAmount = Tooltip.CreditAmount.FormatTooltipWithError(erro.Description);
				//if (appendError && ItemElementName == ItemChoiceType9.DebitAmount)
				//    Tooltip.DebitAmount = Tooltip.DebitAmount.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateTaxExemptionReason(bool appendError = false, string SupPk = "", string paymentNo = "")
		{
			Error erro = null;
			if ((Tax != null && Tax.Item == 0 && string.IsNullOrEmpty(TaxExemptionReason)) || (string.IsNullOrEmpty(TaxExemptionReason) == false && TaxExemptionReason.Length > 60))
			{
				if (!string.IsNullOrEmpty(paymentNo))
					paymentNo = string.Format(" documento {0}", paymentNo);

				erro = new Error { Description = string.Format("Motivo da isenção de imposto incorrecto, {0} linha {1}.", paymentNo, LineNumber), Field = "TaxExemptionReason", TypeofError = GetType(), Value = TaxExemptionReason, UID = Pk, SupUID = SupPk };
				//if (appendError)
				//    Tooltip.TaxExemptionReason = Tooltip.TaxExemptionReason.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}

		public Error[] ValidateSourceDocumentID(string SupPk = "", string paymentNo = "")
		{
			List<Error> listErro = new List<Error>();

			if (!string.IsNullOrEmpty(paymentNo))
				paymentNo = string.Format(" documento {0}", paymentNo);

			if (SourceDocumentID == null || SourceDocumentID.Length == 0)
				listErro.Add(new Error { Description = string.Format("Referência ao documento de origem inexistente,{0} linha {1}.", paymentNo, LineNumber), Field = "SourceDocumentID", TypeofError = GetType(), UID = Pk, SupUID = SupPk });

			if (SourceDocumentID != null && SourceDocumentID.Length > 0)
			{
				foreach (var doc in SourceDocumentID)
				{
					if (string.IsNullOrEmpty(doc.Description) == false && doc.Description.Length > 100)
						listErro.Add(new Error { Description = string.Format("Tamanho da descrição da linha incorrecto,{0} linha {1}.", paymentNo, LineNumber), Field = "Description", TypeofError = GetType(), Value = doc.Description, UID = Pk, SupUID = SupPk });
					if (doc.InvoiceDate > DateTime.Now)
						listErro.Add(new Error { Description = string.Format("Data do documento de origem incorrecta,{0} linha {1}.", paymentNo, LineNumber), Field = "InvoiceDate", TypeofError = GetType(), Value = doc.InvoiceDate.ToString(), UID = Pk, SupUID = SupPk });
					if (string.IsNullOrEmpty(doc.OriginatingON) || doc.OriginatingON.Length > 60)
						listErro.Add(new Error { Description = string.Format("Número do documento de origem incorrecto,{0} linha {1}.", paymentNo, LineNumber), Field = "OriginatingON", TypeofError = GetType(), Value = doc.OriginatingON, UID = Pk, SupUID = SupPk });
				}
			}
			return listErro.ToArray();
		}
		public Error[] ValidateTax(string SupPk = "", string paymentNo = "")
		{
			List<Error> listErro = new List<Error>();
			if (Tax != null)
			{
				if (!string.IsNullOrEmpty(paymentNo))
					paymentNo = string.Format(" documento {0}", paymentNo);

				if (Tax.Item < 0 && Tax.ItemElementName == ItemChoiceType.TaxAmount)
					listErro.Add(new Error { Description = string.Format("Montante do imposto incorrecto, {0} linha {1}.", paymentNo, LineNumber), Field = "TaxAmount", TypeofError = GetType(), Value = Tax.Item.ToString(), UID = Pk, SupUID = SupPk });
				if ((Tax.Item < 0 || Tax.Item > 100) && Tax.ItemElementName == ItemChoiceType.TaxPercentage)
					listErro.Add(new Error { Description = string.Format("Montante do imposto incorrecto, {0} linha {1}.", paymentNo, LineNumber), Field = "TaxPercentage", TypeofError = GetType(), Value = Tax.Item.ToString(), UID = Pk, SupUID = SupPk });
				if (string.IsNullOrEmpty(Tax.TaxCode) || Tax.TaxCode.Length > 10)
					listErro.Add(new Error { Description = string.Format("Código da taxa incorrecto, {0} linha {1}.", paymentNo, LineNumber), Field = "TaxCode", TypeofError = GetType(), Value = Tax.TaxCode, UID = Pk, SupUID = SupPk });
				if (string.IsNullOrEmpty(Tax.TaxCountryRegion) || Tax.TaxCode.Length > 5)
					listErro.Add(new Error { Description = string.Format("País ou região do imposto incorrecto, {0} linha {1}.", paymentNo, LineNumber), Field = "TaxCountryRegion", TypeofError = GetType(), Value = Tax.TaxCountryRegion, UID = Pk, SupUID = SupPk });
			}
			return listErro.ToArray();
		}
		#endregion
	}

	public partial class SourceDocumentsMovementOfGoodsStockMovement : BaseData, IDataErrorInfo
	{
		public string HashTest { get; set; }

		//MovementOfGoodsToolTipService tooltip;
		//public MovementOfGoodsToolTipService Tooltip
		//{
		//    get
		//    {
		//        if (tooltip == null)
		//            tooltip = new MovementOfGoodsToolTipService();
		//        return tooltip;
		//    }
		//    set { tooltip = value; }
		//}

		public string Error
		{
			get
			{
				StringBuilder error = new StringBuilder();

				// iterate over all of the properties
				// of this object - aggregating any validation errors
				PropertyDescriptorCollection props = TypeDescriptor.GetProperties(this);
				foreach (PropertyDescriptor prop in props)
				{
					String propertyError = this[prop.Name];
					if (propertyError != string.Empty)
						error.Append((error.Length != 0 ? ", " : "") + propertyError);
				}

				return error.Length == 0 ? null : error.ToString();
			}
		}

		[System.Runtime.CompilerServices.IndexerName("Items")]
		public string this[string columnName]
		{
			get
			{
				Error erro = null;
				if (columnName == "DocumentNumber")
				{
					erro = ValidateDocumentNumber(appendError: true);
				}
				else if (columnName == "Hash")
				{
					erro = ValidateHash(appendError: true);
				}
				else if (columnName == "HashControl")
				{
					erro = ValidateHashControl(appendError: true);
				}
				else if (columnName == "Period")
				{
					erro = ValidatePeriod(appendError: true);
				}
				else if (columnName == "MovementDate")
				{
					erro = ValidateMovementDate(appendError: true);
				}
				else if (columnName == "SystemEntryDate")
				{
					erro = ValidateSystemEntryDate(appendError: true);
				}
				else if (columnName == "TransactionID")
				{
					erro = ValidateTransactionID(appendError: true);
				}
				else if (columnName == "MovementEndTime")
				{
					erro = ValidateMovementEndTime(appendError: true);
				}
				else if (columnName == "MovementStartTime")
				{
					erro = ValidateMovementStartTime(appendError: true);
				}
				return erro?.Description;
			}
		}

		#region Validation
		public Error ValidateDocumentNumber(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(DocumentNumber) || DocumentNumber.Length > 60)
			{
				erro = new Error { Description = "Identificação única com tamanho incorrecto.", Field = "DocumentNumber", TypeofError = GetType(), Value = DocumentNumber, UID = Pk };
				//if (appendError)
				//    Tooltip.DocumentNumber = Tooltip.DocumentNumber.FormatTooltipWithError(erro.Description);
			}
			else if (!Regex.IsMatch(DocumentNumber, "([a-zA-Z0-9./_-])+ ([a-zA-Z0-9]*/[0-9]+)"))
			{
				erro = new Error { Description = "Identificação única com caracteres não permitidos.", Field = "DocumentNumber", TypeofError = GetType(), Value = DocumentNumber, UID = Pk };
				//if (appendError)
				//    Tooltip.DocumentNumber = Tooltip.DocumentNumber.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateHash(bool appendError = false)
		{
			Error erro = null;

			if (string.IsNullOrEmpty(Hash) || Hash.Length != 172)
			{
				erro = new Error { Description = string.Format("Assinatura do documento {0} de tamanho incorrecto.", DocumentNumber), Field = "Hash", TypeofError = GetType(), Value = Hash, UID = Pk };
				//if (appendError)
				//    Tooltip.Hash = Tooltip.Hash.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateHashControl(bool appendError = false)
		{
			Error erro = null;

			if (string.IsNullOrEmpty(HashControl) || HashControl.Length > 40)
			{
				erro = new Error { Description = string.Format("Versão da chave privada utilizada na assinatura do documento {0} incorrecta.", DocumentNumber), Field = "HashControl", TypeofError = GetType(), Value = HashControl, UID = Pk };
				//if (appendError)
				//    Tooltip.HashControl = Tooltip.HashControl.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidatePeriod(bool appendError = false)
		{
			Error erro = null;

			if (string.IsNullOrEmpty(Period) == false)
			{
				int periodo = -1;
				Int32.TryParse(Period, out periodo);

				if (periodo < 1 || periodo > 12)
				{
					erro = new Error { Description = string.Format("Mês do período de tributação do documento {0} incorrecto.", DocumentNumber), Field = "Period", TypeofError = GetType(), Value = Period, UID = Pk };
					//if (appendError)
					//    Tooltip.Period = Tooltip.Period.FormatTooltipWithError(erro.Description);
				}
			}

			return erro;
		}
		public Error ValidateMovementDate(bool appendError = false)
		{
			Error erro = null;

			if (MovementDate > DateTime.Now)
			{
				erro = new Error { Description = string.Format("Data de emissão do documento {0} incorrecta.", DocumentNumber), Field = "InvoiceDate", TypeofError = GetType(), Value = MovementDate.ToString(), UID = Pk };
				//if (appendError)
				//    Tooltip.MovementDate = Tooltip.MovementDate.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateSystemEntryDate(bool appendError = false)
		{
			Error erro = null;

			if (SystemEntryDate > DateTime.Now)
			{
				erro = new Error { Description = string.Format("Data da gravação do documento {0} incorrecta.", DocumentNumber), Field = "SystemEntryDate", TypeofError = GetType(), Value = SystemEntryDate.ToString(), UID = Pk };
				//if (appendError)
				//    Tooltip.SystemEntryDate = Tooltip.SystemEntryDate.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateTransactionID(bool appendError = false)
		{
			Error erro = null;

			if (!string.IsNullOrEmpty(TransactionID) && TransactionID.Length > 70)
			{
				erro = new Error { Description = string.Format("Identificador da transacção do documento {0} incorrecto.", DocumentNumber), Field = "TransactionID", TypeofError = GetType(), Value = TransactionID, UID = Pk };
				//if (appendError)
				//    Tooltip.TransactionID = Tooltip.TransactionID.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateMovementEndTime(bool appendError = false)
		{
			Error erro = null;

			if (MovementEndTimeSpecified && MovementEndTime > DateTime.Now)
			{
				erro = new Error { Description = string.Format("Data e hora de fim de transporte do documento {0} incorrecta.", DocumentNumber), Field = "MovementEndTime", TypeofError = GetType(), Value = MovementEndTime.ToString(), UID = Pk };
				//if (appendError)
				//    Tooltip.MovementEndTime = Tooltip.MovementEndTime.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateMovementStartTime(bool appendError = false)
		{
			Error erro = null;

			if (MovementStartTime > DateTime.Now)
			{
				erro = new Error { Description = string.Format("Data e hora de início de transporte do documento {0} incorrecta.", DocumentNumber), Field = "MovementStartTime", TypeofError = GetType(), Value = MovementStartTime.ToString(), UID = Pk };
				//if (appendError)
				//    Tooltip.MovementStartTime = Tooltip.MovementStartTime.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}

		public Error[] ValidateDocumentStatus()
		{
			List<Error> listError = new List<Error>();

			if (DocumentStatus == null)
				listError.Add(new Error { Description = string.Format("Situação do documento {0} inexistente.", DocumentNumber), Field = "DocumentStatus", TypeofError = GetType(), UID = Pk });

			if (DocumentStatus != null)
			{
				if (DocumentStatus.MovementStatusDate > DateTime.Now)
					listError.Add(new Error { Description = string.Format("Data e hora do estado atual do documento {0} incorrecta.", DocumentNumber), Field = "InvoiceStatusDate", TypeofError = GetType(), Value = DocumentStatus.MovementStatusDate.ToString(), UID = Pk });
				if (string.IsNullOrEmpty(DocumentStatus.Reason) == false && DocumentStatus.Reason.Length > 50)
					listError.Add(new Error { Description = string.Format("Tamanho do motivo da alteração de estado {0} incorrecto.", DocumentNumber), Field = "Reason", TypeofError = GetType(), Value = DocumentStatus.Reason, UID = Pk });
				if (string.IsNullOrEmpty(DocumentStatus.SourceID) || DocumentStatus.SourceID.Length > 30)
					listError.Add(new Error { Description = string.Format("Utilizador responsável pelo estado atual do documento {0} incorrecto.", DocumentNumber), Field = "SourceID", TypeofError = GetType(), Value = DocumentStatus.SourceID, UID = Pk });
			}

			return listError.ToArray();
		}
		public Error[] ValidateShipTo()
		{
			List<Error> listError = new List<Error>();

			if (ShipTo != null)
			{
				if (ShipTo.Address != null)
				{
					if (string.IsNullOrEmpty(ShipTo.Address.AddressDetail) || ShipTo.Address.AddressDetail.Length > 100)
						listError.Add(new Error { Description = string.Format("Tamanho da morada detalhada do documento {0} do local de descarga incorrecto.", DocumentNumber), Field = "AddressDetail", TypeofError = GetType(), Value = ShipTo.Address.AddressDetail, UID = Pk });
					if (string.IsNullOrEmpty(ShipTo.Address.BuildingNumber) == false && ShipTo.Address.BuildingNumber.Length > 10)
						listError.Add(new Error { Description = string.Format("Tamanho do número de polícia do documento {0} do local de descarga incorrecto.", DocumentNumber), Field = "BuildingNumber", TypeofError = GetType(), Value = ShipTo.Address.BuildingNumber, UID = Pk });
					if (string.IsNullOrEmpty(ShipTo.Address.City) || ShipTo.Address.City.Length > 50)
						listError.Add(new Error { Description = string.Format("Tamanho da localidade do documento {0} do local de descarga incorrecto.", DocumentNumber), Field = "City", TypeofError = GetType(), Value = ShipTo.Address.City, UID = Pk });
					if (string.IsNullOrEmpty(ShipTo.Address.Country) || ShipTo.Address.Country.Length != 2)
						listError.Add(new Error { Description = string.Format("Tamanho do País do documento {0} do local de descarga incorrecto.", DocumentNumber), Field = "Country", TypeofError = GetType(), Value = ShipTo.Address.Country, UID = Pk });
					if (string.IsNullOrEmpty(ShipTo.Address.PostalCode) || ShipTo.Address.PostalCode.Length > 20)
						listError.Add(new Error { Description = string.Format("Tamanho do código postal do documento {0} do local de descarga incorrecto.", DocumentNumber), Field = "PostalCode", TypeofError = GetType(), Value = ShipTo.Address.PostalCode, UID = Pk });
					if (string.IsNullOrEmpty(ShipTo.Address.Region) == false && ShipTo.Address.Region.Length > 50)
						listError.Add(new Error { Description = string.Format("Tamanho do distrito do documento {0} do local de descarga incorrecto.", DocumentNumber), Field = "Region", TypeofError = GetType(), Value = ShipTo.Address.Region, UID = Pk });
					if (string.IsNullOrEmpty(ShipTo.Address.StreetName) == false && ShipTo.Address.StreetName.Length > 90)
						listError.Add(new Error { Description = string.Format("Tamanho do nome da rua do documento {0} do local de descarga incorrecto.", DocumentNumber), Field = "StreetName", TypeofError = GetType(), Value = ShipTo.Address.StreetName, UID = Pk });
				}
				if (ShipTo.DeliveryDate > DateTime.Now)
					listError.Add(new Error { Description = string.Format("Data da entrega do documento {0} incorrecto.", DocumentNumber), Field = "DeliveryDate", TypeofError = GetType(), Value = ShipTo.DeliveryDate.ToString(), UID = Pk });
			}

			return listError.ToArray();
		}
		public Error[] ValidateShipFrom()
		{
			List<Error> listError = new List<Error>();

			if (ShipFrom != null)
			{
				if (ShipFrom.Address != null)
				{
					if (string.IsNullOrEmpty(ShipFrom.Address.AddressDetail) || ShipFrom.Address.AddressDetail.Length > 100)
						listError.Add(new Error { Description = string.Format("Tamanho da morada detalhada do documento {0} do local de carga incorrecto.", DocumentNumber), Field = "AddressDetail", TypeofError = GetType(), Value = ShipFrom.Address.AddressDetail, UID = Pk });
					if (string.IsNullOrEmpty(ShipFrom.Address.BuildingNumber) == false && ShipFrom.Address.BuildingNumber.Length > 10)
						listError.Add(new Error { Description = string.Format("Tamanho do número de polícia do documento {0} do local de carga incorrecto.", DocumentNumber), Field = "BuildingNumber", TypeofError = GetType(), Value = ShipFrom.Address.BuildingNumber, UID = Pk });
					if (string.IsNullOrEmpty(ShipFrom.Address.City) || ShipFrom.Address.City.Length > 50)
						listError.Add(new Error { Description = string.Format("Tamanho da localidade do documento {0} do local de carga incorrecto.", DocumentNumber), Field = "City", TypeofError = GetType(), Value = ShipFrom.Address.City, UID = Pk });
					if (string.IsNullOrEmpty(ShipFrom.Address.Country) || ShipFrom.Address.Country.Length != 2)
						listError.Add(new Error { Description = string.Format("Tamanho do País do documento {0} do local de carga incorrecto.", DocumentNumber), Field = "Country", TypeofError = GetType(), Value = ShipFrom.Address.Country, UID = Pk });
					if (string.IsNullOrEmpty(ShipFrom.Address.PostalCode) || ShipFrom.Address.PostalCode.Length > 20)
						listError.Add(new Error { Description = string.Format("Tamanho do código postal do documento {0} do local de carga incorrecto.", DocumentNumber), Field = "PostalCode", TypeofError = GetType(), Value = ShipFrom.Address.PostalCode, UID = Pk });
					if (string.IsNullOrEmpty(ShipFrom.Address.Region) == false && ShipFrom.Address.Region.Length > 50)
						listError.Add(new Error { Description = string.Format("Tamanho do distrito do documento {0} do local de carga incorrecto.", DocumentNumber), Field = "Region", TypeofError = GetType(), Value = ShipFrom.Address.Region, UID = Pk });
					if (string.IsNullOrEmpty(ShipFrom.Address.StreetName) == false && ShipFrom.Address.StreetName.Length > 90)
						listError.Add(new Error { Description = string.Format("Tamanho do nome da rua do documento {0} do local de carga incorrecto.", DocumentNumber), Field = "StreetName", TypeofError = GetType(), Value = ShipFrom.Address.StreetName, UID = Pk });
				}
				if (ShipFrom.DeliveryDate > DateTime.Now)
					listError.Add(new Error { Description = string.Format("Data da receção do documento {0} incorrecto.", DocumentNumber), Field = "DeliveryDate", TypeofError = GetType(), Value = ShipFrom.DeliveryDate.ToString(), UID = Pk });
			}

			return listError.ToArray();
		}
		public Error[] ValidateDocumentTotals()
		{
			List<Error> listError = new List<Error>();

			if (DocumentTotals == null)
				listError.Add(new Error { Description = string.Format("Totais do documento {0} inexistentes.", DocumentNumber), Field = "DocumentTotals", TypeofError = GetType(), UID = Pk });

			if (DocumentTotals != null)
			{
				if (DocumentTotals.Currency != null)
				{
					if (DocumentTotals.Currency.CurrencyAmount < 0)
						listError.Add(new Error { Description = string.Format("Valor total em moeda estrangeira do documento {0} incorrecto.", DocumentNumber), Field = "CurrencyAmount", TypeofError = GetType(), Value = DocumentTotals.Currency.CurrencyAmount.ToString(), UID = Pk });
					if (string.IsNullOrEmpty(DocumentTotals.Currency.CurrencyCode) || DocumentTotals.Currency.CurrencyCode.Length > 3)
						listError.Add(new Error { Description = string.Format("Tamanho do código de moeda do documento {0} incorrecto.", DocumentNumber), Field = "CurrencyCode", TypeofError = GetType(), Value = DocumentTotals.Currency.CurrencyCode, UID = Pk });
					if (DocumentTotals.Currency.ExchangeRate < 0)
						listError.Add(new Error { Description = string.Format("Taxa de câmbio do documento {0} incorrecta.", DocumentNumber), Field = "ExchangeRate", TypeofError = GetType(), Value = DocumentTotals.Currency.ExchangeRate.ToString(), UID = Pk });
				}

				if (DocumentTotals.GrossTotal < 0)
					listError.Add(new Error { Description = string.Format("Total do documento {0} incorrecto.", DocumentNumber), Field = "GrossTotal", TypeofError = GetType(), Value = DocumentTotals.GrossTotal.ToString(), UID = Pk });
				if (DocumentTotals.NetTotal < 0)
					listError.Add(new Error { Description = string.Format("Total do documento {0} sem impostos incorrecto.", DocumentNumber), Field = "NetTotal", TypeofError = GetType(), Value = DocumentTotals.NetTotal.ToString(), UID = Pk });
				if (DocumentTotals.TaxPayable < 0)
					listError.Add(new Error { Description = string.Format("Valor do imposto a pagar do documento {0} incorrecto.", DocumentNumber), Field = "TaxPayable", TypeofError = GetType(), Value = DocumentTotals.TaxPayable.ToString(), UID = Pk });
			}

			return listError.ToArray();
		}
		#endregion
	}

	public partial class SourceDocumentsMovementOfGoodsStockMovementLine : BaseData, IDataErrorInfo
	{
		/// <summary>
		/// Link to the doc
		/// </summary>
		public string DocNo { get; set; }

		//MovementOfGoodsLineToolTipService tooltip;
		//public MovementOfGoodsLineToolTipService Tooltip
		//{
		//    get
		//    {
		//        if (tooltip == null)
		//            tooltip = new MovementOfGoodsLineToolTipService();
		//        return tooltip;
		//    }
		//    set { tooltip = value; }
		//}

		public string Error
		{
			get
			{
				StringBuilder error = new StringBuilder();

				// iterate over all of the properties
				// of this object - aggregating any validation errors
				PropertyDescriptorCollection props = TypeDescriptor.GetProperties(this);
				foreach (PropertyDescriptor prop in props)
				{
					String propertyError = this[prop.Name];
					if (propertyError != string.Empty)
						error.Append((error.Length != 0 ? ", " : "") + propertyError);
				}

				return error.Length == 0 ? null : error.ToString();
			}
		}

		[System.Runtime.CompilerServices.IndexerName("Items")]
		public string this[string columnName]
		{
			get
			{
				Error erro = null;
				if (columnName == "LineNumber")
				{
					erro = ValidateLineNumber(appendError: true);
				}
				else if (columnName == "ProductCode")
				{
					erro = ValidateProductCode(appendError: true);
				}
				else if (columnName == "ProductDescription")
				{
					erro = ValidateProductDescription(appendError: true);
				}
				else if (columnName == "Quantity")
				{
					erro = ValidateQuantity(appendError: true);
				}
				else if (columnName == "UnitOfMeasure")
				{
					erro = ValidateUnitOfMeasure(appendError: true);
				}
				else if (columnName == "UnitPrice")
				{
					erro = ValidateUnitPrice(appendError: true);
				}
				return erro?.Description;
			}
		}

		public Error ValidateLineNumber(bool appendError = false, string SupPk = "", string movement = "")
		{
			Error erro = null;
			int num = -1;
			if (!string.IsNullOrEmpty(LineNumber))
				Int32.TryParse(LineNumber, out num);

			if (string.IsNullOrEmpty(LineNumber) || num == -1)
			{
				if (!string.IsNullOrEmpty(movement))
					movement = string.Format(", documento {0}", movement);

				erro = new Error { Description = string.Format("Número de linha incorrecto {0}.", movement), Field = "LineNumber", TypeofError = GetType(), Value = LineNumber, UID = Pk, SupUID = SupPk };
				//if (appendError)
				//    Tooltip.LineNumber = Tooltip.LineNumber.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateProductCode(bool appendError = false, string SupPk = "", string movement = "")
		{
			Error erro = null;
			if (string.IsNullOrEmpty(ProductCode) || ProductCode.Length > 30)
			{
				if (!string.IsNullOrEmpty(movement))
					movement = string.Format(" documento {0}", movement);

				erro = new Error { Description = string.Format("Identificador do produto ou serviço incorrecto, {0} linha {1}.", movement, LineNumber), Field = "ProductCode", TypeofError = GetType(), Value = ProductCode, UID = Pk, SupUID = SupPk };
				//if (appendError)
				//    Tooltip.ProductCode = Tooltip.ProductCode.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateProductDescription(bool appendError = false, string SupPk = "", string movement = "")
		{
			Error erro = null;
			if (string.IsNullOrEmpty(ProductDescription) || ProductDescription.Length > 200)
			{
				if (!string.IsNullOrEmpty(movement))
					movement = string.Format(" documento {0}", movement);

				erro = new Error { Description = string.Format("Descrição do produto ou serviço incorrecta, {0} linha {1}.", movement, LineNumber), Field = "ProductDescription", TypeofError = GetType(), Value = ProductDescription, UID = Pk, SupUID = SupPk };
				//if (appendError)
				//    Tooltip.ProductDescription = Tooltip.ProductDescription.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateQuantity(bool appendError = false, string SupPk = "", string movement = "")
		{
			Error erro = null;
			if (Quantity <= 0)
			{
				if (!string.IsNullOrEmpty(movement))
					movement = string.Format(" documento {0}", movement);

				erro = new Error { Description = string.Format("Quantidade incorrecta, {0} linha {1}.", movement, LineNumber), Field = "Quantity", TypeofError = GetType(), Value = Quantity.ToString(), UID = Pk, SupUID = SupPk };
				//if (appendError)
				//    Tooltip.Quantity = Tooltip.Quantity.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateUnitOfMeasure(bool appendError = false, string SupPk = "", string movement = "")
		{
			Error erro = null;
			if (string.IsNullOrEmpty(UnitOfMeasure) || UnitOfMeasure.Length > 20)
			{
				if (!string.IsNullOrEmpty(movement))
					movement = string.Format(" documento {0}", movement);

				erro = new Error { Description = string.Format("Unidade de medida incorrecta, {0} linha {1}.", movement, LineNumber), Field = "UnitOfMeasure", TypeofError = GetType(), Value = UnitOfMeasure, UID = Pk, SupUID = SupPk };
				//if (appendError)
				//    Tooltip.UnitOfMeasure = Tooltip.UnitOfMeasure.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateUnitPrice(bool appendError = false, string SupPk = "", string movement = "")
		{
			Error erro = null;
			if (UnitPrice == 0)
			{
				if (!string.IsNullOrEmpty(movement))
					movement = string.Format(" documento {0}", movement);

				erro = new Error { Description = string.Format("Preço unitário incorrecto, {0} linha {1}.", movement, LineNumber), Field = "UnitPrice", TypeofError = GetType(), Value = UnitPrice.ToString(), UID = Pk, SupUID = SupPk };
				//if (appendError)
				//    Tooltip.UnitPrice = Tooltip.UnitPrice.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}

		public Error[] ValidateOrderReferences(string SupPk = "", string movement = "")
		{
			List<Error> listError = new List<Error>();

			if (OrderReferences != null && OrderReferences.Length > 0)
			{
				foreach (var referencia in OrderReferences)
				{
					if (string.IsNullOrEmpty(referencia.OriginatingON) == false && referencia.OriginatingON.Length > 60)
						listError.Add(new Error { Description = string.Format("Tamanho do número do documento de origem na linha {0} do documento {1} incorrecto.", LineNumber, movement), Field = "OriginatingON", TypeofError = GetType(), Value = referencia.OriginatingON, UID = Pk, SupUID = SupPk });
					if (referencia.OrderDateSpecified && referencia.OrderDate > DateTime.Now)
						listError.Add(new Error { Description = string.Format("Data do documento de origem na linha {0} do documento {1} incorrecto.", LineNumber, movement), Field = "OrderDate", TypeofError = GetType(), Value = referencia.OrderDate.ToString(), UID = Pk, SupUID = SupPk });
				}
			}

			return listError.ToArray();
		}
		public Error[] ValidateTax(string SupPk = "", string movement = "")
		{
			List<Error> listError = new List<Error>();

			if (Tax == null)
				listError.Add(new Error { Description = string.Format("Taxa de imposto na linha {0} do documento {1} inexistente.", LineNumber, movement), Field = "Tax", TypeofError = GetType(), UID = Pk, SupUID = SupPk });

			if (Tax != null)
			{
				if (Tax.TaxPercentage < 0 || Tax.TaxPercentage > 100)
					listError.Add(new Error { Description = string.Format("Percentagem da taxa do imposto na linha {0} do documento {1} incorrecto.", LineNumber, movement), Field = "TaxPercentage", TypeofError = GetType(), Value = Tax.TaxPercentage.ToString(), UID = Pk, SupUID = SupPk });
				if (string.IsNullOrEmpty(Tax.TaxCode) || Tax.TaxCode.Length > 10)
					listError.Add(new Error { Description = string.Format("Código da taxa na linha {0} do documento {1} incorrecto.", LineNumber, movement), Field = "TaxCode", TypeofError = GetType(), Value = Tax.TaxCode, UID = Pk, SupUID = SupPk });
				if (string.IsNullOrEmpty(Tax.TaxCountryRegion) || Tax.TaxCountryRegion.Length > 5)
					listError.Add(new Error { Description = string.Format("País ou região do imposto na linha {0} do documento {1} incorrecto.", LineNumber, movement), Field = "TaxCountryRegion", TypeofError = GetType(), Value = Tax.TaxCountryRegion, UID = Pk, SupUID = SupPk });
			}

			return listError.ToArray();
		}
	}

	public partial class SourceDocumentsWorkingDocumentsWorkDocument : BaseData, IDataErrorInfo
	{
		public string HashTest { get; set; }

		//WorkingDocumentsToolTipService tooltip;
		//public WorkingDocumentsToolTipService Tooltip
		//{
		//    get
		//    {
		//        if (tooltip == null)
		//            tooltip = new WorkingDocumentsToolTipService();
		//        return tooltip;
		//    }
		//    set { tooltip = value; }
		//}

		public string Error
		{
			get
			{
				StringBuilder error = new StringBuilder();

				// iterate over all of the properties
				// of this object - aggregating any validation errors
				PropertyDescriptorCollection props = TypeDescriptor.GetProperties(this);
				foreach (PropertyDescriptor prop in props)
				{
					String propertyError = this[prop.Name];
					if (propertyError != string.Empty)
						error.Append((error.Length != 0 ? ", " : "") + propertyError);
				}

				return error.Length == 0 ? null : error.ToString();
			}
		}

		[System.Runtime.CompilerServices.IndexerName("Items")]
		public string this[string columnName]
		{
			get
			{
				Error erro = null;
				if (columnName == "DocumentNumber")
				{
					erro = ValidateDocumentNumber(appendError: true);
				}
				else if (columnName == "Hash")
				{
					erro = ValidateHash(appendError: true);
				}
				else if (columnName == "HashControl")
				{
					erro = ValidateHashControl(appendError: true);
				}
				else if (columnName == "Period")
				{
					erro = ValidatePeriod(appendError: true);
				}
				else if (columnName == "WorkDate")
				{
					erro = ValidateWorkDate(appendError: true);
				}
				else if (columnName == "SystemEntryDate")
				{
					erro = ValidateSystemEntryDate(appendError: true);
				}
				return erro?.Description;
			}
		}

		#region Validation
		public Error ValidateDocumentNumber(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(DocumentNumber) || DocumentNumber.Length > 60)
			{
				erro = new Error { Description = "Identificação única com tamanho incorrecto.", Field = "DocumentNumber", TypeofError = GetType(), Value = DocumentNumber, UID = Pk };
				//if (appendError)
				//    Tooltip.DocumentNumber = Tooltip.DocumentNumber.FormatTooltipWithError(erro.Description);
			}
			else if (!Regex.IsMatch(DocumentNumber, "([a-zA-Z0-9./_-])+ ([a-zA-Z0-9]*/[0-9]+)"))
			{
				erro = new Error { Description = "Identificação única com caracteres não permitidos.", Field = "DocumentNumber", TypeofError = GetType(), Value = DocumentNumber, UID = Pk };
				//if (appendError)
				//    Tooltip.DocumentNumber = Tooltip.DocumentNumber.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateHash(bool appendError = false)
		{
			Error erro = null;

			if (string.IsNullOrEmpty(Hash) || Hash.Length != 172)
			{
				erro = new Error { Description = string.Format("Assinatura do documento {0} de tamanho incorrecto.", DocumentNumber), Field = "Hash", TypeofError = GetType(), Value = Hash, UID = Pk };
				//if (appendError)
				//    Tooltip.Hash = Tooltip.Hash.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateHashControl(bool appendError = false)
		{
			Error erro = null;

			if (string.IsNullOrEmpty(HashControl) || HashControl.Length > 40)
			{
				erro = new Error { Description = string.Format("Versão da chave privada utilizada na assinatura do documento {0} incorrecta.", DocumentNumber), Field = "HashControl", TypeofError = GetType(), Value = HashControl, UID = Pk };
				//if (appendError)
				//    Tooltip.HashControl = Tooltip.HashControl.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidatePeriod(bool appendError = false)
		{
			Error erro = null;

			if (string.IsNullOrEmpty(Period) == false)
			{
				int periodo = -1;
				Int32.TryParse(Period, out periodo);

				if (periodo < 1 || periodo > 12)
				{
					erro = new Error { Description = string.Format("Mês do período de tributação do documento {0} incorrecto.", DocumentNumber), Field = "Period", TypeofError = GetType(), Value = Period, UID = Pk };
					//if (appendError)
					//    Tooltip.Period = Tooltip.Period.FormatTooltipWithError(erro.Description);
				}
			}

			return erro;
		}
		public Error ValidateWorkDate(bool appendError = false)
		{
			Error erro = null;

			if (WorkDate > DateTime.Now)
			{
				erro = new Error { Description = string.Format("Data de emissão do documento {0} incorrecta.", DocumentNumber), Field = "WorkDate", TypeofError = GetType(), Value = WorkDate.ToString(), UID = Pk };
				//if (appendError)
				//    Tooltip.WorkDate = Tooltip.WorkDate.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateSystemEntryDate(bool appendError = false)
		{
			Error erro = null;

			if (SystemEntryDate > DateTime.Now)
			{
				erro = new Error { Description = string.Format("Data da gravação do documento {0} incorrecta.", DocumentNumber), Field = "SystemEntryDate", TypeofError = GetType(), Value = SystemEntryDate.ToString(), UID = Pk };
				//if (appendError)
				//    Tooltip.SystemEntryDate = Tooltip.SystemEntryDate.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}

		public Error[] ValidateDocumentStatus()
		{
			List<Error> listError = new List<Error>();

			if (DocumentStatus == null)
				listError.Add(new Error { Description = string.Format("Situação do documento {0} inexistente.", DocumentNumber), Field = "DocumentStatus", TypeofError = GetType(), UID = Pk });

			if (DocumentStatus != null)
			{
				if (DocumentStatus.WorkStatusDate > DateTime.Now)
					listError.Add(new Error { Description = string.Format("Data e hora do estado atual do documento {0} incorrecta.", DocumentNumber), Field = "InvoiceStatusDate", TypeofError = GetType(), Value = DocumentStatus.WorkStatusDate.ToString(), UID = Pk });
				if (string.IsNullOrEmpty(DocumentStatus.Reason) == false && DocumentStatus.Reason.Length > 50)
					listError.Add(new Error { Description = string.Format("Tamanho do motivo da alteração de estado {0} incorrecto.", DocumentNumber), Field = "Reason", TypeofError = GetType(), Value = DocumentStatus.Reason, UID = Pk });
				if (string.IsNullOrEmpty(DocumentStatus.SourceID) || DocumentStatus.SourceID.Length > 30)
					listError.Add(new Error { Description = string.Format("Utilizador responsável pelo estado atual do documento {0} incorrecto.", DocumentNumber), Field = "SourceID", TypeofError = GetType(), Value = DocumentStatus.SourceID, UID = Pk });
			}

			return listError.ToArray();
		}
		public Error[] ValidateDocumentTotals()
		{
			List<Error> listError = new List<Error>();

			if (DocumentTotals == null)
				listError.Add(new Error { Description = string.Format("Totais do documento {0} inexistentes.", DocumentNumber), Field = "DocumentTotals", TypeofError = GetType(), UID = Pk });

			if (DocumentTotals != null)
			{
				if (DocumentTotals.Currency != null)
				{
					if (DocumentTotals.Currency.CurrencyAmount < 0)
						listError.Add(new Error { Description = string.Format("Valor total em moeda estrangeira do documento {0} incorrecto.", DocumentNumber), Field = "CurrencyAmount", TypeofError = GetType(), Value = DocumentTotals.Currency.CurrencyAmount.ToString(), UID = Pk });
					if (string.IsNullOrEmpty(DocumentTotals.Currency.CurrencyCode) || DocumentTotals.Currency.CurrencyCode.Length > 3)
						listError.Add(new Error { Description = string.Format("Tamanho do código de moeda do documento {0} incorrecto.", DocumentNumber), Field = "CurrencyCode", TypeofError = GetType(), Value = DocumentTotals.Currency.CurrencyCode, UID = Pk });
					if (DocumentTotals.Currency.ExchangeRate < 0)
						listError.Add(new Error { Description = string.Format("Taxa de câmbio do documento {0} incorrecta.", DocumentNumber), Field = "ExchangeRate", TypeofError = GetType(), Value = DocumentTotals.Currency.ExchangeRate.ToString(), UID = Pk });
				}

				if (DocumentTotals.GrossTotal < 0)
					listError.Add(new Error { Description = string.Format("Total do documento {0} incorrecto.", DocumentNumber), Field = "GrossTotal", TypeofError = GetType(), Value = DocumentTotals.GrossTotal.ToString(), UID = Pk });
				if (DocumentTotals.NetTotal < 0)
					listError.Add(new Error { Description = string.Format("Total do documento {0} sem impostos incorrecto.", DocumentNumber), Field = "NetTotal", TypeofError = GetType(), Value = DocumentTotals.NetTotal.ToString(), UID = Pk });
				if (DocumentTotals.TaxPayable < 0)
					listError.Add(new Error { Description = string.Format("Valor do imposto a pagar do documento {0} incorrecto.", DocumentNumber), Field = "TaxPayable", TypeofError = GetType(), Value = DocumentTotals.TaxPayable.ToString(), UID = Pk });
			}

			return listError.ToArray();
		}
		#endregion
	}

	public partial class SourceDocumentsWorkingDocumentsWorkDocumentLine : BaseData, IDataErrorInfo
	{
		/// <summary>
		/// Link to the doc
		/// </summary>
		public string DocNo { get; set; }

		//WorkingDocumentsLineToolTipService tooltip;
		//public WorkingDocumentsLineToolTipService Tooltip
		//{
		//    get
		//    {
		//        if (tooltip == null)
		//            tooltip = new WorkingDocumentsLineToolTipService();
		//        return tooltip;
		//    }
		//    set { tooltip = value; }
		//}

		public string Error
		{
			get
			{
				StringBuilder error = new StringBuilder();

				// iterate over all of the properties
				// of this object - aggregating any validation errors
				PropertyDescriptorCollection props = TypeDescriptor.GetProperties(this);
				foreach (PropertyDescriptor prop in props)
				{
					String propertyError = this[prop.Name];
					if (propertyError != string.Empty)
						error.Append((error.Length != 0 ? ", " : "") + propertyError);
				}

				return error.Length == 0 ? null : error.ToString();
			}
		}

		[System.Runtime.CompilerServices.IndexerName("Items")]
		public string this[string columnName]
		{
			get
			{
				Error erro = null;
				if (columnName == "LineNumber")
				{
					erro = ValidateLineNumber(appendError: true);
				}
				else if (columnName == "ProductCode")
				{
					erro = ValidateProductCode(appendError: true);
				}
				else if (columnName == "Quantity")
				{
					erro = ValidateQuantity(appendError: true);
				}
				else if (columnName == "UnitOfMeasure")
				{
					erro = ValidateUnitOfMeasure(appendError: true);
				}
				else if (columnName == "UnitPrice")
				{
					erro = ValidateUnitPrice(appendError: true);
				}
				else if (columnName == "TaxPointDate")
				{
					erro = ValidateTaxPointDate(appendError: true);
				}
				return erro == null ? erro.Description : "";
			}
		}

		public Error ValidateLineNumber(bool appendError = false, string SupPk = "", string workingDocument = "")
		{
			Error erro = null;
			int num = -1;
			if (!string.IsNullOrEmpty(LineNumber))
				Int32.TryParse(LineNumber, out num);

			if (string.IsNullOrEmpty(LineNumber) || num == -1)
			{
				if (!string.IsNullOrEmpty(workingDocument))
					workingDocument = string.Format(", documento {0}", workingDocument);

				erro = new Error { Description = string.Format("Número de linha incorrecto {0}.", workingDocument), Field = "LineNumber", TypeofError = GetType(), Value = LineNumber, UID = Pk, SupUID = SupPk };
				//if (appendError)
				//    Tooltip.LineNumber = Tooltip.LineNumber.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateProductCode(bool appendError = false, string SupPk = "", string workingDocument = "")
		{
			Error erro = null;
			if (string.IsNullOrEmpty(ProductCode) || ProductCode.Length > 30)
			{
				if (!string.IsNullOrEmpty(workingDocument))
					workingDocument = string.Format(" documento {0}", workingDocument);

				erro = new Error { Description = string.Format("Identificador do produto ou serviço incorrecto, {0} linha {1}.", workingDocument, LineNumber), Field = "ProductCode", TypeofError = GetType(), Value = ProductCode, UID = Pk, SupUID = SupPk };
				//if (appendError)
				//    Tooltip.ProductCode = Tooltip.ProductCode.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateProductDescription(bool appendError = false, string SupPk = "", string workingDocument = "")
		{
			Error erro = null;
			if (string.IsNullOrEmpty(ProductDescription) || ProductDescription.Length > 200)
			{
				if (!string.IsNullOrEmpty(workingDocument))
					workingDocument = string.Format(" documento {0}", workingDocument);

				erro = new Error { Description = string.Format("Descrição do produto ou serviço incorrecta, {0} linha {1}.", workingDocument, LineNumber), Field = "ProductDescription", TypeofError = GetType(), Value = ProductDescription, UID = Pk, SupUID = SupPk };
				//if (appendError)
				//    Tooltip.ProductDescription = Tooltip.ProductDescription.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateQuantity(bool appendError = false, string SupPk = "", string workingDocument = "")
		{
			Error erro = null;
			if (Quantity <= 0)
			{
				if (!string.IsNullOrEmpty(workingDocument))
					workingDocument = string.Format(" documento {0}", workingDocument);

				erro = new Error { Description = string.Format("Quantidade incorrecta, {0} linha {1}.", workingDocument, LineNumber), Field = "Quantity", TypeofError = GetType(), Value = Quantity.ToString(), UID = Pk, SupUID = SupPk };
				//if (appendError)
				//    Tooltip.Quantity = Tooltip.Quantity.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateUnitOfMeasure(bool appendError = false, string SupPk = "", string workingDocument = "")
		{
			Error erro = null;
			if (string.IsNullOrEmpty(UnitOfMeasure) || UnitOfMeasure.Length > 20)
			{
				if (!string.IsNullOrEmpty(workingDocument))
					workingDocument = string.Format(" documento {0}", workingDocument);

				erro = new Error { Description = string.Format("Unidade de medida incorrecta, {0} linha {1}.", workingDocument, LineNumber), Field = "UnitOfMeasure", TypeofError = GetType(), Value = UnitOfMeasure, UID = Pk, SupUID = SupPk };
				//if (appendError)
				//    Tooltip.UnitOfMeasure = Tooltip.UnitOfMeasure.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateUnitPrice(bool appendError = false, string SupPk = "", string workingDocument = "")
		{
			Error erro = null;
			if (UnitPrice == 0)
			{
				if (!string.IsNullOrEmpty(workingDocument))
					workingDocument = string.Format(" documento {0}", workingDocument);

				erro = new Error { Description = string.Format("Preço unitário incorrecto, {0} linha {1}.", workingDocument, LineNumber), Field = "UnitPrice", TypeofError = GetType(), Value = UnitPrice.ToString(), UID = Pk, SupUID = SupPk };
				//if (appendError)
				//    Tooltip.UnitPrice = Tooltip.UnitPrice.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateTaxPointDate(bool appendError = false, string SupPk = "", string workingDocument = "")
		{
			Error erro = null;
			if (TaxPointDate > DateTime.Now)
			{
				if (!string.IsNullOrEmpty(workingDocument))
					workingDocument = string.Format(" documento {0}", workingDocument);

				erro = new Error { Description = string.Format("Data de envio da mercadoria ou prestação do serviço incorrecta, {0} linha {1}.", workingDocument, LineNumber), Field = "TaxPointDate", TypeofError = GetType(), Value = TaxPointDate.ToString(), UID = Pk, SupUID = SupPk };
				//if (appendError)
				//    Tooltip.TaxPointDate = Tooltip.TaxPointDate.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}

		public Error[] ValidateOrderReferences(string SupPk = "", string workingDocument = "")
		{
			List<Error> listError = new List<Error>();

			if (OrderReferences != null && OrderReferences.Length > 0)
			{
				foreach (var referencia in OrderReferences)
				{
					if (string.IsNullOrEmpty(referencia.OriginatingON) == false && referencia.OriginatingON.Length > 60)
						listError.Add(new Error { Description = string.Format("Tamanho do número do documento de origem na linha {0} do documento {1} incorrecto.", LineNumber, workingDocument), Field = "OriginatingON", TypeofError = GetType(), Value = referencia.OriginatingON, UID = Pk, SupUID = SupPk });
					if (referencia.OrderDate > DateTime.Now)
						listError.Add(new Error { Description = string.Format("Data do documento de origem na linha {0} do documento {1} incorrecto.", LineNumber, workingDocument), Field = "OrderDate", TypeofError = GetType(), Value = referencia.OrderDate.ToString(), UID = Pk, SupUID = SupPk });
				}
			}

			return listError.ToArray();
		}
		public Error[] ValidateTax(string SupPk = "", string workingDocument = "")
		{
			List<Error> listError = new List<Error>();

			if (Tax == null)
				listError.Add(new Error { Description = string.Format("Taxa de imposto na linha {0} do documento {1} inexistente.", LineNumber, workingDocument), Field = "Tax", TypeofError = GetType(), UID = Pk, SupUID = SupPk });

			if (Tax != null)
			{
				if (Tax.ItemElementName == ItemChoiceType1.TaxAmount && Tax.Item < 0)
					listError.Add(new Error { Description = string.Format("Montante do imposto na linha {0} do documento {1} incorrecto.", LineNumber, workingDocument), Field = "TaxAmount", TypeofError = GetType(), Value = Tax.Item.ToString(), UID = Pk, SupUID = SupPk });
				if (Tax.ItemElementName == ItemChoiceType1.TaxPercentage && (Tax.Item < 0 || Tax.Item > 100))
					listError.Add(new Error { Description = string.Format("Percentagem da taxa do imposto na linha {0} do documento {1} incorrecto.", LineNumber, workingDocument), Field = "TaxPercentage", TypeofError = GetType(), Value = Tax.Item.ToString(), UID = Pk, SupUID = SupPk });
				if (string.IsNullOrEmpty(Tax.TaxCode) || Tax.TaxCode.Length > 10)
					listError.Add(new Error { Description = string.Format("Código da taxa na linha {0} do documento {1} incorrecto.", LineNumber, workingDocument), Field = "TaxCode", TypeofError = GetType(), Value = Tax.TaxCode, UID = Pk, SupUID = SupPk });
				if (string.IsNullOrEmpty(Tax.TaxCountryRegion) || Tax.TaxCountryRegion.Length > 5)
					listError.Add(new Error { Description = string.Format("País ou região do imposto na linha {0} do documento {1} incorrecto.", LineNumber, workingDocument), Field = "TaxCountryRegion", TypeofError = GetType(), Value = Tax.TaxCountryRegion, UID = Pk, SupUID = SupPk });
			}

			return listError.ToArray();
		}
	}

	public partial class SourceDocumentsSalesInvoicesInvoice : BaseData, IDataErrorInfo
	{
		public string HashTest { get; set; }

		//SourceDocumentsToolTipService tooltip;
		//public SourceDocumentsToolTipService Tooltip
		//{
		//    get
		//    {
		//        if (tooltip == null)
		//            tooltip = new SourceDocumentsToolTipService();
		//        return tooltip;
		//    }
		//    set { tooltip = value; }
		//}

		public string Error
		{
			get
			{
				StringBuilder error = new StringBuilder();

				// iterate over all of the properties
				// of this object - aggregating any validation errors
				PropertyDescriptorCollection props = TypeDescriptor.GetProperties(this);
				foreach (PropertyDescriptor prop in props)
				{
					String propertyError = this[prop.Name];
					if (propertyError != string.Empty)
						error.Append((error.Length != 0 ? ", " : "") + propertyError);
				}

				return error.Length == 0 ? null : error.ToString();
			}
		}

		public string this[string columnName]
		{
			get
			{
				Error erro = null;
				if (columnName == "InvoiceNo")
				{
					erro = ValidateInvoiceNo(appendError: true);
				}
				else if (columnName == "Hash")
				{
					erro = ValidateHash(appendError: true);
				}
				else if (columnName == "HashControl")
				{
					erro = ValidateHashControl(appendError: true);
				}
				else if (columnName == "Period")
				{
					erro = ValidatePeriod(appendError: true);
				}
				else if (columnName == "InvoiceDate")
				{
					erro = ValidateInvoiceDate(appendError: true);
				}
				else if (columnName == "SystemEntryDate")
				{
					erro = ValidateSystemEntryDate(appendError: true);
				}
				else if (columnName == "TransactionID")
				{
					erro = ValidateTransactionID(appendError: true);
				}
				else if (columnName == "CustomerID")
				{
					erro = ValidateCustomerID(appendError: true);
				}
				else if (columnName == "SourceID")
				{
					erro = ValidateSourceID(appendError: true);
				}
				else if (columnName == "MovementEndTime")
				{
					erro = ValidateMovementEndTime(appendError: true);
				}
				else if (columnName == "MovementStartTime")
				{
					erro = ValidateMovementStartTime(appendError: true);
				}

				return erro?.Description;
			}
		}

		#region Validation
		public Error ValidateInvoiceNo(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(InvoiceNo) || InvoiceNo.Length > 60)
			{
				erro = new Error { Description = "Identificação única com tamanho incorrecto.", Field = "InvoiceNo", TypeofError = GetType(), Value = InvoiceNo, UID = Pk };
				//if (appendError)
				//    Tooltip.InvoiceNo = Tooltip.InvoiceNo.FormatTooltipWithError(erro.Description);
			}
			else if (!Regex.IsMatch(InvoiceNo, "([a-zA-Z0-9./_-])+ ([a-zA-Z0-9]*/[0-9]+)"))
			{
				erro = new Error { Description = "Identificação única com caracteres não permitidos.", Field = "InvoiceNo", TypeofError = GetType(), Value = InvoiceNo, UID = Pk };
				//if (appendError)
				//    Tooltip.InvoiceNo = Tooltip.InvoiceNo.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateHash(bool appendError = false)
		{
			Error erro = null;

			if (string.IsNullOrEmpty(Hash) || Hash.Length != 172)
			{
				erro = new Error { Description = string.Format("Assinatura do documento {0} de tamanho incorrecto.", InvoiceNo), Field = "Hash", TypeofError = GetType(), Value = Hash, UID = Pk };
				//if (appendError)
				//    Tooltip.Hash = Tooltip.Hash.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateHashControl(bool appendError = false)
		{
			Error erro = null;

			if (string.IsNullOrEmpty(HashControl) || HashControl.Length > 40)
			{
				erro = new Error { Description = string.Format("Versão da chave privada utilizada na assinatura do documento {0} incorrecta.", InvoiceNo), Field = "HashControl", TypeofError = GetType(), Value = HashControl, UID = Pk };
				//if (appendError)
				//    Tooltip.HashControl = Tooltip.HashControl.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidatePeriod(bool appendError = false)
		{
			Error erro = null;

			if (string.IsNullOrEmpty(Period) == false)
			{
				int periodo = -1;
				Int32.TryParse(Period, out periodo);

				if (periodo < 1 || periodo > 12)
				{
					erro = new Error { Description = string.Format("Mês do período de tributação do documento {0} incorrecto.", InvoiceNo), Field = "Period", TypeofError = GetType(), Value = Period, UID = Pk };
					//if (appendError)
					//    Tooltip.Period = Tooltip.Period.FormatTooltipWithError(erro.Description);
				}
			}

			return erro;
		}
		public Error ValidateInvoiceDate(bool appendError = false)
		{
			Error erro = null;

			if (InvoiceDate > DateTime.Now)
			{
				erro = new Error { Description = string.Format("Data de emissão do documento {0} incorrecta.", InvoiceNo), Field = "InvoiceDate", TypeofError = GetType(), Value = InvoiceDate.ToString(), UID = Pk };
				//if (appendError)
				//    Tooltip.InvoiceDate = Tooltip.InvoiceDate.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateSystemEntryDate(bool appendError = false)
		{
			Error erro = null;

			if (SystemEntryDate > DateTime.Now)
			{
				erro = new Error { Description = string.Format("Data da gravação do documento {0} incorrecta.", InvoiceNo), Field = "SystemEntryDate", TypeofError = GetType(), Value = SystemEntryDate.ToString(), UID = Pk };
				//if (appendError)
				//    Tooltip.SystemEntryDate = Tooltip.SystemEntryDate.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateTransactionID(bool appendError = false)
		{
			Error erro = null;

			if (!string.IsNullOrEmpty(TransactionID) && TransactionID.Length > 70)
			{
				erro = new Error { Description = string.Format("Identificador da transacção do documento {0} incorrecto.", InvoiceNo), Field = "TransactionID", TypeofError = GetType(), Value = TransactionID, UID = Pk };
				//if (appendError)
				//    Tooltip.TransactionID = Tooltip.TransactionID.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateCustomerID(bool appendError = false)
		{
			Error erro = null;

			if (string.IsNullOrEmpty(CustomerID) || CustomerID.Length > 30)
			{
				erro = new Error { Description = string.Format("Chave única da tabela de clientes no documento {0} incorrecta.", InvoiceNo), Field = "CustomerID", TypeofError = GetType(), Value = CustomerID, UID = Pk };
				//if (appendError)
				//    Tooltip.CustomerID = Tooltip.CustomerID.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateSourceID(bool appendError = false)
		{
			Error erro = null;

			if (string.IsNullOrEmpty(SourceID) || SourceID.Length > 30)
			{
				erro = new Error { Description = string.Format("Utilizador que gerou o documento {0} incorrecto.", InvoiceNo), Field = "CustomerID", TypeofError = GetType(), Value = CustomerID, UID = Pk };
				//if (appendError)
				//    Tooltip.GeneratedDocumentUserSourceID = Tooltip.GeneratedDocumentUserSourceID.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateMovementEndTime(bool appendError = false)
		{
			Error erro = null;

			if (MovementEndTimeSpecified && MovementEndTime > DateTime.Now)
			{
				erro = new Error { Description = string.Format("Data e hora de fim de transporte do documento {0} incorrecta.", InvoiceNo), Field = "MovementEndTime", TypeofError = GetType(), Value = MovementEndTime.ToString(), UID = Pk };
				//if (appendError)
				//    Tooltip.MovementEndTime = Tooltip.MovementEndTime.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateMovementStartTime(bool appendError = false)
		{
			Error erro = null;

			if (MovementStartTimeSpecified && MovementStartTime > DateTime.Now)
			{
				erro = new Error { Description = string.Format("Data e hora de início de transporte do documento {0} incorrecta.", InvoiceNo), Field = "MovementStartTime", TypeofError = GetType(), Value = MovementStartTime.ToString(), UID = Pk };
				//if (appendError)
				//    Tooltip.MovementStartTime = Tooltip.MovementStartTime.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}

		public Error[] ValidateDocumentStatus()
		{
			List<Error> listError = new List<Error>();

			if (DocumentStatus == null)
				listError.Add(new Error { Description = string.Format("Situação do documento {0} inexistente.", InvoiceNo), Field = "DocumentStatus", TypeofError = GetType(), UID = Pk });

			if (DocumentStatus != null)
			{
				if (DocumentStatus.InvoiceStatusDate > DateTime.Now)
					listError.Add(new Error { Description = string.Format("Data e hora do estado atual do documento {0} incorrecta.", InvoiceNo), Field = "InvoiceStatusDate", TypeofError = GetType(), Value = DocumentStatus.InvoiceStatusDate.ToString(), UID = Pk });
				if (string.IsNullOrEmpty(DocumentStatus.Reason) == false && DocumentStatus.Reason.Length > 50)
					listError.Add(new Error { Description = string.Format("Tamanho do motivo da alteração de estado {0} incorrecto.", InvoiceNo), Field = "Reason", TypeofError = GetType(), Value = DocumentStatus.Reason, UID = Pk });
				if (string.IsNullOrEmpty(DocumentStatus.SourceID) || DocumentStatus.SourceID.Length > 30)
					listError.Add(new Error { Description = string.Format("Utilizador responsável pelo estado atual do documento {0} incorrecto.", InvoiceNo), Field = "SourceID", TypeofError = GetType(), Value = DocumentStatus.SourceID, UID = Pk });
			}

			return listError.ToArray();
		}
		public Error[] ValidateSpecialRegimes()
		{
			List<Error> listError = new List<Error>();

			if (SpecialRegimes != null)
			{
				int auto = -1;
				Int32.TryParse(SpecialRegimes.SelfBillingIndicator, out auto);
				if (string.IsNullOrEmpty(SpecialRegimes.SelfBillingIndicator) || (auto != 0 && auto != 1))
					listError.Add(new Error { Description = string.Format("Indicador de autofaturação do documento {0} incorrecto.", InvoiceNo), Field = "SelfBillingIndicator", TypeofError = GetType(), Value = SpecialRegimes.SelfBillingIndicator, UID = Pk });

				if (string.IsNullOrEmpty(SpecialRegimes.CashVATSchemeIndicator) || (SpecialRegimes.CashVATSchemeIndicator != "0" && SpecialRegimes.CashVATSchemeIndicator != "1"))
					listError.Add(new Error { Description = string.Format("Indicador da existência de adesão ao regime de IVA de Caixa do documento {0} incorrecto.", InvoiceNo), Field = "CashVATSchemeIndicator", TypeofError = GetType(), Value = SpecialRegimes.CashVATSchemeIndicator, UID = Pk });
				if (string.IsNullOrEmpty(SpecialRegimes.ThirdPartiesBillingIndicator) || (SpecialRegimes.ThirdPartiesBillingIndicator != "0" && SpecialRegimes.CashVATSchemeIndicator != "1"))
					listError.Add(new Error { Description = string.Format("Indicador da existência de adesão ao regime de IVA de Caixa do documento {0} incorrecto.", InvoiceNo), Field = "ThirdPartiesBillingIndicator", TypeofError = GetType(), Value = SpecialRegimes.ThirdPartiesBillingIndicator, UID = Pk });
			}

			return listError.ToArray();
		}
		public Error[] ValidateShipTo()
		{
			List<Error> listError = new List<Error>();

			if (ShipTo != null)
			{
				if (ShipTo.Address != null)
				{
					if (string.IsNullOrEmpty(ShipTo.Address.AddressDetail) || ShipTo.Address.AddressDetail.Length > 100)
						listError.Add(new Error { Description = string.Format("Tamanho da morada detalhada do documento {0} do local de descarga incorrecto.", InvoiceNo), Field = "AddressDetail", TypeofError = GetType(), Value = ShipTo.Address.AddressDetail, UID = Pk });
					if (string.IsNullOrEmpty(ShipTo.Address.BuildingNumber) == false && ShipTo.Address.BuildingNumber.Length > 10)
						listError.Add(new Error { Description = string.Format("Tamanho do número de polícia do documento {0} do local de descarga incorrecto.", InvoiceNo), Field = "BuildingNumber", TypeofError = GetType(), Value = ShipTo.Address.BuildingNumber, UID = Pk });
					if (string.IsNullOrEmpty(ShipTo.Address.City) || ShipTo.Address.City.Length > 50)
						listError.Add(new Error { Description = string.Format("Tamanho da localidade do documento {0} do local de descarga incorrecto.", InvoiceNo), Field = "City", TypeofError = GetType(), Value = ShipTo.Address.City, UID = Pk });
					if (string.IsNullOrEmpty(ShipTo.Address.Country) || ShipTo.Address.Country.Length != 2)
						listError.Add(new Error { Description = string.Format("Tamanho do País do documento {0} do local de descarga incorrecto.", InvoiceNo), Field = "Country", TypeofError = GetType(), Value = ShipTo.Address.Country, UID = Pk });
					if (string.IsNullOrEmpty(ShipTo.Address.PostalCode) || ShipTo.Address.PostalCode.Length > 20)
						listError.Add(new Error { Description = string.Format("Tamanho do código postal do documento {0} do local de descarga incorrecto.", InvoiceNo), Field = "PostalCode", TypeofError = GetType(), Value = ShipTo.Address.PostalCode, UID = Pk });
					if (string.IsNullOrEmpty(ShipTo.Address.Region) == false && ShipTo.Address.Region.Length > 50)
						listError.Add(new Error { Description = string.Format("Tamanho do distrito do documento {0} do local de descarga incorrecto.", InvoiceNo), Field = "Region", TypeofError = GetType(), Value = ShipTo.Address.Region, UID = Pk });
					if (string.IsNullOrEmpty(ShipTo.Address.StreetName) == false && ShipTo.Address.StreetName.Length > 90)
						listError.Add(new Error { Description = string.Format("Tamanho do nome da rua do documento {0} do local de descarga incorrecto.", InvoiceNo), Field = "StreetName", TypeofError = GetType(), Value = ShipTo.Address.StreetName, UID = Pk });
				}
				if (ShipTo.DeliveryDate > DateTime.Now)
					listError.Add(new Error { Description = string.Format("Data da entrega do documento {0} incorrecto.", InvoiceNo), Field = "DeliveryDate", TypeofError = GetType(), Value = ShipTo.DeliveryDate.ToString(), UID = Pk });
			}

			return listError.ToArray();
		}
		public Error[] ValidateShipFrom()
		{
			List<Error> listError = new List<Error>();

			if (ShipFrom != null)
			{
				if (ShipFrom.Address != null)
				{
					if (string.IsNullOrEmpty(ShipFrom.Address.AddressDetail) || ShipFrom.Address.AddressDetail.Length > 100)
						listError.Add(new Error { Description = string.Format("Tamanho da morada detalhada do documento {0} do local de carga incorrecto.", InvoiceNo), Field = "AddressDetail", TypeofError = GetType(), Value = ShipFrom.Address.AddressDetail, UID = Pk });
					if (string.IsNullOrEmpty(ShipFrom.Address.BuildingNumber) == false && ShipFrom.Address.BuildingNumber.Length > 10)
						listError.Add(new Error { Description = string.Format("Tamanho do número de polícia do documento {0} do local de carga incorrecto.", InvoiceNo), Field = "BuildingNumber", TypeofError = GetType(), Value = ShipFrom.Address.BuildingNumber, UID = Pk });
					if (string.IsNullOrEmpty(ShipFrom.Address.City) || ShipFrom.Address.City.Length > 50)
						listError.Add(new Error { Description = string.Format("Tamanho da localidade do documento {0} do local de carga incorrecto.", InvoiceNo), Field = "City", TypeofError = GetType(), Value = ShipFrom.Address.City, UID = Pk });
					if (string.IsNullOrEmpty(ShipFrom.Address.Country) || ShipFrom.Address.Country.Length != 2)
						listError.Add(new Error { Description = string.Format("Tamanho do País do documento {0} do local de carga incorrecto.", InvoiceNo), Field = "Country", TypeofError = GetType(), Value = ShipFrom.Address.Country, UID = Pk });
					if (string.IsNullOrEmpty(ShipFrom.Address.PostalCode) || ShipFrom.Address.PostalCode.Length > 20)
						listError.Add(new Error { Description = string.Format("Tamanho do código postal do documento {0} do local de carga incorrecto.", InvoiceNo), Field = "PostalCode", TypeofError = GetType(), Value = ShipFrom.Address.PostalCode, UID = Pk });
					if (string.IsNullOrEmpty(ShipFrom.Address.Region) == false && ShipFrom.Address.Region.Length > 50)
						listError.Add(new Error { Description = string.Format("Tamanho do distrito do documento {0} do local de carga incorrecto.", InvoiceNo), Field = "Region", TypeofError = GetType(), Value = ShipFrom.Address.Region, UID = Pk });
					if (string.IsNullOrEmpty(ShipFrom.Address.StreetName) == false && ShipFrom.Address.StreetName.Length > 90)
						listError.Add(new Error { Description = string.Format("Tamanho do nome da rua do documento {0} do local de carga incorrecto.", InvoiceNo), Field = "StreetName", TypeofError = GetType(), Value = ShipFrom.Address.StreetName, UID = Pk });
				}
				if (ShipFrom.DeliveryDate > DateTime.Now)
					listError.Add(new Error { Description = string.Format("Data da receção do documento {0} incorrecto.", InvoiceNo), Field = "DeliveryDate", TypeofError = GetType(), Value = ShipFrom.DeliveryDate.ToString(), UID = Pk });
			}

			return listError.ToArray();
		}
		public Error[] ValidateDocumentTotals()
		{
			List<Error> listError = new List<Error>();

			if (DocumentTotals == null)
				listError.Add(new Error { Description = string.Format("Totais do documento {0} inexistentes.", InvoiceNo), Field = "DocumentTotals", TypeofError = GetType(), UID = Pk });

			if (DocumentTotals != null)
			{
				if (DocumentTotals.Currency != null)
				{
					if (DocumentTotals.Currency.CurrencyAmount < 0)
						listError.Add(new Error { Description = string.Format("Valor total em moeda estrangeira do documento {0} incorrecto.", InvoiceNo), Field = "CurrencyAmount", TypeofError = GetType(), Value = DocumentTotals.Currency.CurrencyAmount.ToString(), UID = Pk });
					if (string.IsNullOrEmpty(DocumentTotals.Currency.CurrencyCode) || DocumentTotals.Currency.CurrencyCode.Length > 3)
						listError.Add(new Error { Description = string.Format("Tamanho do código de moeda do documento {0} incorrecto.", InvoiceNo), Field = "CurrencyCode", TypeofError = GetType(), Value = DocumentTotals.Currency.CurrencyCode, UID = Pk });
					if (DocumentTotals.Currency.ExchangeRate < 0)
						listError.Add(new Error { Description = string.Format("Taxa de câmbio do documento {0} incorrecta.", InvoiceNo), Field = "ExchangeRate", TypeofError = GetType(), Value = DocumentTotals.Currency.ExchangeRate.ToString(), UID = Pk });
				}

				if (DocumentTotals.Settlement != null && DocumentTotals.Settlement.Length > 0)
				{
					foreach (var acordo in DocumentTotals.Settlement)
					{
						if (string.IsNullOrEmpty(acordo.PaymentTerms) == false && acordo.PaymentTerms.Length > 100)
							listError.Add(new Error { Description = string.Format("Tamanho do acordo de pagamento do documento {0} incorrecto.", InvoiceNo), Field = "PaymentTerms", TypeofError = GetType(), Value = acordo.PaymentTerms, UID = Pk });
						if (acordo.SettlementAmountSpecified && acordo.SettlementAmount < 0)
							listError.Add(new Error { Description = string.Format("Acordos de descontos futuros do documento {0} incorrecto.", InvoiceNo), Field = "SettlementAmount", TypeofError = GetType(), Value = acordo.SettlementAmount.ToString(), UID = Pk });
						if (acordo.SettlementDateSpecified )
							listError.Add(new Error { Description = string.Format("Data acordada para o desconto do documento {0} incorrecto.", InvoiceNo), Field = "SettlementDate", TypeofError = GetType(), Value = acordo.SettlementDate.ToString(), UID = Pk });
						if (string.IsNullOrEmpty(acordo.SettlementDiscount) == false && acordo.SettlementDiscount.Length > 30)
							listError.Add(new Error { Description = string.Format("Montante do desconto do documento {0} incorrecto.", InvoiceNo), Field = "SettlementAmount", TypeofError = GetType(), Value = acordo.SettlementAmount.ToString(), UID = Pk });
					}
				}

				if (DocumentTotals.GrossTotal < 0)
					listError.Add(new Error { Description = string.Format("Total do documento {0} incorrecto.", InvoiceNo), Field = "GrossTotal", TypeofError = GetType(), Value = DocumentTotals.GrossTotal.ToString(), UID = Pk });
				if (DocumentTotals.NetTotal < 0)
					listError.Add(new Error { Description = string.Format("Total do documento {0} sem impostos incorrecto.", InvoiceNo), Field = "NetTotal", TypeofError = GetType(), Value = DocumentTotals.NetTotal.ToString(), UID = Pk });
				if (DocumentTotals.TaxPayable < 0)
					listError.Add(new Error { Description = string.Format("Valor do imposto a pagar do documento {0} incorrecto.", InvoiceNo), Field = "TaxPayable", TypeofError = GetType(), Value = DocumentTotals.TaxPayable.ToString(), UID = Pk });
			}

			return listError.ToArray();
		}
		#endregion
	}

	public partial class SourceDocumentsSalesInvoicesInvoiceLine : BaseData, IDataErrorInfo
	{
		/// <summary>
		/// Link to the invoice
		/// </summary>
		public string InvoiceNo { get; set; }

		//SourceDocumentsSalesInvoicesInvoiceLineToolTipService tooltip;
		//public SourceDocumentsSalesInvoicesInvoiceLineToolTipService Tooltip
		//{
		//	get
		//	{
		//		if (tooltip == null)
		//			tooltip = new SourceDocumentsSalesInvoicesInvoiceLineToolTipService();
		//		return tooltip;
		//	}
		//	set { tooltip = value; }
		//}

		public string Error
		{
			get { return string.Empty; }
		}

		[System.Runtime.CompilerServices.IndexerName("Items")]
		public string this[string columnName]
		{
			get
			{
				Error erro = null;
				if (columnName == "LineNumber")
				{
					erro = ValidateLineNumber(appendError: true);
				}
				else if (columnName == "ProductCode")
				{
					erro = ValidateProductCode(appendError: true);
				}
				else if (columnName == "ProductDescription")
				{
					erro = ValidateProductDescription(appendError: true);
				}
				else if (columnName == "Quantity")
				{
					erro = ValidateQuantity(appendError: true);
				}
				else if (columnName == "UnitOfMeasure")
				{
					erro = ValidateUnitOfMeasure(appendError: true);
				}
				else if (columnName == "UnitPrice")
				{
					erro = ValidateUnitPrice(appendError: true);
				}
				else if (columnName == "TaxPointDate")
				{
					erro = ValidateTaxPointDate(appendError: true);
				}

				return erro?.Description;
			}
		}

		#region
		public Error ValidateLineNumber(bool appendError = false, string SupPk = "", string invoiceNo = "")
		{
			Error erro = null;
			int num = -1;
			if (!string.IsNullOrEmpty(LineNumber))
				Int32.TryParse(LineNumber, out num);

			if (string.IsNullOrEmpty(LineNumber) || num == -1)
			{
				if (!string.IsNullOrEmpty(invoiceNo))
					invoiceNo = string.Format(", documento {0}", invoiceNo);

				erro = new Error { Description = string.Format("Número de linha incorrecto {0}.", invoiceNo), Field = "LineNumber", TypeofError = GetType(), Value = LineNumber, UID = Pk, SupUID = SupPk };
				//if (appendError)
				//	Tooltip.LineNumber = Tooltip.LineNumber.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateProductCode(bool appendError = false, string SupPk = "", string invoiceNo = "")
		{
			Error erro = null;
			if (string.IsNullOrEmpty(ProductCode) || ProductCode.Length > 30)
			{
				if (!string.IsNullOrEmpty(invoiceNo))
					invoiceNo = string.Format(" documento {0}", invoiceNo);

				erro = new Error { Description = string.Format("Identificador do produto ou serviço incorrecto, {0} linha {1}.", invoiceNo, LineNumber), Field = "ProductCode", TypeofError = GetType(), Value = ProductCode, UID = Pk, SupUID = SupPk };
				//if (appendError)
				//	Tooltip.ProductCode = Tooltip.ProductCode.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateProductDescription(bool appendError = false, string SupPk = "", string invoiceNo = "")
		{
			Error erro = null;
			if (string.IsNullOrEmpty(ProductDescription) || ProductDescription.Length > 200)
			{
				if (!string.IsNullOrEmpty(invoiceNo))
					invoiceNo = string.Format(" documento {0}", invoiceNo);

				erro = new Error { Description = string.Format("Descrição do produto ou serviço incorrecta, {0} linha {1}.", invoiceNo, LineNumber), Field = "ProductDescription", TypeofError = GetType(), Value = ProductDescription, UID = Pk, SupUID = SupPk };
				//if (appendError)
				//	Tooltip.ProductDescription = Tooltip.ProductDescription.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateQuantity(bool appendError = false, string SupPk = "", string invoiceNo = "")
		{
			Error erro = null;
			if (Quantity <= 0)
			{
				if (!string.IsNullOrEmpty(invoiceNo))
					invoiceNo = string.Format(" documento {0}", invoiceNo);

				erro = new Error { Description = string.Format("Quantidade incorrecta, {0} linha {1}.", invoiceNo, LineNumber), Field = "Quantity", TypeofError = GetType(), Value = Quantity.ToString(), UID = Pk, SupUID = SupPk };
				//if (appendError)
				//	Tooltip.Quantity = Tooltip.Quantity.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateUnitOfMeasure(bool appendError = false, string SupPk = "", string invoiceNo = "")
		{
			Error erro = null;
			if (string.IsNullOrEmpty(UnitOfMeasure) || UnitOfMeasure.Length > 20)
			{
				if (!string.IsNullOrEmpty(invoiceNo))
					invoiceNo = string.Format(" documento {0}", invoiceNo);

				erro = new Error { Description = string.Format("Unidade de medida incorrecta, {0} linha {1}.", invoiceNo, LineNumber), Field = "UnitOfMeasure", TypeofError = GetType(), Value = UnitOfMeasure, UID = Pk, SupUID = SupPk };
				//if (appendError)
				//	Tooltip.UnitOfMeasure = Tooltip.UnitOfMeasure.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateUnitPrice(bool appendError = false, string SupPk = "", string invoiceNo = "")
		{
			Error erro = null;
			if (UnitPrice == 0)
			{
				if (!string.IsNullOrEmpty(invoiceNo))
					invoiceNo = string.Format(" documento {0}", invoiceNo);

				erro = new Error { Description = string.Format("Preço unitário incorrecto, {0} linha {1}.", invoiceNo, LineNumber), Field = "UnitPrice", TypeofError = GetType(), Value = UnitPrice.ToString(), UID = Pk, SupUID = SupPk };
				//if (appendError)
				//	Tooltip.UnitPrice = Tooltip.UnitPrice.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateTaxPointDate(bool appendError = false, string SupPk = "", string invoiceNo = "")
		{
			Error erro = null;
			if (TaxPointDate > DateTime.Now)
			{
				if (!string.IsNullOrEmpty(invoiceNo))
					invoiceNo = string.Format(" documento {0}", invoiceNo);

				erro = new Error { Description = string.Format("Data de envio da mercadoria ou prestação do serviço incorrecta, {0} linha {1}.", invoiceNo, LineNumber), Field = "TaxPointDate", TypeofError = GetType(), Value = TaxPointDate.ToString(), UID = Pk, SupUID = SupPk };
				//if (appendError)
				//	Tooltip.TaxPointDate = Tooltip.TaxPointDate.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}

		public Error[] ValidateOrderReferences(string SupPk = "", string invoiceNo = "")
		{
			List<Error> listError = new List<Error>();

			if (OrderReferences != null && OrderReferences.Length > 0)
			{
				foreach (var referencia in OrderReferences)
				{
					if (string.IsNullOrEmpty(referencia.OriginatingON) == false && referencia.OriginatingON.Length > 60)
						listError.Add(new Error { Description = string.Format("Tamanho do número do documento de origem na linha {0} do documento {1} incorrecto.", LineNumber, invoiceNo), Field = "OriginatingON", TypeofError = GetType(), Value = referencia.OriginatingON, UID = Pk, SupUID = SupPk });
					if (referencia.OrderDateSpecified && referencia.OrderDate > DateTime.Now)
						listError.Add(new Error { Description = string.Format("Data do documento de origem na linha {0} do documento {1} incorrecto.", LineNumber, invoiceNo), Field = "OrderDate", TypeofError = GetType(), Value = referencia.OrderDate.ToString(), UID = Pk, SupUID = SupPk });
				}
			}

			return listError.ToArray();
		}
		public Error[] ValidateReferences(string SupPk = "", string invoiceNo = "")
		{
			List<Error> listError = new List<Error>();

			if (References != null && References.Length > 0)
			{
				foreach (var referencia in References)
				{
					if (string.IsNullOrEmpty(referencia.Reason) == false && referencia.Reason.Length > 50)
						listError.Add(new Error { Description = string.Format("Tamanho do motivo da emissão na linha {0} do documento {1} incorrecto.", LineNumber, invoiceNo), Field = "Reason", TypeofError = GetType(), Value = referencia.Reason, UID = Pk, SupUID = SupPk });
					if (string.IsNullOrEmpty(referencia.Reference) == false && referencia.Reference.Length > 60)
						listError.Add(new Error { Description = string.Format("Tamanho da referência à fatura ou fatura simplificada na linha {0} do documento {1} incorrecto.", LineNumber, invoiceNo), Field = "Reference", TypeofError = GetType(), Value = referencia.Reference, UID = Pk, SupUID = SupPk });
				}
			}

			return listError.ToArray();
		}
		public Error[] ValidateTax(string SupPk = "", string invoiceNo = "")
		{
			List<Error> listError = new List<Error>();

			if (Tax == null)
				listError.Add(new Error { Description = string.Format("Taxa de imposto na linha {0} do documento {1} inexistente.", LineNumber, invoiceNo), Field = "Tax", TypeofError = GetType(), UID = Pk, SupUID = SupPk });

			if (Tax != null)
			{
				if (Tax.ItemElementName == ItemChoiceType1.TaxAmount && Tax.Item < 0)
					listError.Add(new Error { Description = string.Format("Montante do imposto na linha {0} do documento {1} incorrecto.", LineNumber, invoiceNo), Field = "TaxAmount", TypeofError = GetType(), Value = Tax.Item.ToString(), UID = Pk, SupUID = SupPk });
				if (Tax.ItemElementName == ItemChoiceType1.TaxPercentage && (Tax.Item < 0 || Tax.Item > 100))
					listError.Add(new Error { Description = string.Format("Percentagem da taxa do imposto na linha {0} do documento {1} incorrecto.", LineNumber, invoiceNo), Field = "TaxPercentage", TypeofError = GetType(), Value = Tax.Item.ToString(), UID = Pk, SupUID = SupPk });
				if (string.IsNullOrEmpty(Tax.TaxCode) || Tax.TaxCode.Length > 10)
					listError.Add(new Error { Description = string.Format("Código da taxa na linha {0} do documento {1} incorrecto.", LineNumber, invoiceNo), Field = "TaxCode", TypeofError = GetType(), Value = Tax.TaxCode, UID = Pk, SupUID = SupPk });
				if (string.IsNullOrEmpty(Tax.TaxCountryRegion) || Tax.TaxCountryRegion.Length > 5)
					listError.Add(new Error { Description = string.Format("País ou região do imposto na linha {0} do documento {1} incorrecto.", LineNumber, invoiceNo), Field = "TaxCountryRegion", TypeofError = GetType(), Value = Tax.TaxCountryRegion, UID = Pk, SupUID = SupPk });
			}

			return listError.ToArray();
		}
		#endregion
	}

	public partial class Header : BaseData, IDataErrorInfo
	{
		HeaderToolTipService tooltip;
		public HeaderToolTipService Tooltip
		{
			get
			{
				if (tooltip == null)
					tooltip = new HeaderToolTipService();
				return tooltip;
			}
			set { tooltip = value; }
		}

		public string Error
		{
			get { return null; }
		}

		public string this[string columnName]
		{
			get
			{
				Error erro = null;
				if (columnName == "TaxRegistrationNumber")
				{
					erro = ValidateTaxRegistrationNumber(appendError: true);
				}
				else if (columnName == "AuditFileVersion")
				{
					erro = ValidateAuditFileVersion(appendError: true);
				}
				else if (columnName == "BusinessName")
				{
					erro = ValidateBusinessName(appendError: true);
				}
				else if (columnName == "AddressDetail")
				{
					erro = ValidateAddressDetail(appendError: true);
				}
				else if (columnName == "BuildingNumber")
				{
					erro = ValidateBuildingNumber(appendError: true);
				}
				else if (columnName == "City")
				{
					erro = ValidateCity(appendError: true);
				}
				else if (columnName == "Country")
				{
					erro = ValidateCountry(appendError: true);
				}
				else if (columnName == "PostalCode")
				{
					erro = ValidatePostalCode(appendError: true);
				}
				else if (columnName == "Region")
				{
					erro = ValidateRegion(appendError: true);
				}
				else if (columnName == "StreetName")
				{
					erro = ValidateStreetName(appendError: true);
				}
				else if (columnName == "CompanyID")
				{
					erro = ValidateCompanyID(appendError: true);
				}
				else if (columnName == "CompanyName")
				{
					erro = ValidateCompanyName(appendError: true);
				}
				else if (columnName == "CurrencyCode")
				{
					erro = ValidateCurrencyCode(appendError: true);
				}
				else if (columnName == "DateCreated")
				{
					erro = ValidateDateCreated(appendError: true);
				}
				else if (columnName == "Email")
				{
					erro = ValidateEmail(appendError: true);
				}
				else if (columnName == "EndDate")
				{
					erro = ValidateEndDate(appendError: true);
				}
				else if (columnName == "Fax")
				{
					erro = ValidateFax(appendError: true);
				}
				else if (columnName == "FiscalYear")
				{
					erro = ValidateFiscalYear(appendError: true);
				}
				else if (columnName == "HeaderComment")
				{
					erro = ValidateHeaderComment(appendError: true);
				}
				else if (columnName == "ProductCompanyTaxID")
				{
					erro = ValidateProductCompanyTaxID(appendError: true);
				}
				else if (columnName == "ProductID")
				{
					erro = ValidateProductID(appendError: true);
				}
				else if (columnName == "ProductVersion")
				{
					erro = ValidateProductVersion(appendError: true);
				}
				else if (columnName == "SoftwareCertificateNumber")
				{
					erro = ValidateSoftwareCertificateNumber(appendError: true);
				}
				else if (columnName == "StartDate")
				{
					erro = ValidateStartDate(appendError: true);
				}
				else if (columnName == "TaxAccountingBasis")
				{
					erro = ValidateTaxAccountingBasis(appendError: true);
				}
				else if (columnName == "TaxEntity")
				{
					erro = ValidateTaxEntity(appendError: true);
				}
				else if (columnName == "Telephone")
				{
					erro = ValidateTelephone(appendError: true);
				}
				else if (columnName == "Website")
				{
					erro = ValidateWebsite(appendError: true);
				}

				if (erro != null)
					return erro.Description;
				else
					return null;
			}
		}

		#region Validation
		public Error ValidateTaxRegistrationNumber(bool appendError = false)
		{
			Error erro = null;
			if (!Validations.CheckTaxRegistrationNumber(TaxRegistrationNumber))
			{
				erro = new Error { Description = "NIF inválido", Field = "TaxRegistrationNumber", TypeofError = GetType(), Value = TaxRegistrationNumber, UID = Pk };
				//if (appendError)
				//	Tooltip.TaxRegistrationNumber = Tooltip.TaxRegistrationNumber.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateAuditFileVersion(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(AuditFileVersion) || AuditFileVersion.Length > 10)
			{
				erro = new Error { Description = "Versão do ficheiro SAF-T PT incorrecta.", Field = "AuditFileVersion", TypeofError = GetType(), Value = AuditFileVersion, UID = Pk };
				//if (appendError)
				//	Tooltip.AuditFileVersion = Tooltip.AuditFileVersion.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateBusinessName(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(BusinessName) == false)
			{
				if (BusinessName.Length > 60)
				{
					erro = new Error { Description = "Designação comercial incorrecta.", Field = "BusinessName", TypeofError = GetType(), Value = BusinessName, UID = Pk };
					//if (appendError)
					//	Tooltip.BusinessName = Tooltip.BusinessName.FormatTooltipWithError(erro.Description);
				}
			}
			return erro;
		}
		public Error ValidateAddressDetail(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(CompanyAddress.AddressDetail) || CompanyAddress.AddressDetail.Length > 100)
			{
				erro = new Error { Description = "Morada detalhada incorrecta.", Field = "AddressDetail", TypeofError = GetType(), Value = CompanyAddress.AddressDetail, UID = Pk };
				//if (appendError)
				//	Tooltip.AddressDetail = Tooltip.AddressDetail.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateBuildingNumber(bool appendError = false)
		{
			Error erro = null;
			if (!string.IsNullOrEmpty(CompanyAddress.BuildingNumber) && CompanyAddress.BuildingNumber.Length > 10)
			{
				erro = new Error { Description = "Número polícia incorrecto.", Field = "BuildingNumber", TypeofError = GetType(), Value = CompanyAddress.BuildingNumber, UID = Pk };
				//if (appendError)
				//	Tooltip.BuildingNumber = Tooltip.BuildingNumber.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateCity(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(CompanyAddress.City) || CompanyAddress.City.Length > 50)
			{
				erro = new Error { Description = "Localidade incorrecta.", Field = "City", TypeofError = GetType(), Value = CompanyAddress.City, UID = Pk };
				//if (appendError)
				//	Tooltip.City = Tooltip.City.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateCountry(bool appendError = false)
		{
			string country = null;
			if (CompanyAddress != null || CompanyAddress.Country != null)
				country = CompanyAddress.Country.ToString();

			Error erro = null;
			if (string.IsNullOrEmpty(country) || country != "PT")
			{
				erro = new Error { Description = "Localidade incorrecta.", Field = "Country", TypeofError = GetType(), Value = country, UID = Pk };
				//if (appendError)
				//	Tooltip.Country = Tooltip.Country.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidatePostalCode(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(CompanyAddress.PostalCode) || CompanyAddress.PostalCode.Length > 50)
			{
				erro = new Error { Description = "Código postal incorrecto.", Field = "PostalCode", TypeofError = GetType(), Value = CompanyAddress.PostalCode, UID = Pk };
				//if (appendError)
				//	Tooltip.PostalCode = Tooltip.PostalCode.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateRegion(bool appendError = false)
		{
			Error erro = null;
			if (!string.IsNullOrEmpty(CompanyAddress.Region) && CompanyAddress.Region.Length > 50)
			{
				erro = new Error { Description = "Distrito incorrecto.", Field = "Region", TypeofError = GetType(), Value = CompanyAddress.Region, UID = Pk };
				//if (appendError)
				//	Tooltip.Region = Tooltip.Region.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateStreetName(bool appendError = false)
		{
			Error erro = null;
			if (!string.IsNullOrEmpty(CompanyAddress.StreetName) && CompanyAddress.StreetName.Length > 90)
			{
				erro = new Error { Description = "Nome da rua incorrecto.", Field = "StreetName", TypeofError = GetType(), Value = CompanyAddress.StreetName, UID = Pk };
				//if (appendError)
				//	Tooltip.StreetName = Tooltip.StreetName.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateCompanyID(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(CompanyID) || CompanyID.Length > 50 || !Regex.IsMatch(CompanyID, "([0-9])+|([a-zA-Z0-9-/]+ [0-9]+)"))
			{
				if (!SolRIA.SaftAnalyser.Validations.CheckTaxRegistrationNumber(CompanyID))
				{
					erro = new Error { Description = "Registo comercial incorrecto.", Field = "CompanyID", TypeofError = GetType(), Value = CompanyID, UID = Pk };
					//if (appendError)
					//	Tooltip.CompanyID = Tooltip.CompanyID.FormatTooltipWithError(erro.Description);
				}
			}
			return erro;
		}
		public Error ValidateCompanyName(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(CompanyName) || CompanyName.Length > 100)
			{
				erro = new Error { Description = "Nome empresa incorrecto.", Field = "CompanyName", TypeofError = GetType(), Value = CompanyName, UID = Pk };
				//if (appendError)
				//	Tooltip.CompanyName = Tooltip.CompanyName.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateCurrencyCode(bool appendError = false)
		{
			Error erro = null;
			if (CurrencyCode == null || CurrencyCode.ToString() != "EUR")
			{
				erro = new Error { Description = "Código moeda incorrecto.", Field = "CurrencyCode", TypeofError = GetType(), Value = string.Format("{0}", CurrencyCode ?? "null"), UID = Pk };
				//if (appendError)
				//	Tooltip.CurrencyCode = Tooltip.CurrencyCode.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateDateCreated(bool appendError = false)
		{
			Error erro = null;
			if (DateCreated > DateTime.Now)
			{
				erro = new Error { Description = "Data de criação do ficheiro incorrecta.", Field = "DateCreated", TypeofError = GetType(), Value = DateCreated.ToString(), UID = Pk };
				//if (appendError)
				//	Tooltip.DateCreated = Tooltip.DateCreated.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateEmail(bool appendError = false)
		{
			Error erro = null;
			if (!string.IsNullOrEmpty(Email) && (Email.Length > 60 || !Regex.IsMatch(Email, @"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b", RegexOptions.IgnoreCase)))
			{
				erro = new Error { Description = "Email incorrecto.", Field = "Email", TypeofError = GetType(), Value = Email, UID = Pk };
				//if (appendError)
				//	Tooltip.Email = Tooltip.Email.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateEndDate(bool appendError = false)
		{
			Error erro = null;
			if (EndDate == DateTime.MinValue)
			{
				erro = new Error { Description = "Data do fim do periodo incorrecta.", Field = "EndDate", TypeofError = GetType(), Value = EndDate.ToString(), UID = Pk };
				//if (appendError)
				//	Tooltip.EndDate = Tooltip.EndDate.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateFax(bool appendError = false)
		{
			Error erro = null;
			if (!string.IsNullOrEmpty(Fax) && Fax.Length > 20)
			{
				erro = new Error { Description = "Fax incorrecto.", Field = "Fax", TypeofError = GetType(), Value = Fax, UID = Pk };
				//if (appendError)
				//	Tooltip.Fax = Tooltip.Fax.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateFiscalYear(bool appendError = false)
		{
			Error erro = null;
			int ano = -1;
			Int32.TryParse(FiscalYear, out ano);
			if (string.IsNullOrEmpty(FiscalYear) || FiscalYear.Length > 4 || ano == -1)
			{
				erro = new Error { Description = "Ano fiscal incorrecto.", Field = "FiscalYear", TypeofError = GetType(), Value = FiscalYear, UID = Pk };
				//if (appendError)
				//	Tooltip.FiscalYear = Tooltip.FiscalYear.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateHeaderComment(bool appendError = false)
		{
			Error erro = null;
			if (!string.IsNullOrEmpty(HeaderComment) && HeaderComment.Length > 255)
			{
				erro = new Error { Description = "Comentário demasiado longo.", Field = "HeaderComment", TypeofError = GetType(), Value = HeaderComment, UID = Pk };
				//if (appendError)
				//	Tooltip.HeaderComment = Tooltip.HeaderComment.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateProductCompanyTaxID(bool appendError = false)
		{
			Error erro = null;
			if (!Validations.CheckTaxRegistrationNumber(ProductCompanyTaxID))
			{
				erro = new Error { Description = "NIF da empresa produtora de saftware inválido.", Field = "ProductCompanyTaxID", TypeofError = GetType(), Value = ProductCompanyTaxID, UID = Pk };
				//if (appendError)
				//	Tooltip.ProductCompanyTaxID = Tooltip.ProductCompanyTaxID.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateProductID(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(ProductID) || ProductID.Length > 255 || !ProductID.Contains('/'))
			{
				erro = new Error { Description = "Nome da aplicação incorrecto.", Field = "ProductID", TypeofError = GetType(), Value = ProductID, UID = Pk };
				//if (appendError)
				//	Tooltip.ProductID = Tooltip.ProductID.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateProductVersion(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(ProductVersion) || ProductVersion.Length > 30)
			{
				erro = new Error { Description = "Versão da aplicação incorrecta.", Field = "ProductVersion", TypeofError = GetType(), Value = ProductVersion, UID = Pk };
				//if (appendError)
				//	Tooltip.ProductVersion = Tooltip.ProductVersion.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateSoftwareCertificateNumber(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(SoftwareCertificateNumber) || SoftwareCertificateNumber.Length > 20)
			{
				erro = new Error { Description = "Número de certificação incorrecto.", Field = "SoftwareCertificateNumber", TypeofError = GetType(), Value = SoftwareCertificateNumber, UID = Pk };
				//if (appendError)
				//	Tooltip.SoftwareCertificateNumber = Tooltip.SoftwareCertificateNumber.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateStartDate(bool appendError = false)
		{
			Error erro = null;
			//if (StartDate < Workspace.Instance.Config.MinDate)
			//{
			//	erro = new Error { Description = "Data do início do periodo incorrecta.", Field = "StartDate", TypeofError = GetType(), Value = StartDate.ToString(), UID = Pk };
			//	if (appendError)
			//		Tooltip.StartDate = Tooltip.StartDate.FormatTooltipWithError(erro.Description);
			//}
			return erro;
		}
		public Error ValidateTaxAccountingBasis(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(TaxAccountingBasis.ToString()) || TaxAccountingBasis.ToString().Length > 1)
			{
				erro = new Error { Description = "Sistema contabilístico incorrecto.", Field = "TaxAccountingBasis", TypeofError = GetType(), Value = TaxAccountingBasis.ToString(), UID = Pk };
				//if (appendError)
				//	Tooltip.TaxAccountingBasis = Tooltip.TaxAccountingBasis.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateTaxEntity(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(TaxEntity) || TaxEntity.Length > 20)
			{
				erro = new Error { Description = "Identificação do estabelecimento incorrecta.", Field = "TaxEntity", TypeofError = GetType(), Value = TaxEntity, UID = Pk };
				//if (appendError)
				//	Tooltip.TaxEntity = Tooltip.TaxEntity.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateTelephone(bool appendError = false)
		{
			Error erro = null;
			if (!string.IsNullOrEmpty(Telephone) && Telephone.Length > 20)
			{
				erro = new Error { Description = "Identificação do estabelecimento incorrecta.", Field = "Telephone", TypeofError = GetType(), Value = Telephone, UID = Pk };
				//if (appendError)
				//	Tooltip.Telephone = Tooltip.Telephone.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		public Error ValidateWebsite(bool appendError = false)
		{
			Error erro = null;
			if (!string.IsNullOrEmpty(Website) && Website.Length > 60)
			{
				erro = new Error { Description = "Website incorrecto.", Field = "Website", TypeofError = GetType(), Value = Website, UID = Pk };
				//if (appendError)
				//	Tooltip.Website = Tooltip.Website.FormatTooltipWithError(erro.Description);
			}
			return erro;
		}
		#endregion Validation
	}

	public partial class Product : BaseData, IDataErrorInfo
	{
		//ProductToolTipService tooltip;
		//public ProductToolTipService Tooltip
		//{
		//	get
		//	{
		//		if (tooltip == null)
		//			tooltip = new ProductToolTipService();
		//		return tooltip;
		//	}
		//	set { tooltip = value; }
		//}

		public string Error
		{
			get { return string.Empty; }
		}

		public string this[string columnName]
		{
			get
			{
				Error erro = null;
				if (columnName == "ProductCode")
				{
					erro = ValidateProductCode(appendError: true);
				}
				else if (columnName == "ProductGroup")
				{
					erro = ValidateProductGroup(appendError: true);
				}
				else if (columnName == "ProductDescription")
				{
					erro = ValidateProductDescription(appendError: true);
				}
				else if (columnName == "ProductNumberCode")
				{
					erro = ValidateProductNumberCode(appendError: true);
				}

				return erro == null ? "" : erro.Description;
			}
		}

		#region Validation

		public Error ValidateProductCode(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(ProductCode) || ProductCode.Length > 30)
			{
				erro = new Error { Description = "Código do produto inválido", Field = "ProductCode", TypeofError = GetType(), Value = ProductCode, UID = Pk };
				//if (appendError)
				//	Tooltip.ProductCode = Tooltip.ProductCode.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateProductGroup(bool appendError = false)
		{
			Error erro = null;
			if (!string.IsNullOrEmpty(ProductGroup) && ProductCode.Length > 50)
			{
				erro = new Error { Description = "Família do produto ou serviço inválida", Field = "ProductGroup", TypeofError = GetType(), Value = ProductGroup, UID = Pk };
				//if (appendError)
				//	Tooltip.ProductGroup = Tooltip.ProductGroup.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateProductDescription(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(ProductDescription) || ProductDescription.Length > 200)
			{
				erro = new Error { Description = "Descrição do produto ou serviço inválida", Field = "ProductDescription", TypeofError = GetType(), Value = ProductDescription, UID = Pk };
				//if (appendError)
				//	Tooltip.ProductDescription = Tooltip.ProductDescription.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateProductNumberCode(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(ProductNumberCode) || ProductNumberCode.Length > 50)
			{
				erro = new Error { Description = "Família do produto ou serviço inválida", Field = "ProductNumberCode", TypeofError = GetType(), Value = ProductNumberCode, UID = Pk };
				//if (appendError)
				//	Tooltip.ProductNumberCode = Tooltip.ProductNumberCode.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}

		#endregion Validation
	}

	public partial class Customer : BaseData, IDataErrorInfo
	{
		//CustomerToolTipService tooltip;
		//public CustomerToolTipService Tooltip
		//{
		//	get
		//	{
		//		if (tooltip == null)
		//			tooltip = new CustomerToolTipService();
		//		return tooltip;
		//	}
		//	set { tooltip = value; }
		//}

		public string Error
		{
			get { return string.Empty; }
		}

		public string this[string columnName]
		{
			get
			{
				Error erro = null;
				if (columnName == "CustomerID")
				{
					erro = ValidateCustomerID(appendError: true);
				}
				else if (columnName == "AccountID")
				{
					erro = ValidateAccountID(appendError: true);
				}
				else if (columnName == "CustomerTaxID")
				{
					erro = ValidateCustomerTaxID(appendError: true);
				}
				else if (columnName == "CompanyName")
				{
					erro = ValidateCompanyName(appendError: true);
				}
				else if (columnName == "Contact")
				{
					erro = ValidateContact(appendError: true);
				}
				else if (columnName == "Telephone")
				{
					erro = ValidateTelephone(appendError: true);
				}
				else if (columnName == "Fax")
				{
					erro = ValidateFax(appendError: true);
				}
				else if (columnName == "Email")
				{
					erro = ValidateEmail(appendError: true);
				}
				else if (columnName == "Website")
				{
					erro = ValidateWebsite(appendError: true);
				}
				else if (columnName == "SelfBillingIndicator")
				{
					erro = ValidateSelfBillingIndicator(appendError: true);
				}

				return erro == null ? "" : erro.Description;
			}
		}

		#region Validation

		public Error ValidateCustomerID(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(CustomerID) || CustomerID.Length > 30)
			{
				erro = new Error { Description = "Identificador único do cliente inválido", Field = "CustomerID", TypeofError = GetType(), Value = CustomerID, UID = Pk };
				//if (appendError)
				//	Tooltip.CustomerID = Tooltip.CustomerID.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateAccountID(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(AccountID) || AccountID.Length > 30)
			{
				erro = new Error { Description = "Código da conta inválido", Field = "AccountID", TypeofError = GetType(), Value = AccountID, UID = Pk };
				//if (appendError)
				//	Tooltip.AccountID = Tooltip.AccountID.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateCustomerTaxID(bool appendError = false)
		{
			Error erro = null;
			if (!Validations.CheckTaxRegistrationNumber(CustomerTaxID))
			{
				erro = new Error { Description = "Número de identificação fiscal inválido", Field = "CustomerTaxID", TypeofError = GetType(), Value = CustomerTaxID, UID = Pk };
				//if (appendError)
				//	Tooltip.CustomerTaxID = Tooltip.CustomerTaxID.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateCompanyName(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(CompanyName) || CompanyName.Length > 100)
			{
				erro = new Error { Description = "Nome da empresa inválido", Field = "CompanyName", TypeofError = GetType(), Value = CompanyName, UID = Pk };
				//if (appendError)
				//	Tooltip.CompanyName = Tooltip.CompanyName.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateContact(bool appendError = false)
		{
			Error erro = null;
			if (!string.IsNullOrEmpty(Contact) && Contact.Length > 50)
			{
				erro = new Error { Description = "Nome do contacto na empresa inválido.", Field = "Contact", TypeofError = GetType(), Value = Contact, UID = Pk };
				//if (appendError)
				//	Tooltip.Contact = Tooltip.Contact.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateTelephone(bool appendError = false)
		{
			Error erro = null;
			if (!string.IsNullOrEmpty(Telephone) && Telephone.Length > 20)
			{
				erro = new Error { Description = "Telefone inválido", Field = "Telephone", TypeofError = GetType(), Value = Telephone, UID = Pk };
				//if (appendError)
				//	Tooltip.Telephone = Tooltip.Telephone.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateFax(bool appendError = false)
		{
			Error erro = null;
			if (!string.IsNullOrEmpty(Fax) && Fax.Length > 20)
			{
				erro = new Error { Description = "Fax inválido", Field = "Fax", TypeofError = GetType(), Value = Fax, UID = Pk };
				//if (appendError)
				//	Tooltip.Fax = Tooltip.Fax.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateEmail(bool appendError = false)
		{
			Error erro = null;
			if (!string.IsNullOrEmpty(Email) && Email.Length > 60)
			{
				erro = new Error { Description = "Email inválido", Field = "Email", TypeofError = GetType(), Value = Email, UID = Pk };
				//if (appendError)
				//	Tooltip.Email = Tooltip.Email.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateWebsite(bool appendError = false)
		{
			Error erro = null;
			if (!string.IsNullOrEmpty(Website) && Website.Length > 60)
			{
				erro = new Error { Description = "Website inválido", Field = "Website", TypeofError = GetType(), Value = Website, UID = Pk };
				//if (appendError)
				//	Tooltip.Website = Tooltip.Website.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateSelfBillingIndicator(bool appendError = false)
		{
			Error erro = null;

			int selfBillingIndicator = -1;
			if (!string.IsNullOrEmpty(SelfBillingIndicator))
				Int32.TryParse(SelfBillingIndicator, out selfBillingIndicator);

			if (string.IsNullOrEmpty(SelfBillingIndicator) || selfBillingIndicator == -1)
			{
				erro = new Error { Description = "Nº de conta inválido", Field = "SelfBillingIndicator", TypeofError = GetType(), Value = SelfBillingIndicator, UID = Pk };
				//if (appendError)
				//	Tooltip.SelfBillingIndicator = Tooltip.SelfBillingIndicator.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}

		public Error[] ValidateBillingAddress()
		{
			List<Error> listErro = new List<Error>();

			if (BillingAddress == null)
				listErro.Add(new Error { Description = "Morada de faturação inexistente", Field = "BillingAddress", TypeofError = GetType(), UID = Pk });

			if (BillingAddress != null)
			{
				if (string.IsNullOrEmpty(BillingAddress.AddressDetail) || BillingAddress.AddressDetail.Length > 100)
					listErro.Add(new Error { Description = "Tamanho da morada detalhada.", Field = "AddressDetail", TypeofError = GetType(), Value = BillingAddress.AddressDetail, UID = Pk });
				if (string.IsNullOrEmpty(BillingAddress.BuildingNumber) == false && BillingAddress.BuildingNumber.Length > 10)
					listErro.Add(new Error { Description = "Tamanho do número de polícia incorrecto.", Field = "BuildingNumber", TypeofError = GetType(), Value = BillingAddress.BuildingNumber, UID = Pk });
				if (string.IsNullOrEmpty(BillingAddress.City) || BillingAddress.City.Length > 50)
					listErro.Add(new Error { Description = "Tamanho da localidade incorrecto.", Field = "City", TypeofError = GetType(), Value = BillingAddress.City, UID = Pk });
				if (string.IsNullOrEmpty(BillingAddress.PostalCode) || BillingAddress.PostalCode.Length > 20)
					listErro.Add(new Error { Description = "Tamanho do código postal incorrecto.", Field = "PostalCode", TypeofError = GetType(), Value = BillingAddress.PostalCode, UID = Pk });
				if (string.IsNullOrEmpty(BillingAddress.Region) == false && BillingAddress.Region.Length > 50)
					listErro.Add(new Error { Description = "Tamanho do distrito incorrecto.", Field = "Region", TypeofError = GetType(), Value = BillingAddress.Region, UID = Pk });
				if (string.IsNullOrEmpty(BillingAddress.StreetName) == false && BillingAddress.StreetName.Length > 90)
					listErro.Add(new Error { Description = "Tamanho do nome da rua incorrecto.", Field = "StreetName", TypeofError = GetType(), Value = BillingAddress.StreetName, UID = Pk });
				if (string.IsNullOrEmpty(BillingAddress.Country) || (BillingAddress.Country.Length != 2 && BillingAddress.Country != "Desconhecido"))
					listErro.Add(new Error { Description = "Tamanho do País incorrecto.", Field = "Country", TypeofError = GetType(), Value = BillingAddress.Country, UID = Pk });
			}

			return listErro.ToArray();
		}
		public Error[] ValidateShipToAddress()
		{
			List<Error> listErro = new List<Error>();

			if (ShipToAddress != null && ShipToAddress.Length > 0)
			{
				foreach (var morada in ShipToAddress)
				{
					if (string.IsNullOrEmpty(morada.AddressDetail) || morada.AddressDetail.Length > 100)
						listErro.Add(new Error { Description = "Tamanho da morada detalhada.", Field = "AddressDetail", TypeofError = GetType(), Value = morada.AddressDetail, UID = Pk });
					if (string.IsNullOrEmpty(morada.BuildingNumber) == false && morada.BuildingNumber.Length > 10)
						listErro.Add(new Error { Description = "Tamanho do número de polícia incorrecto.", Field = "BuildingNumber", TypeofError = GetType(), Value = morada.BuildingNumber, UID = Pk });
					if (string.IsNullOrEmpty(morada.City) || morada.City.Length > 50)
						listErro.Add(new Error { Description = "Tamanho da localidade incorrecto.", Field = "City", TypeofError = GetType(), Value = morada.City, UID = Pk });
					if (string.IsNullOrEmpty(morada.Country) || morada.Country.Length != 2 || morada.Country != "Desconhecido")
						listErro.Add(new Error { Description = "Tamanho do País incorrecto.", Field = "Country", TypeofError = GetType(), Value = morada.Country, UID = Pk });
					if (string.IsNullOrEmpty(morada.PostalCode) || morada.PostalCode.Length > 20)
						listErro.Add(new Error { Description = "Tamanho do código postal incorrecto.", Field = "PostalCode", TypeofError = GetType(), Value = morada.PostalCode, UID = Pk });
					if (string.IsNullOrEmpty(morada.Region) == false && morada.Region.Length > 50)
						listErro.Add(new Error { Description = "Tamanho do distrito incorrecto.", Field = "Region", TypeofError = GetType(), Value = morada.Region, UID = Pk });
					if (string.IsNullOrEmpty(morada.StreetName) == false && morada.StreetName.Length > 90)
						listErro.Add(new Error { Description = "Tamanho do nome da rua incorrecto.", Field = "StreetName", TypeofError = GetType(), Value = morada.StreetName, UID = Pk });
				}
			}

			return listErro.ToArray();
		}
		#endregion Validation
	}

	public partial class TaxTableEntry : BaseData, IDataErrorInfo
	{
		//TaxToolTipService tooltip;
		//public TaxToolTipService Tooltip
		//{
		//	get
		//	{
		//		if (tooltip == null)
		//			tooltip = new TaxToolTipService();
		//		return tooltip;
		//	}
		//	set { tooltip = value; }
		//}

		public string Error
		{
			get { return string.Empty; }
		}

		[System.Runtime.CompilerServices.IndexerName("Items")]
		public string this[string columnName]
		{
			get
			{
				Error erro = null;
				if (columnName == "TaxCountryRegion")
				{
					erro = ValidateTaxCountryRegion(appendError: true);
				}
				else if (columnName == "TaxCode")
				{
					erro = ValidateTaxCode(appendError: true);
				}

				return erro == null ? "" : erro.Description;
			}
		}

		#region Validations

		public Error ValidateTaxCountryRegion(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(TaxCountryRegion) || TaxCountryRegion.Length > 5)
			{
				erro = new Error { Description = "País ou região do imposto inválido", Field = "TaxCountryRegion", TypeofError = GetType(), Value = TaxCountryRegion, UID = Pk };
				//if (appendError)
				//	Tooltip.TaxCountryRegion = Tooltip.TaxCountryRegion.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateTaxCode(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(TaxCode) || TaxCode.Length > 10)
			{
				erro = new Error { Description = "Código do imposto inválido", Field = "TaxCode", TypeofError = GetType(), Value = TaxCode, UID = Pk };
				//if (appendError)
				//	Tooltip.TaxCode = Tooltip.TaxCode.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		//public Error ValidateDescription(bool appendError = false)
		//{
		//    Error erro = null;
		//    if (string.IsNullOrEmpty(Description) || Description.Length > 255)
		//    {
		//        erro = new Error { Description = "Identificador único do cliente inválido", Field = "Description", TypeofError = GetType(), ID = Description, UID = Pk };
		//        if (appendError)
		//            Tooltip.Description = Tooltip.Description.FormatTooltipWithError(erro.Description);
		//    }

		//    return erro;
		//}
		//public Error ValidateTaxExpirationDate(bool appendError = false)
		//{
		//    Error erro = null;
		//    if (string.IsNullOrEmpty(TaxExpirationDate) || TaxExpirationDate.Length > 30)
		//    {
		//        erro = new Error { Description = "Data de fim de vigência inválida", Field = "TaxExpirationDate", TypeofError = GetType(), ID = TaxExpirationDate, UID = Pk };
		//        if (appendError)
		//            Tooltip.TaxExpirationDate = Tooltip.TaxExpirationDate.FormatTooltipWithError(erro.Description);
		//    }

		//    return erro;
		//}
		//public Error ValidateTaxPercentage(bool appendError = false)
		//{
		//    Error erro = null;
		//    if (string.IsNullOrEmpty(TaxPercentage) || TaxPercentage.Length > 30)
		//    {
		//        erro = new Error { Description = "Percentagem da taxa do imposto inválida.", Field = "TaxPercentage", TypeofError = GetType(), ID = TaxPercentage, UID = Pk };
		//        if (appendError)
		//            Tooltip.TaxPercentage = Tooltip.TaxPercentage.FormatTooltipWithError(erro.Description);
		//    }

		//    return erro;
		//}
		//public Error ValidateTaxAmount(bool appendError = false)
		//{
		//    Error erro = null;
		//    if (string.IsNullOrEmpty(TaxAmount) || TaxAmount.Length > 30)
		//    {
		//        erro = new Error { Description = "Identificador único do cliente inválido", Field = "TaxAmount", TypeofError = GetType(), ID = TaxAmount, UID = Pk };
		//        if (appendError)
		//            Tooltip.TaxAmount = Tooltip.TaxAmount.FormatTooltipWithError(erro.Description);
		//    }

		//    return erro;
		//}
		#endregion
	}

	public partial class Supplier : BaseData, IDataErrorInfo
	{
		//SupplierToolTipService tooltip;
		//public SupplierToolTipService Tooltip
		//{
		//	get
		//	{
		//		if (tooltip == null)
		//			tooltip = new SupplierToolTipService();
		//		return tooltip;
		//	}
		//	set { tooltip = value; }
		//}

		public string Error
		{
			get { return string.Empty; }
		}

		public string this[string columnName]
		{
			get
			{
				Error erro = null;
				if (columnName == "CustomerID")
				{
					erro = ValidateCustomerID(appendError: true);
				}
				else if (columnName == "AccountID")
				{
					erro = ValidateAccountID(appendError: true);
				}
				else if (columnName == "SupplierTaxID")
				{
					erro = ValidateSupplierTaxID(appendError: true);
				}
				else if (columnName == "CompanyName")
				{
					erro = ValidateCompanyName(appendError: true);
				}
				else if (columnName == "Contact")
				{
					erro = ValidateContact(appendError: true);
				}
				else if (columnName == "Telephone")
				{
					erro = ValidateTelephone(appendError: true);
				}
				else if (columnName == "Fax")
				{
					erro = ValidateFax(appendError: true);
				}
				else if (columnName == "Email")
				{
					erro = ValidateEmail(appendError: true);
				}
				else if (columnName == "Website")
				{
					erro = ValidateWebsite(appendError: true);
				}
				else if (columnName == "SelfBillingIndicator")
				{
					erro = ValidateSelfBillingIndicator(appendError: true);
				}

				return erro == null ? "" : erro.Description;
			}
		}

		#region Validation

		public Error ValidateCustomerID(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(SupplierID) || SupplierID.Length > 30)
			{
				erro = new Error { Description = "Identificador único do fornecedor inválido", Field = "SupplierID", TypeofError = GetType(), Value = SupplierID, UID = Pk };
				//if (appendError)
				//	Tooltip.SupplierID = Tooltip.SupplierID.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateAccountID(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(AccountID) || AccountID.Length > 30)
			{
				erro = new Error { Description = "Código da conta inválido", Field = "AccountID", TypeofError = GetType(), Value = AccountID, UID = Pk };
				//if (appendError)
				//	Tooltip.AccountID = Tooltip.AccountID.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateSupplierTaxID(bool appendError = false)
		{
			Error erro = null;
			if (!Validations.CheckTaxRegistrationNumber(SupplierTaxID))
			{
				erro = new Error { Description = "Número de identificação fiscal inválido", Field = "SupplierTaxID", TypeofError = GetType(), Value = SupplierTaxID, UID = Pk };
				//if (appendError)
				//	Tooltip.SupplierTaxID = Tooltip.SupplierTaxID.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateCompanyName(bool appendError = false)
		{
			Error erro = null;
			if (string.IsNullOrEmpty(CompanyName) || CompanyName.Length > 100)
			{
				erro = new Error { Description = "Nome da empresa inválido", Field = "CompanyName", TypeofError = GetType(), Value = CompanyName, UID = Pk };
				//if (appendError)
				//	Tooltip.CompanyName = Tooltip.CompanyName.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateContact(bool appendError = false)
		{
			Error erro = null;
			if (!string.IsNullOrEmpty(Contact) && Contact.Length > 50)
			{
				erro = new Error { Description = "Nome do contacto na empresa inválido.", Field = "Contact", TypeofError = GetType(), Value = Contact, UID = Pk };
				//if (appendError)
				//	Tooltip.Contact = Tooltip.Contact.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateTelephone(bool appendError = false)
		{
			Error erro = null;
			if (!string.IsNullOrEmpty(Telephone) && Telephone.Length > 20)
			{
				erro = new Error { Description = "Telefone inválido", Field = "Telephone", TypeofError = GetType(), Value = Telephone, UID = Pk };
				//if (appendError)
				//	Tooltip.Telephone = Tooltip.Telephone.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateFax(bool appendError = false)
		{
			Error erro = null;
			if (!string.IsNullOrEmpty(Fax) && Fax.Length > 20)
			{
				erro = new Error { Description = "Fax inválido", Field = "Fax", TypeofError = GetType(), Value = Fax, UID = Pk };
				//if (appendError)
				//	Tooltip.Fax = Tooltip.Fax.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateEmail(bool appendError = false)
		{
			Error erro = null;
			if (!string.IsNullOrEmpty(Email) && Email.Length > 60)
			{
				erro = new Error { Description = "Email inválido", Field = "Email", TypeofError = GetType(), Value = Email, UID = Pk };
			//	if (appendError)
			//		Tooltip.Email = Tooltip.Email.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateWebsite(bool appendError = false)
		{
			Error erro = null;
			if (!string.IsNullOrEmpty(Website) && Website.Length > 60)
			{
				erro = new Error { Description = "Website inválido", Field = "Website", TypeofError = GetType(), Value = Website, UID = Pk };
				//if (appendError)
				//	Tooltip.Website = Tooltip.Website.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}
		public Error ValidateSelfBillingIndicator(bool appendError = false)
		{
			Error erro = null;

			int selfBillingIndicator = -1;
			if (!string.IsNullOrEmpty(SelfBillingIndicator))
				Int32.TryParse(SelfBillingIndicator, out selfBillingIndicator);

			if (string.IsNullOrEmpty(SelfBillingIndicator) || selfBillingIndicator == -1)
			{
				erro = new Error { Description = "Nº de conta inválido", Field = "SelfBillingIndicator", TypeofError = GetType(), Value = SelfBillingIndicator, UID = Pk };
				//if (appendError)
				//	Tooltip.SelfBillingIndicator = Tooltip.SelfBillingIndicator.FormatTooltipWithError(erro.Description);
			}

			return erro;
		}

		public Error[] ValidateBillingAddress()
		{
			List<Error> listErro = new List<Error>();

			if (BillingAddress == null)
				listErro.Add(new Error { Description = "Morada de faturação inexistente", Field = "BillingAddress", TypeofError = GetType(), UID = Pk });

			if (BillingAddress != null)
			{
				if (string.IsNullOrEmpty(BillingAddress.AddressDetail) || BillingAddress.AddressDetail.Length > 100)
					listErro.Add(new Error { Description = "Tamanho da morada detalhada.", Field = "AddressDetail", TypeofError = GetType(), Value = BillingAddress.AddressDetail, UID = Pk });
				if (string.IsNullOrEmpty(BillingAddress.BuildingNumber) == false && BillingAddress.BuildingNumber.Length > 10)
					listErro.Add(new Error { Description = "Tamanho do número de polícia incorrecto.", Field = "BuildingNumber", TypeofError = GetType(), Value = BillingAddress.BuildingNumber, UID = Pk });
				if (string.IsNullOrEmpty(BillingAddress.City) || BillingAddress.City.Length > 50)
					listErro.Add(new Error { Description = "Tamanho da localidade incorrecto.", Field = "City", TypeofError = GetType(), Value = BillingAddress.City, UID = Pk });
				if (string.IsNullOrEmpty(BillingAddress.Country) || BillingAddress.Country.Length != 2)
					listErro.Add(new Error { Description = "Tamanho do País incorrecto.", Field = "Country", TypeofError = GetType(), Value = BillingAddress.Country, UID = Pk });
				if (string.IsNullOrEmpty(BillingAddress.PostalCode) || BillingAddress.PostalCode.Length > 20)
					listErro.Add(new Error { Description = "Tamanho do código postal incorrecto.", Field = "PostalCode", TypeofError = GetType(), Value = BillingAddress.PostalCode, UID = Pk });
				if (string.IsNullOrEmpty(BillingAddress.Region) == false && BillingAddress.Region.Length > 50)
					listErro.Add(new Error { Description = "Tamanho do distrito incorrecto.", Field = "Region", TypeofError = GetType(), Value = BillingAddress.Region, UID = Pk });
				if (string.IsNullOrEmpty(BillingAddress.StreetName) == false && BillingAddress.StreetName.Length > 90)
					listErro.Add(new Error { Description = "Tamanho do nome da rua incorrecto.", Field = "StreetName", TypeofError = GetType(), Value = BillingAddress.StreetName, UID = Pk });
			}

			return listErro.ToArray();
		}
		public Error[] ValidateShipFromAddress()
		{
			List<Error> listErro = new List<Error>();

			if (ShipFromAddress != null && ShipFromAddress.Length > 0)
			{
				foreach (var morada in ShipFromAddress)
				{
					if (string.IsNullOrEmpty(morada.AddressDetail) || morada.AddressDetail.Length > 100)
						listErro.Add(new Error { Description = "Tamanho da morada detalhada.", Field = "AddressDetail", TypeofError = GetType(), Value = morada.AddressDetail, UID = Pk });
					if (string.IsNullOrEmpty(morada.BuildingNumber) == false && morada.BuildingNumber.Length > 10)
						listErro.Add(new Error { Description = "Tamanho do número de polícia incorrecto.", Field = "BuildingNumber", TypeofError = GetType(), Value = morada.BuildingNumber, UID = Pk });
					if (string.IsNullOrEmpty(morada.City) || morada.City.Length > 50)
						listErro.Add(new Error { Description = "Tamanho da localidade incorrecto.", Field = "City", TypeofError = GetType(), Value = morada.City, UID = Pk });
					if (string.IsNullOrEmpty(morada.Country) || morada.Country.Length != 2)
						listErro.Add(new Error { Description = "Tamanho do País incorrecto.", Field = "Country", TypeofError = GetType(), Value = morada.Country, UID = Pk });
					if (string.IsNullOrEmpty(morada.PostalCode) || morada.PostalCode.Length > 20)
						listErro.Add(new Error { Description = "Tamanho do código postal incorrecto.", Field = "PostalCode", TypeofError = GetType(), Value = morada.PostalCode, UID = Pk });
					if (string.IsNullOrEmpty(morada.Region) == false && morada.Region.Length > 50)
						listErro.Add(new Error { Description = "Tamanho do distrito incorrecto.", Field = "Region", TypeofError = GetType(), Value = morada.Region, UID = Pk });
					if (string.IsNullOrEmpty(morada.StreetName) == false && morada.StreetName.Length > 90)
						listErro.Add(new Error { Description = "Tamanho do nome da rua incorrecto.", Field = "StreetName", TypeofError = GetType(), Value = morada.StreetName, UID = Pk });
				}
			}

			return listErro.ToArray();
		}
		#endregion Validation
	}

	public partial class GeneralLedger : BaseData, IDataErrorInfo
	{

		public string Error
		{
			get { return string.Empty; }
		}

		public string this[string columnName]
		{
			get { return string.Empty; }
		}
	}

	public partial class GeneralLedgerEntriesJournal : BaseData, IDataErrorInfo
	{
		public string Error
		{
			get { return string.Empty; }
		}

		public string this[string columnName]
		{
			get { return string.Empty; }
		}
	}

	public partial class GeneralLedgerEntriesJournalTransaction : BaseData, IDataErrorInfo
	{
		public string Error
		{
			get { return string.Empty; }
		}

		[System.Runtime.CompilerServices.IndexerName("Items")]
		public string this[string columnName]
		{
			get { return string.Empty; }
		}
	}

	public partial class GeneralLedgerEntriesJournalTransactionLine : BaseData, IDataErrorInfo
	{
		public string Error
		{
			get { return string.Empty; }
		}

		[System.Runtime.CompilerServices.IndexerName("Items")]
		public string this[string columnName]
		{
			get { return string.Empty; }
		}
	}

	public partial class SchemaResults { }

	public partial class HashResults { }
}
