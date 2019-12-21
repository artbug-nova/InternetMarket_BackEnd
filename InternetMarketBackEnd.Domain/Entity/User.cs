using InternetMarketBackEnd.Core.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace InternetMarketBackEnd.Domain.Entity
{
    public class User : BaseEntity<long>
    {
        String _name;
        String _email;
        String _password;

        public String Name { get => _name; set => _name = value; }
        public String Email { get => _email; set => _email = value; }
        public String Password { get => _password; set => _password = GetMd5Hash(value); }
        public long UserRoleId { get; set; }
        public UserRole UserRole { get; set; }


        public static String GetMd5Hash(String input)
        {
            using(MD5 HashMD5 = MD5.Create())
            {
                byte[] data = HashMD5.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder stringBuilder = new StringBuilder();

                for(int i = 0; i < data.Length; i++)
                {
                    stringBuilder.Append(data[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }

        public static Boolean VerifyMd5Hash(String input, String hash)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                // Hash the input.
                string hashOfInput = GetMd5Hash(input);

                // Create a StringComparer an compare the hashes.
                StringComparer comparer = StringComparer.OrdinalIgnoreCase;

                if (0 == comparer.Compare(hashOfInput, hash))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
