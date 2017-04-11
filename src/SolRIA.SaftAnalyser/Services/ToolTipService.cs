using System;

namespace SolRIA.SaftAnalyser.Services
{
	public class HeaderToolTipService
	{
		public HeaderToolTipService()
		{
			AuditFileVersion = string.Format("1.1 * Texto 10{0}Ficheiro de auditoria informática.{0}A versão a utilizar do esquema XML será a que se encontra disponível no endereço http://www.portaldasfinancas.gov.pt.", Environment.NewLine);
			CompanyID = string.Format("1.2 * Texto 50{0}Identificação do registo comercial da empresa.{0}Obtém-se pela concatenação da conservatória do registo comercial com o número do registo comercial, separados pelo carácter espaço.{0}Nos casos em que não existe o registo comercial, deve ser indicado o NIF.", Environment.NewLine);
			TaxRegistrationNumber = string.Format("1.3 * Inteiro 9{0}Número de identificação fiscal da empresa.{0}Preencher com o NIF português sem espaços e sem qualquer prefixo do país.", Environment.NewLine);
			TaxAccountingBasis = string.Format("1.4 * Texto 1{0}Sistema contabilístico.{0}Deve ser preenchido com:{0}C - Contabilidade;{0}F - Faturação incluindo os documentos de transporte e os de conferência;{0}I - Dados integrados de contabilidade e faturação, incluindo os documentos de transporte e os de conferência;{0}S - Autofaturação;{0}E - Faturação emitida por terceiros, incluindo documentos de transporte e os de conferência;{0}P - Dados parciais de faturação, incluindo os documentos de transporte e os de conferência.", Environment.NewLine);
			CompanyName = string.Format("1.5 * Texto 100{0}Nome da empresa.{0}Denominação social da empresa ou nome do sujeito passivo.", Environment.NewLine);
			BusinessName = string.Format("1.6 Texto 60{0}Designação Comercial.{0}Designação comercial do sujeito passivo.", Environment.NewLine);
			CompanyAddress = string.Format("1.7 *{0}Endereço da empresa.", Environment.NewLine);
			BuildingNumber = string.Format("1.7.1 Texto 10{0}Número de polícia.", Environment.NewLine);
			StreetName = string.Format("1.7.2 Texto 90{0}Nome da rua.", Environment.NewLine);
			AddressDetail = string.Format("1.7.3 * Texto 100{0}Morada detalhada.{0}Deve incluir o nome da rua, número de polícia e andar, se aplicável.", Environment.NewLine);
			City = string.Format("1.7.4 * Texto 50{0}Localidade.", Environment.NewLine);
			PostalCode = string.Format("1.7.5 * Texto 8{0}Código postal.", Environment.NewLine);
			Region = string.Format("1.7.6 Texto 50{0}Distrito.", Environment.NewLine);
			Country = string.Format("1.7.7 * Texto 2{0}País.{0}Preencher com «PT».", Environment.NewLine);
			FiscalYear = string.Format("1.8 * Inteiro 4{0}Ano fiscal.{0}Utilizar as regras do Código do IRC, no caso de períodos contabilísticos não coincidentes com o ano civil.{0}(Exemplo: período de tributação de 1-10-2012 a 30-9-2013 corresponde a FiscalYear = 2012).", Environment.NewLine);
			StartDate = string.Format("1.9 * Data{0}Data do início do período do ficheiro.", Environment.NewLine);
			EndDate = string.Format("1.10 * Data{0}Data do fim do período do ficheiro.", Environment.NewLine);
			CurrencyCode = string.Format("1.11 * Texto 3{0}Código de moeda.{0}Preencher com «EUR».", Environment.NewLine);
			DateCreated = string.Format("1.12 * Data{0}Data da criação.{0}Data de criação do ficheiro XML do SAF-T (PT).", Environment.NewLine);
			TaxEntity = string.Format("1.13 * Texto 20{0}Identificação do estabelecimento.{0}No caso do ficheiro de faturação, deverá ser especificado a que estabelecimento diz respeito o ficheiro produzido, se aplicável.{0}Caso contrário, deverá ser preenchido com a especificação «Global».{0}No caso do ficheiro de contabilidade ou integrado, este campo deverá ser preenchido com a especificação «Sede».", Environment.NewLine);
			ProductCompanyTaxID = string.Format("1.14 * Texto 20{0}Identificação fiscal da entidade produtora do software.{0}Preencher com o NIF da entidade produtora do software.", Environment.NewLine);
			SoftwareCertificateNumber = string.Format("1.15 * Texto 20{0}Número do certificado atribuído ao software.{0}Número do certificado atribuído à entidade produtora do software, de acordo com a Portaria n.º 363/2010, de 23 de junho.{0}Se não aplicável, deverá ser preenchido com «0» (zero).", Environment.NewLine);
			ProductID = string.Format("1.16 * Texto 255{0}Nome da aplicação que gera o SAF-T (PT).{0}Deve ser indicado o nome comercial do software e o da empresa produtora no formato «Nome da aplicação/Nome da empresa produtora do software».", Environment.NewLine);
			ProductVersion = string.Format("1.17 * Texto 30{0}Versão da aplicação.{0}Deve ser indicada a versão da aplicação.", Environment.NewLine);
			HeaderComment = string.Format("1.18 Texto 255{0}Comentários adicionais.", Environment.NewLine);
			Telephone = string.Format("1.19 Texto 20{0}Telefone.", Environment.NewLine);
			Fax = string.Format("1.20 Texto 20{0}Fax.", Environment.NewLine);
			Email = string.Format("1.21 Texto 60{0}Endereço de correio eletrónico da empresa.", Environment.NewLine);
			Website = string.Format("1.22 Texto 60{0}Endereço do sítio Web da empresa.", Environment.NewLine);
		}

		public string AuditFileVersion { get; set; }
		public string CompanyID { get; set; }
		public string TaxRegistrationNumber { get; set; }
		public string TaxAccountingBasis { get; set; }
		public string CompanyName { get; set; }
		public string BusinessName { get; set; }
		public string CompanyAddress { get; set; }
		public string BuildingNumber { get; set; }
		public string StreetName { get; set; }
		public string AddressDetail { get; set; }
		public string City { get; set; }
		public string PostalCode { get; set; }
		public string Region { get; set; }
		public string Country { get; set; }
		public string FiscalYear { get; set; }
		public string StartDate { get; set; }
		public string EndDate { get; set; }
		public string CurrencyCode { get; set; }
		public string DateCreated { get; set; }
		public string TaxEntity { get; set; }
		public string ProductCompanyTaxID { get; set; }
		public string SoftwareCertificateNumber { get; set; }
		public string ProductID { get; set; }
		public string ProductVersion { get; set; }
		public string HeaderComment { get; set; }
		public string Telephone { get; set; }
		public string Fax { get; set; }
		public string Email { get; set; }
		public string Website { get; set; }

	}

	public class GeneralLedgerToolTipService
	{
		public GeneralLedgerToolTipService()
		{
			AccountID = string.Format("2.1.1 * Texto 30{0}Código da conta.{0}Devem constar do ficheiro todas as contas, incluindo as respetivas contas integradoras, até às contas do razão.", Environment.NewLine);
			AccountDescription = string.Format("2.1.2 * Texto 60{0}Descrição da conta.", Environment.NewLine);
			OpeningDebitBalance = string.Format("2.1.3 * Monetário{0}Saldo de abertura a débito da conta do plano de contas.{0}O saldo de abertura a débito será sempre o do início do período de tributação.", Environment.NewLine);
			OpeningCreditBalance = string.Format("2.1.4 * Monetário{0}Saldo de abertura a crédito da conta do plano de contas.{0}O saldo de abertura a crédito será sempre o do início do período de tributação.", Environment.NewLine);
			ClosingDebitBalance = string.Format("2.1.5 * Monetário{0}Saldo de encerramento a débito da conta do plano de contas.{0}O saldo de encerramento a débito será o do fim do período de tributação.", Environment.NewLine);
			ClosingCreditBalance = string.Format("2.1.6 * Monetário{0}Saldo de encerramento a crédito da conta do plano de contas.{0}O saldo de encerramento a crédito será o do fim do período de tributação.", Environment.NewLine);
			GroupingCategory = string.Format("2.1.7 * Texto 2{0}Categoria e tipo de conta.{0}Deve ser indicado o tipo e a categoria da conta:{0}GR - Conta de 1.º grau da contabilidade geral;{0}GA - Conta agregadora ou integradora da contabilidade geral;{0}GM - Conta de movimento da contabilidade geral;{0}AR - Conta de 1.º grau da contabilidade analítica;{0}AA - Conta agregadora ou integradora da contabilidade analítica;{0}AM - Conta de movimento da contabilidade analítica.", Environment.NewLine);
			GroupingCode = string.Format("2.1.8 ** Texto 30{0}Hierarquia da conta.{0}Exceto para as contas do 1.º grau deve ser indicada a conta agregadora respetiva, do grau imediatamente superior, utilizando para este efeito a exata estrutura que consta no correspondente campo 2.1.1.", Environment.NewLine);
		}

		public string AccountID { get; set; }
		public string AccountDescription { get; set; }
		public string OpeningDebitBalance { get; set; }
		public string OpeningCreditBalance { get; set; }
		public string ClosingDebitBalance { get; set; }
		public string ClosingCreditBalance { get; set; }
		public string GroupingCategory { get; set; }
		public string GroupingCode { get; set; }
	}

	public class CustomerToolTipService
	{
		public CustomerToolTipService()
		{
			CustomerID = string.Format("2.2.1 * Texto 30{0}Identificador único do cliente.{0}Na lista de clientes não pode existir mais do que um registo com o mesmo CustomerID.{0}Para o caso de consumidores finais, deve ser criado um cliente genérico com a designação «Consumidor final».", Environment.NewLine);
			AccountID = string.Format("2.2.2 * Texto 30{0}Código da conta.{0}Deve ser indicada a respetiva conta-corrente do cliente no plano de contas da contabilidade, caso esteja definida.{0}Caso contrário deverá ser preenchido com a designação «Desconhecido».", Environment.NewLine);
			CustomerTaxID = string.Format(" 2.2.3 * Texto 20{0}Número de identificação fiscal do cliente.{0}Deve ser indicado sem o prefixo do país.{0}O cliente genérico, correspondente ao designado «Consumidor final», deverá ser identificado com o NIF «999999990».", Environment.NewLine);
			CompanyName = string.Format("2.2.4 * Texto 100{0}Nome da empresa.{0}O cliente genérico deverá ser identificado com a designação «Consumidor final».{0}No caso do setor bancário, para as atividades não sujeitas a IVA, deverá ser preenchido com a designação «Desconhecido».", Environment.NewLine);
			Contact = string.Format("2.2.5 Texto 50{0}Nome do contacto na empresa.", Environment.NewLine);
			BillingAddress = string.Format("2.2.6 * N/A{0}Morada de faturação.{0}Corresponde à morada da sede ou do estabelecimento estável em território nacional.", Environment.NewLine);
			BillingAddressBuildingNumber = string.Format("2.2.6.1 * Texto 10{0}Número de polícia.", Environment.NewLine);
			BillingAddressStreetName = string.Format("2.2.6.2 Texto 90{0}Nome da rua.", Environment.NewLine);
			BillingAddressAddressDetail = string.Format("2.2.6.3 * Texto 100{0}Morada detalhada.{0}Deve incluir o nome da rua, número de polícia e andar, se aplicável.{0}Deverá ser preenchido com a designação «Desconhecido», nas seguintes situações:{0}• Sistemas não integrados, se a informação não for conhecida;{0}• Operações realizadas com «Consumidor final»;{0}• No caso do setor bancário, para as atividades não sujeitas a IVA.", Environment.NewLine);
			BillingAddressCity = string.Format("2.2.6.4 * Texto 50{0}Deverá ser preenchido com a designação «Desconhecido», nas seguintes situações:{0}• Sistemas não integrados, se a informação não for conhecida;", Environment.NewLine);
			BillingAddressPostalCode = string.Format("2.2.6.5 * Texto 20{0}Código postal.{0}Deverá ser preenchido com a designação «Desconhecido» nas seguintes situações:{0}• Sistemas não integrados, se a informação não for conhecida;{0}• Operações realizadas com «Consumidor final»; e{0}• No caso do setor bancário, para as atividades não sujeitas a IVA.", Environment.NewLine);
			BillingAddressRegion = string.Format("2.2.6.6 Texto 50{0}Distrito.", Environment.NewLine);
			BillingAddressCountry = string.Format("2.2.6.7 * Texto 12{0}País.{0}Sendo conhecido, deve ser preenchido de acordo com a norma ISO 3166-1-alpha-2.{0}Deverá ser preenchido com a designação «Desconhecido», nas seguintes situações:{0}• Sistemas não integrados, se a informação não for conhecida;{0}• Operações realizadas com «Consumidor final;{0}• No caso do setor bancário, para as atividades não sujeitas a IVA.", Environment.NewLine);
			ShipToAddress = string.Format("2.2.7 Morada de expedição.", Environment.NewLine);
			ShipToAddressBuildingNumber = string.Format("2.2.7.1 Texto 10{0}Número de polícia.", Environment.NewLine);
			ShipToAddressStreetName = string.Format("2.2.7.2 Texto 90{0}Nome da rua.", Environment.NewLine);
			ShipToAddressAddressDetail = string.Format("2.2.7.3 * Texto 100{0}Morada detalhada.{0}Deve incluir o nome da rua, número de polícia e andar, se aplicável.{0}Deverá ser preenchido com a designação «Desconhecido», nas seguintes situações:{0}• Sistemas não integrados, se a informação não for conhecida;{0}• Operações realizadas com «Consumidor final»; e{0}• No caso do setor bancário, para as atividades não sujeitas a IVA.", Environment.NewLine);
			ShipToAddressCity = string.Format("2.2.7.4 * Texto 50{0}Localidade.{0}Deverá ser preenchido com a designação «Desconhecido», nas seguintes situações:{0}• Sistemas não integrados, se a informação não for conhecida;{0}• Operações realizadas com «Consumidor final»; e{0}• No caso do setor bancário, para as atividades não sujeitas a IVA.", Environment.NewLine);
			ShipToAddressPostalCode = string.Format("2.2.7.5 * Texto 20{0}Código postal.{0}Deverá ser preenchido com a designação «Desconhecido», nas seguintes situações:{0}• Sistemas não integrados, se a informação não for conhecida;{0}• Operações realizadas com «Consumidor final»; e{0}• No caso do setor bancário, para as atividades não sujeitas a IVA.", Environment.NewLine);
			ShipToAddressRegion = string.Format("2.2.7.6 Texto 50{0}Distrito.", Environment.NewLine);
			ShipToAddressCountry = string.Format("2.2.7.7 * Texto 12{0}País.{0}Deve ser preenchido de acordo com a norma ISO 3166-1-alpha-2.{0}Deverá ser preenchido com a designação «Desconhecido», nas seguintes situações:{0}• Sistemas não integrados, se a informação não for conhecida;{0}• Operações realizadas com «Consumidor final»; e{0}• No caso do setor bancário, para as atividades não sujeitas a IVA.", Environment.NewLine);
			Telephone = string.Format("2.2.8 Texto 20{0}Telefone.", Environment.NewLine);
			Fax = string.Format("2.2.9 Texto 20{0}Fax.", Environment.NewLine);
			Email = string.Format("2.2.10 Texto 60{0}Endereço de correio eletrónico da empresa.", Environment.NewLine);
			Website = string.Format("2.2.11 Texto 60{0}Endereço do sítio web da empresa.", Environment.NewLine);
			SelfBillingIndicator = string.Format("2.2.12 * Inteiro 1{0}Indicador de autofaturação.{0}Indicador da existência de acordo de autofaturação entre o cliente e o fornecedor.{0}Deve ser preenchido com «1» se houver acordo e com «0» (zero) no caso contrário.", Environment.NewLine);
		}

		public string CustomerID { get; set; }
		public string AccountID { get; set; }
		public string CustomerTaxID { get; set; }
		public string CompanyName { get; set; }
		public string Contact { get; set; }
		public string BillingAddress { get; set; }
		public string BillingAddressBuildingNumber { get; set; }
		public string BillingAddressStreetName { get; set; }
		public string BillingAddressAddressDetail { get; set; }
		public string BillingAddressCity { get; set; }
		public string BillingAddressPostalCode { get; set; }
		public string BillingAddressRegion { get; set; }
		public string BillingAddressCountry { get; set; }
		public string ShipToAddress { get; set; }
		public string ShipToAddressBuildingNumber { get; set; }
		public string ShipToAddressStreetName { get; set; }
		public string ShipToAddressAddressDetail { get; set; }
		public string ShipToAddressCity { get; set; }
		public string ShipToAddressPostalCode { get; set; }
		public string ShipToAddressRegion { get; set; }
		public string ShipToAddressCountry { get; set; }
		public string Telephone { get; set; }
		public string Fax { get; set; }
		public string Email { get; set; }
		public string Website { get; set; }
		public string SelfBillingIndicator { get; set; }
	}

	public class SupplierToolTipService
	{
		public SupplierToolTipService()
		{
			SupplierID = string.Format("2.3.1 * Texto 30{0}Identificador único do fornecedor.{0}Na lista de fornecedores não pode existir mais do que um registo com o mesmo SupplierID.", Environment.NewLine);
			AccountID = string.Format("2.3.2 * Texto 30{0}Código da conta.{0}Deve ser indicada a respetiva conta -corrente do fornecedor no plano de contas da contabilidade, caso esteja definida.{0}Caso contrário deverá ser preenchido com a designação «Desconhecido».", Environment.NewLine);
			SupplierTaxID = string.Format("2.3.3 * Texto 20{0}Número de identificação fiscal do fornecedor.{0}Deve ser indicado sem o prefixo do país.", Environment.NewLine);
			CompanyName = string.Format("2.3.4 * Texto 100{0}Nome da empresa.", Environment.NewLine);
			Contact = string.Format("2.3.5 Texto 50{0}Nome do contacto na empresa (Contact).", Environment.NewLine);
			BillingAddress = string.Format("2.3.6 * Morada de faturação.{0}Corresponde à morada da sede ou do estabelecimento estável em território nacional.", Environment.NewLine);
			BillingAddressBuildingNumber = string.Format("2.3.6.1 Texto 10{0}Número de polícia.", Environment.NewLine);
			BillingAddressStreetName = string.Format("2.3.6.2 Texto 90{0}Nome da rua.", Environment.NewLine);
			BillingAddressAddressDetail = string.Format("2.3.6.3 * Texto 100{0}Morada detalhada.{0}Deve incluir o nome da rua, número de polícia e andar, se aplicável.{0}", Environment.NewLine);
			BillingAddressCity = string.Format("2.3.6.4 * Texto 50{0}Localidade.", Environment.NewLine);
			BillingAddressPostalCode = string.Format("2.3.6.5 * Texto 20{0}Código postal.", Environment.NewLine);
			BillingAddressRegion = string.Format("2.3.6.6 Texto 50{0}Distrito.", Environment.NewLine);
			BillingAddressCountry = string.Format("2.3.6.7 * Texto 2{0}País.{0}Deve ser preenchido de acordo com a norma ISO 3166-1-alpha-2.", Environment.NewLine);
			ShipFromAddress = string.Format("2.3.7 Morada da expedição.", Environment.NewLine);
			ShipFromAddressBuildingNumber = string.Format("2.3.7.1 Texto 10{0}Número de polícia.", Environment.NewLine);
			ShipFromAddressStreetName = string.Format("2.3.7.2 Texto 90{0}Nome da rua.", Environment.NewLine);
			ShipFromAddressAddressDetail = string.Format("2.3.7.3 * Texto 100{0}Morada detalhada.{0}Deve incluir o nome da rua, número de polícia e andar, se aplicável.", Environment.NewLine);
			ShipFromAddressCity = string.Format("2.3.7.4 * Texto 50{0}Localidade.", Environment.NewLine);
			ShipFromAddressPostalCode = string.Format("2.3.7.5 * Texto 20{0}Código postal.", Environment.NewLine);
			ShipFromAddressRegion = string.Format("2.3.7.6 Texto 50{0}Distrito.", Environment.NewLine);
			ShipFromAddressCountry = string.Format("2.3.7.7 * Texto 2{0}País.{0}Deve ser preenchido de acordo com a norma ISO 3166-1-alpha-2.", Environment.NewLine);
			Telephone = string.Format("2.3.8 Texto 20{0}Telefone.", Environment.NewLine);
			Fax = string.Format("2.3.9 Texto 20{0}Fax.", Environment.NewLine);
			Email = string.Format("2.3.10 Texto 60{0}Endereço de correio eletrónico da empresa.", Environment.NewLine);
			Website = string.Format("2.3.11 Texto 60{0}Endereço do sítio web da empresa.", Environment.NewLine);
			SelfBillingIndicator = string.Format("2.3.12 * Inteiro 1{0}Indicador de autofaturação.{0}Indicador da existência de acordo de autofaturação entre o cliente e o fornecedor.{0}Deve ser preenchido com «1» se houver acordo e com «0» (zero) no caso contrário.", Environment.NewLine);
		}
		public string SupplierID { get; set; }
		public string AccountID { get; set; }
		public string SupplierTaxID { get; set; }
		public string CompanyName { get; set; }
		public string Contact { get; set; }
		public string BillingAddress { get; set; }
		public string BillingAddressBuildingNumber { get; set; }
		public string BillingAddressStreetName { get; set; }
		public string BillingAddressAddressDetail { get; set; }
		public string BillingAddressCity { get; set; }
		public string BillingAddressPostalCode { get; set; }
		public string BillingAddressRegion { get; set; }
		public string BillingAddressCountry { get; set; }
		public string ShipFromAddress { get; set; }
		public string ShipFromAddressBuildingNumber { get; set; }
		public string ShipFromAddressStreetName { get; set; }
		public string ShipFromAddressAddressDetail { get; set; }
		public string ShipFromAddressCity { get; set; }
		public string ShipFromAddressPostalCode { get; set; }
		public string ShipFromAddressRegion { get; set; }
		public string ShipFromAddressCountry { get; set; }
		public string Telephone { get; set; }
		public string Fax { get; set; }
		public string Email { get; set; }
		public string Website { get; set; }
		public string SelfBillingIndicator { get; set; }
	}

	public class ProductToolTipService
	{
		public ProductToolTipService()
		{
			ProductType = string.Format("2.4.1 * Texto 1{0}Indicador de produto ou serviço.{0}Deve ser preenchido com:{0}«P» - Produtos;{0}«S» - Serviços;{0}«O» - Outros (Exemplo: portes debitados);{0}«I» - Impostos, taxas e encargos parafiscais exceto IVA e IS que deverão ser refletidos na tabela de impostos (TaxTable).", Environment.NewLine);
			ProductCode = string.Format("2.4.2 * Texto 30{0}Identificador do produto ou serviço.{0}Código único do produto na lista de produtos.", Environment.NewLine);
			ProductGroup = string.Format("2.4.3 Texto 50{0}Família do produto ou serviço.", Environment.NewLine);
			ProductDescription = string.Format("2.4.4 * Texto 200{0}Descrição do produto ou serviço.", Environment.NewLine);
			ProductNumberCode = string.Format("2.4.5 * Texto 50{0}Código do produto.{0}Deve ser utilizado o código EAN (código de barras) do produto.{0}Quando este não existir, preencher com o identificador do produto ou serviço (ProductCode).", Environment.NewLine);
		}
		public string ProductType { get; set; }
		public string ProductCode { get; set; }
		public string ProductGroup { get; set; }
		public string ProductDescription { get; set; }
		public string ProductNumberCode { get; set; }
	}

	public class TaxToolTipService
	{
		public TaxToolTipService()
		{
			TaxTableEntry = string.Format("2.5.1 * Registo na tabela de impostos.", Environment.NewLine);
			TaxType = string.Format("2.5.1.1 * Texto 3{0}Código do tipo de imposto.{0}Neste campo deve ser indicado o tipo de imposto.{0}Deve ser preenchido com:{0}«IVA» - Imposto sobre o valor acrescentado;{0}«IS» - Imposto do selo.", Environment.NewLine);
			TaxCountryRegion = string.Format("2.5.1.2 * Texto 5{0}País ou região do imposto.{0}Deve ser preenchido de acordo com a norma ISO 3166-1-alpha 2.{0}No caso das Regiões Autónomas da Madeira e Açores deve ser preenchido com: «PT-AC» - Espaço fiscal da Região Autónoma dos Açores; e «PT-MA» - Espaço fiscal da Região Autónoma da Madeira.", Environment.NewLine);
			TaxCode = string.Format("2.5.1.3 * Texto 10{0}Código do imposto.{0}No caso do código do tipo de imposto (TaxType) = IVA, deve ser preenchido com:{0}«RED» - Taxa reduzida;{0}«INT» - Taxa intermédia;{0}«NOR» - Taxa normal;{0}«ISE» - Isenta;{0}«OUT» - Outros, aplicável para os regimes especiais de IVA.{0}No caso do código do tipo de imposto (TaxType) = IS, deve ser preenchido com o código da verba respetiva.", Environment.NewLine);
			Description = string.Format("2.5.1.4 * Texto 255{0}Descrição do imposto.{0}No caso do imposto do selo deve ser preenchido com a descrição da verba respetiva.", Environment.NewLine);
			TaxExpirationDate = string.Format("2.5.1.5 Data{0}Data de fim de vigência.{0}Última data legal de aplicação da taxa de imposto, no caso de alteração da mesma, na vigência do período de tributação.", Environment.NewLine);
			TaxPercentage = string.Format("2.5.1.6 ** Decimal{0}Percentagem da taxa do imposto.{0}O preenchimento é obrigatório, no caso de se tratar de uma percentagem do imposto.", Environment.NewLine);
			TaxAmount = string.Format("2.5.1.7 ** Monetário{0}Montante do imposto.{0}O preenchimento é obrigatório, no caso de se tratar de uma verba fixa de imposto do selo.", Environment.NewLine);
		}

		public string TaxTableEntry { get; set; }
		public string TaxType { get; set; }
		public string TaxCountryRegion { get; set; }
		public string TaxCode { get; set; }
		public string Description { get; set; }
		public string TaxExpirationDate { get; set; }
		public string TaxPercentage { get; set; }
		public string TaxAmount { get; set; }
	}

	public class GeneralLedgerEntriesToolTipService
	{
		public GeneralLedgerEntriesToolTipService()
		{
			NumberOfEntries = string.Format("3.1 * Inteiro{0}Número de registo de movimentos contabilísticos.", Environment.NewLine);
			TotalDebit = string.Format("3.2 * Monetário{0}Total dos débitos.{0}Soma a débito de todos os movimentos do período selecionado, registados no campo 3.4.3.11.6 - Valor a débito (DebitAmount).", Environment.NewLine);
			TotalCredit = string.Format("3.3 * Monetário{0}Total dos créditos.{0}Soma a crédito de todos os movimentos do período selecionado, registados no campo 3.4.3.11.7 - Valor a crédito (CreditAmount).", Environment.NewLine);
			Journal = string.Format("3.4 Diários.", Environment.NewLine);
			JournalID = string.Format("3.4.1 * Texto 30{0}Identificador do diário.", Environment.NewLine);
			JournalDescription = string.Format("3.4.2 * Texto 60{0}Descrição do diário.", Environment.NewLine);
			Transaction = string.Format("3.4.3 Identificador da transação.", Environment.NewLine);
			TransactionID = string.Format("3.4.3.1 * Texto Chave única do movimento contabilístico.{0}Deve ser construída de forma a ser única e a corresponder ao número de documento contabilístico, que é utilizado para detetar o documento físico no arquivo, pelo que, deve resultar de uma concatenação, separada por espaços, entre os seguintes valores: data do documento, identificador do diário e número de arquivo do documento (TransactionDate, JournalID e DocArchivalNumber).", Environment.NewLine);
			Period = string.Format("3.4.3.2 Inteiro{0}* Período contabilístico.{0}Deve ser indicado o número do mês do período de tributação, de «1» a «12», contado desde a data do seu início.{0}Pode ainda ser preenchido com «13», «14», «15» ou «16» para movimentos efetuados no último mês do período de tributação, relacionados com o apuramento do resultado.{0}Exemplo: movimentos de apuramentos de inventários, depreciações, ajustamentos ou apuramentos de resultados.", Environment.NewLine);
			TransactionDate = string.Format("3.4.3.3 * Data{0}Data do documento.{0}Deve ser indicada a data impressa no documento que serve de suporte ao registo.", Environment.NewLine);
			SourceID = string.Format("3.4.3.4 * Texto 30{0}Código do utilizador que registou o movimento.", Environment.NewLine);
			TransactionDescription = string.Format("3.4.3.5 * Texto 60{0}Descrição do movimento.", Environment.NewLine);
			DocArchivalNumber = string.Format("3.4.3.6 * Texto 20{0}Número de arquivo do documento.{0}Deve ser indicado o número do documento dentro do diário, que possibilite o acesso ao documento originário do registo.", Environment.NewLine);
			TransactionType = string.Format("3.4.3.7 * Texto 1{0}Tipificação do movimento contabilístico.{0}Deve ser preenchido com:{0}«N» - Normal;{0}«R» - Regularizações do período de tributação;{0}«A» - Apuramento de resultados;{0}«J» - Movimentos de ajustamento.", Environment.NewLine);
			GLPostingDate = string.Format("3.4.3.8 * Data e hora{0}Data do movimento contabilístico.{0}Registo do movimento ao segundo.{0}Tipo de data e hora: «AAAA-MM-DDThh:mm:ss».{0}Quando as gravações são feitas em procedimentos do tipo Batch, poderão ficar com a data de início ou de fim desse processamento.", Environment.NewLine);
			CustomerID = string.Format("3.4.3.9 ** Texto 30{0}Identificador do cliente.{0}O preenchimento é obrigatório, no caso de o cliente ser não residente ou a transação consubstanciar uma venda que deva figurar no anexo O da IES/declaração anual ou que deva figurar no anexo I da declaração periódica de IVA.{0}Deve ser indicada a chave do registo na tabela de clientes.", Environment.NewLine);
			SupplierID = string.Format("3.4.3.10 ** Texto 30{0}Identificador do fornecedor.{0}O preenchimento é obrigatório, no caso de o fornecedor ser não residente ou a transação consubstanciar uma compra que deva figurar no anexo P da IES/declaração anual.{0}Deve ser indicada a chave do registo na tabela de fornecedores.", Environment.NewLine);
			Line = string.Format("3.4.3.11 Linha.", Environment.NewLine);
			RecordID = string.Format("3.4.3.11.1 * Texto 30{0}Identificador do registo de linha.{0}Deve ser indicada a chave única do registo dessa linha no documento.", Environment.NewLine);
			AccountID = string.Format("3.4.3.11.2 * Texto 30{0}Código da conta.", Environment.NewLine);
			SourceDocumentID = string.Format("3.4.3.11.3 Texto 30{0}Chave única da tabela de movimentos contabilísticos.{0}Deve ser indicado o tipo e número do documento comercial relacionado com esta linha.", Environment.NewLine);
			SystemEntryDate = string.Format("3.4.3.11.4 * Data e hora{0}Data do registo do documento contabilístico.{0}Registo do movimento ao segundo.{0}Tipo de data e hora: «AAAA-MM-DDThh:mm:ss».", Environment.NewLine);
			LineDescription = string.Format("3.4.3.11.5 * Texto 60{0}Descrição da linha de documento.", Environment.NewLine);
			DebitAmount = string.Format("3.4.3.11.6 ** Monetário{0}Valor a débito.{0}O preenchimento é obrigatório, no caso de se tratar de um valor a débito.", Environment.NewLine);
			CreditAmount = string.Format("3.4.3.11.7 ** Monetário{0}Valor a crédito.{0}O preenchimento é obrigatório, no caso de se tratar de um valor a crédito.", Environment.NewLine);
		}

		public string NumberOfEntries { get; set; }
		public string TotalDebit { get; set; }
		public string TotalCredit { get; set; }
		public string Journal { get; set; }
		public string JournalID { get; set; }
		public string JournalDescription { get; set; }
		public string Transaction { get; set; }
		public string TransactionID { get; set; }
		public string Period { get; set; }
		public string TransactionDate { get; set; }
		public string SourceID { get; set; }
		public string TransactionDescription { get; set; }
		public string DocArchivalNumber { get; set; }
		public string TransactionType { get; set; }
		public string GLPostingDate { get; set; }
		public string CustomerID { get; set; }
		public string SupplierID { get; set; }
		public string Line { get; set; }
		public string RecordID { get; set; }
		public string AccountID { get; set; }
		public string SourceDocumentID { get; set; }
		public string SystemEntryDate { get; set; }
		public string LineDescription { get; set; }
		public string DebitAmount { get; set; }
		public string CreditAmount { get; set; }
	}

	public class SourceDocumentsToolTipService
	{
		public SourceDocumentsToolTipService()
		{
			SalesInvoices = string.Format("4.1 Documentos comerciais a clientes.{0}Devem ser exportados os documentos indicados no campo 4.1.4.7 - Tipo de documento (InvoiceType).", Environment.NewLine);
			NumberOfEntries = string.Format("4.1.1 * Inteiro{0}Número de registos de documentos comerciais.{0}Deve conter o número total de documentos, incluindo os documentos cujo estado atual (InvoiceStatus) seja do tipo «A» ou «F».", Environment.NewLine);
			TotalDebit = string.Format("4.1.2 * Monetário{0}Total dos débitos.{0}Deve conter a soma de controlo do campo 4.1.4.18.11 - Valor a débito (DebitAmount), dela excluindo os documentos em que o campo 4.1.4.2.1 - Estado atual do documento (InvoiceStatus) seja do tipo «A» ou «F».", Environment.NewLine);
			TotalCredit = string.Format("4.1.3 * Monetário{0}Total dos créditos.{0}Deve conter a soma de controlo do campo 4.1.4.18.12 - Valor a crédito (CreditAmount), dela excluindo os documentos em que o campo 4.1.4.2.1 - Estado atual do documento (InvoiceStatus) seja do tipo «A» ou «F».", Environment.NewLine);
			Invoice = string.Format("4.1.4 * Documento de venda", Environment.NewLine);
			InvoiceNo = string.Format("4.1.4.1 * Texto 60{0}Identificação única do documento de venda.{0}Esta identificação é composta sequencialmente pelos seguintes elementos:{0}o código interno do documento atribuído pela aplicação, um espaço, o identificador da série do documento, uma barra (/) e o número sequencial desse documento dentro dessa série.{0}Não podem existir registos com a mesma identificação.{0}Não podem ser utilizados o mesmo código interno de documento em tipos de documentos (InvoiceType) diferentes.", Environment.NewLine);
			DocumentStatus = string.Format("4.1.4.2 * Situação do documento.", Environment.NewLine);
			InvoiceStatus = string.Format("4.1.4.2.1 * Texto 1{0}Estado atual do documento.{0}Deve ser preenchido com:{0}«N» - Normal;{0}«S» - Autofaturação;{0}«A» - Documento anulado;{0}«R» - Documento de resumo doutros documentos criados noutras aplicações e gerado nesta aplicação;{0}«F» - Documento faturado:{0}• Quando o documento é do tipo talão de venda ou talão de devolução e existe na tabela o correspondente do tipo fatura ou nota de crédito para dados até 2012-12-31;{0}• Quando o documento é do tipo fatura simplificada e existe na tabela o correspondente do tipo fatura - para dados após 2013-01-01.", Environment.NewLine);
			InvoiceStatusDate = string.Format("4.1.4.2.2 * Data e hora{0}Data e hora do estado atual do documento.{0}Data da última gravação do estado do documento ao segundo.{0}Tipo data e hora: «AAAA-MM-DDThh:mm:ss».", Environment.NewLine);
			Reason = string.Format("4.1.4.2.3 Texto 50{0}Motivo da alteração de estado.{0}Deve ser indicada a razão que levou à alteração de estado do documento.", Environment.NewLine);
			ResponsableUserSourceID = string.Format("4.1.4.2.4 * Texto 30{0}Código do utilizador.{0}Utilizador responsável pelo estado atual do documento.", Environment.NewLine);
			SourceBilling = string.Format("4.1.4.2.5 * Texto 1{0}Deve ser preenchido com: «P» - Documento produzido na aplicação;{0}«I» - Documento integrado e produzido noutra aplicação;{0}«M» - Documento proveniente de recuperação ou de emissão manual.", Environment.NewLine);
			Hash = string.Format("4.1.4.3 * Texto 172{0}Chave do documento.{0}Assinatura nos termos da Portaria n.º 363/2010, de 23 de junho.{0}O campo deve ser preenchido com «0» (zero), caso não haja obrigatoriedade de certificação.", Environment.NewLine);
			HashControl = string.Format("4.1.4.4 Texto 40{0}Chave de controlo.{0}Versão da chave privada utilizada na criação da assinatura do campo 4.1.4.3.", Environment.NewLine);
			Period = string.Format("4.1.4.5 Inteiro{0}Período contabilístico.{0}Deve ser indicado o mês do período de tributação de «1» a «12», contando desde a data do seu início.", Environment.NewLine);
			InvoiceDate = string.Format("4.1.4.6 * Data{0}Data do documento de venda.{0}Data de emissão do documento de venda.", Environment.NewLine);
			InvoiceType = string.Format("4.1.4.7 * Texto 2{0}Tipo de documento.{0}Deve ser preenchido com:{0}«FT» - Fatura, emitida nos termos do artigo 36.º do Código do IVA;{0}«FS» - Fatura simplificada, emitida nos termos do artigo 40.º do Código do IVA;{0}«FR» - Fatura-recibo;{0}«ND» - Nota de débito;{0}«NC» - Nota de crédito;{0}«VD» - Venda a dinheiro e fatura/recibo (a);{0}«TV» - Talão de venda (a);{0}«TD» - Talão de devolução (a);{0}«AA» - Alienação de ativos;{0}«DA» - Devolução de ativos.{0}Para o setor Segurador, ainda pode ser preenchido com:{0}«RP» - Prémio ou recibo de prémio;{0}«RE» - Estorno ou recibo de estorno;{0}«CS» - Imputação a cosseguradoras; «LD» - Imputação a cosseguradora líder;{0}«RA» - Resseguro aceite.{0}(a) Para os dados até 2012-12-31.", Environment.NewLine);
			SelfBillingIndicator = string.Format("4.1.4.8.1 * Inteiro{0}Indicador de autofaturação.{0}Deverá ser preenchido com «1» se respeitar a autofaturação e com «0» (zero) no caso contrário.", Environment.NewLine);
			CashVATSchemeIndicator = string.Format("4.1.4.8.2 * Inteiro{0}Indicador de faturação emitida em nome e por conta de terceiros.{0}Deve ser preenchido com «1» se respeitar a faturação emitida em nome e por conta de terceiros e com «0» (zero) no caso contrário.", Environment.NewLine);
			ThirdPartiesBillingIndicator = string.Format("4.1.4.8.3 * Inteiro{0}Indicador de autofaturação.{0}Deverá ser preenchido com «1» se respeitar a autofaturação e com «0» (zero) no caso contrário.", Environment.NewLine);
			GeneratedDocumentUserSourceID = string.Format("4.1.4.9 * Texto 30{0}Código do utilizador.{0}Utilizador que gerou o documento.", Environment.NewLine);
			SystemEntryDate = string.Format("4.1.4.10 * Data e hora{0}Data de gravação do documento.{0}Data da gravação do registo ao segundo, no momento da assinatura.{0}Tipo data e hora: «AAAA-MM-DDThh:mm:ss».", Environment.NewLine);
			TransactionID = string.Format("4.1.4.11 ** Texto 70{0}Identificador da transação (TransactionID).{0}O preenchimento é obrigatório, no caso de se tratar de um sistema integrado em que o campo 1.4 - Sistema contabilístico (TaxAccountingBasis) = «I».{0}Chave única da tabela de movimentos contabilísticos (GeneralLedgerEntries) da transação onde foi lançado este documento, respeitando a regra aí definida para o campo chave única do movimento contabilístico (TransactionID).", Environment.NewLine);
			CustomerID = string.Format("4.1.4.12 * Texto 30{0}Identificador do cliente.{0}Chave única da tabela de clientes (Customer) respeitando a regra aí definida para o campo identificador único do cliente (CustomerID).", Environment.NewLine);
			ShipTo = string.Format("4.1.4.13 Envio para.{0}Informação do local e data de entrega onde os artigos vendidos são colocados à disposição do cliente.", Environment.NewLine);
			ShipToDeliveryID = string.Format("4.1.4.13.1 Texto 30{0}Identificador da entrega.", Environment.NewLine);
			ShipToDeliveryDate = string.Format("4.1.4.13.2 Data{0}Data da entrega.", Environment.NewLine);
			ShipToWarehouseID = string.Format("4.1.4.13.3 Texto 50{0}Identificador do armazém de destino.", Environment.NewLine);
			ShipToLocationID = string.Format("4.1.4.13.4 Texto 30{0}Localização dos bens no armazém de destino.", Environment.NewLine);
			ShipToAddress = string.Format("4.1.4.13.5 Morada.", Environment.NewLine);
			ShipToBuildingNumber = string.Format("4.1.4.13.5.1 Texto 10{0}Número de polícia.", Environment.NewLine);
			ShipToStreetName = string.Format("4.1.4.13.5.2 Texto 90{0}Nome da rua.", Environment.NewLine);
			ShipToAddressDetail = string.Format("4.1.4.13.5.3 * Texto 100{0}Morada detalhada.{0}Deve incluir o nome da rua, número de polícia e andar, se aplicável.", Environment.NewLine);
			ShipToCity = string.Format("4.1.4.13.5.4 * Texto 50{0}Localidade.", Environment.NewLine);
			ShipToPostalCode = string.Format("4.1.4.13.5.5 * Texto 20{0}Código postal.", Environment.NewLine);
			ShipToRegion = string.Format("4.1.4.13.5.6 Texto 50{0}Distrito.", Environment.NewLine);
			ShipToCountry = string.Format("4.1.4.13.5.7 * Texto 2{0}País.{0}Deve ser preenchido de acordo com a norma ISO 3166-1-alpha-2.", Environment.NewLine);
			ShipFrom = string.Format("4.1.4.14 Envio de.{0}Informação do local e data de carga onde se inicia a expedição dos artigos vendidos para o cliente.", Environment.NewLine);
			ShipFromDeliveryID = string.Format("4.1.4.14.1 Texto 30{0}Identificador da entrega", Environment.NewLine);
			ShipFromDeliveryDate = string.Format("4.1.4.14.2 Data{0}Data de receção.", Environment.NewLine);
			ShipFromWarehouseID = string.Format("4.1.4.14.3 Texto 50{0}Identificador do armazém de partida.", Environment.NewLine);
			ShipFromLocationID = string.Format("4.1.4.14.4 Texto 30{0}Localização dos bens no armazém de partida.", Environment.NewLine);
			ShipFromAddress = string.Format("4.1.4.14.5 Morada.", Environment.NewLine);
			ShipFromBuildingNumber = string.Format("4.1.4.14.5.1 Texto 10{0}Número de polícia.", Environment.NewLine);
			ShipFromStreetName = string.Format("4.1.4.14.5.2 Texto 90{0}Nome da rua.", Environment.NewLine);
			ShipFromAddressDetail = string.Format("4.1.4.14.5.3 * Texto 100{0}Morada detalhada.{0}Deve incluir o nome da rua, número de polícia e andar, se aplicável.", Environment.NewLine);
			ShipFromCity = string.Format("4.1.4.14.5.4 * Texto 50{0}Localidade.", Environment.NewLine);
			ShipFromPostalCode = string.Format("4.1.4.14.5.5 * Texto 20{0}Código postal.", Environment.NewLine);
			ShipFromRegion = string.Format("4.1.4.14.5.6 Texto 50{0}Distrito.", Environment.NewLine);
			ShipFromCountry = string.Format("4.1.4.14.5.7 * Texto 2{0}País.{0}Deve ser preenchido de acordo com a norma ISO 3166-1-alpha-2.", Environment.NewLine);
			MovementEndTime = string.Format("4.1.4.15 Data e hora{0}Data e hora de fim de transporte.{0}Tipo de data e hora: «AAAA-MM-DDThh:mm:ss» em que o «ss» pode ser «00», na ausência de informação concreta.", Environment.NewLine);
			MovementStartTime = string.Format("4.1.4.16 Data e hora{0}Data e hora para o início de transporte.{0}Tipo de data e hora: «AAAA-MM-DDThh:mm:ss» em que o «ss» pode ser «00», na ausência de informação concreta.", Environment.NewLine);
			ATDocCodeID = string.Format("4.1.4.17 Texto 200{0}Código de identificação do documento.{0}Código de identificação atribuído pela AT ao documento, nos termos do Decreto-Lei n.º 198/2012, de 24 de agosto.", Environment.NewLine);
			References = string.Format("4.1.4.18.9 Referências.{0}Referências a outros documentos.", Environment.NewLine);
			CreditNote = string.Format("4.1.4.18.9.1 Nota de crédito.{0}Referências da nota de crédito, caso seja aplicável.", Environment.NewLine);
			Reference = string.Format("4.1.4.18.9.1 Texto 60{0}Referência.{0}Referência à fatura ou fatura simplificada, através de identificação única da mesma, nos sistemas em que exista.{0}Deve ser utilizada a estrutura de numeração do campo de origem.", Environment.NewLine);
			LineReason = string.Format("4.1.4.18.9.1 Texto 50{0}Motivo.{0}Deve ser preenchido com o motivo do crédito.", Environment.NewLine);
			Description = string.Format("4.1.4.18.10 * Texto 60{0}Descrição.{0}Descrição da linha do documento.", Environment.NewLine);
			DebitAmount = string.Format("4.1.4.18.11 ** Monetário{0}Valor a débito.{0}Valor da linha dos documentos a lançar a débito na conta de vendas.{0}Este valor é sem imposto e deduzido dos descontos de linha e cabeçalho.", Environment.NewLine);
			CreditAmount = string.Format("4.1.4.18.12 ** Monetário{0}Valor a crédito.{0}Valor da linha dos documentos a lançar a crédito à conta de vendas.{0}Este valor é sem imposto e deduzido dos descontos de linha e cabeçalho.", Environment.NewLine);
			Tax = string.Format("4.1.4.18.13 Taxa de imposto.", Environment.NewLine);
			TaxType = string.Format("4.1.4.18.13 * Texto 3{0}Identificador do regime de imposto.{0}Neste campo deve ser indicado o tipo de imposto.{0}Deve preenchido com: «IVA» - Imposto sobre o valor acrescentado; «IS» - Imposto do selo.", Environment.NewLine);
			TaxCountryRegion = string.Format("4.1.4.18.13 * Texto 5{0}País ou região do imposto.{0}Deve ser preenchido de acordo com a norma ISO 3166-1-alpha-2.{0}No caso das Regiões Autónomas da Madeira e Açores deve ser preenchido com: «PT-AC» - Espaço fiscal da Região Autónoma dos Açores; «PT-MA» - Espaço fiscal da Região Autónoma da Madeira.", Environment.NewLine);
			TaxCode = string.Format("4.1.4.18.13 * Texto 10{0}Código da taxa.{0}Código da taxa na tabela de impostos.{0}Tem que ser preenchido quando os campos percentagem da taxa de imposto (TaxPercentage) ou montante do imposto (TaxAmount) são diferentes de zero.{0}No caso do código do tipo de imposto (TaxType) = IVA, deve ser preenchido com: «RED» - Taxa reduzida; «INT» - Taxa intermédia; «NOR» - Taxa normal; «ISE» - Isenta; «OUT» - Outros, aplicável para os regimes especiais de IVA.{0}No caso do código do tipo de imposto (TaxType) = «IS», deve ser preenchido com o código da verba respetiva.", Environment.NewLine);
			TaxPercentage = string.Format("4.1.4.18.13 ** Decimal{0}Percentagem da taxa de imposto.{0}O preenchimento é obrigatório, no caso de se tratar de uma percentagem de imposto.{0}A percentagem da taxa é correspondente ao imposto aplicável ao campo 4.1.4.18.11 - Valor a débito (DebitAmount) ou ao campo 4.1.418.12 - Valor a crédito (CreditAmount).", Environment.NewLine);
			TaxAmount = string.Format("4.1.4.18.13 ** Monetário{0}Montante do imposto.{0}O preenchimento é obrigatório, no caso de se tratar de uma verba fixa de imposto do selo.", Environment.NewLine);
			TaxExemptionReason = string.Format("4.1.4.18.14 ** Texto 60{0}Motivo da isenção de imposto.{0}O preenchimento é obrigatório, quando os campos percentagem da taxa de imposto (TaxPercentage) ou montante do imposto (TaxAmount) são iguais a zero.{0}Deve ser referido o preceito legal aplicável.{0}Este campo deve ser igualmente preenchido nos casos de não sujeição aos impostos referidos na tabela 2.5 - Tabela de impostos (TaxTable).", Environment.NewLine);
			LineSettlementAmount = string.Format("4.1.4.18.15 Monetário{0}Montante do desconto da linha.{0}Deve refletir todos os descontos concedidos (globais e de linha) que afetam o valor do campo 4.1.4.19.3 - GrossTotal.", Environment.NewLine);
			DocumentTotals = string.Format("4.1.4.19 * Totais do documento.", Environment.NewLine);
			TaxPayable = string.Format("4.1.4.19.1 * Monetário{0}Valor do imposto a pagar.", Environment.NewLine);
			NetTotal = string.Format("4.1.4.19.2 * Monetário{0}Total do documento sem impostos.{0}Este campo não deve incluir as parcelas referentes aos impostos constantes da tabela de impostos (TaxTable).", Environment.NewLine);
			GrossTotal = string.Format("4.1.4.19.3 * Monetário{0}Total do documento com impostos.{0}Este campo não deve refletir eventuais retenções na fonte constantes no campo 4.1.4.20 - Retenção na fonte (WithholdingTax).", Environment.NewLine);
			Currency = string.Format("4.1.4.19.4.1 * Texto 3{0}Código de moeda.{0}No caso de moeda estrangeira deve ser preenchido de acordo com a norma ISO 4217.", Environment.NewLine);
			CurrencyAmount = string.Format("4.1.4.19.4.2 * Monetário{0}Valor total em moeda estrangeira.{0}Valor do campo 4.1.4.19.3 - Total do documento com impostos (GrossTotal) na moeda original do documento.", Environment.NewLine);
			ExchangeRate = string.Format("4.1.4.19.4.3 Decimal{0}Taxa de câmbio.{0}Deve ser indicada a taxa de câmbio utilizada na conversão para EUR.", Environment.NewLine);
			Settlement = string.Format("4.1.4.19.5 Acordos.{0}Acordos ou formas de pagamento.", Environment.NewLine);
			SettlementDiscount = string.Format("4.1.4.19.5.1 Texto 30{0}Acordos de descontos futuros.{0}Deve ser preenchido com os acordos de descontos a aplicar no futuro sobre o valor presente.", Environment.NewLine);
			SettlementAmount = string.Format("4.1.4.19.5.2 Monetário{0}Montante do desconto.{0}Representa o valor do desconto futuro sem afetar o valor presente do documento indicado no campo 4.1.4.19.3 - Total do documento com impostos (GrossTotal).", Environment.NewLine);
			SettlementDate = string.Format("4.1.4.19.5.3 Data{0}Data acordada para o desconto.{0}A informação a constar é a data acordada para o pagamento com desconto.", Environment.NewLine);
			PaymentTerms = string.Format("4.1.4.19.5.4 Texto 100{0}Acordos de pagamento.{0}A informação a constar são os acordos estabelecidos, a data limite de pagamento ou os prazos relativos a regimes especiais de exigibilidade de IVA.", Environment.NewLine);
			PaymentMechanism = string.Format("4.1.4.19.5.5 Texto 2{0}Forma prevista de pagamento.{0}Deve ser preenchido com:{0}«CC» - Cartão crédito;{0}«CD» - Cartão débito{0}«CH» - Cheque;{0}«CS» - Compensação de saldos em conta corrente;{0}«LC» - Letra comercial;{0}«MB» - Multibanco;{0}«NU» - Numerário;{0}«PR» - Permuta;{0}«TB» - Transferência bancária;{0}«TR» - Ticket restaurante.", Environment.NewLine);
			WithholdingTax = string.Format("4.1.4.20 Retenção na fonte.", Environment.NewLine);
			WithholdingTaxType = string.Format("4.1.4.20.1 Texto 3{0}Código do tipo de imposto retido.{0}Neste campo deve ser indicado o tipo de imposto retido, preenchendo-o com:{0}«IRS» - Imposto sobre o rendimento de pessoas singulares;{0}«IRC» - Imposto sobre o rendimento de pessoas coletivas;{0}«IS» - Imposto do selo.", Environment.NewLine);
			WithholdingTaxDescription = string.Format("4.1.4.20.2 Texto 60{0}Motivo da retenção na fonte.{0}Deve ser indicado o normativo legal aplicável.{0}No caso do código do tipo de imposto (TaxType) = IS, deve ser preenchido com o código da verba respetiva.", Environment.NewLine);
			WithholdingTaxAmount = string.Format("4.1.4.20.3 * Monetário{0}Montante da retenção na fonte.{0}Deve ser indicado o montante retido de imposto.", Environment.NewLine);
		}

		public string SalesInvoices { get; set; }
		public string NumberOfEntries { get; set; }
		public string TotalDebit { get; set; }
		public string TotalCredit { get; set; }
		public string Invoice { get; set; }
		public string InvoiceNo { get; set; }
		public string DocumentStatus { get; set; }
		public string InvoiceStatus { get; set; }
		public string InvoiceStatusDate { get; set; }
		public string Reason { get; set; }
		public string ResponsableUserSourceID { get; set; }
		public string SourceBilling { get; set; }
		public string Hash { get; set; }
		public string HashControl { get; set; }
		public string Period { get; set; }
		public string InvoiceDate { get; set; }
		public string InvoiceType { get; set; }
		public string SelfBillingIndicator { get; set; }
		public string CashVATSchemeIndicator { get; set; }
		public string ThirdPartiesBillingIndicator { get; set; }
		public string GeneratedDocumentUserSourceID { get; set; }
		public string SystemEntryDate { get; set; }
		public string TransactionID { get; set; }
		public string CustomerID { get; set; }
		public string ShipTo { get; set; }
		public string ShipToDeliveryID { get; set; }
		public string ShipToDeliveryDate { get; set; }
		public string ShipToWarehouseID { get; set; }
		public string ShipToLocationID { get; set; }
		public string ShipToAddress { get; set; }
		public string ShipToBuildingNumber { get; set; }
		public string ShipToStreetName { get; set; }
		public string ShipToAddressDetail { get; set; }
		public string ShipToCity { get; set; }
		public string ShipToPostalCode { get; set; }
		public string ShipToRegion { get; set; }
		public string ShipToCountry { get; set; }
		public string ShipFrom { get; set; }
		public string ShipFromDeliveryID { get; set; }
		public string ShipFromDeliveryDate { get; set; }
		public string ShipFromWarehouseID { get; set; }
		public string ShipFromLocationID { get; set; }
		public string ShipFromAddress { get; set; }
		public string ShipFromBuildingNumber { get; set; }
		public string ShipFromStreetName { get; set; }
		public string ShipFromAddressDetail { get; set; }
		public string ShipFromCity { get; set; }
		public string ShipFromPostalCode { get; set; }
		public string ShipFromRegion { get; set; }
		public string ShipFromCountry { get; set; }
		public string MovementEndTime { get; set; }
		public string MovementStartTime { get; set; }
		public string ATDocCodeID { get; set; }
		public string References { get; set; }
		public string CreditNote { get; set; }
		public string Reference { get; set; }
		public string LineReason { get; set; }
		public string Description { get; set; }
		public string DebitAmount { get; set; }
		public string CreditAmount { get; set; }
		public string Tax { get; set; }
		public string TaxType { get; set; }
		public string TaxCountryRegion { get; set; }
		public string TaxCode { get; set; }
		public string TaxPercentage { get; set; }
		public string TaxAmount { get; set; }
		public string TaxExemptionReason { get; set; }
		public string LineSettlementAmount { get; set; }
		public string DocumentTotals { get; set; }
		public string TaxPayable { get; set; }
		public string NetTotal { get; set; }
		public string GrossTotal { get; set; }
		public string Currency { get; set; }
		public string CurrencyAmount { get; set; }
		public string ExchangeRate { get; set; }
		public string Settlement { get; set; }
		public string SettlementDiscount { get; set; }
		public string SettlementAmount { get; set; }
		public string SettlementDate { get; set; }
		public string PaymentTerms { get; set; }
		public string PaymentMechanism { get; set; }
		public string WithholdingTax { get; set; }
		public string WithholdingTaxType { get; set; }
		public string WithholdingTaxDescription { get; set; }
		public string WithholdingTaxAmount { get; set; }
	}

	public class SourceDocumentsSalesInvoicesInvoiceLineToolTipService
	{
		public SourceDocumentsSalesInvoicesInvoiceLineToolTipService()
		{
			Line = string.Format("4.1.4.18 * Linha.", Environment.NewLine);
			LineNumber = string.Format("4.1.4.18.1 * Inteiro{0}Número de linha.{0}As linhas devem ser exportadas pela mesma ordem em que se encontram no documento original.", Environment.NewLine);
			OrderReferences = string.Format("4.1.4.18.2 Referência ao documento de origem.", Environment.NewLine);
			OriginatingON = string.Format("4.1.4.18.2.1 Texto 255{0}Número do documento de origem.{0}Deve ser indicado o tipo, a série e o número do documento que despoletou a emissão.{0}Se o documento estiver contido no SAF-T(PT) deve ser utilizada a estrutura de numeração do campo de origem.{0}Caso sejam referenciados vários documentos, estes deverão ser separados por «;».", Environment.NewLine);
			OrderDate = string.Format("4.1.4.18.2.2 Data{0}Data do documento de origem.", Environment.NewLine);
			ProductCode = string.Format("4.1.4.18.3 * Texto 30{0}Identificador do produto ou serviço.{0}Chave do registo na tabela de produtos/serviços.", Environment.NewLine);
			ProductDescription = string.Format("4.1.4.18.4 * Texto 200{0}Descrição do produto ou serviço.{0}Descrição da linha da fatura, ligada à tabela de produtos/serviços.", Environment.NewLine);
			Quantity = string.Format("4.1.4.18.5 * Decimal{0}Quantidade.", Environment.NewLine);
			UnitOfMeasure = string.Format("4.1.4.18.6 * Texto 20{0}Unidade de medida.", Environment.NewLine);
			UnitPrice = string.Format("4.1.4.18.7 * Monetário{0}Preço unitário.{0}Preço unitário sem imposto e deduzido dos descontos de linha e cabeçalho.", Environment.NewLine);
			TaxPointDate = string.Format("4.1.4.18.8 * Data{0}Data de envio da mercadoria ou prestação do serviço.{0}Data de envio da mercadoria ou da prestação de serviço Deve ser preenchido com a data da guia de remessa asso- ciada, se existir.", Environment.NewLine);
		}

		public string Line { get; set; }
		public string LineNumber { get; set; }
		public string OrderReferences { get; set; }
		public string OriginatingON { get; set; }
		public string OrderDate { get; set; }
		public string ProductCode { get; set; }
		public string ProductDescription { get; set; }
		public string Quantity { get; set; }
		public string UnitOfMeasure { get; set; }
		public string UnitPrice { get; set; }
		public string TaxPointDate { get; set; }
	}

	public class MovementOfGoodsToolTipService
	{
		public MovementOfGoodsToolTipService()
		{
			MovementOfGoods = string.Format("4.2 Movimentos de bens.{0}Devem ser exportados os documentos, nomeadamente guias de transporte ou de remessa, que sirvam de documento de transporte, de acordo com o disposto no regime de bens em circulação, aprovado pelo Decreto-Lei n.º 147/2003, de 11 de julho.{0}Não devem aqui ser exportados os documentos de transporte que devam constar da tabela 4.1.{0}- Documentos comerciais a clientes (SalesInvoices).", Environment.NewLine);
			NumberOfMovementLines = string.Format("4.2.1 * Inteiro{0}Número de registos das linhas de movimentos dos bens.{0}Deve conter o número total de linhas com relevância fiscal dos documentos do período disponibilizado.", Environment.NewLine);
			TotalQuantityIssued = string.Format("4.2.2 * Decimal{0}Total das quantidades movimentadas.{0}Deve conter a soma de controlo do campo 4.2.3.19.5 - Quantidade (Quantity).", Environment.NewLine);
			StockMovement = string.Format("4.2.3 * Documento de movimentação de mercadorias.", Environment.NewLine);
			DocumentNumber = string.Format("4.2.3.1 * Texto 60{0}Identificação única do documento de movimentação de mercadorias.{0}Esta identificação é composta sequencialmente pelos seguintes elementos: o código interno do documento atribuído pela aplicação, um espaço, o identificador da série do documento, uma barra (/) e o número sequencial desse documento dentro dessa série.{0}Não podem neste campo existir registos com a mesma identificação.{0}Não podem ser utilizados o mesmo código interno de documento em tipos de documentos (InvoiceType) diferentes.", Environment.NewLine);
			DocumentStatus = string.Format("4.2.3.2 * Situação do documento.", Environment.NewLine);
			MovementStatus = string.Format("4.2.3.2.1 * Texto 1{0}Estado atual do documento.{0}Deve ser preenchido com:{0}«N» - Normal;{0}«T» - Por conta de terceiros;{0}«A» - Documento anulado.", Environment.NewLine);
			MovementStatusDate = string.Format("4.2.3.2.2 * Data e hora{0}Data e hora do estado atual do documento.{0}Data da última gravação do estado do documento ao segundo.{0}Tipo data e hora: «AAAA-MM-DDThh:mm:ss».", Environment.NewLine);
			Reason = string.Format("4.2.3.2.3 Texto 50{0}Motivo da alteração do estado.{0}Deve ser indicada a razão que levou à alteração de estado do documento.", Environment.NewLine);
			ResponsableUserSourceID = string.Format("4.2.3.2.4 * Texto 30{0}Código do utilizador.{0}Utilizador responsável pelo estado atual do documento.", Environment.NewLine);
			Hash = string.Format("4.2.3.3 * Texto 172{0}Chave do documento.{0}Assinatura nos termos da Portaria n.º 363/2010, de 23 de junho.{0}O campo deve ser preenchido com «0» (zero), caso não haja obrigatoriedade de certificação.", Environment.NewLine);
			HashControl = string.Format("4.2.3.4 Texto 40{0}Chave de controlo.{0}Versão da chave privada, utilizada na criação da assinatura do campo 4.2.3.3.", Environment.NewLine);
			Period = string.Format("4.2.3.5 Inteiro{0}Período contabilístico.{0}Deve ser indicado o mês do período de tributação de «1» a «12», contando desde o seu início.", Environment.NewLine);
			MovementDate = string.Format("4.2.3.6 * Data{0}Data do documento de movimentação de mercadorias.{0}Data de emissão do documento de transporte.", Environment.NewLine);
			MovementType = string.Format("4.2.3.7 * Texto 2{0}Tipo de documento.{0}Deve ser preenchido com:{0}«GR» - Guia de remessa;{0}«GT» - Guia de transporte;{0}«GA» - Guia de movimentação de ativos próprios;{0}«GC» - Guia de consignação;{0}«GD» - Guia ou nota de devolução efetuada pelo cliente.", Environment.NewLine);
			SystemEntryDate = string.Format("4.2.3.8 * Data e hora{0}Data de gravação do documento.{0}Data da gravação do registo ao segundo, no momento da assinatura.{0}Tipo data e hora: «AAAA-MM-DDThh:mm:ss».", Environment.NewLine);
			TransactionID = string.Format("4.2.3.9 ** Texto 70{0}Identificador da transação.{0}O preenchimento é obrigatório, no caso de se tratar de um sistema integrado que inclua inventário permanente em que o campo 1.4 - Sistema contabilístico (TaxAccountingBasis) = «I».{0}Deve ser indicada a chave única da tabela de movimentos contabilísticos de stocks (GeneralLedgerEntries) onde foi lançado este documento, respeitando a regra aí definida para o campo chave única do movimento contabilístico (TransactionID).", Environment.NewLine);
			CustomerID = string.Format("4.2.3.10 ** Texto 30{0}Identificador do cliente.{0}Chave única da tabela de clientes (Customer) respeitando a regra aí definida para o campo identificador único do cliente (CustomerID).{0}No caso de guias em que não se conhece o destinatário, deve ser utilizado o cliente genérico previsto na tabela 2.2 - Tabela de clientes (Customer).{0}Este campo também deve ser preenchido no caso de guias que titulam a transferência de bens do próprio remetente.", Environment.NewLine);
			SupplierID = string.Format("4.2.3.11 ** Texto 30{0}Identificador do fornecedor.{0}Chave única da tabela de fornecedores (Supplier) respeitando a regra aí definida para o campo identificador único do fornecedor (SupplierID), no caso das guias de devolução ou guia de transporte de bens móveis produzidos ou montados sob encomenda com materiais que o dono da obra tenha fornecido para o efeito (trabalho a feitio).", Environment.NewLine);
			GeneratedDocumentUserSourceID = string.Format("4.2.3.12 * Texto 30{0}Código do utilizador.{0}Utilizador que gerou o documento.", Environment.NewLine);
			MovementComments = string.Format("4.2.3.13 Texto 60{0}Razão da emissão do documento.", Environment.NewLine);
			ShipTo = string.Format("4.2.3.14 Local de descarga.{0}Informação do local e data de entrega onde os artigos são colocados à disposição do cliente.", Environment.NewLine);
			ShipToDeliveryID = string.Format("4.2.3.14.1 Texto 30{0}Identificador da entrega.", Environment.NewLine);
			ShipToDeliveryDate = string.Format("4.2.3.14.2 Data{0}Data da entrega.", Environment.NewLine);
			ShipToWarehouseID = string.Format("4.2.3.14.3 Texto 50{0}Identificador do armazém de destino.", Environment.NewLine);
			ShipToLocationID = string.Format("4.2.3.14.4 Texto 30{0}Localização dos bens no armazém de destino.", Environment.NewLine);
			ShipToAddress = string.Format("4.2.3.14.5 Morada.", Environment.NewLine);
			ShipToBuildingNumber = string.Format("4.2.3.14.5.1 Texto 10{0}Número de polícia.", Environment.NewLine);
			ShipToStreetName = string.Format("4.2.3.14.5.2 Texto 90{0}Nome da rua.", Environment.NewLine);
			ShipToAddressDetail = string.Format("4.2.3.14.5.3 * Texto 100{0}Morada detalhada.{0}Deve incluir o nome da rua, número de polícia e andar, se aplicável.", Environment.NewLine);
			ShipToCity = string.Format("4.2.3.14.5.4 * Texto 50{0}Localidade.", Environment.NewLine);
			ShipToPostalCode = string.Format("4.2.3.14.5.5 * Texto 20{0}Código postal.", Environment.NewLine);
			ShipToRegion = string.Format("4.2.3.14.5.6 Texto 50{0}Distrito.", Environment.NewLine);
			ShipToCountry = string.Format("4.2.3.14.5.7 * Texto 2{0}País.{0}Deve ser preenchido de acordo com a norma ISO 3166-1-alpha-2.", Environment.NewLine);
			ShipFrom = string.Format("4.2.3.15 Local de carga.{0}Informação do local e data de carga onde se inicia a expedição dos artigos vendidos para o cliente.", Environment.NewLine);
			ShipFromDeliveryID = string.Format("4.2.3.15.1 Texto 30{0}Identificador da entrega.", Environment.NewLine);
			ShipFromDeliveryDate = string.Format("4.2.3.15.2 Data{0}Data de expedição.", Environment.NewLine);
			ShipFromWarehouseID = string.Format("4.2.3.15.3 Texto 50{0}Identificador do armazém de partida.", Environment.NewLine);
			ShipFromLocationID = string.Format("4.2.3.15.4 Texto 30{0}Localização dos bens no armazém de partida.", Environment.NewLine);
			ShipFromBuildingNumber = string.Format("4.2.3.15.5.1 Texto 10{0}Número de polícia.", Environment.NewLine);
			ShipFromStreetName = string.Format("4.2.3.15.5.2 Texto 90{0}Nome da rua.", Environment.NewLine);
			ShipFromAddressDetail = string.Format("4.2.3.15.5.3 * Texto 100{0}Morada detalhada.{0}Deve incluir o nome da rua, número de polícia e andar, se aplicável.", Environment.NewLine);
			ShipFromCity = string.Format("4.2.3.15.5.4 * Texto 50{0}Localidade.", Environment.NewLine);
			ShipFromPostalCode = string.Format("4.2.3.15.5.5 * Texto 20{0}Código postal.", Environment.NewLine);
			ShipFromRegion = string.Format("4.2.3.15.5.6 Texto 50{0}Distrito.", Environment.NewLine);
			ShipFromCountry = string.Format("4.2.3.15.5.7 * Texto 2{0}País.{0}Deve ser preenchido de acordo com a norma ISO 3166-1-alpha-2.", Environment.NewLine);
			MovementEndTime = string.Format("4.2.3.16 Data e hora{0}Data e hora de fim de transporte.{0}Tipo de data e hora: «AAAA-MM-DDThh:mm:ss» em que o «ss» pode ser «00», na ausência de informação concreta.", Environment.NewLine);
			MovementStartTime = string.Format("4.2.3.17 * Data e hora{0}Data e hora para o início de transporte.{0}Tipo de data e hora: «AAAA-MM-DDThh:mm:ss» em que o «ss» pode ser «00», na ausência de informação concreta.", Environment.NewLine);
			ATDocCodeID = string.Format("4.2.3.18 Texto 200{0}Código de identificação do documento.{0}Código de identificação atribuído pela AT ao documento, nos termos do Decreto-Lei n.º 198/2012, de 24 de agosto.", Environment.NewLine);
			DocumentTotals = string.Format("4.2.3.20 * Totais do documento.", Environment.NewLine);
			TaxPayable = string.Format("4.2.3.20.1 * Monetário{0}Valor do imposto a pagar.{0}Quando a guia não for valorizada deve ser preenchido com «0.00».", Environment.NewLine);
			NetTotal = string.Format("4.2.3.20.2 * Monetário{0}Total do documento sem impostos.{0}Este campo não deve incluir as parcelas referentes aos impostos constantes da tabela de impostos (TaxTable).{0}Quando a guia não for valorizada este campo deve ser preenchido com «0.00».", Environment.NewLine);
			GrossTotal = string.Format("4.2.3.20.3 * Monetário{0}Total do documento com impostos.{0}Quando a guia não for valorizada este campo deve ser preenchido com «0.00».", Environment.NewLine);
			Currency = string.Format("4.2.3.20.4 Moeda.", Environment.NewLine);
			CurrencyCode = string.Format("4.2.3.20.4.1 * Texto 3{0}Código de moeda.{0}No caso de moeda estrangeira deve ser preenchido de acordo com a norma ISO 4217.", Environment.NewLine);
			CurrencyAmount = string.Format("4.2.3.20.4.2 * Monetário{0}Valor total em moeda estrangeira.{0}Valor do campo 4.2.3.20.3. GrossTotal na moeda original do documento.", Environment.NewLine);
			ExchangeRate = string.Format("4.2.3.20.4.3 Decimal{0}Taxa de câmbio.{0}Deve ser indicada a taxa de câmbio utilizada na conversão para EUR.", Environment.NewLine);
		}

		public string MovementOfGoods { get; set; }
		public string NumberOfMovementLines { get; set; }
		public string TotalQuantityIssued { get; set; }
		public string StockMovement { get; set; }
		public string DocumentNumber { get; set; }
		public string DocumentStatus { get; set; }
		public string MovementStatus { get; set; }
		public string MovementStatusDate { get; set; }
		public string Reason { get; set; }
		public string ResponsableUserSourceID { get; set; }
		public string Hash { get; set; }
		public string HashControl { get; set; }
		public string Period { get; set; }
		public string MovementDate { get; set; }
		public string MovementType { get; set; }
		public string SystemEntryDate { get; set; }
		public string TransactionID { get; set; }
		public string CustomerID { get; set; }
		public string SupplierID { get; set; }
		public string GeneratedDocumentUserSourceID { get; set; }
		public string MovementComments { get; set; }
		public string ShipTo { get; set; }
		public string ShipToDeliveryID { get; set; }
		public string ShipToDeliveryDate { get; set; }
		public string ShipToWarehouseID { get; set; }
		public string ShipToLocationID { get; set; }
		public string ShipToAddress { get; set; }
		public string ShipToBuildingNumber { get; set; }
		public string ShipToStreetName { get; set; }
		public string ShipToAddressDetail { get; set; }
		public string ShipToCity { get; set; }
		public string ShipToPostalCode { get; set; }
		public string ShipToRegion { get; set; }
		public string ShipToCountry { get; set; }
		public string ShipFrom { get; set; }
		public string ShipFromDeliveryID { get; set; }
		public string ShipFromDeliveryDate { get; set; }
		public string ShipFromWarehouseID { get; set; }
		public string ShipFromLocationID { get; set; }
		public string ShipFromBuildingNumber { get; set; }
		public string ShipFromStreetName { get; set; }
		public string ShipFromAddressDetail { get; set; }
		public string ShipFromCity { get; set; }
		public string ShipFromPostalCode { get; set; }
		public string ShipFromRegion { get; set; }
		public string ShipFromCountry { get; set; }
		public string MovementEndTime { get; set; }
		public string MovementStartTime { get; set; }
		public string ATDocCodeID { get; set; }
		public string DocumentTotals { get; set; }
		public string TaxPayable { get; set; }
		public string NetTotal { get; set; }
		public string GrossTotal { get; set; }
		public string Currency { get; set; }
		public string CurrencyCode { get; set; }
		public string CurrencyAmount { get; set; }
		public string ExchangeRate { get; set; }
	}

	public class MovementOfGoodsLineToolTipService
	{
		public MovementOfGoodsLineToolTipService()
		{
			Line = string.Format("4.2.3.19 * Linha.", Environment.NewLine);
			LineNumber = string.Format("4.2.3.19.1 * Inteiro{0}Número de linha.{0}As linhas devem ser exportadas pela mesma ordem em que se encontram no documento original.", Environment.NewLine);
			OrderReferences = string.Format("4.2.3.19.2 Referência ao documento de origem.", Environment.NewLine);
			OriginatingON = string.Format("4.2.3.19.2.1 Texto 255{0}Número do documento de origem.{0}Se o documento estiver contido no SAF-T(PT) deve ser utilizada a estrutura de numeração do campo de origem.{0}Caso existam várias referencias, estas deverão ser separadas por «;».", Environment.NewLine);
			OrderDate = string.Format("4.2.3.19.2.2 Data{0}Data do documento de origem.", Environment.NewLine);
			ProductCode = string.Format("4.2.3.19.3 * Texto 30{0}Identificador do produto ou serviço.{0}Chave do registo na tabela de produtos/serviços.", Environment.NewLine);
			ProductDescription = string.Format("4.2.3.19.4 * Texto 200{0}Descrição do produto ou serviço.{0}Descrição da linha da fatura, ligada à tabela de produtos/serviços.", Environment.NewLine);
			Quantity = string.Format("4.2.3.19.5 * Decimal{0}Quantidade.", Environment.NewLine);
			UnitOfMeasure = string.Format("4.2.3.19.6 * Texto 20{0}Unidade de medida.", Environment.NewLine);
			UnitPrice = string.Format("4.2.3.19.7 * Monetário{0}Preço unitário.{0}Preço unitário sem imposto e deduzido dos descontos de linha e cabeçalho.{0}Em documentos não valorizados deve ser preenchido com «0.00».", Environment.NewLine);
			Description = string.Format("4.2.3.19.8 * Texto 60{0}Descrição.{0}Descrição da linha do documento.", Environment.NewLine);
			DebitAmount = string.Format("4.2.3.19.9 ** Monetário{0}Valor a débito.{0}Campo a preencher no caso de a guia ou nota de devolução, ser valorizada.{0}Este valor deve ser indicado sem imposto e descontos de linha e cabeçalho.{0}Se não for valorizada, deve ser preenchida com «0.00».", Environment.NewLine);
			CreditAmount = string.Format("4.2.3.19.10 ** Monetário{0}Valor a crédito.{0}Valor da linha sem imposto, deduzido dos descontos de linha e cabeçalho.{0}Se não for valorizada, deve ser preenchida com «0.00».", Environment.NewLine);
			Tax = string.Format("4.2.3.19.11 Taxa de imposto.{0}Esta estrutura só deve ser criada nos documentos valorizados.", Environment.NewLine);
			TaxType = string.Format("4.2.3.19.11 * Texto 3{0}Identificador do regime de imposto.{0}Neste campo deve ser preenchido com:{0}«IVA» - Imposto sobre o valor acrescentado.", Environment.NewLine);
			TaxCountryRegion = string.Format("4.2.3.19.11 * Texto 5{0}País ou região do imposto.{0}Deve ser preenchido de acordo com a norma ISO 3166-1-alpha-2.{0}No caso das Regiões Autónomas da Madeira e Açores deve ser preenchido com: «PT-AC» - Espaço fiscal da Região Autónoma dos Açores; «PT-MA» - Espaço fiscal da Região Autónoma da Madeira.", Environment.NewLine);
			TaxCode = string.Format("4.2.3.19.11 * Texto 10{0}Código da taxa.{0}Código da taxa na tabela de impostos.{0}Tem que ser preenchido quando o campo Percentagem da Taxa de Imposto (TaxPercentage) é diferente de zero.{0}Deve ser preenchido com: «RED» - Taxa reduzida; «INT» - Taxa intermédia; «NOR» - Taxa normal; «ISE» - Isenta; «OUT» - Outros, aplicável para os regimes especiais de IVA.", Environment.NewLine);
			TaxPercentage = string.Format("4.2.3.19.11 * Decimal{0}Percentagem da taxa de imposto.{0}Percentagem da taxa correspondente ao imposto aplicável ao campo valor a débito (DebitAmount) ou ao campo valor a crédito (CreditAmount).", Environment.NewLine);
			TaxExemptionReason = string.Format("4.2.3.19.12 ** Texto 60{0}Motivo da isenção de imposto.{0}O seu preenchimento é obrigatório, quando o campo percentagem da taxa de imposto (TaxPercentage) é igual a «0» zero, devendo ser referido o preceito legal aplicável.{0}Nos documentos em que o imposto ainda não foi  determinado ou referido, deve ser preenchido com «Documento sem imposto calculado».", Environment.NewLine);
			SettlementAmount = string.Format("4.2.3.19.13 Monetário{0}Montante do desconto da linha.{0}Deve refletir todos os descontos concedidos (globais e de linha) que afetam o valor do campo 4.2.3.20.3.{0}- total do documento com impostos (GrossTotal).", Environment.NewLine);
		}

		public string Line { get; set; }
		public string LineNumber { get; set; }
		public string OrderReferences { get; set; }
		public string OriginatingON { get; set; }
		public string OrderDate { get; set; }
		public string ProductCode { get; set; }
		public string ProductDescription { get; set; }
		public string Quantity { get; set; }
		public string UnitOfMeasure { get; set; }
		public string UnitPrice { get; set; }
		public string Description { get; set; }
		public string DebitAmount { get; set; }
		public string CreditAmount { get; set; }
		public string Tax { get; set; }
		public string TaxType { get; set; }
		public string TaxCountryRegion { get; set; }
		public string TaxCode { get; set; }
		public string TaxPercentage { get; set; }
		public string TaxExemptionReason { get; set; }
		public string SettlementAmount { get; set; }
	}

	public class WorkingDocumentsToolTipService
	{
		public WorkingDocumentsToolTipService()
		{
			WorkingDocuments = string.Format("4.3 Documentos de conferência.", Environment.NewLine);
			NumberOfEntries = string.Format("4.3.1 * Inteiro{0}Número de registos de documentos de conferência.{0}Deve conter o número total de documentos, incluindo os documentos cujo estado atual (WorkStatus) seja do tipo «A» ou «F».", Environment.NewLine);
			TotalDebit = string.Format("4.3.2 * Monetário{0}Total dos débitos.{0}Deve conter a soma de controlo do campo 4.3.4.11.10.{0}- valor a débito (DebitAmount), dela excluindo os documentos em que o campo 4.3.4.2.1.{0}- estado atual do documento (WorkStatus) seja do tipo «A».", Environment.NewLine);
			TotalCredit = string.Format("4.3.3 * Monetário{0}Total dos créditos.{0}Deve conter a soma de controlo do campo 4.3.4.11.11.{0}- valor a crédito (CreditAmount), dela excluindo os documentos em que o campo 4.3.4.2.1.{0}- estado atual do documento (WorkStatus) seja do tipo «A».", Environment.NewLine);
			WorkDocument = string.Format("4.3.4 * Documento de conferência.", Environment.NewLine);
			DocumentNumber = string.Format("4.3.4.1 * Texto 60{0}Identificação única do documento.{0}Esta identificação é composta sequencialmente pelos seguintes elementos: o código interno do documento atribuído pela aplicação, um espaço, o identificador da série do documento, uma barra (/) e o número sequencial desse documento dentro dessa série.{0}Não podem neste campo, existir registos com a mesma identificação.{0}Não podem ser utilizados o mesmo código interno de documento em tipos de documentos (InvoiceType) diferente.", Environment.NewLine);
			DocumentStatus = string.Format("4.3.4.2 * Situação do documento.", Environment.NewLine);
			WorkStatus = string.Format("4.3.4.2.1 * Texto 1{0}Estado atual do documento.{0}Deve ser preenchido com:{0}«N» - Normal;{0}«A» - Documento anulado;{0}«F» - Documento faturado, quando para este documento também existe na tabela 4.1 o correspondente do tipo fatura ou fatura simplificada.", Environment.NewLine);
			WorkStatusDate = string.Format("4.3.4.2.2 * Data e hora{0}Data e hora do estado atual do documento.{0}Data da última gravação do estado do documento ao segundo.{0}Tipo data e hora: «AAAA-MM-DDThh:mm:ss».", Environment.NewLine);
			Reason = string.Format("4.3.4.2.3 Texto 50{0}Motivo da alteração de estado.{0}Deve ser indicada a razão que levou à alteração de estado do documento.", Environment.NewLine);
			ResponsableUserSourceID = string.Format("4.3.4.2.4 * Texto 30{0}Código do utilizador.{0}Utilizador responsável pelo estado atual do documento.", Environment.NewLine);
			Hash = string.Format("4.3.4.3 * Texto 172{0}Chave do documento.{0}Assinatura nos termos da Portaria n.º 363/2010, de 23 de junho.{0}O campo deve ser preenchido com «0» (zero), caso não haja obrigatoriedade de certificação.", Environment.NewLine);
			HashControl = string.Format("4.3.4.4 Texto 40{0}Chave de controlo.{0}Versão da chave privada utilizada na criação da assinatura do campo 4.3.4.3.", Environment.NewLine);
			Period = string.Format("4.3.4.5 Inteiro{0}Período contabilístico.{0}Deve ser indicado o mês do período de tributação de «1» a «12», contando desde o início.", Environment.NewLine);
			WorkDate = string.Format("4.3.4.6 * Data{0}Data do documento.{0}Data de emissão do documento operativo.", Environment.NewLine);
			WorkType = string.Format("4.3.4.7 * Texto 2{0}Tipo de documento.{0}Deve ser preenchido com:{0}«DC» - Documentos emitidos que sejam suscetiveis de apresentação ao cliente para conferência de entrega de mercadorias ou da prestação de serviços.", Environment.NewLine);
			GeneratedDocumentUserSourceID = string.Format("4.3.4.8 * Texto 30{0}Código do utilizador.{0}Utilizador que gerou o documento.", Environment.NewLine);
			SystemEntryDate = string.Format("4.3.4.9 * Data e hora{0}Data de gravação do documento.{0}Data da gravação do registo ao segundo, no momento da assinatura.{0}Tipo data e hora: «AAAA-MM-DDThh:mm:ss».", Environment.NewLine);
			CustomerID = string.Format("4.3.4.10 * Texto 30{0}Identificador do cliente.{0}Chave única da tabela de clientes (Customer) respeitando a regra aí definida para o campo identificador único do cliente (CustomerID).", Environment.NewLine);
			DocumentTotals = string.Format("4.3.4.12 * Totais do documento.", Environment.NewLine);
			TaxPayable = string.Format("4.3.4.12.1 * Monetário{0}Valor do imposto a pagar.", Environment.NewLine);
			NetTotal = string.Format("4.3.4.12.2 * Monetário{0}Total do documento sem impostos.{0}Este campo não deve incluir as parcelas referentes aos impostos constantes da tabela de impostos (TaxTable).", Environment.NewLine);
			GrossTotal = string.Format("4.3.4.12.3 * Monetário{0}Total do documento com impostos.", Environment.NewLine);
			Currency = string.Format("4.3.4.12.4 Moeda.", Environment.NewLine);
			CurrencyCode = string.Format("4.3.4.12.4.1 * Texto 3{0}Código de moeda.{0}No caso de moeda estrangeira deve ser preenchido de acordo com a norma ISO 4217.", Environment.NewLine);
			CurrencyAmount = string.Format("4.3.4.12.4.2 * Monetário{0}Valor total em moeda estrangeira.{0}Valor do campo 4.3.4.12.3 - total do documento com impostos (GrossTotal) na moeda original do documento.", Environment.NewLine);
			ExchangeRate = string.Format("4.3.4.12.4.3 Decimal{0}Taxa de câmbio.{0}Deve ser indicada a taxa de câmbio utilizada na conversão para EUR.", Environment.NewLine);
		}

		public string WorkingDocuments { get; set; }
		public string NumberOfEntries { get; set; }
		public string TotalDebit { get; set; }
		public string TotalCredit { get; set; }
		public string WorkDocument { get; set; }
		public string DocumentNumber { get; set; }
		public string DocumentStatus { get; set; }
		public string WorkStatus { get; set; }
		public string WorkStatusDate { get; set; }
		public string Reason { get; set; }
		public string ResponsableUserSourceID { get; set; }
		public string Hash { get; set; }
		public string HashControl { get; set; }
		public string Period { get; set; }
		public string WorkDate { get; set; }
		public string WorkType { get; set; }
		public string GeneratedDocumentUserSourceID { get; set; }
		public string SystemEntryDate { get; set; }
		public string CustomerID { get; set; }
		public string DocumentTotals { get; set; }
		public string TaxPayable { get; set; }
		public string NetTotal { get; set; }
		public string GrossTotal { get; set; }
		public string Currency { get; set; }
		public string CurrencyCode { get; set; }
		public string CurrencyAmount { get; set; }
		public string ExchangeRate { get; set; }
	}

	public class WorkingDocumentsLineToolTipService
	{
		public WorkingDocumentsLineToolTipService()
		{
			Line = string.Format("4.3.4.11 * Linha.", Environment.NewLine);
			LineNumber = string.Format("4.3.4.11.1 * Inteiro{0}Número de linha.{0}As linhas devem ser exportadas pela mesma ordem em que se encontram no documento original.", Environment.NewLine);
			OrderReferences = string.Format("4.3.4.11.2 Referência ao documento de origem.", Environment.NewLine);
			OriginatingON = string.Format("4.3.4.11.2.1 Texto 255{0}Número do documento precedente.{0}Se o documento estiver contido no SAF-T(PT) deve ser utilizada a estrutura de numeração do campo de origem.{0}Caso sejam referenciados vários documentos, estes deverão ser separados por «;».", Environment.NewLine);
			OrderDate = string.Format("4.3.4.11.2.2 Data{0}Data do documento de origem.", Environment.NewLine);
			ProductCode = string.Format("4.3.4.11.3 * Texto 30{0}Identificador do produto ou serviço.{0}Chave do registo na tabela de produtos/serviços.", Environment.NewLine);
			ProductDescription = string.Format("4.3.4.11.4 * Texto 200{0}Descrição do produto ou serviço.{0}Descrição da linha do documento, ligada à tabela de produtos/serviços.", Environment.NewLine);
			Quantity = string.Format("4.3.4.11.5 * Decimal{0}Quantidade.", Environment.NewLine);
			UnitOfMeasure = string.Format("4.3.4.11.6 * Texto 20{0}Unidade de medida.", Environment.NewLine);
			UnitPrice = string.Format("4.3.4.11.7 * Monetário{0}Preço unitário.{0}Preço unitário sem imposto e deduzido dos descontos de linha e cabeçalho.", Environment.NewLine);
			TaxPointDate = string.Format("4.3.4.11.8 * Data{0}Data de envio da mercadoria ou prestação do serviço.{0}Data de envio da mercadoria ou da prestação de serviço.", Environment.NewLine);
			Description = string.Format("4.3.4.11.9 * Texto 60{0}Descrição.{0}Descrição da linha do documento.", Environment.NewLine);
			DebitAmount = string.Format("4.3.4.11.10 ** Monetário{0}Valor a débito.{0}Valor da linha dos documentos a débito.{0}Este valor é sem imposto e deduzido dos descontos de linha e cabeçalho.", Environment.NewLine);
			CreditAmount = string.Format("4.3.4.11.11 ** Monetário{0}Valor a crédito.{0}Valor da linha dos documentos a crédito.{0}Este valor é sem imposto e deduzido dos descontos de linha e cabeçalho.", Environment.NewLine);
			Tax = string.Format("4.3.4.11.12 Taxa de imposto.", Environment.NewLine);
			TaxType = string.Format("4.3.4.11.12 * Texto 3{0}Identificador do regime de imposto.{0}Neste campo deve ser indicado o tipo de imposto.{0}Deve preenchido com:{0}«IVA» - Imposto sobre o valor acrescentado;{0}«IS» - Imposto do selo.", Environment.NewLine);
			TaxCountryRegion = string.Format("4.3.4.11.12 * Texto 5{0}País ou região do imposto.{0}Deve ser preenchido de acordo com a norma ISO 3166-1-alpha 2.{0}No caso das regiões autónomas da Madeira e Açores deve ser preenchido com:{0}«PT-AC» - Espaço fiscal da região autónoma dos Açores;{0}«PT-MA» - Espaço fiscal da região autónoma da Madeira.", Environment.NewLine);
			TaxCode = string.Format("4.3.4.11.12 * Texto 10{0}Código da taxa.{0}Código da taxa na tabela de impostos.{0}Tem que ser preenchido quando os campos percentagem da taxa de imposto (TaxPercentage) ou montante do imposto (TaxAmount) são diferentes de zero.{0}No caso do código do tipo de imposto (TaxType) = IVA, deve ser preenchido com:{0}«RED» - Taxa reduzida;{0}«INT» - Taxa intermédia;{0}«NOR» - Taxa normal;{0}«ISE» - Isenta;{0}«OUT» - Outros, aplicável para os regimes especiais de IVA.{0}No caso do código do tipo de imposto (TaxType) = «IS», deve ser preenchido com o código da verba respetiva.", Environment.NewLine);
			TaxPercentage = string.Format("4.3.4.11.12 ** Decimal{0}Percentagem da taxa de imposto.{0}O preenchimento é obrigatório, no caso de se tratar de uma percentagem de imposto.{0}A percentagem da taxa é correspondente ao imposto aplicável ao campo 4.3.4.11.10 - Valor a débito (DebitAmount) ou ao campo 4.3.4.11.11 - Valor a crédito (CreditAmount).", Environment.NewLine);
			TaxAmount = string.Format("4.3.4.11.12 ** Monetário{0}Montante do imposto.{0}O preenchimento é obrigatório, no caso de se tratar de uma verba fixa de imposto do selo.", Environment.NewLine);
			TaxExemptionReason = string.Format("4.3.4.11.13 ** Texto 60{0}Motivo da isenção de imposto.{0}O preenchimento é obrigatório, quando os campos percentagem da taxa de imposto (TaxPercentage) ou montante do imposto (TaxAmount) são iguais a «0» zero.{0}Deve ser referido o preceito legal aplicável.{0}Nos documentos em que o imposto ainda não foi determinado ou referido, deve ser preenchido com «Documento sem imposto calculado».{0}Este campo deve ser igualmente preenchido nos casos de não sujeição aos impostos referidos na tabela 2.5 - Tabela de impostos (TaxTable).", Environment.NewLine);
			SettlementAmount = string.Format("4.3.4.11.14 Monetário{0}Montante do desconto da linha.", Environment.NewLine);
		}

		public string Line { get; set; }
		public string LineNumber { get; set; }
		public string OrderReferences { get; set; }
		public string OriginatingON { get; set; }
		public string OrderDate { get; set; }
		public string ProductCode { get; set; }
		public string ProductDescription { get; set; }
		public string Quantity { get; set; }
		public string UnitOfMeasure { get; set; }
		public string UnitPrice { get; set; }
		public string TaxPointDate { get; set; }
		public string Description { get; set; }
		public string DebitAmount { get; set; }
		public string CreditAmount { get; set; }
		public string Tax { get; set; }
		public string TaxType { get; set; }
		public string TaxCountryRegion { get; set; }
		public string TaxCode { get; set; }
		public string TaxPercentage { get; set; }
		public string TaxAmount { get; set; }
		public string TaxExemptionReason { get; set; }
		public string SettlementAmount { get; set; }
	}

	public class SourceDocumentsPaymentsPaymentToolTipService
	{
		public SourceDocumentsPaymentsPaymentToolTipService()
		{
			this.PaymentRefNo = string.Format("4.4.4.1 * Texto 60{0}Identificação única do recibo.{0}Esta identificação é composta sequencialmente pelos seguintes elementos: o código interno do tipo de recibo atribuído pela aplicação, um espaço, o identificador da série do recibo, uma barra (/) e o número sequencial desse recibo dentro dessa série. Não podem existir registos com a mesma identificação. Não pode ser utilizado o mesmo código interno de tipo de documento em diferente tipo de recibos (PaymentType).", Environment.NewLine);
			this.Period = string.Format("4.4.4.2 Inteiro{0}Deve ser indicado o mês do período de tributação de “1” a “12”, contado desde a data do seu início.", Environment.NewLine);
			this.TransactionID = string.Format("4.4.4.3 ** Texto 70{0}Identificador da transação.{0} O preenchimento é obrigatório, no caso de se tratar de um sistema integrado em que o campo 1.4. - Sistema contabilístico (TaxAccountingBasis) = «I».{0}Deve ser indicada a chave única da tabela 3 Movimentos contabilísticos (GeneralLedgerEntries) da transação onde foi lançado este documento, respeitando a regra aí definida para o campo 3.4.3.1 - Chave única do movimento contabilístico (TransactionID).", Environment.NewLine);
			this.TransactionDate = string.Format("4.4.4.4 * Data{0}Data do recibo.{0}Data de emissão do recibo.", Environment.NewLine);
			this.PaymentType = string.Format("4.4.4.5 * Texto 2{0}Tipo de recibo.{0}Deve ser preenchido com:{0}«RC» - Recibo emitido no âmbito do regime de IVA de Caixa (incluindo os relativos a adiantamentos desse regime);{0}«RG» - Outros recibos emitidos.", Environment.NewLine);
			this.Description = string.Format("4.4.4.6 Texto 200{0}Descrição do pagamento.", Environment.NewLine);
			this.SystemID = string.Format("4.4.4.7 Texto 35{0}Numero gerado pela aplicação.{0}Número único do recibo gerado internamente pela aplicação.", Environment.NewLine);
			this.PaymentStatus = string.Format("4.4.4.8.1 * Texto 1{0}Estado atual do recibo.{0}Deve ser preenchido com:{0}«N» - Recibo normal e vigente;{0}«A» - Recibo anulado.", Environment.NewLine);
			this.PaymentStatusDate = string.Format("4.4.4.8.2 * Data e Hora{0}Data e hora do estado atual do recibo.{0}Data da última gravação do estado do recibo ao segundo.{0}Tipo data e hora: “AAAA-MM-DDThh:mm:ss”.", Environment.NewLine);
			this.Reason = string.Format("4.4.4.8.3 Texto 50{0}Motivo da alteração de estado do recibo.{0}Deve ser indicada a razão que levou à alteração de estado do recibo.", Environment.NewLine);
			this.ResponsableUserSourceID = string.Format("4.4.4.8.4 * Texto 30{0}Código do utilizador. Utilizador responsável pelo estado atual do recibo.", Environment.NewLine);
			this.SourcePayment = string.Format("4.4.4.9 * Texto 1{0}Origem  do  documento. Deve ser preenchido com:{0}«P» - Recibo produzido na aplicação;{0}«I» - Recibo integrado e produzido noutra aplicação;{0}«M» - Recibo proveniente de recuperação ou de emissão manual.", Environment.NewLine);
			this.PaymentMethod = string.Format("4.4.4.10{0}Forma de Pagamento.{0}Deve ser indicado o meio de pagamento utilizado. No caso de pagamentos mistos devem ser indicados os montantes  por tipo de meio e data de pagamento.", Environment.NewLine);
			this.PaymentMechanism = string.Format("4.4.4.10.1 * Texto 2{0}Meios de pagamento. Deve ser preenchido com:{0}«CC» - Cartão crédito;{0}«CD» - Cartão débito;{0}«CH» - Cheque bancário;{0}«CO» - Cheque ou cartão oferta;{0}«CS» - Compensação de saldos em conta corrente;{0}«DE» - Dinheiro eletrónico, por exemplo residente em cartões de fidelidade ou de pontos;{0}«LC» - Letra comercial;{0}«MB» - Referências de pagamento para Multibanco;{0}«NU» - Numerário;{0}«OU» - Outros meios aqui não assinalados;{0}«PR» - Permuta de bens;{0}«TB» - Transferência bancária ou débito direto autorizado;{0}«TR» - Ticket restaurante.", Environment.NewLine);
			this.PaymentAmount = string.Format("4.4.4.10.2 * Monetário{0}Montante do pagamento.{0}Deve ser indicado o montante por meio de pagamento.", Environment.NewLine);
			this.PaymentDate = string.Format("4.4.4.10.3 * Data{0}Data do pagamento.", Environment.NewLine);
			this.GeneratedDocumentUserSourceID = string.Format("4.4.4.11 * Texto 30{0}Código do utilizador.{0}Utilizador que gerou o documento.", Environment.NewLine);
			this.SystemEntryDate = string.Format("4.4.4.12 * Data e Hora{0}Data de gravação do recibo.{0}Data da gravação do registo ao segundo, Tipo data e hora: «AAAA-MM-DDThh:mm:ss».", Environment.NewLine);
			this.CustomerID = string.Format("4.4.4.13 * Texto 30{0}Identificador do cliente.{0}Chave única da tabela 2.2. — Tabela de clientes (Customer) respeitando a regra aí definida para o campo 2.2.1. — Identificador único do cliente (CustomerID).", Environment.NewLine);
		}

		public string PaymentRefNo { get; set; }
		public string Period { get; set; }
		public string TransactionID { get; set; }
		public string TransactionDate { get; set; }
		public string PaymentType { get; set; }
		public string Description { get; set; }
		public string SystemID { get; set; }
		public string PaymentStatus { get; set; }
		public string PaymentStatusDate { get; set; }
		public string Reason { get; set; }
		public string ResponsableUserSourceID { get; set; }
		public string SourcePayment { get; set; }
		public string PaymentMethod { get; set; }
		public string PaymentMechanism { get; set; }
		public string PaymentAmount { get; set; }
		public string PaymentDate { get; set; }
		public string GeneratedDocumentUserSourceID { get; set; }
		public string SystemEntryDate { get; set; }
		public string CustomerID { get; set; }
	}

	public class SourceDocumentsPaymentsPaymentLineToolTipService
	{
		public SourceDocumentsPaymentsPaymentLineToolTipService()
		{
			this.LineNumber = string.Format("4.4.4.14.1 * Inteiro{0}Número de linha.{0}As linhas devem ser exportadas pela mesma ordem em que se encontram no recibo original.", Environment.NewLine);
			this.SourceDocumentID = string.Format("4.4.4.14.2 *{0}Referência ao documento de origem.{0}Existindo a necessidade de efetuar mais do que uma referência, este campo poderá ser gerado tantas vezes quantas as necessárias.", Environment.NewLine);
			this.OriginatingON = string.Format("4.4.4.14.2.1 * Texto 60{0}Número do documento de origem.{0}Deve ser indicado o tipo, a série e o número da fatura ou documento retificativo desta a que respeita o pagamento.{0}Se o documento referido estiver contido no SAF-T(PT) deve ser utilizada a estrutura de numeração do campo 4.1.4.1 - Identificação única do documento de venda (InvoiceNo) da Tabela 4.1. - Documentos comerciais a clientes (SalesInvoices).", Environment.NewLine);
			this.InvoiceDate = string.Format("4.4.4.14.2.2 * Data{0}Data do documento de origem.{0}Deve ser indicada a data da fatura ou documento retificativo desta a que se refere o pagamento.", Environment.NewLine);
			this.Description = string.Format("4.4.4.14.2.3 Texto 100{0}Descrição da linha.{0}Descrição da linha de recebimento.", Environment.NewLine);
			this.LineSettlementAmount = string.Format("4.4.4.14.3 Monetário{0}Montante do desconto da linha.{0}Descontos concedidos aquando do pagamento deste documento.", Environment.NewLine);
			this.DebitAmount = string.Format("4.4.4.14.4 ** Monetário{0}Valor a débito.{0}Valor desta linha do recibo do documento retificativo, sem impostos e eventuais descontos. ", Environment.NewLine);
			this.CreditAmount = string.Format("4.4.4.14.5 ** Monetário{0}Valor a crédito.{0}Valor desta linha do recibo da fatura ou documento retificativo, sem impostos e eventuais descontos.", Environment.NewLine);
			this.Tax = string.Format("4.4.4.14.6 {0}Taxa de imposto.{0}Nos recibos do sistema de IVA de Caixa, deve ser indicada uma linha por cada taxa de IVA diferente, que conste da fatura respetiva.", Environment.NewLine);
			this.TaxType = string.Format("4.4.4.14.6.1 * Texto 3{0}Código do tipo de imposto.{0}Neste campo deve ser indicado o tipo de imposto.{0}Deve ser preenchido com:{0}«IVA» - Imposto sobre o valor acrescentado, para o regime de IVA de Caixa;{0}«IS» - Imposto de Selo;{0}«NS» - Não sujeito a IVA ou IS.", Environment.NewLine);
			this.TaxCountryRegion = string.Format("4.4.4.14.6.2 * Texto 5{0}País ou região do imposto.{0}Deve  ser  preenchido  de  acordo  com  a  norma  ISO 3166-1-alpha-2.{0}No caso das regiões autónomas da Madeira e Açores deve ser preenchido com:{0}«PT-AC» - Espaço fiscal da Região Autónoma dos Açores;{0}«PT-MA» - Espaço fiscal da Região Autónoma da Madeira.", Environment.NewLine);
			this.TaxCode = string.Format("4.4.4.14.6.3 * Texto 10{0}Código da taxa.{0}Código da taxa na tabela de impostos.{0}No caso do campo 2.5.1.1 - Código do tipo de imposto (TaxType) = IVA, deve ser preenchido com:{0}«RED» - Taxa reduzida;{0}«INT» - Taxa intermédia;{0}«NOR» - Taxa normal;{0}«ISE» - Isenta;{0}«OUT» - Outros, aplicável para os regimes especiais de IVA.{0}No caso do campo 2.5.1.1 - Código do tipo de imposto (TaxType) = «IS», deve ser preenchido com o código da verba respetiva.{0}No caso de não aplicabilidade de imposto deve ser preenchido com «NA».", Environment.NewLine);
			this.TaxPercentage = string.Format("4.4.4.14.6.4 ** Decimal{0}Percentagem da taxa de imposto.{0}O preenchimento é obrigatório, no caso de se tratar de uma percentagem de imposto.{0}A percentagem da taxa é correspondente ao imposto aplicável ao campo 4.4.4.14.4 - Valor a débito (DebitAmount) ou ao campo 4.4.4.14.5 - Valor a crédito (CreditAmount).{0}No caso de isenção ou não sujeição a imposto, utilizar este campo com o valor «0» (zero).", Environment.NewLine);
			this.TaxAmount = string.Format("4.4.4.14.6.5 ** Monetário{0}Montante do imposto.{0}O preenchimento é obrigatório, no caso de se tratar de uma verba fixa de imposto de selo. ", Environment.NewLine);
			this.TaxExemptionReason = string.Format("4.4.4.14.6.6 ** Texto 60{0}Motivo da isenção de imposto.{0}O preenchimento é obrigatório, quando os campos 4.4.4.16.4 - Percentagem da taxa de imposto (TaxPercentage) ou 4.4.4.16.5 - Montante do imposto (TaxAmount) são iguais a zero.{0}Deve ser referido o preceito legal aplicável.{0}Este campo deve ser igualmente preenchido nos casos de não sujeição aos impostos referidos na tabela 2.5 - Tabela de impostos (TaxTable).", Environment.NewLine);
			this.DocumentTotals = string.Format("4.4.4.15 *{0}Totais do documento", Environment.NewLine);
			this.TaxPayable = string.Format("4.4.4.15.1 * Monetário{0}Valor do imposto a pagar.", Environment.NewLine);
			this.NetTotal = string.Format("4.4.4.15.2 * Monetário{0}Total do documento sem impostos.{0}Este campo não deve incluir as parcelas referentes aos impostos constantes da tabela 2.5 - Tabela de impostos (TaxTable).", Environment.NewLine);
			this.GrossTotal = string.Format("4.4.4.15.3 * Monetário{0}Total do documento com impostos.{0}Este campo não deve refletir eventuais retenções na fonte constantes no campo 4.4.4.18 — Retenção na fonte (WithholdingTax).", Environment.NewLine);
			this.Settlement = string.Format("4.4.4.16{0}Acordos sobre descontos nas formas de pagamento.", Environment.NewLine);
			this.TotalSettlementAmount = string.Format("4.4.4.16.1 * Monetário{0}Montante dos descontos.{0}Total dos descontos concedidos aquando deste pagamento.", Environment.NewLine);
			this.Currency = string.Format("4.4.4.17{0}Moeda.{0}Esta estrutura é obrigatória no caso da emissão do documento ser em moeda estrangeira.", Environment.NewLine);
			this.CurrencyCode = string.Format("4.4.4.17.1 * Texto 3{0}Código de moeda.{0}No caso de moeda estrangeira deve ser preenchido de acordo com a norma ISO 4217.", Environment.NewLine);
			this.CurrencyAmount = string.Format("4.4.4.17.2 * Monetário{0}Valor total em moeda estrangeira.{0}Valor do campo 4.4.4.15.3 - Total do documento com impostos (GrossTotal) na moeda original do documento.", Environment.NewLine);
			this.ExchangeRate = string.Format("4.4.4.17.3 * Decimal{0}Taxa de câmbio.{0}Deve ser indicada a taxa de câmbio utilizada na conversão para EUR.", Environment.NewLine);
			this.WithholdingTax = string.Format("4.4.4.18{0}Retenção na fonte.", Environment.NewLine);
			this.WithholdingTaxType = string.Format("4.4.4.18.1 Texto 3{0}Código do tipo de imposto retido.{0}Neste campo deve ser indicado o tipo de imposto retido, preenchendo-o com:{0}«IRS» - Imposto sobre o rendimento de pessoas singulares;{0}«IRC» - Imposto sobre o rendimento de pessoas coletivas;{0}«IS» - Imposto do selo.", Environment.NewLine);
		}

		public string LineNumber { get; set; }
		public string SourceDocumentID { get; set; }
		public string OriginatingON { get; set; }
		public string InvoiceDate { get; set; }
		public string Description { get; set; }
		public string LineSettlementAmount { get; set; }
		public string DebitAmount { get; set; }
		public string CreditAmount { get; set; }
		public string Tax { get; set; }
		public string TaxType { get; set; }
		public string TaxCountryRegion { get; set; }
		public string TaxCode { get; set; }
		public string TaxPercentage { get; set; }
		public string TaxAmount { get; set; }
		public string TaxExemptionReason { get; set; }
		public string DocumentTotals { get; set; }
		public string TaxPayable { get; set; }
		public string NetTotal { get; set; }
		public string GrossTotal { get; set; }
		public string Settlement { get; set; }
		public string TotalSettlementAmount { get; set; }
		public string Currency { get; set; }
		public string CurrencyCode { get; set; }
		public string CurrencyAmount { get; set; }
		public string ExchangeRate { get; set; }
		public string WithholdingTax { get; set; }
		public string WithholdingTaxType { get; set; }
	}
}
