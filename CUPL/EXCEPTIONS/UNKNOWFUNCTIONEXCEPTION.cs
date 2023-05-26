namespace CUPL.EXCEPTIONS
{
    internal class UNKNOWNFUNCTIONEXCEPTION : MainException
    {
        private string v;

        public UNKNOWNFUNCTIONEXCEPTION(string FUNCTIONNAME, string FILE, int LINE)
        {
            message = "UNKNOWN FUNCTION CALL FOR '" + FUNCTIONNAME + "' AT " + FILE + ":" + LINE;
        }
    }
}