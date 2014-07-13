// Decorator pattern
namespace DecoratorPattern
{
    using System;

    /// <summary>
    /// MainApp startup class for Real-World
    /// Decorator Design Pattern.
    /// </summary>
    public class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Main()
        {
            // Create book
            Book book = new Book("Worley", "Inside ASP.NET", 10);

            book.Display();

            // Create video
            Video video = new Video("Spielberg", "Jaws", 23, 92);

            video.Display();

            // Make video borrowable, then borrow and display
            Console.WriteLine("\nMaking video borrowable:");

            Rentable borrowvideo = new Rentable(video);

            borrowvideo.BorrowItem("Customer #1");
            borrowvideo.BorrowItem("Customer #2");
            borrowvideo.Display();

            // Wait for user
            Console.ReadKey();
        }
    }
}