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
            User user = new User();
            Random rnd = new Random();

            user.Login = rnd.Next().ToString();
            user.Password = rnd.Next().ToString();
            user.IsActive = true;
            
            return user;
        }
    }
}
