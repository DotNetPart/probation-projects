using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeLibrary
{
    public class User
    {
        internal User() { }

        public User(string login, string password, bool isActive = false)
        {
            Login = login;
            Password = password;
            IsActive = isActive;
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = false;

    }
}
