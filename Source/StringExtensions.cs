using System.Globalization;
using System.Text;

static public class StringExtensions
{
	public static string RemoveDiacritics(this string text)
	{
		var builder = new StringBuilder();
		foreach (var c in text.Normalize(NormalizationForm.FormD)) {
			if (
				CharUnicodeInfo.GetUnicodeCategory(c)
					!= UnicodeCategory.NonSpacingMark
			) {
				builder.Append(c);
			}
		}
		return builder.ToString().Normalize(NormalizationForm.FormC);
	}
}