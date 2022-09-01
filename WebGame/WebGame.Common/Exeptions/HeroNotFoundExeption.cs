namespace WebGame.Common.Exeptions
{
    public class HeroNotFoundExeption : BuisnessException
    {
        public HeroNotFoundExeption() { }

        public HeroNotFoundExeption(string message) : base(message) { }
    }
}
