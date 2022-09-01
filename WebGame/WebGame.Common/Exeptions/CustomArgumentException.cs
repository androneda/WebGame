namespace WebGame.Common.Exeptions
{
    public class CustomArgumentException : BuisnessException
    {
        public CustomArgumentException() { }

        public CustomArgumentException(string message) : base(message) { }
    }
}
