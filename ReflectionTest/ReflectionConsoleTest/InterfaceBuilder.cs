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
        public void BuildInterface(Type type, string destPath)
        {
            IEnumerable<MemberInfo> members = type.GetTypeInfo().DeclaredMembers;
            var file = destPath + "//"+ "I" + type.Name + ".cs";
            File.Delete(file);
            StreamWriter sw = File.CreateText(file);

            sw.WriteLine($"public interface I{type.Name}");
            sw.WriteLine("{");

            foreach (var member in members)
            {
                switch (member.MemberType)
                {
                    case MemberTypes.Property:
                        {

                            var property = (PropertyInfo)member;
                            var propTypeName = property.PropertyType.Name;

                            if (property.PropertyType.IsGenericType)
                            {
                                sw.Write("    ");
                                sw.Write($"{ propTypeName.Split('`')[0] }<{ property.PropertyType.GetGenericArguments()[0].Name }> { property.Name } ");
                            }
                            else
                            {
                                
                                sw.Write("    ");
                                if (property.PropertyType.Namespace == "System")
                                {
                                    sw.Write($"{ propTypeName.ToLower() } { property.Name } ");
                                }
                                else
                                {
                                    sw.Write($"{ propTypeName } { property.Name } ");
                                }
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
                                if (method.ReturnType.Namespace == "System")
                                {
                                    sw.Write($"{ method.ReturnType.Name.ToLower() } { method.Name } ");
                                }
                                else
                                {
                                    sw.Write($"{ method.ReturnType.Name } { method.Name }");
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
