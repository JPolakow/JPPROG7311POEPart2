//st10081881
//15/05/2023

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JPPROG7311POEPart2.Classes
{
   public class ActiveUserClass
   {
      //ensure only one instance is created, thus keeping the data
      private static readonly ActiveUserClass instance = new ActiveUserClass();
      public static ActiveUserClass Instance => instance;

      //active user ID
      private int UserID = -1;
      //active user type
      private string UserType = string.Empty;

      public int UserID1 { get => UserID; set => UserID = value; }
      public string UserType1 { get => UserType; set => UserType = value; }
   }
}
//==========================================END OF FILE============================================