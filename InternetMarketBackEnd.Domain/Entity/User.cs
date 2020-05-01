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
            return BCrypt.Net.BCrypt.HashPassword(input);
        }

        public static Boolean VerifyMd5Hash(String input, String hash)
        {
            return BCrypt.Net.BCrypt.Verify(input, hash);
        }
    }
}
