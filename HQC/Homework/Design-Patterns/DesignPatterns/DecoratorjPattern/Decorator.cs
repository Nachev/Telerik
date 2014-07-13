namespace DecoratorPattern
{
    /// <summary> The 'Decorator' abstract class </summary>
    public abstract class Decorator : LibraryItem
    {
        private LibraryItem libraryItem;

        // Constructor
        public Decorator(LibraryItem libraryItem)
        {
            this.LibraryItem = libraryItem;
        }

        protected LibraryItem LibraryItem
        {
            get
            {
                return this.libraryItem;
            }

            set
            {
                this.libraryItem = value;
            }
        }

        public override void Display()
        {
            this.LibraryItem.Display();
        }
    }
}