namespace CUPL.EXCEPTIONS
{
    internal class INVALIDVARNAMEEXCEPTION : MainException
    {

        public INVALIDVARNAMEEXCEPTION(string CHARTYPE, string FILE, int LINE, bool ATSTART = true)
        {
            if (ATSTART)
                message = "INVALID VARIABLE NAME, VARIABLES CAN'T HAVE CHARACTERS TYPE '" + CHARTYPE + "' AT START AT " + FILE + ":" + LINE;
            if (!ATSTART)
                message = "INVALID VARIABLE NAME, VARIABLES CAN'T HAVE CHARACTERS TYPE '" + CHARTYPE + "' AT " + FILE + ":" + LINE;
        }
    }
}