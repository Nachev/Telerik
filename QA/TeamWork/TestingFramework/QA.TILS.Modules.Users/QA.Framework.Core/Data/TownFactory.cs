namespace QA.Framework.Core.Data
{
    using QA.Framework.Core.Data.Templates;

    public class TownFactory
    {
        private const string ValidBulgarianName = "Хасково";
        private const string ValidBulgarianName2 = "Пловдив";
        private const string InvalidBulgarianNameWithLatinCharacters = "Haskovo";

        private const string ValidEnglishName = "Haskovo";
        private const string ValidEnglishName2 = "Plovdiv";
        private const string InvalidEnglishNameWithCyrillicCharacters = "Хасково";

        public Town GetValidTown()
        {
            return new Town(ValidBulgarianName, ValidEnglishName);
        }

        public Town GetInvalidEnglishName()
        {
            return new Town(ValidBulgarianName, InvalidEnglishNameWithCyrillicCharacters);
        }

        public Town GetInvalidBulgarianName()
        {
            return new Town(InvalidBulgarianNameWithLatinCharacters, ValidEnglishName);
        }

        public Town GetEmptyEnglishName()
        {
            return new Town(ValidBulgarianName, string.Empty);
        }

        public Town GetEmptyBulgariaName()
        {
            return new Town(string.Empty, ValidEnglishName);
        }

        public Town GetValidTown2()
        {
            return new Town(ValidBulgarianName2, ValidEnglishName2);
        }
    }
}
