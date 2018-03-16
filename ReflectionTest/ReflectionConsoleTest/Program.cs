using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var testClass = new SomeLibrary.Class1();
            Console.WriteLine(testClass.TestRetInt());
            Console.WriteLine(testClass.TestRetClass1());

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
