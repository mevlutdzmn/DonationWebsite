using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        // verdiğimiz bir passwordun hash ini oluşturuyor bu method,saltınıda oluşturuyor
        public static void CreatePasswordHash
            (string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            //kullanacağımız algoritma
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                //(Encoding.UTF8.GetBytes(password)----> bir stringin byte karşılığını almak için kullanılır
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));


            }
        }
        //passwordhash ı doğrulamak için yazıldı
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                //hesaplanan hashın tüm değerlerini dolaş 
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }


        }
    }
}
