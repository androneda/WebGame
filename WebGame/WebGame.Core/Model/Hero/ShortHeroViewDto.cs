namespace WebGame.Core.Model.Hero
{
    public class ShortHeroViewDto
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Race
        /// </summary>
        public string Race { get; set; }

        /// <summary>
        ///  Class
        /// </summary>
        public string HeroClass { get; set; }

        /// <summary>
        /// Show Helmet
        /// </summary>
        public bool ShowHelmet { get; set; }
    }
}
