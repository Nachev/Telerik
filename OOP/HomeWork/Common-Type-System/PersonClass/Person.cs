namespace PersonClass
{
    using System;
    using System.Linq;
    using System.Text;

    public class Person
    {
        private readonly string name;
        private readonly int? age;

        public Person(string name)
        {
            this.name = name;
            this.age = null;
        }

        public Person(string name, int age)
            : this(name)
        {
            this.age = age;
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendFormat("name: {0}, ", this.name);
            if (this.age != null)
            {
                result.AppendFormat("age: {0}", this.age);
            }
            else
            {
                result.Append("age not specified");
            }

            return result.ToString();
        }
    }
}
