using CUPLInterpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUPL.FUNCTIONS
{
    public class ToString
    {
        public ToString(ref Variable arg1, Variable arg2)
        {
            if (arg1.type == "string")
            {
                string arg2data = arg2.value.ToString();
                arg1.value = arg2data;
            }
            else
            {
                Program.ThrowCompilationException(new EXCEPTIONS.INVALIDTYPEEXCEPTION("string", arg1.type, Program.filename, Program.currentline));
            }
        }
        public ToString(ref Variable arg1, string arg2)
        {
            if (arg1.type == "string")
            {
                string arg2data = arg2.ToString();
                arg1.value = arg2data;
            }
            else
            {
                Program.ThrowCompilationException(new EXCEPTIONS.INVALIDTYPEEXCEPTION("string", arg1.type, Program.filename, Program.currentline));
            }
        }
    }
}
