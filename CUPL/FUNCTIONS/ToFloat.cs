using CUPLInterpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUPL.FUNCTIONS
{
    public class ToFloat
    {
        public ToFloat(ref Variable arg1, Variable arg2)
        {
            if (arg1.type == "float")
            {
                string arg2data = arg2.value.ToString();
                string number = "";
                for (int i = 0; i < arg2data.Length; i++)
                {
                    if (char.IsDigit(arg2data[i]))
                    {
                        number += arg2data[i];
                    }
                    if (arg2data[i] == '.') { number += arg2data[i]; }
                }
                arg1.value = double.Parse(number, System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                Program.ThrowCompilationException(new EXCEPTIONS.INVALIDTYPEEXCEPTION("float", arg1.type, Program.filename, Program.currentline));
            }
        }
        public ToFloat(ref Variable arg1, string arg2)
        {
            if (arg1.type == "float")
            {
                string arg2data = arg2.ToString();
                string number = "";
                for (int i = 0; i < arg2data.Length; i++)
                {
                    if (char.IsDigit(arg2data[i]))
                    {
                        number += arg2data[i];
                    }
                    if (arg2data[i] == '.') { number += arg2data[i]; }
                }
                arg1.value = double.Parse(number, System.Globalization.CultureInfo.InvariantCulture);
            }
            else
            {
                Program.ThrowCompilationException(new EXCEPTIONS.INVALIDTYPEEXCEPTION("float", arg1.type, Program.filename, Program.currentline));
            }
        }
    }
}
