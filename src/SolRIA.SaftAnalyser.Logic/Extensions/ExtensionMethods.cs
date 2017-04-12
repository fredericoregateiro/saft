using System;

namespace SolRIA.SaftAnalyser.Logic.Extensions
{
	public static class ExtensionMethods
	{
		public static string FormatTooltipWithError(this string tooltip, string error)
		{
			if (tooltip.Contains("Erro:"))
				return tooltip;
			return string.Format("{0}{2}{2}Erro:{2}{1}", tooltip, error, Environment.NewLine);
		}

		public static bool AreEqualIgnoreCase(this string s1, string s2)
		{
			if (string.IsNullOrEmpty(s1) && !string.IsNullOrEmpty(s2) || !string.IsNullOrEmpty(s1) && string.IsNullOrEmpty(s2))
				return false;

			return s1.Length == s2.Length && s1.IndexOf(s2, StringComparison.OrdinalIgnoreCase) == 0;
		}
	}
}
