namespace SolRia.Erp.MobileApp.Models.SaftV4
{
	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public partial class AuditFile
	{
		private Header headerField;

		private AuditFileMasterFiles masterFilesField;

		private GeneralLedgerEntries generalLedgerEntriesField;

		private SourceDocuments sourceDocumentsField;

		/// <remarks/>
		public Header Header
		{
			get => headerField;
			set => headerField = value;
		}

		/// <remarks/>
		public AuditFileMasterFiles MasterFiles
		{
			get => masterFilesField;
			set => masterFilesField = value;
		}

		/// <remarks/>
		public GeneralLedgerEntries GeneralLedgerEntries
		{
			get => generalLedgerEntriesField;
			set => generalLedgerEntriesField = value;
		}

		/// <remarks/>
		public SourceDocuments SourceDocuments
		{
			get => sourceDocumentsField;
			set => sourceDocumentsField = value;
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public partial class Header
	{
		private string auditFileVersionField;

		private string companyIDField;

		private string taxRegistrationNumberField;

		private TaxAccountingBasis taxAccountingBasisField;

		private string companyNameField;

		private string businessNameField;

		private AddressStructurePT companyAddressField;

		private string fiscalYearField;

		private System.DateTime startDateField;

		private System.DateTime endDateField;

		private object currencyCodeField;

		private System.DateTime dateCreatedField;

		private string taxEntityField;

		private string productCompanyTaxIDField;

		private string softwareCertificateNumberField;

		private string productIDField;

		private string productVersionField;

		private string headerCommentField;

		private string telephoneField;

		private string faxField;

		private string emailField;

		private string websiteField;

		/// <remarks/>
		public string AuditFileVersion
		{
			get
			{
				return auditFileVersionField;
			}
			set
			{
				auditFileVersionField = value;
			}
		}

		/// <remarks/>
		public string CompanyID
		{
			get
			{
				return companyIDField;
			}
			set
			{
				companyIDField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
		public string TaxRegistrationNumber
		{
			get
			{
				return taxRegistrationNumberField;
			}
			set
			{
				taxRegistrationNumberField = value;
			}
		}

		/// <remarks/>
		public TaxAccountingBasis TaxAccountingBasis
		{
			get
			{
				return taxAccountingBasisField;
			}
			set
			{
				taxAccountingBasisField = value;
			}
		}

		/// <remarks/>
		public string CompanyName
		{
			get
			{
				return companyNameField;
			}
			set
			{
				companyNameField = value;
			}
		}

		/// <remarks/>
		public string BusinessName
		{
			get
			{
				return businessNameField;
			}
			set
			{
				businessNameField = value;
			}
		}

		/// <remarks/>
		public AddressStructurePT CompanyAddress
		{
			get
			{
				return companyAddressField;
			}
			set
			{
				companyAddressField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
		public string FiscalYear
		{
			get
			{
				return fiscalYearField;
			}
			set
			{
				fiscalYearField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
		public System.DateTime StartDate
		{
			get
			{
				return startDateField;
			}
			set
			{
				startDateField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
		public System.DateTime EndDate
		{
			get
			{
				return endDateField;
			}
			set
			{
				endDateField = value;
			}
		}

		/// <remarks/>
		// CODEGEN Warning: 'fixed' attribute supported only for primitive types.  Ignoring fixed='EUR' attribute.
		public object CurrencyCode
		{
			get
			{
				return currencyCodeField;
			}
			set
			{
				currencyCodeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
		public System.DateTime DateCreated
		{
			get
			{
				return dateCreatedField;
			}
			set
			{
				dateCreatedField = value;
			}
		}

		/// <remarks/>
		public string TaxEntity
		{
			get
			{
				return taxEntityField;
			}
			set
			{
				taxEntityField = value;
			}
		}

		/// <remarks/>
		public string ProductCompanyTaxID
		{
			get
			{
				return productCompanyTaxIDField;
			}
			set
			{
				productCompanyTaxIDField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
		public string SoftwareCertificateNumber
		{
			get
			{
				return softwareCertificateNumberField;
			}
			set
			{
				softwareCertificateNumberField = value;
			}
		}

		/// <remarks/>
		public string ProductID
		{
			get
			{
				return productIDField;
			}
			set
			{
				productIDField = value;
			}
		}

		/// <remarks/>
		public string ProductVersion
		{
			get
			{
				return productVersionField;
			}
			set
			{
				productVersionField = value;
			}
		}

		/// <remarks/>
		public string HeaderComment
		{
			get
			{
				return headerCommentField;
			}
			set
			{
				headerCommentField = value;
			}
		}

		/// <remarks/>
		public string Telephone
		{
			get
			{
				return telephoneField;
			}
			set
			{
				telephoneField = value;
			}
		}

		/// <remarks/>
		public string Fax
		{
			get
			{
				return faxField;
			}
			set
			{
				faxField = value;
			}
		}

		/// <remarks/>
		public string Email
		{
			get
			{
				return emailField;
			}
			set
			{
				emailField = value;
			}
		}

		/// <remarks/>
		public string Website
		{
			get
			{
				return websiteField;
			}
			set
			{
				websiteField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public enum TaxAccountingBasis
	{
		/// <remarks/>
		C,

		/// <remarks/>
		E,

		/// <remarks/>
		F,

		/// <remarks/>
		I,

		/// <remarks/>
		P,

		/// <remarks/>
		R,

		/// <remarks/>
		S,

		/// <remarks/>
		T,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot("CompanyAddress", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public partial class AddressStructurePT
	{
		private string buildingNumberField;

		private string streetNameField;

		private string addressDetailField;

		private string cityField;

		private string postalCodeField;

		private string regionField;

		private object countryField;

		/// <remarks/>
		public string BuildingNumber
		{
			get
			{
				return buildingNumberField;
			}
			set
			{
				buildingNumberField = value;
			}
		}

		/// <remarks/>
		public string StreetName
		{
			get
			{
				return streetNameField;
			}
			set
			{
				streetNameField = value;
			}
		}

		/// <remarks/>
		public string AddressDetail
		{
			get
			{
				return addressDetailField;
			}
			set
			{
				addressDetailField = value;
			}
		}

		/// <remarks/>
		public string City
		{
			get
			{
				return cityField;
			}
			set
			{
				cityField = value;
			}
		}

		/// <remarks/>
		public string PostalCode
		{
			get
			{
				return postalCodeField;
			}
			set
			{
				postalCodeField = value;
			}
		}

		/// <remarks/>
		public string Region
		{
			get
			{
				return regionField;
			}
			set
			{
				regionField = value;
			}
		}

		/// <remarks/>
		// CODEGEN Warning: 'fixed' attribute supported only for primitive types.  Ignoring fixed='PT' attribute.
		public object Country
		{
			get
			{
				return countryField;
			}
			set
			{
				countryField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class WithholdingTax
	{
		private WithholdingTaxType withholdingTaxTypeField;

		private bool withholdingTaxTypeFieldSpecified;

		private string withholdingTaxDescriptionField;

		private decimal withholdingTaxAmountField;

		/// <remarks/>
		public WithholdingTaxType WithholdingTaxType
		{
			get
			{
				return withholdingTaxTypeField;
			}
			set
			{
				withholdingTaxTypeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool WithholdingTaxTypeSpecified
		{
			get
			{
				return withholdingTaxTypeFieldSpecified;
			}
			set
			{
				withholdingTaxTypeFieldSpecified = value;
			}
		}

		/// <remarks/>
		public string WithholdingTaxDescription
		{
			get
			{
				return withholdingTaxDescriptionField;
			}
			set
			{
				withholdingTaxDescriptionField = value;
			}
		}

		/// <remarks/>
		public decimal WithholdingTaxAmount
		{
			get
			{
				return withholdingTaxAmountField;
			}
			set
			{
				withholdingTaxAmountField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public enum WithholdingTaxType
	{
		/// <remarks/>
		IRS,

		/// <remarks/>
		IRC,

		/// <remarks/>
		IS,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class Tax
	{
		private TaxType taxTypeField;

		private string taxCountryRegionField;

		private string taxCodeField;

		private decimal itemField;

		private ItemChoiceType1 itemElementNameField;

		/// <remarks/>
		public TaxType TaxType
		{
			get
			{
				return taxTypeField;
			}
			set
			{
				taxTypeField = value;
			}
		}

		/// <remarks/>
		public string TaxCountryRegion
		{
			get
			{
				return taxCountryRegionField;
			}
			set
			{
				taxCountryRegionField = value;
			}
		}

		/// <remarks/>
		public string TaxCode
		{
			get
			{
				return taxCodeField;
			}
			set
			{
				taxCodeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("TaxAmount", typeof(decimal))]
		[System.Xml.Serialization.XmlElementAttribute("TaxPercentage", typeof(decimal))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
		public decimal Item
		{
			get
			{
				return itemField;
			}
			set
			{
				itemField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemChoiceType1 ItemElementName
		{
			get
			{
				return itemElementNameField;
			}
			set
			{
				itemElementNameField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public enum TaxType
	{
		/// <remarks/>
		IVA,

		/// <remarks/>
		IS,

		/// <remarks/>
		NS,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IncludeInSchema = false)]
	public enum ItemChoiceType1
	{
		/// <remarks/>
		TaxAmount,

		/// <remarks/>
		TaxPercentage,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SupplierAddressStructure
	{
		private string buildingNumberField;

		private string streetNameField;

		private string addressDetailField;

		private string cityField;

		private string postalCodeField;

		private string regionField;

		private string countryField;

		/// <remarks/>
		public string BuildingNumber
		{
			get
			{
				return buildingNumberField;
			}
			set
			{
				buildingNumberField = value;
			}
		}

		/// <remarks/>
		public string StreetName
		{
			get
			{
				return streetNameField;
			}
			set
			{
				streetNameField = value;
			}
		}

		/// <remarks/>
		public string AddressDetail
		{
			get
			{
				return addressDetailField;
			}
			set
			{
				addressDetailField = value;
			}
		}

		/// <remarks/>
		public string City
		{
			get
			{
				return cityField;
			}
			set
			{
				cityField = value;
			}
		}

		/// <remarks/>
		public string PostalCode
		{
			get
			{
				return postalCodeField;
			}
			set
			{
				postalCodeField = value;
			}
		}

		/// <remarks/>
		public string Region
		{
			get
			{
				return regionField;
			}
			set
			{
				regionField = value;
			}
		}

		/// <remarks/>
		public string Country
		{
			get
			{
				return countryField;
			}
			set
			{
				countryField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SpecialRegimes
	{
		private string selfBillingIndicatorField;

		private string cashVATSchemeIndicatorField;

		private string thirdPartiesBillingIndicatorField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
		public string SelfBillingIndicator
		{
			get
			{
				return selfBillingIndicatorField;
			}
			set
			{
				selfBillingIndicatorField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
		public string CashVATSchemeIndicator
		{
			get
			{
				return cashVATSchemeIndicatorField;
			}
			set
			{
				cashVATSchemeIndicatorField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
		public string ThirdPartiesBillingIndicator
		{
			get
			{
				return thirdPartiesBillingIndicatorField;
			}
			set
			{
				thirdPartiesBillingIndicatorField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class Settlement
	{
		private string settlementDiscountField;

		private decimal settlementAmountField;

		private bool settlementAmountFieldSpecified;

		private System.DateTime settlementDateField;

		private bool settlementDateFieldSpecified;

		private string paymentTermsField;

		/// <remarks/>
		public string SettlementDiscount
		{
			get
			{
				return settlementDiscountField;
			}
			set
			{
				settlementDiscountField = value;
			}
		}

		/// <remarks/>
		public decimal SettlementAmount
		{
			get
			{
				return settlementAmountField;
			}
			set
			{
				settlementAmountField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool SettlementAmountSpecified
		{
			get
			{
				return settlementAmountFieldSpecified;
			}
			set
			{
				settlementAmountFieldSpecified = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
		public System.DateTime SettlementDate
		{
			get
			{
				return settlementDateField;
			}
			set
			{
				settlementDateField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool SettlementDateSpecified
		{
			get
			{
				return settlementDateFieldSpecified;
			}
			set
			{
				settlementDateFieldSpecified = value;
			}
		}

		/// <remarks/>
		public string PaymentTerms
		{
			get
			{
				return paymentTermsField;
			}
			set
			{
				paymentTermsField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class References
	{
		private string referenceField;

		private string reasonField;

		/// <remarks/>
		public string Reference
		{
			get
			{
				return referenceField;
			}
			set
			{
				referenceField = value;
			}
		}

		/// <remarks/>
		public string Reason
		{
			get
			{
				return reasonField;
			}
			set
			{
				reasonField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class PaymentTax
	{
		private TaxType taxTypeField;

		private string taxCountryRegionField;

		private string taxCodeField;

		private decimal itemField;

		private ItemChoiceType itemElementNameField;

		/// <remarks/>
		public TaxType TaxType
		{
			get
			{
				return taxTypeField;
			}
			set
			{
				taxTypeField = value;
			}
		}

		/// <remarks/>
		public string TaxCountryRegion
		{
			get
			{
				return taxCountryRegionField;
			}
			set
			{
				taxCountryRegionField = value;
			}
		}

		/// <remarks/>
		public string TaxCode
		{
			get
			{
				return taxCodeField;
			}
			set
			{
				taxCodeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("TaxAmount", typeof(decimal))]
		[System.Xml.Serialization.XmlElementAttribute("TaxPercentage", typeof(decimal))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
		public decimal Item
		{
			get
			{
				return itemField;
			}
			set
			{
				itemField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemChoiceType ItemElementName
		{
			get
			{
				return itemElementNameField;
			}
			set
			{
				itemElementNameField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IncludeInSchema = false)]
	public enum ItemChoiceType
	{
		/// <remarks/>
		TaxAmount,

		/// <remarks/>
		TaxPercentage,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class PaymentMethod
	{
		private PaymentMechanism paymentMechanismField;

		private bool paymentMechanismFieldSpecified;

		private decimal paymentAmountField;

		private System.DateTime paymentDateField;

		/// <remarks/>
		public PaymentMechanism PaymentMechanism
		{
			get
			{
				return paymentMechanismField;
			}
			set
			{
				paymentMechanismField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool PaymentMechanismSpecified
		{
			get
			{
				return paymentMechanismFieldSpecified;
			}
			set
			{
				paymentMechanismFieldSpecified = value;
			}
		}

		/// <remarks/>
		public decimal PaymentAmount
		{
			get
			{
				return paymentAmountField;
			}
			set
			{
				paymentAmountField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
		public System.DateTime PaymentDate
		{
			get
			{
				return paymentDateField;
			}
			set
			{
				paymentDateField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public enum PaymentMechanism
	{
		/// <remarks/>
		CC,

		/// <remarks/>
		CD,

		/// <remarks/>
		CH,

		/// <remarks/>
		CI,

		/// <remarks/>
		CO,

		/// <remarks/>
		CS,

		/// <remarks/>
		DE,

		/// <remarks/>
		LC,

		/// <remarks/>
		MB,

		/// <remarks/>
		NU,

		/// <remarks/>
		OU,

		/// <remarks/>
		PR,

		/// <remarks/>
		TB,

		/// <remarks/>
		TR,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class OrderReferences
	{
		private string originatingONField;

		private System.DateTime orderDateField;

		private bool orderDateFieldSpecified;

		/// <remarks/>
		public string OriginatingON
		{
			get
			{
				return originatingONField;
			}
			set
			{
				originatingONField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
		public System.DateTime OrderDate
		{
			get
			{
				return orderDateField;
			}
			set
			{
				orderDateField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool OrderDateSpecified
		{
			get
			{
				return orderDateFieldSpecified;
			}
			set
			{
				orderDateFieldSpecified = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class MovementTax
	{
		private SAFTPTMovementTaxType taxTypeField;

		private string taxCountryRegionField;

		private string taxCodeField;

		private decimal taxPercentageField;

		/// <remarks/>
		public SAFTPTMovementTaxType TaxType
		{
			get
			{
				return taxTypeField;
			}
			set
			{
				taxTypeField = value;
			}
		}

		/// <remarks/>
		public string TaxCountryRegion
		{
			get
			{
				return taxCountryRegionField;
			}
			set
			{
				taxCountryRegionField = value;
			}
		}

		/// <remarks/>
		public string TaxCode
		{
			get
			{
				return taxCodeField;
			}
			set
			{
				taxCodeField = value;
			}
		}

		/// <remarks/>
		public decimal TaxPercentage
		{
			get
			{
				return taxPercentageField;
			}
			set
			{
				taxPercentageField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public enum SAFTPTMovementTaxType
	{
		/// <remarks/>
		IVA,

		/// <remarks/>
		NS,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class CustomsInformation
	{
		private string[] aRCNoField;

		private decimal iECAmountField;

		private bool iECAmountFieldSpecified;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ARCNo")]
		public string[] ARCNo
		{
			get
			{
				return aRCNoField;
			}
			set
			{
				aRCNoField = value;
			}
		}

		/// <remarks/>
		public decimal IECAmount
		{
			get
			{
				return iECAmountField;
			}
			set
			{
				iECAmountField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool IECAmountSpecified
		{
			get
			{
				return iECAmountFieldSpecified;
			}
			set
			{
				iECAmountFieldSpecified = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class CustomsDetails
	{
		private string[] cNCodeField;

		private string[] uNNumberField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("CNCode")]
		public string[] CNCode
		{
			get
			{
				return cNCodeField;
			}
			set
			{
				cNCodeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("UNNumber")]
		public string[] UNNumber
		{
			get
			{
				return uNNumberField;
			}
			set
			{
				uNNumberField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class Currency
	{
		private string currencyCodeField;

		private decimal currencyAmountField;

		private decimal exchangeRateField;

		/// <remarks/>
		public string CurrencyCode
		{
			get
			{
				return currencyCodeField;
			}
			set
			{
				currencyCodeField = value;
			}
		}

		/// <remarks/>
		public decimal CurrencyAmount
		{
			get
			{
				return currencyAmountField;
			}
			set
			{
				currencyAmountField = value;
			}
		}

		/// <remarks/>
		public decimal ExchangeRate
		{
			get
			{
				return exchangeRateField;
			}
			set
			{
				exchangeRateField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class AuditFileMasterFiles
	{
		private GeneralLedgerAccounts generalLedgerAccountsField;

		private Customer[] customerField;

		private Supplier[] supplierField;

		private Product[] productField;

		private TaxTableEntry[] taxTableField;

		/// <remarks/>
		public GeneralLedgerAccounts GeneralLedgerAccounts
		{
			get
			{
				return generalLedgerAccountsField;
			}
			set
			{
				generalLedgerAccountsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Customer")]
		public Customer[] Customer
		{
			get
			{
				return customerField;
			}
			set
			{
				customerField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Supplier")]
		public Supplier[] Supplier
		{
			get
			{
				return supplierField;
			}
			set
			{
				supplierField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Product")]
		public Product[] Product
		{
			get
			{
				return productField;
			}
			set
			{
				productField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("TaxTableEntry", IsNullable = false)]
		public TaxTableEntry[] TaxTable
		{
			get
			{
				return taxTableField;
			}
			set
			{
				taxTableField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public partial class GeneralLedgerAccounts
	{

		private TaxonomyReference taxonomyReferenceField;

		private GeneralLedgerAccountsAccount[] accountField;

		/// <remarks/>
		public TaxonomyReference TaxonomyReference
		{
			get
			{
				return taxonomyReferenceField;
			}
			set
			{
				taxonomyReferenceField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Account")]
		public GeneralLedgerAccountsAccount[] Account
		{
			get
			{
				return accountField;
			}
			set
			{
				accountField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public enum TaxonomyReference
	{
		/// <remarks/>
		S,

		/// <remarks/>
		M,

		/// <remarks/>
		N,

		/// <remarks/>
		O,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class GeneralLedgerAccountsAccount
	{

		private string accountIDField;

		private string accountDescriptionField;

		private decimal openingDebitBalanceField;

		private decimal openingCreditBalanceField;

		private decimal closingDebitBalanceField;

		private decimal closingCreditBalanceField;

		private GroupingCategory groupingCategoryField;

		private string groupingCodeField;

		private string taxonomyCodeField;

		/// <remarks/>
		public string AccountID
		{
			get
			{
				return accountIDField;
			}
			set
			{
				accountIDField = value;
			}
		}

		/// <remarks/>
		public string AccountDescription
		{
			get
			{
				return accountDescriptionField;
			}
			set
			{
				accountDescriptionField = value;
			}
		}

		/// <remarks/>
		public decimal OpeningDebitBalance
		{
			get
			{
				return openingDebitBalanceField;
			}
			set
			{
				openingDebitBalanceField = value;
			}
		}

		/// <remarks/>
		public decimal OpeningCreditBalance
		{
			get
			{
				return openingCreditBalanceField;
			}
			set
			{
				openingCreditBalanceField = value;
			}
		}

		/// <remarks/>
		public decimal ClosingDebitBalance
		{
			get
			{
				return closingDebitBalanceField;
			}
			set
			{
				closingDebitBalanceField = value;
			}
		}

		/// <remarks/>
		public decimal ClosingCreditBalance
		{
			get
			{
				return closingCreditBalanceField;
			}
			set
			{
				closingCreditBalanceField = value;
			}
		}

		/// <remarks/>
		public GroupingCategory GroupingCategory
		{
			get
			{
				return groupingCategoryField;
			}
			set
			{
				groupingCategoryField = value;
			}
		}

		/// <remarks/>
		public string GroupingCode
		{
			get
			{
				return groupingCodeField;
			}
			set
			{
				groupingCodeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
		public string TaxonomyCode
		{
			get
			{
				return taxonomyCodeField;
			}
			set
			{
				taxonomyCodeField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public enum GroupingCategory
	{
		/// <remarks/>
		GR,

		/// <remarks/>
		GA,

		/// <remarks/>
		GM,

		/// <remarks/>
		AR,

		/// <remarks/>
		AA,

		/// <remarks/>
		AM,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public partial class Customer
	{
		private string customerIDField;

		private string accountIDField;

		private string customerTaxIDField;

		private string companyNameField;

		private string contactField;

		private AddressStructure billingAddressField;

		private AddressStructure[] shipToAddressField;

		private string telephoneField;

		private string faxField;

		private string emailField;

		private string websiteField;

		private string selfBillingIndicatorField;

		/// <remarks/>
		public string CustomerID
		{
			get
			{
				return customerIDField;
			}
			set
			{
				customerIDField = value;
			}
		}

		/// <remarks/>
		public string AccountID
		{
			get
			{
				return accountIDField;
			}
			set
			{
				accountIDField = value;
			}
		}

		/// <remarks/>
		public string CustomerTaxID
		{
			get
			{
				return customerTaxIDField;
			}
			set
			{
				customerTaxIDField = value;
			}
		}

		/// <remarks/>
		public string CompanyName
		{
			get
			{
				return companyNameField;
			}
			set
			{
				companyNameField = value;
			}
		}

		/// <remarks/>
		public string Contact
		{
			get
			{
				return contactField;
			}
			set
			{
				contactField = value;
			}
		}

		/// <remarks/>
		public AddressStructure BillingAddress
		{
			get
			{
				return billingAddressField;
			}
			set
			{
				billingAddressField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ShipToAddress")]
		public AddressStructure[] ShipToAddress
		{
			get
			{
				return shipToAddressField;
			}
			set
			{
				shipToAddressField = value;
			}
		}

		/// <remarks/>
		public string Telephone
		{
			get
			{
				return telephoneField;
			}
			set
			{
				telephoneField = value;
			}
		}

		/// <remarks/>
		public string Fax
		{
			get
			{
				return faxField;
			}
			set
			{
				faxField = value;
			}
		}

		/// <remarks/>
		public string Email
		{
			get
			{
				return emailField;
			}
			set
			{
				emailField = value;
			}
		}

		/// <remarks/>
		public string Website
		{
			get
			{
				return websiteField;
			}
			set
			{
				websiteField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
		public string SelfBillingIndicator
		{
			get
			{
				return selfBillingIndicatorField;
			}
			set
			{
				selfBillingIndicatorField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot("Address", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public partial class AddressStructure
	{
		private string buildingNumberField;

		private string streetNameField;

		private string addressDetailField;

		private string cityField;

		private string postalCodeField;

		private string regionField;

		private string countryField;

		/// <remarks/>
		public string BuildingNumber
		{
			get
			{
				return buildingNumberField;
			}
			set
			{
				buildingNumberField = value;
			}
		}

		/// <remarks/>
		public string StreetName
		{
			get
			{
				return streetNameField;
			}
			set
			{
				streetNameField = value;
			}
		}

		/// <remarks/>
		public string AddressDetail
		{
			get
			{
				return addressDetailField;
			}
			set
			{
				addressDetailField = value;
			}
		}

		/// <remarks/>
		public string City
		{
			get
			{
				return cityField;
			}
			set
			{
				cityField = value;
			}
		}

		/// <remarks/>
		public string PostalCode
		{
			get
			{
				return postalCodeField;
			}
			set
			{
				postalCodeField = value;
			}
		}

		/// <remarks/>
		public string Region
		{
			get
			{
				return regionField;
			}
			set
			{
				regionField = value;
			}
		}

		/// <remarks/>
		public string Country
		{
			get
			{
				return countryField;
			}
			set
			{
				countryField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public partial class Supplier
	{
		private string supplierIDField;

		private string accountIDField;

		private string supplierTaxIDField;

		private string companyNameField;

		private string contactField;

		private SupplierAddressStructure billingAddressField;

		private SupplierAddressStructure[] shipFromAddressField;

		private string telephoneField;

		private string faxField;

		private string emailField;

		private string websiteField;

		private string selfBillingIndicatorField;

		/// <remarks/>
		public string SupplierID
		{
			get
			{
				return supplierIDField;
			}
			set
			{
				supplierIDField = value;
			}
		}

		/// <remarks/>
		public string AccountID
		{
			get
			{
				return accountIDField;
			}
			set
			{
				accountIDField = value;
			}
		}

		/// <remarks/>
		public string SupplierTaxID
		{
			get
			{
				return supplierTaxIDField;
			}
			set
			{
				supplierTaxIDField = value;
			}
		}

		/// <remarks/>
		public string CompanyName
		{
			get
			{
				return companyNameField;
			}
			set
			{
				companyNameField = value;
			}
		}

		/// <remarks/>
		public string Contact
		{
			get
			{
				return contactField;
			}
			set
			{
				contactField = value;
			}
		}

		/// <remarks/>
		public SupplierAddressStructure BillingAddress
		{
			get
			{
				return billingAddressField;
			}
			set
			{
				billingAddressField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("ShipFromAddress")]
		public SupplierAddressStructure[] ShipFromAddress
		{
			get
			{
				return shipFromAddressField;
			}
			set
			{
				shipFromAddressField = value;
			}
		}

		/// <remarks/>
		public string Telephone
		{
			get
			{
				return telephoneField;
			}
			set
			{
				telephoneField = value;
			}
		}

		/// <remarks/>
		public string Fax
		{
			get
			{
				return faxField;
			}
			set
			{
				faxField = value;
			}
		}

		/// <remarks/>
		public string Email
		{
			get
			{
				return emailField;
			}
			set
			{
				emailField = value;
			}
		}

		/// <remarks/>
		public string Website
		{
			get
			{
				return websiteField;
			}
			set
			{
				websiteField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
		public string SelfBillingIndicator
		{
			get
			{
				return selfBillingIndicatorField;
			}
			set
			{
				selfBillingIndicatorField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public partial class Product
	{
		private ProductType productTypeField;

		private string productCodeField;

		private string productGroupField;

		private string productDescriptionField;

		private string productNumberCodeField;

		private CustomsDetails customsDetailsField;

		/// <remarks/>
		public ProductType ProductType
		{
			get
			{
				return productTypeField;
			}
			set
			{
				productTypeField = value;
			}
		}

		/// <remarks/>
		public string ProductCode
		{
			get
			{
				return productCodeField;
			}
			set
			{
				productCodeField = value;
			}
		}

		/// <remarks/>
		public string ProductGroup
		{
			get
			{
				return productGroupField;
			}
			set
			{
				productGroupField = value;
			}
		}

		/// <remarks/>
		public string ProductDescription
		{
			get
			{
				return productDescriptionField;
			}
			set
			{
				productDescriptionField = value;
			}
		}

		/// <remarks/>
		public string ProductNumberCode
		{
			get
			{
				return productNumberCodeField;
			}
			set
			{
				productNumberCodeField = value;
			}
		}

		/// <remarks/>
		public CustomsDetails CustomsDetails
		{
			get
			{
				return customsDetailsField;
			}
			set
			{
				customsDetailsField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public enum ProductType
	{
		/// <remarks/>
		P,

		/// <remarks/>
		S,

		/// <remarks/>
		O,

		/// <remarks/>
		E,

		/// <remarks/>
		I,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public partial class TaxTableEntry
	{
		private TaxType taxTypeField;

		private string taxCountryRegionField;

		private string taxCodeField;

		private string descriptionField;

		private System.DateTime taxExpirationDateField;

		private bool taxExpirationDateFieldSpecified;

		private decimal itemField;

		private ItemChoiceType2 itemElementNameField;

		/// <remarks/>
		public TaxType TaxType
		{
			get
			{
				return taxTypeField;
			}
			set
			{
				taxTypeField = value;
			}
		}

		/// <remarks/>
		public string TaxCountryRegion
		{
			get
			{
				return taxCountryRegionField;
			}
			set
			{
				taxCountryRegionField = value;
			}
		}

		/// <remarks/>
		public string TaxCode
		{
			get
			{
				return taxCodeField;
			}
			set
			{
				taxCodeField = value;
			}
		}

		/// <remarks/>
		public string Description
		{
			get
			{
				return descriptionField;
			}
			set
			{
				descriptionField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
		public System.DateTime TaxExpirationDate
		{
			get
			{
				return taxExpirationDateField;
			}
			set
			{
				taxExpirationDateField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool TaxExpirationDateSpecified
		{
			get
			{
				return taxExpirationDateFieldSpecified;
			}
			set
			{
				taxExpirationDateFieldSpecified = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("TaxAmount", typeof(decimal))]
		[System.Xml.Serialization.XmlElementAttribute("TaxPercentage", typeof(decimal))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
		public decimal Item
		{
			get
			{
				return itemField;
			}
			set
			{
				itemField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemChoiceType2 ItemElementName
		{
			get
			{
				return itemElementNameField;
			}
			set
			{
				itemElementNameField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IncludeInSchema = false)]
	public enum ItemChoiceType2
	{
		/// <remarks/>
		TaxAmount,

		/// <remarks/>
		TaxPercentage,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public partial class GeneralLedgerEntries
	{
		private string numberOfEntriesField;

		private decimal totalDebitField;

		private decimal totalCreditField;

		private GeneralLedgerEntriesJournal[] journalField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
		public string NumberOfEntries
		{
			get
			{
				return numberOfEntriesField;
			}
			set
			{
				numberOfEntriesField = value;
			}
		}

		/// <remarks/>
		public decimal TotalDebit
		{
			get
			{
				return totalDebitField;
			}
			set
			{
				totalDebitField = value;
			}
		}

		/// <remarks/>
		public decimal TotalCredit
		{
			get
			{
				return totalCreditField;
			}
			set
			{
				totalCreditField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Journal")]
		public GeneralLedgerEntriesJournal[] Journal
		{
			get
			{
				return journalField;
			}
			set
			{
				journalField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class GeneralLedgerEntriesJournal
	{
		private string journalIDField;

		private string descriptionField;

		private GeneralLedgerEntriesJournalTransaction[] transactionField;

		/// <remarks/>
		public string JournalID
		{
			get
			{
				return journalIDField;
			}
			set
			{
				journalIDField = value;
			}
		}

		/// <remarks/>
		public string Description
		{
			get
			{
				return descriptionField;
			}
			set
			{
				descriptionField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Transaction")]
		public GeneralLedgerEntriesJournalTransaction[] Transaction
		{
			get
			{
				return transactionField;
			}
			set
			{
				transactionField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class GeneralLedgerEntriesJournalTransaction
	{
		private string transactionIDField;

		private string periodField;

		private System.DateTime transactionDateField;

		private string sourceIDField;

		private string descriptionField;

		private string docArchivalNumberField;

		private TransactionType transactionTypeField;

		private System.DateTime gLPostingDateField;

		private string itemField;

		private ItemChoiceType3 itemElementNameField;

		private GeneralLedgerEntriesJournalTransactionLines linesField;

		/// <remarks/>
		public string TransactionID
		{
			get
			{
				return transactionIDField;
			}
			set
			{
				transactionIDField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
		public string Period
		{
			get
			{
				return periodField;
			}
			set
			{
				periodField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
		public System.DateTime TransactionDate
		{
			get
			{
				return transactionDateField;
			}
			set
			{
				transactionDateField = value;
			}
		}

		/// <remarks/>
		public string SourceID
		{
			get
			{
				return sourceIDField;
			}
			set
			{
				sourceIDField = value;
			}
		}

		/// <remarks/>
		public string Description
		{
			get
			{
				return descriptionField;
			}
			set
			{
				descriptionField = value;
			}
		}

		/// <remarks/>
		public string DocArchivalNumber
		{
			get
			{
				return docArchivalNumberField;
			}
			set
			{
				docArchivalNumberField = value;
			}
		}

		/// <remarks/>
		public TransactionType TransactionType
		{
			get
			{
				return transactionTypeField;
			}
			set
			{
				transactionTypeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
		public System.DateTime GLPostingDate
		{
			get
			{
				return gLPostingDateField;
			}
			set
			{
				gLPostingDateField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("CustomerID", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SupplierID", typeof(string))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
		public string Item
		{
			get
			{
				return itemField;
			}
			set
			{
				itemField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemChoiceType3 ItemElementName
		{
			get
			{
				return itemElementNameField;
			}
			set
			{
				itemElementNameField = value;
			}
		}

		/// <remarks/>
		public GeneralLedgerEntriesJournalTransactionLines Lines
		{
			get
			{
				return linesField;
			}
			set
			{
				linesField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public enum TransactionType
	{
		/// <remarks/>
		N,

		/// <remarks/>
		R,

		/// <remarks/>
		A,

		/// <remarks/>
		J,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IncludeInSchema = false)]
	public enum ItemChoiceType3
	{
		/// <remarks/>
		CustomerID,

		/// <remarks/>
		SupplierID,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class GeneralLedgerEntriesJournalTransactionLines
	{
		private GeneralLedgerEntriesJournalTransactionLinesDebitLine debitLineField;

		private GeneralLedgerEntriesJournalTransactionLinesCreditLine creditLineField;

		/// <remarks/>
		public GeneralLedgerEntriesJournalTransactionLinesDebitLine DebitLine
		{
			get
			{
				return debitLineField;
			}
			set
			{
				debitLineField = value;
			}
		}

		/// <remarks/>
		public GeneralLedgerEntriesJournalTransactionLinesCreditLine CreditLine
		{
			get
			{
				return creditLineField;
			}
			set
			{
				creditLineField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class GeneralLedgerEntriesJournalTransactionLinesDebitLine
	{
		private string recordIDField;

		private string accountIDField;

		private string sourceDocumentIDField;

		private System.DateTime systemEntryDateField;

		private string descriptionField;

		private decimal debitAmountField;

		/// <remarks/>
		public string RecordID
		{
			get
			{
				return recordIDField;
			}
			set
			{
				recordIDField = value;
			}
		}

		/// <remarks/>
		public string AccountID
		{
			get
			{
				return accountIDField;
			}
			set
			{
				accountIDField = value;
			}
		}

		/// <remarks/>
		public string SourceDocumentID
		{
			get
			{
				return sourceDocumentIDField;
			}
			set
			{
				sourceDocumentIDField = value;
			}
		}

		/// <remarks/>
		public System.DateTime SystemEntryDate
		{
			get
			{
				return systemEntryDateField;
			}
			set
			{
				systemEntryDateField = value;
			}
		}

		/// <remarks/>
		public string Description
		{
			get
			{
				return descriptionField;
			}
			set
			{
				descriptionField = value;
			}
		}

		/// <remarks/>
		public decimal DebitAmount
		{
			get
			{
				return debitAmountField;
			}
			set
			{
				debitAmountField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class GeneralLedgerEntriesJournalTransactionLinesCreditLine
	{
		private string recordIDField;

		private string accountIDField;

		private string sourceDocumentIDField;

		private System.DateTime systemEntryDateField;

		private string descriptionField;

		private decimal creditAmountField;

		/// <remarks/>
		public string RecordID
		{
			get
			{
				return recordIDField;
			}
			set
			{
				recordIDField = value;
			}
		}

		/// <remarks/>
		public string AccountID
		{
			get
			{
				return accountIDField;
			}
			set
			{
				accountIDField = value;
			}
		}

		/// <remarks/>
		public string SourceDocumentID
		{
			get
			{
				return sourceDocumentIDField;
			}
			set
			{
				sourceDocumentIDField = value;
			}
		}

		/// <remarks/>
		public System.DateTime SystemEntryDate
		{
			get
			{
				return systemEntryDateField;
			}
			set
			{
				systemEntryDateField = value;
			}
		}

		/// <remarks/>
		public string Description
		{
			get
			{
				return descriptionField;
			}
			set
			{
				descriptionField = value;
			}
		}

		/// <remarks/>
		public decimal CreditAmount
		{
			get
			{
				return creditAmountField;
			}
			set
			{
				creditAmountField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public partial class SourceDocuments
	{
		private SourceDocumentsSalesInvoices salesInvoicesField;

		private SourceDocumentsMovementOfGoods movementOfGoodsField;

		private SourceDocumentsWorkingDocuments workingDocumentsField;

		private SourceDocumentsPayments paymentsField;

		/// <remarks/>
		public SourceDocumentsSalesInvoices SalesInvoices
		{
			get
			{
				return salesInvoicesField;
			}
			set
			{
				salesInvoicesField = value;
			}
		}

		/// <remarks/>
		public SourceDocumentsMovementOfGoods MovementOfGoods
		{
			get
			{
				return movementOfGoodsField;
			}
			set
			{
				movementOfGoodsField = value;
			}
		}

		/// <remarks/>
		public SourceDocumentsWorkingDocuments WorkingDocuments
		{
			get
			{
				return workingDocumentsField;
			}
			set
			{
				workingDocumentsField = value;
			}
		}

		/// <remarks/>
		public SourceDocumentsPayments Payments
		{
			get
			{
				return paymentsField;
			}
			set
			{
				paymentsField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SourceDocumentsSalesInvoices
	{
		private string numberOfEntriesField;

		private decimal totalDebitField;

		private decimal totalCreditField;

		private SourceDocumentsSalesInvoicesInvoice[] invoiceField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
		public string NumberOfEntries
		{
			get
			{
				return numberOfEntriesField;
			}
			set
			{
				numberOfEntriesField = value;
			}
		}

		/// <remarks/>
		public decimal TotalDebit
		{
			get
			{
				return totalDebitField;
			}
			set
			{
				totalDebitField = value;
			}
		}

		/// <remarks/>
		public decimal TotalCredit
		{
			get
			{
				return totalCreditField;
			}
			set
			{
				totalCreditField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Invoice")]
		public SourceDocumentsSalesInvoicesInvoice[] Invoice
		{
			get
			{
				return invoiceField;
			}
			set
			{
				invoiceField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SourceDocumentsSalesInvoicesInvoice
	{
		private string invoiceNoField;

		private string aTCUDField;

		private SourceDocumentsSalesInvoicesInvoiceDocumentStatus documentStatusField;

		private string hashField;

		private string hashControlField;

		private string periodField;

		private System.DateTime invoiceDateField;

		private InvoiceType invoiceTypeField;

		private SpecialRegimes specialRegimesField;

		private string sourceIDField;

		private string eACCodeField;

		private System.DateTime systemEntryDateField;

		private string transactionIDField;

		private string customerIDField;

		private ShippingPointStructure shipToField;

		private ShippingPointStructure shipFromField;

		private System.DateTime movementEndTimeField;

		private bool movementEndTimeFieldSpecified;

		private System.DateTime movementStartTimeField;

		private bool movementStartTimeFieldSpecified;

		private SourceDocumentsSalesInvoicesInvoiceLine[] lineField;

		private SourceDocumentsSalesInvoicesInvoiceDocumentTotals documentTotalsField;

		private WithholdingTax[] withholdingTaxField;

		/// <remarks/>
		public string InvoiceNo
		{
			get
			{
				return invoiceNoField;
			}
			set
			{
				invoiceNoField = value;
			}
		}

		/// <remarks/>
		public string ATCUD
		{
			get
			{
				return aTCUDField;
			}
			set
			{
				aTCUDField = value;
			}
		}

		/// <remarks/>
		public SourceDocumentsSalesInvoicesInvoiceDocumentStatus DocumentStatus
		{
			get
			{
				return documentStatusField;
			}
			set
			{
				documentStatusField = value;
			}
		}

		/// <remarks/>
		public string Hash
		{
			get
			{
				return hashField;
			}
			set
			{
				hashField = value;
			}
		}

		/// <remarks/>
		public string HashControl
		{
			get
			{
				return hashControlField;
			}
			set
			{
				hashControlField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
		public string Period
		{
			get
			{
				return periodField;
			}
			set
			{
				periodField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
		public System.DateTime InvoiceDate
		{
			get
			{
				return invoiceDateField;
			}
			set
			{
				invoiceDateField = value;
			}
		}

		/// <remarks/>
		public InvoiceType InvoiceType
		{
			get
			{
				return invoiceTypeField;
			}
			set
			{
				invoiceTypeField = value;
			}
		}

		/// <remarks/>
		public SpecialRegimes SpecialRegimes
		{
			get
			{
				return specialRegimesField;
			}
			set
			{
				specialRegimesField = value;
			}
		}

		/// <remarks/>
		public string SourceID
		{
			get
			{
				return sourceIDField;
			}
			set
			{
				sourceIDField = value;
			}
		}

		/// <remarks/>
		public string EACCode
		{
			get
			{
				return eACCodeField;
			}
			set
			{
				eACCodeField = value;
			}
		}

		/// <remarks/>
		public System.DateTime SystemEntryDate
		{
			get
			{
				return systemEntryDateField;
			}
			set
			{
				systemEntryDateField = value;
			}
		}

		/// <remarks/>
		public string TransactionID
		{
			get
			{
				return transactionIDField;
			}
			set
			{
				transactionIDField = value;
			}
		}

		/// <remarks/>
		public string CustomerID
		{
			get
			{
				return customerIDField;
			}
			set
			{
				customerIDField = value;
			}
		}

		/// <remarks/>
		public ShippingPointStructure ShipTo
		{
			get
			{
				return shipToField;
			}
			set
			{
				shipToField = value;
			}
		}

		/// <remarks/>
		public ShippingPointStructure ShipFrom
		{
			get
			{
				return shipFromField;
			}
			set
			{
				shipFromField = value;
			}
		}

		/// <remarks/>
		public System.DateTime MovementEndTime
		{
			get
			{
				return movementEndTimeField;
			}
			set
			{
				movementEndTimeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool MovementEndTimeSpecified
		{
			get
			{
				return movementEndTimeFieldSpecified;
			}
			set
			{
				movementEndTimeFieldSpecified = value;
			}
		}

		/// <remarks/>
		public System.DateTime MovementStartTime
		{
			get
			{
				return movementStartTimeField;
			}
			set
			{
				movementStartTimeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool MovementStartTimeSpecified
		{
			get
			{
				return movementStartTimeFieldSpecified;
			}
			set
			{
				movementStartTimeFieldSpecified = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Line")]
		public SourceDocumentsSalesInvoicesInvoiceLine[] Line
		{
			get
			{
				return lineField;
			}
			set
			{
				lineField = value;
			}
		}

		/// <remarks/>
		public SourceDocumentsSalesInvoicesInvoiceDocumentTotals DocumentTotals
		{
			get
			{
				return documentTotalsField;
			}
			set
			{
				documentTotalsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("WithholdingTax")]
		public WithholdingTax[] WithholdingTax
		{
			get
			{
				return withholdingTaxField;
			}
			set
			{
				withholdingTaxField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SourceDocumentsSalesInvoicesInvoiceDocumentStatus
	{
		private InvoiceStatus invoiceStatusField;

		private System.DateTime invoiceStatusDateField;

		private string reasonField;

		private string sourceIDField;

		private SAFTPTSourceBilling sourceBillingField;

		/// <remarks/>
		public InvoiceStatus InvoiceStatus
		{
			get
			{
				return invoiceStatusField;
			}
			set
			{
				invoiceStatusField = value;
			}
		}

		/// <remarks/>
		public System.DateTime InvoiceStatusDate
		{
			get
			{
				return invoiceStatusDateField;
			}
			set
			{
				invoiceStatusDateField = value;
			}
		}

		/// <remarks/>
		public string Reason
		{
			get
			{
				return reasonField;
			}
			set
			{
				reasonField = value;
			}
		}

		/// <remarks/>
		public string SourceID
		{
			get
			{
				return sourceIDField;
			}
			set
			{
				sourceIDField = value;
			}
		}

		/// <remarks/>
		public SAFTPTSourceBilling SourceBilling
		{
			get
			{
				return sourceBillingField;
			}
			set
			{
				sourceBillingField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public enum InvoiceStatus
	{
		/// <remarks/>
		N,

		/// <remarks/>
		S,

		/// <remarks/>
		A,

		/// <remarks/>
		R,

		/// <remarks/>
		F,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public enum SAFTPTSourceBilling
	{
		/// <remarks/>
		P,

		/// <remarks/>
		I,

		/// <remarks/>
		M,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public enum InvoiceType
	{
		/// <remarks/>
		FT,

		/// <remarks/>
		FS,

		/// <remarks/>
		FR,

		/// <remarks/>
		ND,

		/// <remarks/>
		NC,

		/// <remarks/>
		VD,

		/// <remarks/>
		TV,

		/// <remarks/>
		TD,

		/// <remarks/>
		AA,

		/// <remarks/>
		DA,

		/// <remarks/>
		RP,

		/// <remarks/>
		RE,

		/// <remarks/>
		CS,

		/// <remarks/>
		LD,

		/// <remarks/>
		RA,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot("ShipFrom", Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public partial class ShippingPointStructure
	{
		private string[] deliveryIDField;

		private System.DateTime deliveryDateField;

		private bool deliveryDateFieldSpecified;

		private string[] warehouseIDField;

		private string[] locationIDField;

		private AddressStructure addressField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("DeliveryID")]
		public string[] DeliveryID
		{
			get
			{
				return deliveryIDField;
			}
			set
			{
				deliveryIDField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
		public System.DateTime DeliveryDate
		{
			get
			{
				return deliveryDateField;
			}
			set
			{
				deliveryDateField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool DeliveryDateSpecified
		{
			get
			{
				return deliveryDateFieldSpecified;
			}
			set
			{
				deliveryDateFieldSpecified = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("WarehouseID")]
		public string[] WarehouseID
		{
			get
			{
				return warehouseIDField;
			}
			set
			{
				warehouseIDField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("LocationID")]
		public string[] LocationID
		{
			get
			{
				return locationIDField;
			}
			set
			{
				locationIDField = value;
			}
		}

		/// <remarks/>
		public AddressStructure Address
		{
			get
			{
				return addressField;
			}
			set
			{
				addressField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SourceDocumentsSalesInvoicesInvoiceLine
	{
		private string lineNumberField;

		private OrderReferences[] orderReferencesField;

		private string productCodeField;

		private string productDescriptionField;

		private decimal quantityField;

		private string unitOfMeasureField;

		private decimal unitPriceField;

		private decimal taxBaseField;

		private bool taxBaseFieldSpecified;

		private System.DateTime taxPointDateField;

		private References[] referencesField;

		private string descriptionField;

		private string[] productSerialNumberField;

		private decimal itemField;

		private ItemChoiceType4 itemElementNameField;

		private Tax taxField;

		private string taxExemptionReasonField;

		private string taxExemptionCodeField;

		private decimal settlementAmountField;

		private bool settlementAmountFieldSpecified;

		private CustomsInformation customsInformationField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
		public string LineNumber
		{
			get
			{
				return lineNumberField;
			}
			set
			{
				lineNumberField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("OrderReferences")]
		public OrderReferences[] OrderReferences
		{
			get
			{
				return orderReferencesField;
			}
			set
			{
				orderReferencesField = value;
			}
		}

		/// <remarks/>
		public string ProductCode
		{
			get
			{
				return productCodeField;
			}
			set
			{
				productCodeField = value;
			}
		}

		/// <remarks/>
		public string ProductDescription
		{
			get
			{
				return productDescriptionField;
			}
			set
			{
				productDescriptionField = value;
			}
		}

		/// <remarks/>
		public decimal Quantity
		{
			get
			{
				return quantityField;
			}
			set
			{
				quantityField = value;
			}
		}

		/// <remarks/>
		public string UnitOfMeasure
		{
			get
			{
				return unitOfMeasureField;
			}
			set
			{
				unitOfMeasureField = value;
			}
		}

		/// <remarks/>
		public decimal UnitPrice
		{
			get
			{
				return unitPriceField;
			}
			set
			{
				unitPriceField = value;
			}
		}

		/// <remarks/>
		public decimal TaxBase
		{
			get
			{
				return taxBaseField;
			}
			set
			{
				taxBaseField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool TaxBaseSpecified
		{
			get
			{
				return taxBaseFieldSpecified;
			}
			set
			{
				taxBaseFieldSpecified = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
		public System.DateTime TaxPointDate
		{
			get
			{
				return taxPointDateField;
			}
			set
			{
				taxPointDateField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("References")]
		public References[] References
		{
			get
			{
				return referencesField;
			}
			set
			{
				referencesField = value;
			}
		}

		/// <remarks/>
		public string Description
		{
			get
			{
				return descriptionField;
			}
			set
			{
				descriptionField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("SerialNumber", IsNullable = false)]
		public string[] ProductSerialNumber
		{
			get
			{
				return productSerialNumberField;
			}
			set
			{
				productSerialNumberField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("CreditAmount", typeof(decimal))]
		[System.Xml.Serialization.XmlElementAttribute("DebitAmount", typeof(decimal))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
		public decimal Item
		{
			get
			{
				return itemField;
			}
			set
			{
				itemField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemChoiceType4 ItemElementName
		{
			get
			{
				return itemElementNameField;
			}
			set
			{
				itemElementNameField = value;
			}
		}

		/// <remarks/>
		public Tax Tax
		{
			get
			{
				return taxField;
			}
			set
			{
				taxField = value;
			}
		}

		/// <remarks/>
		public string TaxExemptionReason
		{
			get
			{
				return taxExemptionReasonField;
			}
			set
			{
				taxExemptionReasonField = value;
			}
		}

		/// <remarks/>
		public string TaxExemptionCode
		{
			get
			{
				return taxExemptionCodeField;
			}
			set
			{
				taxExemptionCodeField = value;
			}
		}

		/// <remarks/>
		public decimal SettlementAmount
		{
			get
			{
				return settlementAmountField;
			}
			set
			{
				settlementAmountField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool SettlementAmountSpecified
		{
			get
			{
				return settlementAmountFieldSpecified;
			}
			set
			{
				settlementAmountFieldSpecified = value;
			}
		}

		/// <remarks/>
		public CustomsInformation CustomsInformation
		{
			get
			{
				return customsInformationField;
			}
			set
			{
				customsInformationField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IncludeInSchema = false)]
	public enum ItemChoiceType4
	{
		/// <remarks/>
		CreditAmount,

		/// <remarks/>
		DebitAmount,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SourceDocumentsSalesInvoicesInvoiceDocumentTotals
	{
		private decimal taxPayableField;

		private decimal netTotalField;

		private decimal grossTotalField;

		private Currency currencyField;

		private Settlement[] settlementField;

		private PaymentMethod[] paymentField;

		/// <remarks/>
		public decimal TaxPayable
		{
			get
			{
				return taxPayableField;
			}
			set
			{
				taxPayableField = value;
			}
		}

		/// <remarks/>
		public decimal NetTotal
		{
			get
			{
				return netTotalField;
			}
			set
			{
				netTotalField = value;
			}
		}

		/// <remarks/>
		public decimal GrossTotal
		{
			get
			{
				return grossTotalField;
			}
			set
			{
				grossTotalField = value;
			}
		}

		/// <remarks/>
		public Currency Currency
		{
			get
			{
				return currencyField;
			}
			set
			{
				currencyField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Settlement")]
		public Settlement[] Settlement
		{
			get
			{
				return settlementField;
			}
			set
			{
				settlementField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Payment")]
		public PaymentMethod[] Payment
		{
			get
			{
				return paymentField;
			}
			set
			{
				paymentField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SourceDocumentsMovementOfGoods
	{
		private string numberOfMovementLinesField;

		private decimal totalQuantityIssuedField;

		private SourceDocumentsMovementOfGoodsStockMovement[] stockMovementField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
		public string NumberOfMovementLines
		{
			get
			{
				return numberOfMovementLinesField;
			}
			set
			{
				numberOfMovementLinesField = value;
			}
		}

		/// <remarks/>
		public decimal TotalQuantityIssued
		{
			get
			{
				return totalQuantityIssuedField;
			}
			set
			{
				totalQuantityIssuedField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("StockMovement")]
		public SourceDocumentsMovementOfGoodsStockMovement[] StockMovement
		{
			get
			{
				return stockMovementField;
			}
			set
			{
				stockMovementField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SourceDocumentsMovementOfGoodsStockMovement
	{
		private string documentNumberField;

		private string aTCUDField;

		private SourceDocumentsMovementOfGoodsStockMovementDocumentStatus documentStatusField;

		private string hashField;

		private string hashControlField;

		private string periodField;

		private System.DateTime movementDateField;

		private MovementType movementTypeField;

		private System.DateTime systemEntryDateField;

		private string transactionIDField;

		private string itemField;

		private ItemChoiceType5 itemElementNameField;

		private string sourceIDField;

		private string eACCodeField;

		private string movementCommentsField;

		private ShippingPointStructure shipToField;

		private ShippingPointStructure shipFromField;

		private System.DateTime movementEndTimeField;

		private bool movementEndTimeFieldSpecified;

		private System.DateTime movementStartTimeField;

		private string aTDocCodeIDField;

		private SourceDocumentsMovementOfGoodsStockMovementLine[] lineField;

		private SourceDocumentsMovementOfGoodsStockMovementDocumentTotals documentTotalsField;

		/// <remarks/>
		public string DocumentNumber
		{
			get
			{
				return documentNumberField;
			}
			set
			{
				documentNumberField = value;
			}
		}

		/// <remarks/>
		public string ATCUD
		{
			get
			{
				return aTCUDField;
			}
			set
			{
				aTCUDField = value;
			}
		}

		/// <remarks/>
		public SourceDocumentsMovementOfGoodsStockMovementDocumentStatus DocumentStatus
		{
			get
			{
				return documentStatusField;
			}
			set
			{
				documentStatusField = value;
			}
		}

		/// <remarks/>
		public string Hash
		{
			get
			{
				return hashField;
			}
			set
			{
				hashField = value;
			}
		}

		/// <remarks/>
		public string HashControl
		{
			get
			{
				return hashControlField;
			}
			set
			{
				hashControlField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
		public string Period
		{
			get
			{
				return periodField;
			}
			set
			{
				periodField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
		public System.DateTime MovementDate
		{
			get
			{
				return movementDateField;
			}
			set
			{
				movementDateField = value;
			}
		}

		/// <remarks/>
		public MovementType MovementType
		{
			get
			{
				return movementTypeField;
			}
			set
			{
				movementTypeField = value;
			}
		}

		/// <remarks/>
		public System.DateTime SystemEntryDate
		{
			get
			{
				return systemEntryDateField;
			}
			set
			{
				systemEntryDateField = value;
			}
		}

		/// <remarks/>
		public string TransactionID
		{
			get
			{
				return transactionIDField;
			}
			set
			{
				transactionIDField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("CustomerID", typeof(string))]
		[System.Xml.Serialization.XmlElementAttribute("SupplierID", typeof(string))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
		public string Item
		{
			get
			{
				return itemField;
			}
			set
			{
				itemField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemChoiceType5 ItemElementName
		{
			get
			{
				return itemElementNameField;
			}
			set
			{
				itemElementNameField = value;
			}
		}

		/// <remarks/>
		public string SourceID
		{
			get
			{
				return sourceIDField;
			}
			set
			{
				sourceIDField = value;
			}
		}

		/// <remarks/>
		public string EACCode
		{
			get
			{
				return eACCodeField;
			}
			set
			{
				eACCodeField = value;
			}
		}

		/// <remarks/>
		public string MovementComments
		{
			get
			{
				return movementCommentsField;
			}
			set
			{
				movementCommentsField = value;
			}
		}

		/// <remarks/>
		public ShippingPointStructure ShipTo
		{
			get
			{
				return shipToField;
			}
			set
			{
				shipToField = value;
			}
		}

		/// <remarks/>
		public ShippingPointStructure ShipFrom
		{
			get
			{
				return shipFromField;
			}
			set
			{
				shipFromField = value;
			}
		}

		/// <remarks/>
		public System.DateTime MovementEndTime
		{
			get
			{
				return movementEndTimeField;
			}
			set
			{
				movementEndTimeField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool MovementEndTimeSpecified
		{
			get
			{
				return movementEndTimeFieldSpecified;
			}
			set
			{
				movementEndTimeFieldSpecified = value;
			}
		}

		/// <remarks/>
		public System.DateTime MovementStartTime
		{
			get
			{
				return movementStartTimeField;
			}
			set
			{
				movementStartTimeField = value;
			}
		}

		/// <remarks/>
		public string ATDocCodeID
		{
			get
			{
				return aTDocCodeIDField;
			}
			set
			{
				aTDocCodeIDField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Line")]
		public SourceDocumentsMovementOfGoodsStockMovementLine[] Line
		{
			get
			{
				return lineField;
			}
			set
			{
				lineField = value;
			}
		}

		/// <remarks/>
		public SourceDocumentsMovementOfGoodsStockMovementDocumentTotals DocumentTotals
		{
			get
			{
				return documentTotalsField;
			}
			set
			{
				documentTotalsField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SourceDocumentsMovementOfGoodsStockMovementDocumentStatus
	{
		private MovementStatus movementStatusField;

		private System.DateTime movementStatusDateField;

		private string reasonField;

		private string sourceIDField;

		private SAFTPTSourceBilling sourceBillingField;

		/// <remarks/>
		public MovementStatus MovementStatus
		{
			get
			{
				return movementStatusField;
			}
			set
			{
				movementStatusField = value;
			}
		}

		/// <remarks/>
		public System.DateTime MovementStatusDate
		{
			get
			{
				return movementStatusDateField;
			}
			set
			{
				movementStatusDateField = value;
			}
		}

		/// <remarks/>
		public string Reason
		{
			get
			{
				return reasonField;
			}
			set
			{
				reasonField = value;
			}
		}

		/// <remarks/>
		public string SourceID
		{
			get
			{
				return sourceIDField;
			}
			set
			{
				sourceIDField = value;
			}
		}

		/// <remarks/>
		public SAFTPTSourceBilling SourceBilling
		{
			get
			{
				return sourceBillingField;
			}
			set
			{
				sourceBillingField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public enum MovementStatus
	{
		/// <remarks/>
		N,

		/// <remarks/>
		T,

		/// <remarks/>
		A,

		/// <remarks/>
		F,

		/// <remarks/>
		R,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public enum MovementType
	{
		/// <remarks/>
		GR,

		/// <remarks/>
		GT,

		/// <remarks/>
		GA,

		/// <remarks/>
		GC,

		/// <remarks/>
		GD,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IncludeInSchema = false)]
	public enum ItemChoiceType5
	{
		/// <remarks/>
		CustomerID,

		/// <remarks/>
		SupplierID,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SourceDocumentsMovementOfGoodsStockMovementLine
	{
		private string lineNumberField;

		private OrderReferences[] orderReferencesField;

		private string productCodeField;

		private string productDescriptionField;

		private decimal quantityField;

		private string unitOfMeasureField;

		private decimal unitPriceField;

		private string descriptionField;

		private string[] productSerialNumberField;

		private decimal itemField;

		private ItemChoiceType6 itemElementNameField;

		private MovementTax taxField;

		private string taxExemptionReasonField;

		private string taxExemptionCodeField;

		private decimal settlementAmountField;

		private bool settlementAmountFieldSpecified;

		private CustomsInformation customsInformationField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
		public string LineNumber
		{
			get
			{
				return lineNumberField;
			}
			set
			{
				lineNumberField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("OrderReferences")]
		public OrderReferences[] OrderReferences
		{
			get
			{
				return orderReferencesField;
			}
			set
			{
				orderReferencesField = value;
			}
		}

		/// <remarks/>
		public string ProductCode
		{
			get
			{
				return productCodeField;
			}
			set
			{
				productCodeField = value;
			}
		}

		/// <remarks/>
		public string ProductDescription
		{
			get
			{
				return productDescriptionField;
			}
			set
			{
				productDescriptionField = value;
			}
		}

		/// <remarks/>
		public decimal Quantity
		{
			get
			{
				return quantityField;
			}
			set
			{
				quantityField = value;
			}
		}

		/// <remarks/>
		public string UnitOfMeasure
		{
			get
			{
				return unitOfMeasureField;
			}
			set
			{
				unitOfMeasureField = value;
			}
		}

		/// <remarks/>
		public decimal UnitPrice
		{
			get
			{
				return unitPriceField;
			}
			set
			{
				unitPriceField = value;
			}
		}

		/// <remarks/>
		public string Description
		{
			get
			{
				return descriptionField;
			}
			set
			{
				descriptionField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("SerialNumber", IsNullable = false)]
		public string[] ProductSerialNumber
		{
			get
			{
				return productSerialNumberField;
			}
			set
			{
				productSerialNumberField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("CreditAmount", typeof(decimal))]
		[System.Xml.Serialization.XmlElementAttribute("DebitAmount", typeof(decimal))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
		public decimal Item
		{
			get
			{
				return itemField;
			}
			set
			{
				itemField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemChoiceType6 ItemElementName
		{
			get
			{
				return itemElementNameField;
			}
			set
			{
				itemElementNameField = value;
			}
		}

		/// <remarks/>
		public MovementTax Tax
		{
			get
			{
				return taxField;
			}
			set
			{
				taxField = value;
			}
		}

		/// <remarks/>
		public string TaxExemptionReason
		{
			get
			{
				return taxExemptionReasonField;
			}
			set
			{
				taxExemptionReasonField = value;
			}
		}

		/// <remarks/>
		public string TaxExemptionCode
		{
			get
			{
				return taxExemptionCodeField;
			}
			set
			{
				taxExemptionCodeField = value;
			}
		}

		/// <remarks/>
		public decimal SettlementAmount
		{
			get
			{
				return settlementAmountField;
			}
			set
			{
				settlementAmountField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool SettlementAmountSpecified
		{
			get
			{
				return settlementAmountFieldSpecified;
			}
			set
			{
				settlementAmountFieldSpecified = value;
			}
		}

		/// <remarks/>
		public CustomsInformation CustomsInformation
		{
			get
			{
				return customsInformationField;
			}
			set
			{
				customsInformationField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IncludeInSchema = false)]
	public enum ItemChoiceType6
	{
		/// <remarks/>
		CreditAmount,

		/// <remarks/>
		DebitAmount,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SourceDocumentsMovementOfGoodsStockMovementDocumentTotals
	{
		private decimal taxPayableField;

		private decimal netTotalField;

		private decimal grossTotalField;

		private Currency currencyField;

		/// <remarks/>
		public decimal TaxPayable
		{
			get
			{
				return taxPayableField;
			}
			set
			{
				taxPayableField = value;
			}
		}

		/// <remarks/>
		public decimal NetTotal
		{
			get
			{
				return netTotalField;
			}
			set
			{
				netTotalField = value;
			}
		}

		/// <remarks/>
		public decimal GrossTotal
		{
			get
			{
				return grossTotalField;
			}
			set
			{
				grossTotalField = value;
			}
		}

		/// <remarks/>
		public Currency Currency
		{
			get
			{
				return currencyField;
			}
			set
			{
				currencyField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SourceDocumentsWorkingDocuments
	{
		private string numberOfEntriesField;

		private decimal totalDebitField;

		private decimal totalCreditField;

		private SourceDocumentsWorkingDocumentsWorkDocument[] workDocumentField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
		public string NumberOfEntries
		{
			get
			{
				return numberOfEntriesField;
			}
			set
			{
				numberOfEntriesField = value;
			}
		}

		/// <remarks/>
		public decimal TotalDebit
		{
			get
			{
				return totalDebitField;
			}
			set
			{
				totalDebitField = value;
			}
		}

		/// <remarks/>
		public decimal TotalCredit
		{
			get
			{
				return totalCreditField;
			}
			set
			{
				totalCreditField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("WorkDocument")]
		public SourceDocumentsWorkingDocumentsWorkDocument[] WorkDocument
		{
			get
			{
				return workDocumentField;
			}
			set
			{
				workDocumentField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SourceDocumentsWorkingDocumentsWorkDocument
	{
		private string documentNumberField;

		private string aTCUDField;

		private SourceDocumentsWorkingDocumentsWorkDocumentDocumentStatus documentStatusField;

		private string hashField;

		private string hashControlField;

		private string periodField;

		private System.DateTime workDateField;

		private WorkType workTypeField;

		private string sourceIDField;

		private string eACCodeField;

		private System.DateTime systemEntryDateField;

		private string transactionIDField;

		private string customerIDField;

		private SourceDocumentsWorkingDocumentsWorkDocumentLine[] lineField;

		private SourceDocumentsWorkingDocumentsWorkDocumentDocumentTotals documentTotalsField;

		/// <remarks/>
		public string DocumentNumber
		{
			get
			{
				return documentNumberField;
			}
			set
			{
				documentNumberField = value;
			}
		}

		/// <remarks/>
		public string ATCUD
		{
			get
			{
				return aTCUDField;
			}
			set
			{
				aTCUDField = value;
			}
		}

		/// <remarks/>
		public SourceDocumentsWorkingDocumentsWorkDocumentDocumentStatus DocumentStatus
		{
			get
			{
				return documentStatusField;
			}
			set
			{
				documentStatusField = value;
			}
		}

		/// <remarks/>
		public string Hash
		{
			get
			{
				return hashField;
			}
			set
			{
				hashField = value;
			}
		}

		/// <remarks/>
		public string HashControl
		{
			get
			{
				return hashControlField;
			}
			set
			{
				hashControlField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
		public string Period
		{
			get
			{
				return periodField;
			}
			set
			{
				periodField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
		public System.DateTime WorkDate
		{
			get
			{
				return workDateField;
			}
			set
			{
				workDateField = value;
			}
		}

		/// <remarks/>
		public WorkType WorkType
		{
			get
			{
				return workTypeField;
			}
			set
			{
				workTypeField = value;
			}
		}

		/// <remarks/>
		public string SourceID
		{
			get
			{
				return sourceIDField;
			}
			set
			{
				sourceIDField = value;
			}
		}

		/// <remarks/>
		public string EACCode
		{
			get
			{
				return eACCodeField;
			}
			set
			{
				eACCodeField = value;
			}
		}

		/// <remarks/>
		public System.DateTime SystemEntryDate
		{
			get
			{
				return systemEntryDateField;
			}
			set
			{
				systemEntryDateField = value;
			}
		}

		/// <remarks/>
		public string TransactionID
		{
			get
			{
				return transactionIDField;
			}
			set
			{
				transactionIDField = value;
			}
		}

		/// <remarks/>
		public string CustomerID
		{
			get
			{
				return customerIDField;
			}
			set
			{
				customerIDField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Line")]
		public SourceDocumentsWorkingDocumentsWorkDocumentLine[] Line
		{
			get
			{
				return lineField;
			}
			set
			{
				lineField = value;
			}
		}

		/// <remarks/>
		public SourceDocumentsWorkingDocumentsWorkDocumentDocumentTotals DocumentTotals
		{
			get
			{
				return documentTotalsField;
			}
			set
			{
				documentTotalsField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SourceDocumentsWorkingDocumentsWorkDocumentDocumentStatus
	{
		private WorkStatus workStatusField;

		private System.DateTime workStatusDateField;

		private string reasonField;

		private string sourceIDField;

		private SAFTPTSourceBilling sourceBillingField;

		/// <remarks/>
		public WorkStatus WorkStatus
		{
			get
			{
				return workStatusField;
			}
			set
			{
				workStatusField = value;
			}
		}

		/// <remarks/>
		public System.DateTime WorkStatusDate
		{
			get
			{
				return workStatusDateField;
			}
			set
			{
				workStatusDateField = value;
			}
		}

		/// <remarks/>
		public string Reason
		{
			get
			{
				return reasonField;
			}
			set
			{
				reasonField = value;
			}
		}

		/// <remarks/>
		public string SourceID
		{
			get
			{
				return sourceIDField;
			}
			set
			{
				sourceIDField = value;
			}
		}

		/// <remarks/>
		public SAFTPTSourceBilling SourceBilling
		{
			get
			{
				return sourceBillingField;
			}
			set
			{
				sourceBillingField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public enum WorkStatus
	{
		/// <remarks/>
		N,

		/// <remarks/>
		A,

		/// <remarks/>
		F,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public enum WorkType
	{
		/// <remarks/>
		CM,

		/// <remarks/>
		CC,

		/// <remarks/>
		FC,

		/// <remarks/>
		FO,

		/// <remarks/>
		NE,

		/// <remarks/>
		OU,

		/// <remarks/>
		OR,

		/// <remarks/>
		PF,

		/// <remarks/>
		DC,

		/// <remarks/>
		RP,

		/// <remarks/>
		RE,

		/// <remarks/>
		CS,

		/// <remarks/>
		LD,

		/// <remarks/>
		RA,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SourceDocumentsWorkingDocumentsWorkDocumentLine
	{
		private string lineNumberField;

		private OrderReferences[] orderReferencesField;

		private string productCodeField;

		private string productDescriptionField;

		private decimal quantityField;

		private string unitOfMeasureField;

		private decimal unitPriceField;

		private decimal taxBaseField;

		private bool taxBaseFieldSpecified;

		private System.DateTime taxPointDateField;

		private string descriptionField;

		private string[] productSerialNumberField;

		private decimal itemField;

		private ItemChoiceType7 itemElementNameField;

		private Tax taxField;

		private string taxExemptionReasonField;

		private string taxExemptionCodeField;

		private decimal settlementAmountField;

		private bool settlementAmountFieldSpecified;

		private CustomsInformation customsInformationField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
		public string LineNumber
		{
			get
			{
				return lineNumberField;
			}
			set
			{
				lineNumberField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("OrderReferences")]
		public OrderReferences[] OrderReferences
		{
			get
			{
				return orderReferencesField;
			}
			set
			{
				orderReferencesField = value;
			}
		}

		/// <remarks/>
		public string ProductCode
		{
			get
			{
				return productCodeField;
			}
			set
			{
				productCodeField = value;
			}
		}

		/// <remarks/>
		public string ProductDescription
		{
			get
			{
				return productDescriptionField;
			}
			set
			{
				productDescriptionField = value;
			}
		}

		/// <remarks/>
		public decimal Quantity
		{
			get
			{
				return quantityField;
			}
			set
			{
				quantityField = value;
			}
		}

		/// <remarks/>
		public string UnitOfMeasure
		{
			get
			{
				return unitOfMeasureField;
			}
			set
			{
				unitOfMeasureField = value;
			}
		}

		/// <remarks/>
		public decimal UnitPrice
		{
			get
			{
				return unitPriceField;
			}
			set
			{
				unitPriceField = value;
			}
		}

		/// <remarks/>
		public decimal TaxBase
		{
			get
			{
				return taxBaseField;
			}
			set
			{
				taxBaseField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool TaxBaseSpecified
		{
			get
			{
				return taxBaseFieldSpecified;
			}
			set
			{
				taxBaseFieldSpecified = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
		public System.DateTime TaxPointDate
		{
			get
			{
				return taxPointDateField;
			}
			set
			{
				taxPointDateField = value;
			}
		}

		/// <remarks/>
		public string Description
		{
			get
			{
				return descriptionField;
			}
			set
			{
				descriptionField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("SerialNumber", IsNullable = false)]
		public string[] ProductSerialNumber
		{
			get
			{
				return productSerialNumberField;
			}
			set
			{
				productSerialNumberField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("CreditAmount", typeof(decimal))]
		[System.Xml.Serialization.XmlElementAttribute("DebitAmount", typeof(decimal))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
		public decimal Item
		{
			get
			{
				return itemField;
			}
			set
			{
				itemField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemChoiceType7 ItemElementName
		{
			get
			{
				return itemElementNameField;
			}
			set
			{
				itemElementNameField = value;
			}
		}

		/// <remarks/>
		public Tax Tax
		{
			get
			{
				return taxField;
			}
			set
			{
				taxField = value;
			}
		}

		/// <remarks/>
		public string TaxExemptionReason
		{
			get
			{
				return taxExemptionReasonField;
			}
			set
			{
				taxExemptionReasonField = value;
			}
		}

		/// <remarks/>
		public string TaxExemptionCode
		{
			get
			{
				return taxExemptionCodeField;
			}
			set
			{
				taxExemptionCodeField = value;
			}
		}

		/// <remarks/>
		public decimal SettlementAmount
		{
			get
			{
				return settlementAmountField;
			}
			set
			{
				settlementAmountField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool SettlementAmountSpecified
		{
			get
			{
				return settlementAmountFieldSpecified;
			}
			set
			{
				settlementAmountFieldSpecified = value;
			}
		}

		/// <remarks/>
		public CustomsInformation CustomsInformation
		{
			get
			{
				return customsInformationField;
			}
			set
			{
				customsInformationField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IncludeInSchema = false)]
	public enum ItemChoiceType7
	{
		/// <remarks/>
		CreditAmount,

		/// <remarks/>
		DebitAmount,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SourceDocumentsWorkingDocumentsWorkDocumentDocumentTotals
	{

		private decimal taxPayableField;

		private decimal netTotalField;

		private decimal grossTotalField;

		private Currency currencyField;

		/// <remarks/>
		public decimal TaxPayable
		{
			get
			{
				return taxPayableField;
			}
			set
			{
				taxPayableField = value;
			}
		}

		/// <remarks/>
		public decimal NetTotal
		{
			get
			{
				return netTotalField;
			}
			set
			{
				netTotalField = value;
			}
		}

		/// <remarks/>
		public decimal GrossTotal
		{
			get
			{
				return grossTotalField;
			}
			set
			{
				grossTotalField = value;
			}
		}

		/// <remarks/>
		public Currency Currency
		{
			get
			{
				return currencyField;
			}
			set
			{
				currencyField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SourceDocumentsPayments
	{
		private string numberOfEntriesField;

		private decimal totalDebitField;

		private decimal totalCreditField;

		private SourceDocumentsPaymentsPayment[] paymentField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
		public string NumberOfEntries
		{
			get
			{
				return numberOfEntriesField;
			}
			set
			{
				numberOfEntriesField = value;
			}
		}

		/// <remarks/>
		public decimal TotalDebit
		{
			get
			{
				return totalDebitField;
			}
			set
			{
				totalDebitField = value;
			}
		}

		/// <remarks/>
		public decimal TotalCredit
		{
			get
			{
				return totalCreditField;
			}
			set
			{
				totalCreditField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Payment")]
		public SourceDocumentsPaymentsPayment[] Payment
		{
			get
			{
				return paymentField;
			}
			set
			{
				paymentField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SourceDocumentsPaymentsPayment
	{
		private string paymentRefNoField;

		private string aTCUDField;

		private string periodField;

		private string transactionIDField;

		private System.DateTime transactionDateField;

		private SAFTPTPaymentType paymentTypeField;

		private string descriptionField;

		private string systemIDField;

		private SourceDocumentsPaymentsPaymentDocumentStatus documentStatusField;

		private PaymentMethod[] paymentMethodField;

		private string sourceIDField;

		private System.DateTime systemEntryDateField;

		private string customerIDField;

		private SourceDocumentsPaymentsPaymentLine[] lineField;

		private SourceDocumentsPaymentsPaymentDocumentTotals documentTotalsField;

		private WithholdingTax[] withholdingTaxField;

		/// <remarks/>
		public string PaymentRefNo
		{
			get
			{
				return paymentRefNoField;
			}
			set
			{
				paymentRefNoField = value;
			}
		}

		/// <remarks/>
		public string ATCUD
		{
			get
			{
				return aTCUDField;
			}
			set
			{
				aTCUDField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
		public string Period
		{
			get
			{
				return periodField;
			}
			set
			{
				periodField = value;
			}
		}

		/// <remarks/>
		public string TransactionID
		{
			get
			{
				return transactionIDField;
			}
			set
			{
				transactionIDField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
		public System.DateTime TransactionDate
		{
			get
			{
				return transactionDateField;
			}
			set
			{
				transactionDateField = value;
			}
		}

		/// <remarks/>
		public SAFTPTPaymentType PaymentType
		{
			get
			{
				return paymentTypeField;
			}
			set
			{
				paymentTypeField = value;
			}
		}

		/// <remarks/>
		public string Description
		{
			get
			{
				return descriptionField;
			}
			set
			{
				descriptionField = value;
			}
		}

		/// <remarks/>
		public string SystemID
		{
			get
			{
				return systemIDField;
			}
			set
			{
				systemIDField = value;
			}
		}

		/// <remarks/>
		public SourceDocumentsPaymentsPaymentDocumentStatus DocumentStatus
		{
			get
			{
				return documentStatusField;
			}
			set
			{
				documentStatusField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("PaymentMethod")]
		public PaymentMethod[] PaymentMethod
		{
			get
			{
				return paymentMethodField;
			}
			set
			{
				paymentMethodField = value;
			}
		}

		/// <remarks/>
		public string SourceID
		{
			get
			{
				return sourceIDField;
			}
			set
			{
				sourceIDField = value;
			}
		}

		/// <remarks/>
		public System.DateTime SystemEntryDate
		{
			get
			{
				return systemEntryDateField;
			}
			set
			{
				systemEntryDateField = value;
			}
		}

		/// <remarks/>
		public string CustomerID
		{
			get
			{
				return customerIDField;
			}
			set
			{
				customerIDField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("Line")]
		public SourceDocumentsPaymentsPaymentLine[] Line
		{
			get
			{
				return lineField;
			}
			set
			{
				lineField = value;
			}
		}

		/// <remarks/>
		public SourceDocumentsPaymentsPaymentDocumentTotals DocumentTotals
		{
			get
			{
				return documentTotalsField;
			}
			set
			{
				documentTotalsField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("WithholdingTax")]
		public WithholdingTax[] WithholdingTax
		{
			get
			{
				return withholdingTaxField;
			}
			set
			{
				withholdingTaxField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public enum SAFTPTPaymentType
	{
		/// <remarks/>
		RC,

		/// <remarks/>
		RG,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SourceDocumentsPaymentsPaymentDocumentStatus
	{

		private PaymentStatus paymentStatusField;

		private System.DateTime paymentStatusDateField;

		private string reasonField;

		private string sourceIDField;

		private SAFTPTSourcePayment sourcePaymentField;

		/// <remarks/>
		public PaymentStatus PaymentStatus
		{
			get
			{
				return paymentStatusField;
			}
			set
			{
				paymentStatusField = value;
			}
		}

		/// <remarks/>
		public System.DateTime PaymentStatusDate
		{
			get
			{
				return paymentStatusDateField;
			}
			set
			{
				paymentStatusDateField = value;
			}
		}

		/// <remarks/>
		public string Reason
		{
			get
			{
				return reasonField;
			}
			set
			{
				reasonField = value;
			}
		}

		/// <remarks/>
		public string SourceID
		{
			get
			{
				return sourceIDField;
			}
			set
			{
				sourceIDField = value;
			}
		}

		/// <remarks/>
		public SAFTPTSourcePayment SourcePayment
		{
			get
			{
				return sourcePaymentField;
			}
			set
			{
				sourcePaymentField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public enum PaymentStatus
	{
		/// <remarks/>
		N,

		/// <remarks/>
		A,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public enum SAFTPTSourcePayment
	{
		/// <remarks/>
		P,

		/// <remarks/>
		I,

		/// <remarks/>
		M,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SourceDocumentsPaymentsPaymentLine
	{
		private string lineNumberField;

		private SourceDocumentsPaymentsPaymentLineSourceDocumentID[] sourceDocumentIDField;

		private decimal settlementAmountField;

		private bool settlementAmountFieldSpecified;

		private decimal itemField;

		private ItemChoiceType8 itemElementNameField;

		private PaymentTax taxField;

		private string taxExemptionReasonField;

		private string taxExemptionCodeField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "nonNegativeInteger")]
		public string LineNumber
		{
			get
			{
				return lineNumberField;
			}
			set
			{
				lineNumberField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("SourceDocumentID")]
		public SourceDocumentsPaymentsPaymentLineSourceDocumentID[] SourceDocumentID
		{
			get
			{
				return sourceDocumentIDField;
			}
			set
			{
				sourceDocumentIDField = value;
			}
		}

		/// <remarks/>
		public decimal SettlementAmount
		{
			get
			{
				return settlementAmountField;
			}
			set
			{
				settlementAmountField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public bool SettlementAmountSpecified
		{
			get
			{
				return settlementAmountFieldSpecified;
			}
			set
			{
				settlementAmountFieldSpecified = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("CreditAmount", typeof(decimal))]
		[System.Xml.Serialization.XmlElementAttribute("DebitAmount", typeof(decimal))]
		[System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemElementName")]
		public decimal Item
		{
			get
			{
				return itemField;
			}
			set
			{
				itemField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlIgnoreAttribute()]
		public ItemChoiceType8 ItemElementName
		{
			get
			{
				return itemElementNameField;
			}
			set
			{
				itemElementNameField = value;
			}
		}

		/// <remarks/>
		public PaymentTax Tax
		{
			get
			{
				return taxField;
			}
			set
			{
				taxField = value;
			}
		}

		/// <remarks/>
		public string TaxExemptionReason
		{
			get
			{
				return taxExemptionReasonField;
			}
			set
			{
				taxExemptionReasonField = value;
			}
		}

		/// <remarks/>
		public string TaxExemptionCode
		{
			get
			{
				return taxExemptionCodeField;
			}
			set
			{
				taxExemptionCodeField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SourceDocumentsPaymentsPaymentLineSourceDocumentID
	{
		private string originatingONField;

		private System.DateTime invoiceDateField;

		private string descriptionField;

		/// <remarks/>
		public string OriginatingON
		{
			get
			{
				return originatingONField;
			}
			set
			{
				originatingONField = value;
			}
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
		public System.DateTime InvoiceDate
		{
			get
			{
				return invoiceDateField;
			}
			set
			{
				invoiceDateField = value;
			}
		}

		/// <remarks/>
		public string Description
		{
			get
			{
				return descriptionField;
			}
			set
			{
				descriptionField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IncludeInSchema = false)]
	public enum ItemChoiceType8
	{
		/// <remarks/>
		CreditAmount,

		/// <remarks/>
		DebitAmount,
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SourceDocumentsPaymentsPaymentDocumentTotals
	{
		private decimal taxPayableField;

		private decimal netTotalField;

		private decimal grossTotalField;

		private SourceDocumentsPaymentsPaymentDocumentTotalsSettlement settlementField;

		private Currency currencyField;

		/// <remarks/>
		public decimal TaxPayable
		{
			get
			{
				return taxPayableField;
			}
			set
			{
				taxPayableField = value;
			}
		}

		/// <remarks/>
		public decimal NetTotal
		{
			get
			{
				return netTotalField;
			}
			set
			{
				netTotalField = value;
			}
		}

		/// <remarks/>
		public decimal GrossTotal
		{
			get
			{
				return grossTotalField;
			}
			set
			{
				grossTotalField = value;
			}
		}

		/// <remarks/>
		public SourceDocumentsPaymentsPaymentDocumentTotalsSettlement Settlement
		{
			get
			{
				return settlementField;
			}
			set
			{
				settlementField = value;
			}
		}

		/// <remarks/>
		public Currency Currency
		{
			get
			{
				return currencyField;
			}
			set
			{
				currencyField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	public partial class SourceDocumentsPaymentsPaymentDocumentTotalsSettlement
	{
		private decimal settlementAmountField;

		/// <remarks/>
		public decimal SettlementAmount
		{
			get
			{
				return settlementAmountField;
			}
			set
			{
				settlementAmountField = value;
			}
		}
	}

	/// <remarks/>
	[System.Serializable()]
	[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01")]
	[System.Xml.Serialization.XmlRoot(Namespace = "urn:OECD:StandardAuditFile-Tax:PT_1.04_01", IsNullable = false)]
	public partial class TaxTable
	{
		private TaxTableEntry[] taxTableEntryField;

		/// <remarks/>
		[System.Xml.Serialization.XmlElementAttribute("TaxTableEntry")]
		public TaxTableEntry[] TaxTableEntry
		{
			get
			{
				return taxTableEntryField;
			}
			set
			{
				taxTableEntryField = value;
			}
		}
	}
}