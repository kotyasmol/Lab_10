using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    public interface IInit
    {
        Person Init();
        Person RandomInit();
    }
}
