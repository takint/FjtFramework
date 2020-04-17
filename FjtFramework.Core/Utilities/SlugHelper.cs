using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace FjtFramework.Core.Utilities
{
    public static class SlugHelper
    {
        public static string GenerateSlug(string phrase)
        {
            IdnMapping idn = new IdnMapping();
            string punyCode = idn.GetAscii(phrase);
            return punyCode;
        }

        public static string RemoveDiacritics(string text)
        {
            var s = new string(text.Normalize(NormalizationForm.FormD)
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray());

            return s.Normalize(NormalizationForm.FormC);
        }
    }
}
