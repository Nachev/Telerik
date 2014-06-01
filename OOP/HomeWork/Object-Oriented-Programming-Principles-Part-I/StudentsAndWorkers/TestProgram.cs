namespace StudentsAndWorkers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /*Define abstract class Human with first name and last name. Define new class Student which 
     * is derived from Human and has new field – grade. Define class Worker derived from Human 
     * with new property WeekSalary and WorkHoursPerDay and method MoneyPerHour() that returns 
     * money earned by hour by the worker. Define the proper constructors and properties for this 
     * hierarchy. Initialize a list of 10 students and sort them by grade in ascending order 
     * (use LINQ or OrderBy() extension method). Initialize a list of 10 workers and sort them by 
     * money per hour in descending order. Merge the lists and sort them by first name and last name.*/

    public class TestProgram
    {
        #region Constants definition
        private const int MAX_GRADE = 6;
        private const int MIN_GRADE = 2;
        private const double MAX_MONTHLY_SALARY = 5000.00;
        private const double MIN_MONTHLY_SALARY = 350.00;
        private const int MAx_WORK_HOURS_PER_DAY = 15;
        private const int MIN_WORK_HOURS_PER_DAY = 4;
        private const int ARRAY_SIZE = 10;
        #endregion

        private static string[] firstNames = { "Pesho", "Gosho", "Tosho", "Misho", "Tisho", "Onufri", "Pretsaki" };
        private static string[] familyNames = { "Petrov", "Georgiev", "Ivanov", "Hristov", "Dimitrov" };

        private static Random rng = new Random();

        private static void Main()
        {
            List<Worker> workerList = WorkersGenerator().ToList();
            List<Student> studentList = StudentsGenerator().ToList();
            
            workerList = SortWorkers(workerList).ToList();
            foreach (var worker in workerList)
            {
                Console.WriteLine("Name: {0} , payment per hour: {1:C}", worker.FirstName + ' ' + worker.LastName, worker.MoneyPerHour());
            }

            studentList = SortStudents(studentList).ToList();
            foreach (var student in studentList)
            {
                Console.WriteLine("Name: {0} , grade: {1}", student.FirstName + ' ' + student.LastName, student.Grade);
            }

            var mergedList = MergeAndSortLists(workerList, studentList);
            foreach (var item in mergedList)
            {
                Console.WriteLine(item);
            }
        }
         
        private static IEnumerable MergeAndSortLists(IEnumerable<Worker> firstList, IEnumerable<Student> secondList)
        {
            var selection1 = from x in firstList
                             select new { FirstName = x.FirstName, LastName = x.LastName };

            var selection2 = from y in secondList
                             select new { FirstName = y.FirstName, LastName = y.LastName };

            return selection1.Concat(selection2).OrderBy(x => x.FirstName).ThenBy(y => y.LastName);
        }

        private static IEnumerable<Student> SortStudents(IEnumerable<Student> list)
        {
            var result = list.OrderBy(k => k.Grade);
            return result;
        }

        private static IEnumerable<Worker> SortWorkers(IEnumerable<Worker> list)
        {
            var result = from w in list
                         orderby w.MoneyPerHour() descending
                         select w;
            return result;
        }

        private static IEnumerable<Worker> WorkersGenerator()
        {
            var result = new Worker[ARRAY_SIZE];
            for (int index = 0; index < ARRAY_SIZE; index++)
            {
                result[index] = SingleWorkerGenerator();
            }

            return result;
        }

        private static IEnumerable<Student> StudentsGenerator()
        {
            var result = new Student[ARRAY_SIZE];
            for (int index = 0; index < ARRAY_SIZE; index++)
            {
                result[index] = SingleStudentGenerator();
            }

            return result;
        }

        private static Worker SingleWorkerGenerator()
        {
            var names = NameSelector();
            decimal salary = (decimal)(((MAX_MONTHLY_SALARY - MIN_MONTHLY_SALARY) * rng.NextDouble()) + MIN_MONTHLY_SALARY);
            int workHours = rng.Next(MIN_WORK_HOURS_PER_DAY, MAx_WORK_HOURS_PER_DAY);
            return new Worker(names.Item1, names.Item2, salary, workHours);
        }

        private static Student SingleStudentGenerator()
        {
            var names = NameSelector();
            int grade = rng.Next(MIN_GRADE, MAX_GRADE);
            return new Student(names.Item1, names.Item2, grade);
        }

        private static Tuple<string, string> NameSelector()
        {
            int firstNameChooser = rng.Next(firstNames.Length);
            int lastNameChosser = rng.Next(familyNames.Length);
            return new Tuple<string, string>(firstNames[firstNameChooser], familyNames[lastNameChosser]);
        }
    }
}
