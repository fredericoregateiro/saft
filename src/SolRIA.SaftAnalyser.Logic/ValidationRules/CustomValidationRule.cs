using SolRia.Erp.MobileApp.Models.SaftV4;
using SolRIA.SaftAnalyser.Logic.Extensions;
using System.Linq;
using System.Text;

namespace SolRIA.SaftAnalyser.Logic.ValidationRules
{
	public class CustomValidationRule<T> : System.Windows.Controls.ValidationRule where T : BaseData
	{
		public override System.Windows.Controls.ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
		{
			T rowToValidate = (value as System.Windows.Data.BindingGroup).Items[0] as T;

			if (OpenedFileInstance.Instance.MensagensErro != null && OpenedFileInstance.Instance.MensagensErro.Count > 0)
			{
				var rowErrors =
					from m in OpenedFileInstance.Instance.MensagensErro
					where m.TypeofError == typeof(T) && m.UID.AreEqualIgnoreCase(rowToValidate.Pk)
					select m;

				if (rowErrors != null && rowErrors.Count() > 0)
				{
					StringBuilder errors = new StringBuilder();
					foreach (var invoiceError in rowErrors)
					{
						errors.AppendLine(invoiceError.Description);
					}

					//return the description errors found
					return new System.Windows.Controls.ValidationResult(false, errors.ToString());
				}
			}

			//no errors
			return System.Windows.Controls.ValidationResult.ValidResult;
		}
	}
}
