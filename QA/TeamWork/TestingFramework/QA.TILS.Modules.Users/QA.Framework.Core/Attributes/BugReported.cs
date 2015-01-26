namespace QA.Framework.Core.Attributes
{
    using System;

    public class BugReported : Attribute
    {
        private readonly string id;

        public BugReported(string id)
        {
            this.id = id;
        }
    }
}