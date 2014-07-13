namespace AbstractFactory
{
    /// <summary>
    /// The 'Client' class
    /// </summary>
    public class AnimalWorld
    {
        private readonly Herbivore herbivore;

        private readonly Carnivore carnivore;

        // Constructor.
        public AnimalWorld(ContinentFactory factory)
        {
            this.carnivore = factory.CreateCarnivore();
            this.herbivore = factory.CreateHerbivore();
        }

        public void RunFoodChain()
        {
            this.carnivore.Eat(this.herbivore);
        }
    }
}