using CUPL.EXCEPTIONS;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace CUPLInterpreter
{
    public unsafe class Program
    {
        public static bool debug = true;
        public static int currentline = 0;
        public static string filename;
        public static bool terminate = false;
        public static void Main(string[] args)
        {
            Console.Clear();
            filename = "ASD.cupl";
            var _Lines = new StreamReader(filename).ReadToEnd().Replace("\r","");
            var Lines = _Lines.Replace("\t", "");

            AddVariable("null", "string");
            Variable.Variables[0].value = CUPL.Constants.NONE;
            Variable.Variables[0].type = "BUILTINCONSTANT";
            Variable.Variables[0].accessLevel = 1;
            while (terminate == false)
            {
                Variable.Variables[variable("null")].value = CUPL.Constants.NONE;
                for (int i = 0; i < Lines.Split("\n").Length; i++)
                {
                    if(terminate)
                    {
                        break;
                    }
                    currentline++;
                    var line = Lines.Split("\n")[i];
                    var code = line.Split(" ");

                    // In case its a variable
                    var accessLevel = 0;
                    var typeIndex = 0;
                    var variableLine = false;

                    void ReUseVariable()
                    {
                        if (line.Contains("="))
                        {
                            var strValue = line.Split("=")[1];
                            if (strValue[0] == ' ')
                            {
                                strValue = strValue.Substring(1);
                            }
                            var type = GetType(strValue);
                            if (type == "bool")
                            {
                                var True = "true";
                                var False = "false";

                                if (strValue == True)
                                    Variable.Variables[variable(code[typeIndex + 1])].value = true;

                                else if (strValue == False)
                                    Variable.Variables[variable(code[typeIndex + 1])].value = false;
                            }
                            else if (type == "string")
                            {
                                Variable.Variables[variable(code[typeIndex + 1])].value = strValue;
                            }
                            else if (type == "char")
                            {
                                Variable.Variables[variable(code[typeIndex + 1])].value = strValue[1];
                            }
                            else if (type == "int")
                            {
                                if(strValue.Contains(","))
                                {
                                    ThrowCompilationException(new CUPL.EXCEPTIONS.INVALIDTYPEEXCEPTION("int", "coma separated float", filename, currentline));
                                    return;
                                }
                                Variable.Variables[variable(code[typeIndex + 1])].value = Convert.ToInt32(strValue);
                            }
                            else if (type == "float")
                            {
                                Variable.Variables[variable(code[typeIndex + 1])].value = (float)double.Parse(strValue, System.Globalization.CultureInfo.InvariantCulture);
                            }
                            else if (type == "BUILTINCONSTANT")
                            {
                                Variable.Variables[variable(code[typeIndex + 1])].value = CUPL.Constants.NONE;
                            }
                            else if (type == "FUNCTION")
                            {
                                if (line.Contains("input()"))
                                {
                                    var varname = line.Split('=')[0].Split(" ")[typeIndex+1];
                                    new CUPL.FUNCTIONS.input(ref Variable.Variables[variable(varname)]);
                                }
                                else if (line.Contains("ToInt("))
                                {
                                    string arg = "";
                                    try
                                    {
                                        arg = line.Replace("ToInt(", "");
                                        arg = arg.Replace(")", "");
                                        arg = arg.Replace("\r", "");
                                    }
                                    catch (Exception e)
                                    {
                                        ThrowCompilationException(new CUPL.EXCEPTIONS.MISSINGARGUMENTEXCEPTION(currentline, filename, "ToInt(object obj)"));
                                    }
                                    var varname = line.Split('=')[0].Split(" ")[typeIndex + 1];
                                    if (varname[0] == ' ')
                                    {
                                        varname = varname.Substring(1);
                                    }
                                    varname = varname.Replace("\r", "");
                                    arg = arg.Split("=")[1].Substring(1);
                                    if (arg.StartsWith('"')) {
                                        new CUPL.FUNCTIONS.ToInt(ref Variable.Variables[variable(varname)], arg);
                                    }
                                    else
                                    {
                                        new CUPL.FUNCTIONS.ToInt(ref Variable.Variables[variable(varname)], Variable.Variables[variable(arg)]);
                                    }
                                }
                                else if (line.Contains("ToString("))
                                {
                                    string arg = "";
                                    try
                                    {
                                        arg = line.Replace("ToString(", "");
                                        arg = arg.Replace(")", "");
                                        arg = arg.Replace("\r", "");
                                    }
                                    catch (Exception e)
                                    {
                                        ThrowCompilationException(new CUPL.EXCEPTIONS.MISSINGARGUMENTEXCEPTION(currentline, filename, "ToString(object obj)"));
                                    }
                                    var varname = line.Split('=')[0].Split(" ")[typeIndex + 1];
                                    if (varname[0] == ' ')
                                    {
                                        varname = varname.Substring(1);
                                    }
                                    varname = varname.Replace("\r", "");
                                    arg = arg.Split("=")[1].Substring(1);
                                    if (arg.StartsWith('"')) {
                                        
                                        new CUPL.FUNCTIONS.ToString(ref Variable.Variables[variable(varname)], arg);
                                    }
                                    else
                                    {
                                        new CUPL.FUNCTIONS.ToString(ref Variable.Variables[variable(varname)], Variable.Variables[variable(arg)]);
                                    }
                                }
                                else if (line.Contains("ToBool("))
                                {
                                    string arg = "";
                                    try
                                    {
                                        arg = line.Replace("ToBool(", "");
                                        arg = arg.Replace(")", "");
                                        arg = arg.Replace("\r", "");
                                    }
                                    catch (Exception e)
                                    {
                                        ThrowCompilationException(new CUPL.EXCEPTIONS.MISSINGARGUMENTEXCEPTION(currentline, filename, "ToBool(object obj)"));
                                    }
                                    var varname = line.Split('=')[0].Split(" ")[typeIndex + 1];
                                    if (varname[0] == ' ')
                                    {
                                        varname = varname.Substring(1);
                                    }
                                    varname = varname.Replace("\r", "");
                                    arg = arg.Split("=")[1].Substring(1);
                                    if (arg.StartsWith('"'))
                                    {

                                        new CUPL.FUNCTIONS.ToBool(ref Variable.Variables[variable(varname)], arg);
                                    }
                                    else
                                    {
                                        new CUPL.FUNCTIONS.ToBool(ref Variable.Variables[variable(varname)], Variable.Variables[variable(arg)]);
                                    }
                                }
                                else if (line.Contains("ToFloat("))
                                {
                                    string arg = "";
                                    try
                                    {
                                        arg = line.Replace("ToFloat(", "");
                                        arg = arg.Replace(")", "");
                                        arg = arg.Replace("\r", "");
                                    }
                                    catch (Exception e)
                                    {
                                        ThrowCompilationException(new CUPL.EXCEPTIONS.MISSINGARGUMENTEXCEPTION(currentline, filename, "ToFloat(object obj)"));
                                    }
                                    var varname = line.Split('=')[0].Split(" ")[typeIndex + 1];
                                    if (varname[0] == ' ')
                                    {
                                        varname = varname.Substring(1);
                                    }
                                    varname = varname.Replace("\r", "");
                                    arg = arg.Split("=")[1].Substring(1);
                                    if (arg.StartsWith('"'))
                                    {

                                        new CUPL.FUNCTIONS.ToFloat(ref Variable.Variables[variable(varname)], arg);
                                    }
                                    else
                                    {
                                        new CUPL.FUNCTIONS.ToFloat(ref Variable.Variables[variable(varname)], Variable.Variables[variable(arg)]);
                                    }
                                }
                                else if (line.Contains("ToChar("))
                                {
                                    string arg = "";
                                    try
                                    {
                                        arg = line.Replace("ToChar(", "");
                                        arg = arg.Replace(")", "");
                                        arg = arg.Replace("\r", "");
                                    }
                                    catch (Exception e)
                                    {
                                        ThrowCompilationException(new CUPL.EXCEPTIONS.MISSINGARGUMENTEXCEPTION(currentline, filename, "ToChar(object obj)"));
                                    }
                                    var varname = line.Split('=')[0].Split(" ")[typeIndex + 1];
                                    if (varname[0] == ' ')
                                    {
                                        varname = varname.Substring(1);
                                    }
                                    varname = varname.Replace("\r", "");
                                    arg = arg.Split("=")[1].Substring(1);
                                    if (arg.StartsWith('"'))
                                    {

                                        new CUPL.FUNCTIONS.ToChar(ref Variable.Variables[variable(varname)], arg);
                                    }
                                    else
                                    {
                                        new CUPL.FUNCTIONS.ToChar(ref Variable.Variables[variable(varname)], Variable.Variables[variable(arg)]);
                                    }
                                }
                                else
                                {
                                    var functionName= line.Split('=')[1];
                                    if (functionName[0] == ' ')
                                    {
                                        ThrowCompilationException(new CUPL.EXCEPTIONS.UNKNOWNFUNCTIONEXCEPTION(functionName.Substring(1), filename, currentline));
                                    }
                                    else
                                    {
                                        ThrowCompilationException(new CUPL.EXCEPTIONS.UNKNOWNFUNCTIONEXCEPTION(functionName, filename, currentline));
                                    }
                                }
                            }
                        }
                    }
                    if (code[0] == "public") {
                        accessLevel = 1;
                        typeIndex = 1;
                        variableLine = true;
                    }
                    else if (code[0] == "private")
                    {
                        accessLevel = 0;
                        typeIndex = 1;
                        variableLine = true;
                    }
                    else if (code[0] == "bool" || code[0] == "int" || code[0] == "string" || code[0] == "bin" || code[0] == "float" || code[0] == "char")
                    {
                        typeIndex = 0;
                        accessLevel = 0;
                        variableLine = true;
                    }
                    else if(isVariable(code[0]))
                    {
                        typeIndex = -1;
                        variableLine = false;
                        accessLevel = 0;
                        ReUseVariable();
                    }
                    else
                    {
                        variableLine = false;
                    }

                    if (variableLine)
                    {
                        AddVariable(code[typeIndex + 1], code[typeIndex]);
                        Variable.Variables[variable(code[typeIndex + 1])].accessLevel = accessLevel;
                        Variable.Variables[variable(code[typeIndex + 1])].value = CUPL.Constants.NONE;
                        
                        ReUseVariable();
                    }
                    // In case its a function
                    else if (line.StartsWith("print("))
                    {
                        string arg = "";
                        try
                        {
                            arg = line.Split('"')[line.Split('"').Length - 2];
                            new CUPL.FUNCTIONS.print(arg);

                        }
                        catch (Exception e)
                        {
                            try
                            {
                                arg = line.Replace("print(", "");
                                arg = arg.Replace(")", "");
                                arg = arg.Replace("\r", "");

                                if (char.IsDigit(arg[0]))
                                {
                                    new CUPL.FUNCTIONS.print(arg);
                                }
                                else
                                {
                                    var argss = Variable.Variables[variable(arg)];
                                    new CUPL.FUNCTIONS.print(argss);
                                }
                            }
                            catch (Exception e2)
                            {
                                ThrowCompilationException(new CUPL.EXCEPTIONS.MISSINGARGUMENTEXCEPTION(currentline, filename, "print()"));
                            }
                        }
                    }
                    else if (line.StartsWith("startProcess("))
                    {
                        string arg = "";
                        try
                        {
                            arg = line.Split('"')[line.Split('"').Length - 2];
                            new CUPL.FUNCTIONS.startProcess(arg);

                        }
                        catch (Exception e)
                        {
                            try
                            {
                                arg = line.Replace("startProcess(", "");
                                arg = arg.Replace(")", "");
                                arg = arg.Replace("\r", "");

                                if (char.IsDigit(arg[0]))
                                {
                                    new CUPL.FUNCTIONS.startProcess(arg);
                                }
                                else
                                {
                                    var argss = Variable.Variables[variable(arg)];
                                    new CUPL.FUNCTIONS.startProcess(argss);
                                }
                            }
                            catch (Exception e2)
                            {
                                ThrowCompilationException(new CUPL.EXCEPTIONS.MISSINGARGUMENTEXCEPTION(currentline, filename, "startProcess()"));
                            }
                        }
                    }
                    else if (line.StartsWith("wait("))
                    {
                        string arg = "";
                        try
                        {
                            arg = line.Split('"')[line.Split('"').Length - 2];
                            new CUPL.FUNCTIONS.print(arg);

                        }
                        catch (Exception e)
                        {
                            try
                            {
                                arg = line.Replace("wait(", "");
                                arg = arg.Replace(")", "");
                                arg = arg.Replace("\r", "");

                                if (char.IsDigit(arg[0]))
                                {
                                    new CUPL.FUNCTIONS.Wait(arg);
                                }
                                else
                                {
                                    var argss = Variable.Variables[variable(arg)];
                                    new CUPL.FUNCTIONS.Wait(argss);
                                }
                            }
                            catch (Exception e2)
                            {
                                ThrowCompilationException(new CUPL.EXCEPTIONS.MISSINGARGUMENTEXCEPTION(currentline, filename, "wait(int miliseconds)"));
                            }
                        }
                    }
                    else if (line.Contains("ClearConsole()"))
                    {
                        new CUPL.FUNCTIONS.ClearConsole();
                    }

                }
                terminate = true;
            }
        }
        public static int variable(string name)
        {
            for (int i = 0; i < Variable.Variables.Length; i++)
            {
                if (Variable.Variables[i].name == name)
                {
                    return i;
                }
            }
            ThrowCompilationException(new CUPL.EXCEPTIONS.VARUSEDBEFOREDECLARATIONEXCEPTION(name,currentline,filename));
            return -1;
        }
        public static bool isVariable(string name)
        {
            for (int i = 0; i < Variable.Variables.Length; i++)
            {
                if (Variable.Variables[i].name == name)
                {
                    return true;
                }
            }
            return false;
        }
        public static void AddVariable(string name, string type)
        {
            if (char.IsDigit(name[0]))
            {
                ThrowCompilationException(new CUPL.EXCEPTIONS.INVALIDVARNAMEEXCEPTION("DIGIT", filename, currentline));
            }
            Variable v = new Variable();
            if (type == "bool" || 
                type == "int" ||
                type == "string" ||
                type == "float" ||
                type == "char")
            {
                v.type = type;
                v.name = name;
                v.accessLevel = 0;
                v.value = null;
                Array.Resize(ref Variable.Variables, Variable.Variables.Length + 1);
                Variable.Variables[Variable.Variables.Length - 1] = v;
            }
            else
            {
                ThrowCompilationException(new CUPL.EXCEPTIONS.INVALIDTYPEEXCEPTION("UNKNOWN", "OBJECT", filename, currentline));
            }
        }
        public static string? GetType(string Value)
        {
            Value = Value.Replace("\r", "");
            string type = "";
            if (Value == "true" || Value == "false") { 
                type = "bool";
                return type; 
            }
            for (int i = 0; i < Value.Length; i++)
            {
                if (Value == "null") { type = "BUILTINCONSTANT"; break; }
                else if (Value.EndsWith(")")) { type = "FUNCTION"; break; }
                else if ((Value.StartsWith('\'') && Value.EndsWith('\'')) || (Value.StartsWith('"') && Value.EndsWith('"')))
                {

                    if (Value.Length == 1)
                    {
                        type = "char";
                        break;
                    }
                    else
                    {
                        type = "string";
                        break;
                    }
                }
                else if (char.IsDigit(Value[i]) && type == "")
                {
                    if (Value.Contains("."))
                    {
                        type = "float";
                        break;
                    }
                    else
                    {
                        type = "int";
                        break;
                    }
                }
                else
                {
                    ThrowCompilationException(new CUPL.EXCEPTIONS.UNKNOWNTYPEEXCEPTION(currentline, filename, Value));
                }
                
            }
            if(type == "")
            {
                ThrowCompilationException(new CUPL.EXCEPTIONS.NONEVALUETYPEEXCEPTION(filename, currentline));
                return null;
            }
            return type;
        }
        public static void ThrowCompilationException(MainException exception)
        {
            Console.WriteLine("ERROR: " + exception.message);
            Console.WriteLine("EXCEPTION TYPE: " + exception.ToString().Replace("CUPL.EXCEPTIONS.",""));
            terminate = true;
        }
    }
}