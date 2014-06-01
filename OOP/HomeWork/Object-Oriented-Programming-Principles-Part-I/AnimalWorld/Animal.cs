namespace AnimalWorld
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Animal : ISound
    {
        private int age;
        private string name;
        private string sex;

        protected internal Animal(string name, int age, string sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public int Age
        {
            get 
            { 
                return this.age; 
            }

            private set 
            {
                if (value < 0 || value > 300)
                {
                    throw new ArgumentException("Incorrect value for age!");
                }

                this.age = value; 
            }
        }

        public string Name
        {
            get 
            {
                return this.name; 
            }

            private set 
            { 
                this.name = value; 
            }
        }

        public string Sex
        {
            get 
            { 
                return this.sex; 
            }

            private set 
            {
                if (value.ToLower() != "male" && value.ToLower() != "female")
                {
                    throw new ArgumentException("Sex must be male or female!");
                }

                this.sex = value; 
            }
        }

        public abstract string ProduceSound();

        public static double AverageAge(IEnumerable<Animal> list)
        {
            // var result = list.Select(x => x.Age).Aggregate((y, z) => y + z) / list.Count();
            var result = list.Average(x => x.Age);
            return result;
        }

        public override string ToString()
        {
            return this.Name + ' ' + this.Age + ' ' + this.Sex;
        }
    }
}
