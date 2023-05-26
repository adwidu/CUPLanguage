using CUPLInterpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUPL.FUNCTIONS
{
    public class ToBool
    {
        public ToBool(ref Variable arg1, Variable arg2)
        {
            if (arg1.type == "bool")
            {
                arg2.value = arg2.value.ToString().Substring(1, arg2.value.ToString().Length - 2);
                bool arg2data = !string.IsNullOrEmpty(arg2.value.ToString());
                arg1.value = arg2data;
            }
            else
            {
                Program.ThrowCompilationException(new EXCEPTIONS.INVALIDTYPEEXCEPTION("bool", arg1.type, Program.filename, Program.currentline));
            }
        }
        public ToBool(ref Variable arg1, string arg2)
        {
            if (arg1.type == "bool")
            {
                arg2 = arg2.Substring(1, arg2.Length - 2);
                bool arg2data = !string.IsNullOrEmpty(arg2.ToString());
                arg1.value = arg2data;
            }
            else
            {
                Program.ThrowCompilationException(new EXCEPTIONS.INVALIDTYPEEXCEPTION("bool", arg1.type, Program.filename, Program.currentline));
            }
        }
    }
}
