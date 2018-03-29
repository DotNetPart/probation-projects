using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeLibrary
{
    public interface IUser
    {
        String Login { get; }
        String Password { get; }
        Boolean IsActive { get; set; }
    }



}
