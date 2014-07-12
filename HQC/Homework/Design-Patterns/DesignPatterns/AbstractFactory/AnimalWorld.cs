namespace AbstractFactory
{
    /// <summary>
    /// The 'Client' class
    /// </summary>
    class AnimalWorld
    {
        private Herbivore herbivore;

        private Carnivore carnivore;

        // Constructor

        public AnimalWorld(ContinentFactory factory)
        {
            carnivore = factory.CreateCarnivore();

            herbivore = factory.CreateHerbivore();
        }

        public void RunFoodChain()
        {
            carnivore.Eat(herbivore);
        }
    }
}