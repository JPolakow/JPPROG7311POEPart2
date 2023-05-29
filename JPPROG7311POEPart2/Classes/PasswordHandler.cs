//st10081881
//15/05/2023

using JPPROG7311POEPart2.EntityFramework;
using JPPROG7311POEPart2.Objects;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI.WebControls;

namespace JPPROG7311POEPart2.Classes
{
   public class PasswordHandler
   {
      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method to generate new password hash and salt, return in LoginCredential object
      /// </summary>
      /// <param name="userPassword"></param>
      /// <returns></returns>
      public LoginCredential CreateNewPassword(string userPassword)
      {
         try
         {
            LoginCredential NewUserLogin = new LoginCredential();

            //var of type byte, 
            byte[] salt = new byte[128 / 8];
            // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
            using (var rngCSP = new RNGCryptoServiceProvider())
            {
               rngCSP.GetNonZeroBytes(salt);
            }

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: userPassword,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            NewUserLogin.Hash = hashed;
            NewUserLogin.Salt = Convert.ToBase64String(salt);

            return NewUserLogin;
         }
         catch (Exception ex)
         {
            return null;
         }
      }

      //-------------------------------------------------------------------------------------------
      /// <summary>
      /// method to check users password is correct, takes UserLogin class, return bool
      /// </summary>
      /// <param name="userLogin"></param>
      /// <returns></returns>
      public bool CheckOldPassword(UserLoginShuttle userLogin)
      {
         string originalSalt = userLogin.UserSalt1;
         string originalHash = userLogin.UserHashedPword1;
         string newPlainPassword = userLogin.UserPlainPword1;

         byte[] salt = Convert.FromBase64String(originalSalt);

         // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
         string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
             password: newPlainPassword,
             salt: salt,
             prf: KeyDerivationPrf.HMACSHA256,
             iterationCount: 100000,
             numBytesRequested: 256 / 8));

         if (hashed == originalHash)
            return true;
         else
            return false;
      }
   }
}
//==========================================END OF FILE============================================