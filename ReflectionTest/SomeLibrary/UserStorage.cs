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

        public void DeleteUser(User user)
        {
            try
            {
                if (users.Remove(user))
                {
                    throw new Exception("Can't delete. This user doesn't exist.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }

        public User FindByLogin(string login)
        {
            foreach (var user in users)
            {
                if (user.Login == login)
                {
                    return user;
                }
            }
            return null;
        }
        
    }
}
