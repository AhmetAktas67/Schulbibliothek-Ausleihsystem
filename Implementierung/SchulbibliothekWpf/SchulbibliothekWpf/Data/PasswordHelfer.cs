using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SchulbibliothekWpf.Data
{
    internal class PasswordHelfer
    {
        public static string Hash(string passwort)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(passwort));
            return Convert.ToBase64String(bytes);
        }
    }
}
