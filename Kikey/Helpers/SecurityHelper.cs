using System.Security.Cryptography;
using System.Text;

namespace Kikey.Helpers
{
    public static class SecurityHelper
    {
        public static byte[] GetHash(string data)
        {
            return SHA256.HashData(Encoding.UTF8.GetBytes(data));
        }
    }
}