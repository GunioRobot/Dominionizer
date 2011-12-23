namespace Dominionizer.Phone.Core
{
    using System.Text.RegularExpressions;

    public static class Utils
    {
        public static string CamelCaseToProperSpace(string value)
        {
            return Regex.Replace(value, "([A-Z]{1,2}|[0-9]+)", " $1").TrimStart();
        }
    }
}