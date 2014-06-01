namespace School
{
    using System;
    using System.Linq;

    internal class Discipline : ICommentable
    {
        private string name;

        public Discipline(string name, int numberOfLectures, int numberOfExersices, string comment = null)
        {
            this.Name = name;
            this.NumberOfExersizes = numberOfExersices;
            this.NumberOfLectures = numberOfLectures;
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
                if (IsNotCorrectName(value))
                {
                    throw new ArgumentException("Value for discipline name is not correct!");
                }

                this.name = value;
            }
        }

        public int NumberOfLectures { get; private set; }

        public int NumberOfExersizes { get; private set; }

        public string Comment { get; set; }

        private static bool IsNotCorrectName(string name)
        {
            char[] allowedSymbols = { ' ', '.', '-', ',', '_', '"' };
            return name.All(l => !(char.IsLetter(l) || allowedSymbols.Contains(l)));
        }
    }
}
