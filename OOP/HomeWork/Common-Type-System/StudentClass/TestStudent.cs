namespace StudentClass
{
    using System;
    using System.Linq;

    /*Define a class Student, which contains data about a student – first, middle and last name, 
     * SSN, permanent address, mobile phone e-mail, course, specialty, university, faculty. Use 
     * an enumeration for the specialties, universities and faculties. Override the standard methods, 
     * inherited by  System.Object: Equals(), ToString(), GetHashCode() and operators == and !=.*/

    /*Add implementations of the ICloneable interface. The Clone() method should deeply copy all 
     * object's fields into a new object of type Student.*/

    /*Implement the  IComparable<Student> interface to compare students by names (as first criteria, 
     * in lexicographic order) and by social security number (as second criteria, in increasing order).*/

    public class TestStudent
    {
        private static void Main()
        {
            var test = new Student("Pesho", "Petrov", "Petrov", 192, "tri", "+359887005", "gosho@ebg.bg", "Math", "Algorythms", "TU", "FMI");
            var test2 = new Student("Pesho", "Petrov", "Petrov", 193, "tri", "+359887005", "gosho@ebg.bg", "Math", "Algorythms", "SU", "FMI");
            Console.WriteLine(test.GetHashCode());
            Console.WriteLine(test2.GetHashCode());
            Console.WriteLine(test.Equals(test2));
            Console.WriteLine(test);
            Console.WriteLine(test2);
            var clone = test.Clone();
            Console.WriteLine(clone);
            Console.WriteLine(test.Equals(clone));
            Console.WriteLine(test == clone);
            Console.WriteLine(test == clone as Student);
            Console.WriteLine(test.CompareTo(test2));
        }
    }
}
