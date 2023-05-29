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
      
      public bool ForceLogin = true;

      public DBHandler _DBHandler = DBHandler.Instance;
      public PasswordHandler _PasswordHandler = new PasswordHandler();
      public ActiveUserClass _ActiveUserClass = ActiveUserClass.Instance;
   }
}
//==========================================END OF FILE============================================