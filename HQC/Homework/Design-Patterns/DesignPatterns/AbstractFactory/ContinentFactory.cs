namespace AbstractFactory
{
    /// <summary>
    /// The 'AbstractFactory' abstract class
    /// </summary>
    public abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();

        public abstract Carnivore CreateCarnivore();
    }
}