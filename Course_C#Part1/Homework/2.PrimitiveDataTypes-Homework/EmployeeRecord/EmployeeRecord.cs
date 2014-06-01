namespace EmployeeRecord
{
    using System;
    using System.Linq;

    /*A marketing firm wants to keep record of its employees. 
     * Each record would have the following characteristics – 
     * first name, family name, age, gender (m or f), ID number,
     * unique employee number (27560000 to 27569999). 
     * Declare the variables needed to keep the information 
     * for a single employee using appropriate data types and descriptive names.
    */

    class EmployeeRecord
    {
        static void Main()
        {
            string firstName = "Ivan";
            string lastName = "Petrov";
            byte age = 32;
            char gender = 'M';
            int iDnumber = 987456321;
            int unqEmpNumb = 27569999;
            //first name input with check for digits in input string
            do
            {
                Console.Write("Enter employee's first name: ");
                firstName = Console.ReadLine();
                //check every single digit in the array is it digit 
                bool check = firstName.All(Char.IsLetter);
                if (check)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input for first name! Try again.");
                }
            } while (true);
            //last namr input with check for digits in input string
            do
            {
                Console.Write("Enter employee's family name: ");
                lastName = Console.ReadLine();
                bool check = lastName.All(Char.IsLetter);
                if (check)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input for last name! Try again.");
                }
            } while (true);
            //input for age
            do
            {
                Console.Write("Enter employee's age: ");
                string temp = Console.ReadLine();
                bool check = byte.TryParse(temp, out age);
                //Borders low - 16 high - 166 other values are unreal
                if (check && age > 16 && age < 166)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong age input! Try again.");
                }
            } while (true);
            //input for gender
            do
            {
                Console.Write("Enter employee's gender: ");
                string temp = Console.ReadLine();
                //check for correct input
                if (temp[0] == 'M' || temp[0] == 'm' || temp[0] == 'F' || temp[0] == 'f')
                {
                    //if small letter convert to capital
                    if (temp[0] < 'f')
                    {
                        gender = temp[0];
                    }
                    else
                    {
                        gender = (char)((int)temp[0] - ('a' - 'A'));
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input for gender! Try again.");
                }
            } while (true);
            //input for ID number
            do
            {
                Console.Write("Enter ID number: ");
                string temp = Console.ReadLine();
                bool check = int.TryParse(temp, out iDnumber);
                if (check)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input for ID number! Try again.");
                }
            } while (true);
            //input for unique employee number
            do
            {
                Console.Write("Enter unique employee number:");
                string temp = Console.ReadLine();
                bool check = int.TryParse(temp, out unqEmpNumb);
                if (check)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input for UEN! Try again.");
                }
            } while (true);
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("First name: {0}\nFamily name: {1}\nSex: {2}\nAge: {3}\nID: {4}\nUnique employee number: {5}", firstName, lastName, gender, age, iDnumber, unqEmpNumb);
        }
    }
}