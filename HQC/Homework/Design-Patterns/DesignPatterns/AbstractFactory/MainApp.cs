// Abstract Factory pattern example
namespace AbstractFactory
{
    using System;

    /// <summary>
    /// MainApp startup class for Abstract Factory Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Main()
        {
            // Create and run the African animal world
            ContinentFactory africa = new AfricaFactory();

            AnimalWorld world = new AnimalWorld(africa);

            world.RunFoodChain();

            // Create and run the American animal world
            ContinentFactory america = new AmericaFactory();

            world = new AnimalWorld(america);

            world.RunFoodChain();

            // Wait for user input
            Console.ReadKey();
        }
    }
}
