namespace WebGame.Common.Exeptions
{
    public class SpecializationNotFoundExeption : BuisnessException
    {
        public SpecializationNotFoundExeption() { }

        public SpecializationNotFoundExeption(string message)
            : base(message) { }
    }
}
