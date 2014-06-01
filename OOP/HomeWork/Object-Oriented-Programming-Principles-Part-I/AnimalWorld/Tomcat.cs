namespace AnimalWorld
{
    public class Tomcat : Cat
    {
        public const string SEX = "male";

        public Tomcat(string name, int age)
            : base(name, age, SEX)
        {
        }
    }
}
