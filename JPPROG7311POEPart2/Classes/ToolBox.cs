//st10081881
//15/05/2023

using JPPROG7311POEPart2.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JPPROG7311POEPart2.Classes
{
   public class ToolBox
   {
      //ensure only one instance is created, thus keeping the data
      private static readonly ToolBox instance = new ToolBox();
      public static ToolBox Instance => instance;
      
      //forces user to be logged in, used for development
      public bool ForceLogin = true;

      //singleton isnstances of objects
      public DBHandler _DBHandler = DBHandler.Instance;
      public ActiveUserClass _ActiveUserClass = ActiveUserClass.Instance;

      public PasswordHandler _PasswordHandler = new PasswordHandler();
   }
}
//==========================================END OF FILE============================================