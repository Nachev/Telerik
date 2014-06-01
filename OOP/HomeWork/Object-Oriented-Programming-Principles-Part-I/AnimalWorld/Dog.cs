namespace AnimalWorld
{
    public class Dog : Animal
    {
        public Dog(string name, int age, string sex)
            : base(name, age, sex)
        {
        }

        public override string ProduceSound()
        {
            return "Woof";
        }
    }
}
