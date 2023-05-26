using CUPL.FUNCTIONS;
using CUPLInterpreter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUPL.FUNCTIONS
{
    public class startProcess
    {
        public startProcess(string text)
        {
            try
            {
                Process.Start(text);
            }
            catch
            {
                CUPLInterpreter.Program.ThrowCompilationException(new EXCEPTIONS.INVALIDPROCESSEXCEPTION(Program.currentline, Program.filename, "startProcess"));
            }
        }
        public startProcess(CUPLInterpreter.Variable text)
        {
            Variable v = new Variable();
            v.type = "string";
            v.value = "";
            v.accessLevel = 0;
            new ToString(ref v, text);

            var tex = v.value.ToString();
            if (tex.EndsWith("\r"))
            {
                tex = tex.Substring(1);
                tex = tex.Substring(0, tex.Length - 2);
            }
            if (tex.EndsWith('"'))
            {
                tex = tex.Substring(1);
                tex = tex.Substring(0, tex.Length - 1);
            }
            try
            {
                Process.Start(tex);
            }
            catch
            {
                CUPLInterpreter.Program.ThrowCompilationException(new EXCEPTIONS.INVALIDPROCESSEXCEPTION(Program.currentline,Program.filename, "startProcess"));
            }
        }
    }
}
