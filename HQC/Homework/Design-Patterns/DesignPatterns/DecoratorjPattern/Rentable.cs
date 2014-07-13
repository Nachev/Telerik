namespace DecoratorPattern
{
    using System;
    using System.Collections.Generic;

    /// <summary> The 'ConcreteDecorator' class </summary>
    public class Rentable : Decorator
    {
        private List<string> renters = new List<string>();

        // Constructor
        public Rentable(LibraryItem libraryItem) : base(libraryItem)
        {
        }

        protected List<string> Renters
        {
            get
            {
                return this.renters;
            }

            set
            {
                this.renters = value;
            }
        }

        public void BorrowItem(string name)
        {
            this.Renters.Add(name);

            this.LibraryItem.NumCopies--;
        }

        public void ReturnItem(string name)
        {
            this.Renters.Remove(name);

            this.LibraryItem.NumCopies++;
        }
          
        public override void Display()
        {
            base.Display();

            foreach (string borrower in this.Renters)
            {
                Console.WriteLine(" borrower: " + borrower);
            }
        }
    }
}