namespace AnimalWorld
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class TestAnimals
    {
        private static string[] maleNames = 
        {
            "MAX", "BUDDY", "JAKE", "BAILEY", "ROCKY", "CHARLIE", "JACK", "TOBY", "CODY", "BUSTER", "DUKE", "COOPER", "HARLEY"
        };

        private static string[] femaleNames = 
        {
            "MOLLY", "BELLA", "LUCY", "MAGGIE", "DAISY", "SADIE", "CHLOE", "SOPHIE", "BAILEY", "ZOE", "LOLA", "ABBY", "GINGER"
        };

        private static string[] sex = { "male", "female" };

        private static Random rng = new Random();

        private static void Main()
        {
            var dogs = GenerateAnimalArray<Dog>();
            var frogs = GenerateAnimalArray<Frog>();
            var kittens = GenerateAnimalArray<Kitten>();
            var tomcats = GenerateAnimalArray<Tomcat>();

            PrintCollection(dogs);
            Console.WriteLine("Average dogs age: {0:#.##}", Dog.AverageAge(dogs));
            Console.WriteLine();
            PrintCollection(frogs);
            Console.WriteLine("Average frogs age: {0:#.##}", Frog.AverageAge(frogs));
            Console.WriteLine();
            PrintCollection(kittens);
            Console.WriteLine("Average kittens age: {0:#.##}", Kitten.AverageAge(kittens));
            Console.WriteLine();
            PrintCollection(tomcats);
            Console.WriteLine("Average tomcats age: {0:#.##}", Tomcat.AverageAge(tomcats));
        }

        private static void PrintCollection(IEnumerable collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        private static IEnumerable<T> GenerateAnimalArray<T>()
        {
            var animalArray = new Animal[rng.Next(7, 15)];
            for (int index = 0; index < animalArray.Length; index++)
            {
                animalArray[index] = GenerateAnimal<T>();
            }

            return animalArray.Cast<T>();
        }

        private static Animal GenerateAnimal<T>()
        {
            if (typeof(T) == typeof(Frog))
            {
                return ReturnFrog();
            }
            else if (typeof(T) == typeof(Dog))
            {
                return ReturnDog();
            }
            else if (typeof(T) == typeof(Kitten))
            {
                return ReturnKitten();
            }
            else
            {
                return ReturnTomcat();
            }
        }

        private static Frog ReturnFrog()
        {
            string sex = SexSelector();
            int age = rng.Next(17);
            string name = NameSelector(sex);
            return new Frog(name, age, sex);
        }

        private static Dog ReturnDog()
        {
            string sex = SexSelector();
            int age = rng.Next(14);
            string name = NameSelector(sex);
            return new Dog(name, age, sex);
        }

        private static Kitten ReturnKitten()
        {
            string name = NameSelector(Kitten.SEX);
            int age = rng.Next(17);
            return new Kitten(name, age);
        }

        private static Tomcat ReturnTomcat()
        {
            string name = NameSelector(Tomcat.SEX);
            int age = rng.Next(17);
            return new Tomcat(name, age);
        }

        private static string NameSelector(string sex)
        {
            if (sex == "male")
            {
                return maleNames[rng.Next(maleNames.Length)];
            }

            return femaleNames[rng.Next(femaleNames.Length)];
        }

        private static string SexSelector()
        {
            return sex[rng.Next(sex.Length)];
        }
    }
}
