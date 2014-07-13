namespace DecoratorPattern
{
    /// <summary> The 'Component' abstract class </summary>
    public abstract class LibraryItem
    {
        private int numCopies;

        // Property
        public int NumCopies
        {
            get
            {
                return this.numCopies;
            }

            set
            {
                this.numCopies = value;
            }
        }

        public abstract void Display();
    }
}