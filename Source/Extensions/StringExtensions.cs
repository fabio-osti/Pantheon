using System.Globalization;
using System.Text;

namespace OmnisExtensionum.Extensions;

/// <summary>
/// 	Extensions of string.
/// </summary>
public static class StringExtensions
{
	/// <summary>
	/// 	Remove any diacritics (accents) of <paramref name="text"/>.
	/// </summary>
	/// 
	/// <param name="text">
	/// 	Text containing diacritics.
	/// </param>
	/// 
	/// <returns>
	/// 	The <paramref name="text"/> without any diacritics.
	/// </returns>
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
