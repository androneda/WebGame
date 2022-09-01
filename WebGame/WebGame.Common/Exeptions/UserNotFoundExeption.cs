namespace WebGame.Common.Exeptions
{
    public class UserNotFoundExeption : BuisnessException
    {
        public UserNotFoundExeption() { }

        public UserNotFoundExeption(string message) : base(message) { }
    }
}
