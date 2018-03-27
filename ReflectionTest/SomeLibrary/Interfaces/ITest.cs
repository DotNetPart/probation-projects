using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeLibrary
{
    public interface ITest
    {
        IEnumerable<User> GetUsers(Int32 para, String data);
        List<Int32> gee();
    }
}
