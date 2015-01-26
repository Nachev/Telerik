namespace QA.Framework.Core.Data.Templates
{
    public class University
    {
        public University(string name, string web, string order)
        {
            this.Name = name;
            this.WebPage = web;
            this.Order = order;
        }

        public string Name { get; private set; }

        public string WebPage { get; private set; }

        public string Order { get; private set; }
    }
}
