using System.Text.RegularExpressions;

namespace Walaks.Poc.Minimal.Api.Common.Extensions
{
    public static class StringExensions
    {
        public static string RemoverMascara(this string str) => new string(Regex.Replace(str, @"\D", ""));
        public static string RemoverEspacosETabs(this string str)
        {
            return Regex.Replace(str, @"[\s\t]+", "");
        }
    }
}
