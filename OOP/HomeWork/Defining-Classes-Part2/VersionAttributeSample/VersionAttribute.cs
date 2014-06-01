namespace VersionAttributeSample
{
    using System.Text.RegularExpressions;

    [System.AttributeUsage(
        System.AttributeTargets.Class |
        System.AttributeTargets.Struct |
        System.AttributeTargets.Interface |
        System.AttributeTargets.Method |
        System.AttributeTargets.Enum,
        AllowMultiple = true,
        Inherited = false)]

    public sealed class VersionAttribute : System.Attribute
    {
        private int major;
        private int minor;

        public VersionAttribute(string version, string info = null)
        {
            this.VersionValidation(version);
            string[] versionElements = version.Split(new[] { '.' }, System.StringSplitOptions.RemoveEmptyEntries);
            this.minor = int.Parse(versionElements[1]);
            this.major = int.Parse(versionElements[0]);
            this.Info = info;
        }

        public string Info { get; private set; }

        public string Version
        {
            get
            {
                return this.major.ToString() + '.' + this.minor.ToString();
            }
        }

        private void VersionValidation(string version)
        {
            string regex = @"[0-9]+\.[0-9]+";
            if (!Regex.IsMatch(version, regex))
            {
                throw new System.FormatException("Wrong version format");
            }
        }
    }
}
