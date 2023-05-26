using CUPLInterpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUPL.FUNCTIONS
{
    public class ToInt
    {
        public ToInt(ref Variable arg1, Variable arg2)
        {
            if (arg1.type == "int")
            {
                string arg2data = arg2.value.ToString();
                string number = "";
                for (int i = 0; i < arg2data.Length; i++)
                {
                    if (char.IsDigit(arg2data[i]))
                    {
                        number += arg2data[i];
                    }
                }
                arg1.value = Convert.ToInt32(number);
            }
            else
            {
                Program.ThrowCompilationException(new EXCEPTIONS.INVALIDTYPEEXCEPTION("int", arg1.type, Program.filename, Program.currentline));
            }
        }
        public ToInt(ref Variable arg1, string arg2)
        {
            if (arg1.type == "int")
            {
                string arg2data = arg2.ToString();
                string number = "";
                for (int i = 0; i < arg2data.Length; i++)
                {
                    if (char.IsDigit(arg2data[i]))
                    {
                        number += arg2data[i];
                    }
                }
                arg1.value = Convert.ToInt32(number);
                
            }
            else
            {
                Program.ThrowCompilationException(new EXCEPTIONS.INVALIDTYPEEXCEPTION("int", arg1.type, Program.filename, Program.currentline));
            }
        }
    }
}
