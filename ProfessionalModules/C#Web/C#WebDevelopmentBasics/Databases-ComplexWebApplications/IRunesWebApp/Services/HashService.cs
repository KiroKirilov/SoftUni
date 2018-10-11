namespace IRunesWebApp.Services
{
    using IRunesWebApp.Services.Contracts;
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class HashService: IHashService
    {
        private const string Salt = "DAMN_IS_NOT_A_7!";

        public string Hash(string stringToHash)
        {
            stringToHash = stringToHash + Salt;

            using (var sha256 = SHA256.Create())
            {  
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hash;
            }
        }
    }
}
