namespace WebGame.Common.Exeptions
{
    public class RaceNotFoundExeption : BuisnessException
    {
        public RaceNotFoundExeption() { }

        public RaceNotFoundExeption(string message) : base(message) { }
    }
}
