using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaverAccountingSoftware.Models;

namespace WaverAccountingSoftware.Data
{
    public static class Session
    {
        public static User user;

        public static DateTime tokenTime;

        public static bool RenewSession()
        {
            if(user.UserName != null) { 
                User userFromDB = MYSQLDatabase.GetUser(user.UserName, user.UserPassword);
                if(userFromDB != null)
                {
                    user = userFromDB;
                    tokenTime = DateTime.Now;
                    return true;
                } 
            }

            return false;
        }
    }
}
