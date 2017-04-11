using System;
using System.Text.RegularExpressions;

namespace SolRIA.SaftAnalyser
{
	internal static class Validations
	{
		internal static bool CheckTaxRegistrationNumber(string taxRegistrationNumber)
		{
			if (string.IsNullOrEmpty(taxRegistrationNumber))
				return false;

			int checkDigit;
			char firstNumber;

			if (IsNumeric(taxRegistrationNumber) && taxRegistrationNumber.Length == 9)
			{
				firstNumber = taxRegistrationNumber[0];

				if (firstNumber.Equals('1') || firstNumber.Equals('2') || firstNumber.Equals('5') || firstNumber.Equals('6') || firstNumber.Equals('8') || firstNumber.Equals('9'))
				{
					checkDigit = (Convert.ToInt16(firstNumber.ToString()) * 9);
					for (int i = 2; i <= 8; i++)
					{
						checkDigit += Convert.ToInt16(taxRegistrationNumber[i - 1].ToString()) * (10 - i);
					}
					checkDigit = 11 - (checkDigit % 11);

					if (checkDigit >= 10)
						checkDigit = 0;

					if (checkDigit.ToString() == taxRegistrationNumber[8].ToString())
						return true;
				}
			}

			return false;
		}

		internal static bool IsNumeric(string inputString)
		{
			return Regex.IsMatch(inputString, "^[0-9]+$");
		}
	}
}
