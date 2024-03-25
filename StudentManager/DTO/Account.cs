using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Account
    {
        private string username, hashedPassword, email;
        public Account(string username = "", string hashedPassword = "", string email = "")
        {
            this.username = username;
            this.hashedPassword = hashedPassword;
            this.email = email;
        }


        public string Username
        {
            get { return username; }
        }

        public string HashedPassword
        {
            get { return hashedPassword; }
        }

        public string Email
        {
            get { return email; }
        }


    }
}
