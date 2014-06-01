namespace Secrets
{
    using System;

    class Secrets
    {
        static void Main()
        {
            string numberN = Console.ReadLine();
            numberN = numberN.TrimStart(new char[] { '0', '-' });
            // Spec Sum calculation
            int specialSum = new int();
            int count = 1;
            int multiplier = 1;
            
            while (count <= numberN.Length)
            {
                int currentElement = new int();
                if (numberN[count - 1] >= '0')
                {
                    currentElement = (numberN[numberN.Length - count] - '0');
                    multiplier = 1;
                }
                else
                {
                    multiplier = -1;
                    count++;
                    continue;
                }
                 
                if ((count & 1) == 1) // odd
                {
                    currentElement = currentElement * count * count * multiplier;
                }
                else // even
                {
                    currentElement = currentElement * currentElement * count * multiplier;
                }

                count++;
                specialSum += currentElement;
            }

            Console.WriteLine(specialSum);

            // Secret Alpha sequence calculation
            int length = new int();
            int absoluteSpecSum = Math.Abs(specialSum);
            length = absoluteSpecSum % 10;
            int remainder = new int();
            const int ALPHABETCOUNT = 26;
            remainder = absoluteSpecSum % ALPHABETCOUNT;
            count = 0;
            if (length <= 0)
            {
                Console.Write("{0} has no secret alpha-sequence", numberN);
            }
            while (length > count)
            {
                int letterInt = remainder + 65 + count;
                char letter = new char();
                if (letterInt <= 90)
                {
                    letter = (char)letterInt;
                }
                else
                {
                    letter = (char)(letterInt - ALPHABETCOUNT);
                }
                Console.Write(letter);
                count++;
            }
        }
    }
}
