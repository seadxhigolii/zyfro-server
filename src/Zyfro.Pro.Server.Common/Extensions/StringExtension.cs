using System;

namespace Zyfro.Pro.Server.Common.Extensions
{
    public static class StringExtension
    {
        public static string FirstCharToUpper(this string input)
          => string.Concat(input[0].ToString().ToUpper(), input.AsSpan(1));
    }
}
