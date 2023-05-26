namespace CUPL.EXCEPTIONS
{
    internal class MISSINGARGUMENTEXCEPTION : MainException
    {
        
        public MISSINGARGUMENTEXCEPTION(int LINE, string FILE, string FUNCTION)
        {
            message = "MISSING ARGUMENT IN FUNCTION " + FUNCTION + " AT " + FILE + ":" + LINE; 
        }
    }
}