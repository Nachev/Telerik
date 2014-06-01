using System;

class LeastMajorityMultiple
{
    static void Main()
    {
        int[] numbers = new int[5];
        for (int arrIndex = 0; arrIndex < 5; arrIndex++)
        {
            string tempInputStr = Console.ReadLine();
            numbers[arrIndex] = int.Parse(tempInputStr);    
        }
        //sort in increasing order
        bool flag1 = true;
        bool flag2 = true;
        while(flag1 || flag2)
        {
            flag1 = false;
            flag2 = false;
            for (int arrIndex = 1; arrIndex < 5; arrIndex++)
            {
                if (numbers[arrIndex] < numbers[arrIndex - 1])
                {
                    int tempInt1 = numbers[arrIndex - 1];
                    numbers[arrIndex - 1] = numbers[arrIndex];
                    numbers[arrIndex] = tempInt1;
                    flag1 = true;
                }
                else if (arrIndex < 4)
                {
                    if (numbers[arrIndex] > numbers[arrIndex + 1])
                    {
                        int tempInt2 = numbers[arrIndex + 1];
                        numbers[arrIndex + 1] = numbers[arrIndex];
                        numbers[arrIndex] = tempInt2;
                        flag2 = true;
                    }
                }
            }    
        }
        ////display the rsult
        //foreach (var number in numbers)
        //{
        //    Console.Write(number + " ");
        //}
        bool check = true;
        int leastMajorityMultiple = numbers[2];
        while (check)
        {
            int counter = 0;
            foreach (int number in numbers)
            {
                if (leastMajorityMultiple % number == 0)
                {
                    counter++;
                }
            }
            leastMajorityMultiple++;
            check = counter < 3;
        }
        Console.Write(--leastMajorityMultiple);
    }
}
