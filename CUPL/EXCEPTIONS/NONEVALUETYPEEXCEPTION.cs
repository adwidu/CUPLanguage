namespace CUPL.EXCEPTIONS
{
    internal class NONEVALUETYPEEXCEPTION : MainException
    {
        private string filename;
        private int currentline;

        public NONEVALUETYPEEXCEPTION(string FILE, int LINE)
        {
            message = "THE VALUE HAD NO TYPE AT " + FILE + ":" + LINE.ToString();
        }
    }
}