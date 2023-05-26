using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUPL.EXCEPTIONS
{
    internal class INVALIDTYPEEXCEPTION : MainException
    {
        public INVALIDTYPEEXCEPTION(string EXPECTEDTYPE, string TYPE, string FILENAME, int LINE)
        {
            message = "WRONG TYPE OF VALUE AT " + FILENAME + ":" + LINE.ToString() + "\nEXPECTED '" + EXPECTEDTYPE + "' GOT '" + TYPE + "'";
        }
    }
}
