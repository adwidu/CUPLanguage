using CUPLInterpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUPL.FUNCTIONS
{
    public class print
    {
        public print(string text) {
            Console.WriteLine(text);
        }
        public print(CUPLInterpreter.Variable text)
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
            Console.WriteLine(tex);
        }
    }
}
