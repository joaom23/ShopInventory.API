using System.Globalization;
using System.Text;

namespace ShopInventory.API.ExtentionMethods;

public static class StringExtentions
{
    public static string RemoveDiacritics(this string input)
    {
        string normalizedString = input.Normalize(NormalizationForm.FormD);
        var stringBuilder = new System.Text.StringBuilder();

        foreach (char c in normalizedString)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                stringBuilder.Append(c);
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }
}
