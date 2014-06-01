using System;

//Which of the following values can be assigned to a variable of type float and
//which to a variable of type double: 34.567839023, 12.345, 8923.1234857, 3456.091?

class FloatOrDoubleCompare
{
    static void Main()
    {
        float try1_1 = 34.567839023f;
        double try1_2 = 34.567839023;
        float try2_1 = 12.345f;
        double try2_2 = 12.345;
        float try3_1 = 8923.1234857f;
        double try3_2 = 8923.1234857;
        float try4_1 = 3456.091f;
        double try4_2 = 3456.091;
        Console.WriteLine("Which type is better, float or double for following values:\n1. {1,12} -> float- {0,8} vs. double- {1}\n2. {2,12} -> float- {2,8} vs. double- {3}\n3. {5,12} -> float- {4,8} vs. double- {5}\n4. {6,12} -> float- {6,8} vs. double- {7}", try1_1, try1_2, try2_1, try2_2, try3_1, try3_2, try4_1, try4_2);
        Console.WriteLine("1.Double \n2.Float \n3.Double \n4.Float");
    }
}