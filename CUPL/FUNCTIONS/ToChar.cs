using CUPLInterpreter;

namespace CUPL.FUNCTIONS
{
    public class ToChar
    {
        public ToChar(ref Variable arg1, Variable arg2)
        {
            if (arg1.type == "char")
            {
                arg2.value = arg2.value.ToString().Substring(1, arg2.value.ToString().Length - 2);
                string arg2data = arg2.value.ToString();
                arg1.value = arg2data[0];
            }
            else
            {
                Program.ThrowCompilationException(new EXCEPTIONS.INVALIDTYPEEXCEPTION("char", arg1.type, Program.filename, Program.currentline));
            }
        }
        public ToChar(ref Variable arg1, string arg2)
        {
            if (arg1.type == "char")
            {
                arg2 = arg2.Substring(1, arg2.Length - 2);
                string arg2data = arg2.ToString();
                arg1.value = arg2data[0];
            }
            else
            {
                Program.ThrowCompilationException(new EXCEPTIONS.INVALIDTYPEEXCEPTION("char", arg1.type, Program.filename, Program.currentline));
            }
        }
    }
}