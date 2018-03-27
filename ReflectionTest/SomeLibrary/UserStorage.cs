using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeLibrary
{
    public class UserStorage
    {
        private List<User> users = new List<User>();

        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        public void AddUser(User user)
        {
            users.Add(user); 
        }

        public void AddRandomUser()
        {
            AddUser(UserGenerator.CreateRandomUser());
        }

        public bool DeleteUser(User user)
        {
            if (!users.Remove(user))
            {
                return false;
            }

            return true;
            
        }

        public User FindByLogin(string login)
        {
            return users.Where(u => u.Login == login).FirstOrDefault();
        }
        
    }
}
