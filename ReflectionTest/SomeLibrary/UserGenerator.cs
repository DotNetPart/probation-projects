using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeLibrary
{
    internal static class UserGenerator
    {
        internal static User CreateRandomUser()
        {
            Random rnd = new Random();

            var login = rnd.Next().ToString();
            var password = rnd.Next().ToString();
            var isActive = true;

            User user = new User(login, password, isActive);

            return user;
        }
    }
}
