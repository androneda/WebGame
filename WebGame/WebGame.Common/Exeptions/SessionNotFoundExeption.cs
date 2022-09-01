namespace WebGame.Common.Exeptions
{
    public class SessionNotFoundExeption : BuisnessException
    {
        public SessionNotFoundExeption() { }

        public SessionNotFoundExeption(string message) : base(message) { }
    }
}
