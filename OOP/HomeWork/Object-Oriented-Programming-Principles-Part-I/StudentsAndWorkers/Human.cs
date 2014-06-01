namespace StudentsAndWorkers
{
    using System;
    using System.Linq;

    public abstract class Human
    {
        private string firstName;
        private string lastName;

        protected Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            protected set
            {
                this.HandleIncorrectName(value);
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            protected set
            {
                this.HandleIncorrectName(value);
                this.lastName = value;
            }
        }

        private void HandleIncorrectName(string input)
        {
            if (input.Any(l => !char.IsLetter(l) && l != '-' && l != ' '))
            {
                throw new ArgumentException("Name can contain only letters, space and -.");
            }
        }
    }
}
