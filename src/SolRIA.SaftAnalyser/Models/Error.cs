using System;

namespace SolRIA.SaftAnalyser.Models
{
	public class Error
	{
		public string Description { get; set; }

		public Type TypeofError { get; set; }

		public string Field { get; set; }

		public string Value { get; set; }

		/// <summary>
		/// Unique ID, to identify the register with error
		/// </summary>
		public string UID { get; set; }

		public string SupUID { get; set; }

		public string GranSupUID { get; set; }

		string displayName;
		public string DisplayName
		{
			get
			{
				if (TypeofError == null)
					displayName = "??";
				else
				{
					switch (TypeofError.Name)
					{
						case "SourceDocumentsSalesInvoicesInvoice":
							displayName = "Documentos facturação";
							break;
						case "SourceDocumentsSalesInvoices":
							displayName = "Documentos facturação";
							break;
						case "SourceDocumentsWorkingDocuments":
							displayName = "Documentos de conferência";
							break;
						case "SourceDocumentsWorkingDocumentsWorkDocument":
							displayName = "Documentos de conferência";
							break;
						case "SourceDocumentsWorkingDocumentsWorkDocumentLine":
							displayName = "Linhas documentos de conferência";
							break;
						case "SourceDocumentsMovementOfGoods":
							displayName = "Mercadorias";
							break;
						case "SourceDocumentsMovementOfGoodsStockMovement":
							displayName = "Mercadorias";
							break;
						case "SourceDocumentsMovementOfGoodsStockMovementLine":
							displayName = "Linhas mercadorias";
							break;
						case "SourceDocumentsPayments":
							displayName = "Linhas mercadorias";
							break;
						case "SourceDocumentsPaymentsPayment":
							displayName = "Recibos";
							break;
						case "SourceDocumentsPaymentsPaymentLine":
							displayName = "Linhas recibos";
							break;
						case "SourceDocumentsSalesInvoicesInvoiceLine":
							displayName = "Linhas documentos de facturação";
							break;
						case "Product":
							displayName = "Produtos";
							break;
						case "Customer":
							displayName = "Clientes";
							break;
						case "Header":
							displayName = "Cabeçalho";
							break;
						case "Tax":
							displayName = "Impostos";
							break;
						case "Supplier":
							displayName = "Fornecedores";
							break;
						case "SchemaResults":
							displayName = "Schema";
							break;
						case "HashResults":
							displayName = "Assinaturas documentos";
							break;
						default:
							displayName = "??";
							break;
					}
				}

				return displayName;
			}

			private set { displayName = value; }
		}
	}
}
