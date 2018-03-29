using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeLibrary
{
    public interface IUserStorage
    {
        IEnumerable<User> GetUsers();

        void AddUser(User user);

        void AddRandomUser();

        Boolean DeleteUser(User user);

        User FindByLogin(String login);
    }

}
