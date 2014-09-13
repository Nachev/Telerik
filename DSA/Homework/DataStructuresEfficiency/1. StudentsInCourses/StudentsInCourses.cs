namespace _1.StudentsInCourses
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class StudentsInCourses
    {
        private static SortedDictionary<string, List<Person>> peopleByCourse = new SortedDictionary<string, List<Person>>();

        public static void Main(string[] args)
        {
            string filename = "students.txt";
            ParseInput(filename);

            foreach (var course in peopleByCourse.Keys)
            {
                var sortedPeople = peopleByCourse[course];
                sortedPeople.Sort();
                Console.Write(course + ": ");
                Console.WriteLine(string.Join(", ", sortedPeople));
            }
        }

        private static void ParseInput(string filename)
        {
            using (var sr = new StreamReader(filename))
            {
                string line;
                char[] delims = { '|', ' ' };
                do
                {
                    line = sr.ReadLine();
                    string[] parameters = line.Split(delims, StringSplitOptions.RemoveEmptyEntries);
                    Person person = new Person(parameters[0], parameters[1]);
                    if (peopleByCourse.ContainsKey(parameters[2]))
                    {
                        List<Person> personList = peopleByCourse[parameters[2]];
                        personList.Add(person);
                    }
                    else
                    {
                        List<Person> personList = new List<Person>();
                        personList.Add(person);
                        peopleByCourse.Add(parameters[2], personList);
                    }
                }
                while (!sr.EndOfStream);
            }
        }
    }
}
