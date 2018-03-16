using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeLibrary
{
    public class Class1
    {
        public int TestRetInt()
        {
            return 42;
        }
        public Class1 TestRetClass1()
        {
            var testClass = new Class1();
            return testClass;
        }
        public IEnumerable<T> TestRetEnumerable<T>()
        {
            Stack<T> stackOfT = new Stack<T>();
            return stackOfT;
        }

        public IEnumerable TestRetEnumerable()
        {
            Stack stackOfT = new Stack();
            return stackOfT;
        }
    }
}
