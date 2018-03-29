using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionConsoleTest
{
    public class InterfaceBuilder
    {
        public void CreateInterfacesByTypes(IEnumerable<Type> types, string destinationPath)
        {
            foreach (Type type in types)
            {
                if (type.IsPublic && !type.IsAbstract && type.IsClass)
                {
                    var builder = new InterfaceBuilder();
                    builder.BuildInterfaceToFile(type, destinationPath);
                }
            }
        }

        public void BuildInterfaceToFile(Type type, string destinationPath)
        {
            var file = destinationPath + "//"+ "I" + type.Name + ".cs";
            StreamWriter sw = File.CreateText(file);

            sw.WriteLine($"public interface I{type.Name}");
            sw.WriteLine("{");

            IEnumerable<MemberInfo> members = type.GetTypeInfo().DeclaredMembers;
            foreach (var member in members)
            {
                switch (member.MemberType)
                {
                    case MemberTypes.Property:
                        { 
                            var property = (PropertyInfo)member;

                            if (property.PropertyType.IsGenericType)
                            {
                                sw.Write("    ");
                                sw.Write($"{ property.PropertyType.Name.Split('`')[0] }<{ property.PropertyType.GetGenericArguments()[0].Name }> { property.Name } ");
                            }
                            else
                            {
                                sw.Write("    ");
                                sw.Write($"{ property.PropertyType.Name } { property.Name } ");
                            }

                            var accessors = property.GetAccessors();

                            if (accessors.Any())
                            {
                                sw.Write("{ ");
                                foreach (var acc in accessors)
                                {
                                    sw.Write($"{ acc.Name.Split('_')[0] }; ");
                                }
                                sw.WriteLine("}");
                            }
                            else
                            {
                                sw.WriteLine(";");
                            }

                        }
                        break;

                    case MemberTypes.Method:
                        {
                            var methodBase = (MethodBase)member;
                            var attributes = methodBase.Attributes;

                            var method = (MethodInfo)member;
                            if ((attributes & MethodAttributes.SpecialName) == MethodAttributes.SpecialName)
                            {
                                break;
                            }
                            if (method.ReturnType.IsGenericType)
                            {
                                sw.Write("    ");
                                sw.Write($"{ method.ReturnType.Name.Split('`')[0] }<{ method.ReturnType.GetGenericArguments()[0].Name }> { method.Name }");
                            }
                            else
                            {
                                sw.Write("    ");
                                    if (method.ReturnType.Name == "Void")
                                    {
                                        sw.Write($"void { method.Name } ");
                                    }
                                    else
                                    {
                                        sw.Write($"{ method.ReturnType.Name } { method.Name } ");
                                    }
                            }


                            sw.Write("(");
                            var parametrs = methodBase.GetParameters();
                            int i = 0;
                            foreach (var parametr in parametrs)
                            {
                                if (parametrs.Count() == i + 1)
                                {
                                    sw.Write($"{ parametr.ParameterType.Name } { parametr.Name }");
                                }
                                else
                                {
                                    sw.Write($"{ parametr.ParameterType.Name } { parametr.Name }, ");
                                }
                                i++;
                            }
                            sw.WriteLine(");");
                        }
                        break;
                }
            }
            sw.WriteLine("}");
            Console.WriteLine($"I{type.Name}.cs successfully created");
            sw.Close();
        }
    }
}
