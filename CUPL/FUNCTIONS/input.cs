using CUPLInterpreter;

namespace CUPL.FUNCTIONS
{
    public class input
    {
        public input(ref Variable variable)
        {
            if(variable.type == "string")
            {
                variable.value = Console.ReadLine();
            }
            else
            {
                Program.ThrowCompilationException(new EXCEPTIONS.INVALIDTYPEEXCEPTION("string", variable.type, Program.filename, Program.currentline));
            }
        }
    }
}