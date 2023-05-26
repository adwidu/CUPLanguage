using CUPLInterpreter;

namespace CUPL.FUNCTIONS
{
    public class Wait
    {
        public Wait(string time)
        {
            var v = new CUPLInterpreter.Variable();
            v.name = "TEMP";
            v.value = "";
            v.accessLevel = 0;
            v.type = "int";
            var t = new ToInt(ref v, time);

            Thread.Sleep((int)v.value);
        }
        public Wait(CUPLInterpreter.Variable time)
        {
            if(time.type == "int")
            {
                Thread.Sleep((int)time.value);
            }
            else
            {
                CUPLInterpreter.Program.ThrowCompilationException(new CUPL.EXCEPTIONS.INVALIDTYPEEXCEPTION("int", time.type, CUPLInterpreter.Program.filename, CUPLInterpreter.Program.currentline)); ;
            }
        }
    }
}