namespace AnimalWorld
{
    public class Frog : Animal
    {
        public Frog(string name, int age, string sex)
            : base(name, age, sex)
        {
        }

        public override string ProduceSound()
        {
            return "Ribbit";
        }
    }
}
