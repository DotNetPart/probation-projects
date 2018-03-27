using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeLibrary
{
    interface IUserGenerator
    {
        User CreateRandomUser();
        int Count { get; set; }
    }
}
