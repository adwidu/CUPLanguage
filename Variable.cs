using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CUPLInterpreter
{
    public class Variable
    {
        public static Variable[] Variables = new Variable[0];
        public Object value;
        public string name;
        public string type;
        public int accessLevel;
        public Variable()
        {
            value = new Object();
            name = "NEWMADEVARIABLE<<M>>";
            type = "NONE";
            accessLevel = 0;
        }
    }
}
