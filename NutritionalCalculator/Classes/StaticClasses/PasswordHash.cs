using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NutritionalCalculator.Classes
{
    static class PasswordHash
    {
        public static string GetPasswordHash (string password)
        {
            Byte[] result = Encoding.Unicode.GetBytes(password);
            return Convert.ToBase64String(result);
        }

        public static string GetPassword(string passworHash)
        {
            Byte[] result = Convert.FromBase64String(passworHash);
            return Encoding.Unicode.GetString(result);
        }
    }
}
