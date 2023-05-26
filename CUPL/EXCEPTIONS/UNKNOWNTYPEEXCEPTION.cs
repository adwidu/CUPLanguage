namespace CUPL.EXCEPTIONS
{
    internal class UNKNOWNTYPEEXCEPTION : MainException
    {

        public UNKNOWNTYPEEXCEPTION(int LINE, string FILE, string VALUE)
        {
            message = "UNKNOWN VALUE '" + VALUE + "' AT " + FILE + ":" + LINE.ToString();
        }
    }
}