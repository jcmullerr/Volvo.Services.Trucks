using System.Security.Cryptography;
using System.Text;

namespace Volvo.Services.Trucks.Infra.CrossCutting.Extensions
{
    public static class StringExtensions
    {
        public static string ToMd5Hash(this string input)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                return Encoding.UTF8.GetString(result);
            }
        }
    }
}