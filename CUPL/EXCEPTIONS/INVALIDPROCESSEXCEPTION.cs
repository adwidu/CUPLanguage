namespace CUPL.EXCEPTIONS
{
    public class INVALIDPROCESSEXCEPTION : MainException
    {
        public INVALIDPROCESSEXCEPTION(int LINE, string FILE, string FUNCTION)
        {
            message = "ERROR STARTING PROCESS IN FUNCTION " + FUNCTION + " AT " + FILE + ":" + LINE;
        }
    }
}