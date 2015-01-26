namespace QA.Framework.Core.Data.Templates
{
    public class Town
    {
        public Town(string bulgarianName, string englishName)
        {
            this.BulgarianName = bulgarianName;
            this.EnglishName = englishName;
        }

        public string EnglishName { get; private set; }

        public string BulgarianName { get; private set; }
    }
}
