using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaverAccountingSoftware.Data;
using WaverAccountingSoftware.Models;

namespace WaverAccountingSoftware.Controllers
{
    class LoginController
    {
        public static bool LoginCheck(string username, string password)
        {
            User user = MYSQLDatabase.GetUser(username, password);

            if(user != null)
            {
                Session.user = user;
                Session.tokenTime = DateTime.Now;
                return true;
            }

            return false;
        }
    }
}
