using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Msg
    {
        public long id;
        public string msg;
        public string fistName;

        public override string ToString()
        {
            return id + ":" + msg;
        }
    }
}
