namespace Dacanetdev.ECommerce.Infrastructure.CosmosDb.Extensions
{
    public static class StringExtensions
    {
        public static string ToCamelCaseString(this string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                return char.ToLowerInvariant(str[0]) + str.Substring(1);
            }

            return str;
        }
    }
}
