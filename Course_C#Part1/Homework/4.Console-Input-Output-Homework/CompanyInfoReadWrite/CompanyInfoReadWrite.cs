namespace CompanyInfoReadWrite
{
    using System;

    /* A company has name, address, phone number, fax number, web site and manager. 
     The manager has first name, last name, age and a phone number. 
     Write a program that reads the information about a company and its manager and prints them on the console */

    public class CompanyInfoReadWrite
    {
        private static void Main()
        {
            Console.Write("Enter company name: ");
            string compName = Console.ReadLine();
            Console.Write("Enter company adress: ");
            string compAdress = Console.ReadLine();
            Console.Write("Enter phone number: ");
            string compPhone = Console.ReadLine();
            Console.Write("Enter fax number: ");
            string compFax = Console.ReadLine();
            Console.Write("Enter web site:");
            string webSite = Console.ReadLine();
            Console.Write("Enter manager\'s first name: ");
            string manFirstName = Console.ReadLine();
            Console.Write("Enter manager\'s last name: ");
            string manLastName = Console.ReadLine();
            Console.Write("Enter manager\'s age :");
            byte manAge = new byte();
            int insaneCount = 10;
            do
            {
                Console.WriteLine("-> ");
                string temp = Console.ReadLine();
                bool check = byte.TryParse(temp, out manAge);
                if (check)
                {
                    if (manAge < 18)
                    {
                        Console.WriteLine("Manager\'s age is incorrect! Should be higher than 18. Try again.");
                        continue;
                    }
                    else if (manAge > 180)
                    {
                        Console.WriteLine("This is impossible. Manager has to be alive. Try again.");
                        continue;
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("Wrong input number! Try again.");
                }

                insaneCount--;
            }
            while (insaneCount > 0);
            Console.Write("Enter manager\'s phone number :");
            string manPhone = Console.ReadLine();
            Console.WriteLine("Company name: {0}\r\nadress: {1}\r\nphone number: {2}\r\nfax number: {3}\r\nweb site: {4}", compName, compAdress, compPhone, compFax, webSite);
            Console.WriteLine("Manager\'s first name: {0}\r\nlast name: {1}\r\nage: {2}\r\nphone number: {3}", manFirstName, manLastName, manAge, manPhone);
        }
    }
}
