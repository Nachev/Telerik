namespace QA.Framework.Core.Data
{
    using QA.Framework.Core.Data.Templates;

    public class UniversityFactory
    {
        private const string ValidName = "УАСГ-proba2";
        private const string ValidWebSite = "http://uacg.bg/";
        private const string ValidOrder = "101";

        public University GetValidUniversity()
        {
            return new University(ValidName, ValidWebSite, ValidOrder);
        }
    }
}
