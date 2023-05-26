using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUPL.EXCEPTIONS
{
    internal class VARUSEDBEFOREDECLARATIONEXCEPTION : MainException
    {
        public VARUSEDBEFOREDECLARATIONEXCEPTION(string VARNAME, int LINE, string FILENAME) {
            this.message = ("VARIABLE '" + VARNAME + "' IS BEING USED BEFORE DECLARATION OR IS NOT DECLARED AT ALL AT " + FILENAME+ ":" +LINE.ToString());
        }

    }
}
