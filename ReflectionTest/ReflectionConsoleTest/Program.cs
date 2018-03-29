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


            var types = GetTypesByNamespace("SomeLibrary");

            ConsoleReflection(types);
            CreateInterfaces(types, "C:\\Users\\suhan\\Desktop"); // Change the path, if not working

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        private static IEnumerable<Type> GetTypesByNamespace(string assemblyNamespace)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                var types = assembly.GetTypes().Where(t => t.Namespace == assemblyNamespace);
                if (types.Any())
                {
                    return types;
                }
            }
            return null;
        }

        private static void ConsoleReflection(IEnumerable<Type> types)
        {
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
        }

        private static void CreateInterfaces(IEnumerable<Type> types, string destPath)
        { 
            foreach (Type type in types)
            {
                if (type.IsPublic && !type.IsAbstract && type.IsClass)
                {
                    var builder = new InterfaceBuilder();
                    builder.BuildInterface(type, destPath);
                }
            }
        }
    }
}
