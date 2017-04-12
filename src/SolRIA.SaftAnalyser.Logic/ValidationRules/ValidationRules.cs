using SolRia.Erp.MobileApp.Models.SaftV4;

namespace SolRIA.SaftAnalyser.Logic.ValidationRules
{
	public class PaymentValidationRule : CustomValidationRule<SourceDocumentsPaymentsPayment> { }

	public class PaymentLineValidationRule : CustomValidationRule<SourceDocumentsPaymentsPaymentLine> { }

	public class InvoiceValidationRule : CustomValidationRule<SourceDocumentsSalesInvoicesInvoice> { }

	public class InvoiceLineValidationRule : CustomValidationRule<SourceDocumentsSalesInvoicesInvoiceLine> { }

	public class MovementValidationRule : CustomValidationRule<SourceDocumentsMovementOfGoodsStockMovement> { }

	public class MovementLineValidationRule : CustomValidationRule<SourceDocumentsMovementOfGoodsStockMovementLine> { }

	public class WorkingDocumentsValidationRule : CustomValidationRule<SourceDocumentsWorkingDocumentsWorkDocument> { }

	public class WorkingDocumentsLineValidationRule : CustomValidationRule<SourceDocumentsWorkingDocumentsWorkDocumentLine> { }

	public class CustomersValidationRule : CustomValidationRule<Customer> { }

	public class ProductValidationRule : CustomValidationRule<Product> { }

	public class TaxValidationRule : CustomValidationRule<TaxTableEntry> { }

	public class SupplierValidationRule : CustomValidationRule<Supplier> { }

	public class GeneralLedgerValidationRule : CustomValidationRule<GeneralLedger> { }

	public class GeneralLedgerEntriesJournalValidationRule : CustomValidationRule<GeneralLedgerEntriesJournal> { }

	public class GeneralLedgerEntriesJournalTransactionValidationRule : CustomValidationRule<GeneralLedgerEntriesJournalTransaction> { }

	public class GeneralLedgerEntriesJournalTransactionLineValidationRule : CustomValidationRule<GeneralLedgerEntriesJournalTransactionLine> { }
}
