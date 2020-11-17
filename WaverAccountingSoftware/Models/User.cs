using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaverAccountingSoftware.Models
{
    public class User
    {

        private int userID;

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string userPassword;

        public string UserPassword
        {
            get { return userPassword; }
            set { userPassword = value; }
        }

        private string userType;

        public string UserType
        {
            get { return userType; }
            set { userType = value; }
        }

        public User(int userID, string userName, string userPassword, string userType)
        {
            this.userID = userID;
            this.userName = userName;
            this.userPassword = userPassword;
            this.userType = userType;
        }
    }
}
