namespace AnimalWorld
{
    public class Kitten : Cat
    {
        public const string SEX = "female";

        public Kitten(string name, int age)
            : base(name, age, SEX)
        {
        }
    }
}
