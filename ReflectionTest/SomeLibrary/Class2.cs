using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeLibrary
{
    internal class Class2
    {
        Class2 TestRetClass2()
        {
            var testClass = new Class2();
            return testClass;
        }
        string TestRetString()
        {
            return "42";
        }
    }
}
