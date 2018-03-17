using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SomeLibrary;

namespace ReflectionConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var user = new User("tsar", "12345", true);
                var users = new UserStorage();

                for (int i = 0; i < 20; i++)
                {
                    users.AddRandomUser();
                }

                users.AddUser(user);
                users.DeleteUser(users.FindByLogin("tsar"));
                users.DeleteUser(user);
                users.DeleteUser(user);

                
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                Type[] typelist = new Type[0];
                foreach (var assembly in assemblies)
                {
                    typelist = assembly.GetTypes().Where(t => t.Namespace == "SomeLibrary").ToArray();

                    if (typelist.Any())
                    {
                        break;
                    }
                }

                if (!typelist.Any())
                {
                    throw new Exception("Сan't find the target assembly.");
                }

                Console.WriteLine("\nReflection test: \n");

                foreach (Type type in typelist)
                {
                    if (type.IsClass)
                    {
                        Console.WriteLine($"--Class name: { type.Name }");

                        foreach (var member in type.GetMembers())
                        {
                            Console.WriteLine($"----{ member.MemberType } name: { member.Name }");
                        }
                        Console.WriteLine();
                    }
                } 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
