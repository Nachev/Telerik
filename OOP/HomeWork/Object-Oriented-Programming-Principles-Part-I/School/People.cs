namespace School
{
    using System;
    using System.Linq;
    using System.Text;

    internal abstract class People : ICommentable
    {
        private string name;

        public People(string name, string comment = null)
        {
            this.Name = name;
            this.Comment = comment;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value.Any(l => !char.IsLetter(l) && l != '-' && l != ' '))
                {
                    throw new ArgumentException("Name can contain only letters, space and -.");
                }

                this.name = value;
            }
        }

        public string Comment { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendFormat("Name: {0} ", this.Name);
            if (this.Comment != null)
            {
                result.AppendFormat("Comment: {0}", this.Comment);
            }

            return result.ToString();
        }
    }
}
