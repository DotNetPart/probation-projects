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
            var user = new User("tsar", "12345", true);
            var users = new UserStorage();

            for (int i = 0; i < 20; i++)
            {
                users.AddRandomUser();
            }

            users.AddUser(user);
            users.DeleteUser(users.FindByLogin("tsar"));
            users.DeleteUser(user);

            GetReflectionInfo("SomeLibrary");

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        public static bool GetReflectionInfo(string assemblyNamespace)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            IEnumerable<Type> types = new Type[0];
            foreach (var assembly in assemblies)
            {
                types = assembly.GetTypes().Where(t => t.Namespace == assemblyNamespace);

                if (types.Any())
                {
                    break;
                }
            }

            if (!types.Any())
            {
                return false;
            }

            Console.WriteLine("\nReflection test: \n");

            foreach (Type type in types)
            {
                IEnumerable<MemberInfo> membersInfo = type.GetTypeInfo().DeclaredMembers;
                if (type.IsClass)
                {
                    Console.WriteLine($"--Class name: { type.Name }");

                    foreach (var member in membersInfo)
                    {
                        Console.WriteLine($"----{ member.MemberType } name: { member.Name }");
                    }
                    Console.WriteLine();
                }
            }

            return true;
        }
    }
}
