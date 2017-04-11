using SolRia.Erp.MobileApp.Models.SaftV4;
using SolRIA.SaftAnalyser.Interfaces;
using SolRIA.SaftAnalyser.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SolRIA.SaftAnalyser.Services
{
	public class SaftValidator : ISaftValidator
	{
		List<Error> ErrorList = new List<Error>();

		public void ValidateSaft(AuditFile file)
		{
			ValidateSaftCustomers();
			ValidateSaftHeader(file.Header);
			ValidateSaftInvoices();
			ValidateSaftProducts();
			ValidateSaftTaxes();
		}
		public void ValidateSaftCustomers()
		{
		}

		public void ValidateSaftHeader(Header header)
		{
			ErrorList.Add(header.ValidateTaxRegistrationNumber());
			ErrorList.Add(header.ValidateAuditFileVersion());
			ErrorList.Add(header.ValidateBusinessName());
			ErrorList.Add(header.ValidateEmail());
			ErrorList.Add(header.ValidateAddressDetail());
			ErrorList.Add(header.ValidateBuildingNumber());
			ErrorList.Add(header.ValidateCity());
			ErrorList.Add(header.ValidateCountry());
			ErrorList.Add(header.ValidatePostalCode());
			ErrorList.Add(header.ValidateRegion());
			ErrorList.Add(header.ValidateStreetName());
			ErrorList.Add(header.ValidateCompanyID());
			ErrorList.Add(header.ValidateCompanyName());
			ErrorList.Add(header.ValidateCurrencyCode());
			ErrorList.Add(header.ValidateDateCreated());
			ErrorList.Add(header.ValidateEndDate());
			ErrorList.Add(header.ValidateFax());
			ErrorList.Add(header.ValidateFiscalYear());
			ErrorList.Add(header.ValidateHeaderComment());
			ErrorList.Add(header.ValidateProductCompanyTaxID());
			ErrorList.Add(header.ValidateProductID());
			ErrorList.Add(header.ValidateProductVersion());
			ErrorList.Add(header.ValidateSoftwareCertificateNumber());
			ErrorList.Add(header.ValidateStartDate());
			ErrorList.Add(header.ValidateTaxAccountingBasis());
			ErrorList.Add(header.ValidateTaxEntity());
			ErrorList.Add(header.ValidateTelephone());
			ErrorList.Add(header.ValidateWebsite());
		}

		public void ValidateSaftInvoices()
		{
		}

		public void ValidateSaftProducts()
		{
		}

		public void ValidateSaftTaxes()
		{
		}

		public int GetSaftErrors()
		{
			return ErrorList.Count();
		}

		public int GetSaftHeaderErrors()
		{
			return ErrorList.Where(c => c.TypeofError == typeof(Header)).Count();
		}
	}
}
