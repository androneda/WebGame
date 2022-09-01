namespace WebGame.Common.Exeptions
{
    public class SkillNotFoundExeption : BuisnessException
    {
        public SkillNotFoundExeption() { }

        public SkillNotFoundExeption(string message)
            : base(message) { }
    }
}
