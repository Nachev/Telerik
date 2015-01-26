namespace QA.Framework.Core.Data
{
    using QA.Framework.Core.Data.Templates;

    public class RoleFactory
    {
        private const string ValidName = "SomeRole";

        public Role GetValidRole()
        {
            return new Role(ValidName);
        }
    }
}
