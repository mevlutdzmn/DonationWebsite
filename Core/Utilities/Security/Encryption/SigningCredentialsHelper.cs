using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    
    public class SigningCredentialsHelper
    {
        //hangi anahtar hangi algoritma
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            //securityKey-güvenlik anahtarın bu
            //SecurityAlgorithms.HmacSha512Signature-şifreleme algoritman budur 
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
