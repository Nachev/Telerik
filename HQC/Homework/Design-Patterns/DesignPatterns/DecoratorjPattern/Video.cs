namespace DecoratorPattern
{
    using System;

    /// <summary> The 'ConcreteComponent' class </summary>
    public class Video : LibraryItem
    {
        private readonly string director;

        private readonly string title;

        private readonly int playTime;

        // Constructor
        public Video(string director, string title, int numCopies, int playTime)
        {
            this.director = director;
            this.title = title;
            this.NumCopies = numCopies;
            this.playTime = playTime;
        }

        public override void Display()
        {
            Console.WriteLine("\nVideo ----- ");
            Console.WriteLine(" Director: {0}", this.director);
            Console.WriteLine(" Title: {0}", this.title);
            Console.WriteLine(" # Copies: {0}", this.NumCopies);
            Console.WriteLine(" Playtime: {0}\n", this.playTime);
        }
    }
}