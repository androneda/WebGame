namespace WebGame.Common.Exeptions
{
    public class AmmunitionNotFoundExeption : BuisnessException
    {
        public AmmunitionNotFoundExeption() { }

        public AmmunitionNotFoundExeption(string message) : base(message) { }
    }
}
