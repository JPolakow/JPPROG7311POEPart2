//st10081881
//15/05/2023

using JPPROG7311POEPart2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JPPROG7311POEPart2.Objects
{
   public class UserLoginShuttle
   {
      //ensure only one instance is created, thus keeping the data
      private static readonly UserLoginShuttle instance = new UserLoginShuttle();
      public static UserLoginShuttle Instance => instance;

      //users email
      private string UserEmail;
      //users plain password
      private string UserPlainPword;
      //users hashed password
      private string UserHashedPword;
      //users salt
      private string UserSalt;

      public string UserEmail1 { get => UserEmail; set => UserEmail = value; }
      public string UserPlainPword1 { get => UserPlainPword; set => UserPlainPword = value; }
      public string UserHashedPword1 { get => UserHashedPword; set => UserHashedPword = value; }
      public string UserSalt1 { get => UserSalt; set => UserSalt = value; }
   }
}
//==========================================END OF FILE============================================