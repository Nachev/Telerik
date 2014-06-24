//---------------------------------------------------------------------------------------
//Take the VS solution "Methods" and refactor its code to follow the guidelines of 
//high-quality methods. Ensure you handle errors correctly: when the methods cannot do 
//what their name says, throw an exception (do not return wrong result).
//Ensure good cohesion and coupling, good naming, no side effects, etc.
//---------------------------------------------------------------------------------------
namespace Methods
{
    using System;

    /// <summary>
    /// Test class with static methods.
    /// </summary>
    public class Methods
    {
        /// <summary>
        /// Calculates triangle's area by three sides 
        /// </summary>
        /// <param name="sideA">Length of first side.</param>
        /// <param name="sideB">Length of second side.</param>
        /// <param name="sideC">Length of third side.</param>
        /// <returns>Calculated area.</returns>
        static double CalcTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            double semiSum = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(semiSum * (semiSum - sideA) * (semiSum - sideB) * (semiSum - sideC));
            return area;
        }

        /// <summary>
        /// Translates digit
        /// </summary>
        /// <param name="digit">Input to be translated.</param>
        /// <returns>String representation of a digit.</returns>
        static string DigitToStringName(int digit)
        {
            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("Invalid number!");
            }           
        }

        /// <summary>
        /// Finds the maximal value of a set.
        /// </summary>
        /// <param name="elements">Input set of numbers.</param>
        /// <returns>Maximal value.</returns>
        static int FindMaxValue(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Input parameter must not be null!");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("Input parameter must not be empty!");
            }

            int maxValue = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxValue)
                {
                    maxValue = elements[i];
                }
            }

            return maxValue;
        }

        /// <summary>
        /// Prints entered value as number in specified format.
        /// </summary>
        /// <param name="number">Number to be printed.</param>
        /// <param name="format">Format identifier.</param>
        static void PrintAsNumber(object number, string format)
        {
            if (number == null)
            {
                throw new ArgumentNullException("Number to be printed cannot be null.");
            }

            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
            else
            {
                throw new ArgumentException("Unknown format identifier! -> " + format);
            }
        }

        /// <summary>
        /// Calculates the distanse between in two-dimensional euclidean space
        /// </summary>
        /// <param name="pointOneX"></param>
        /// <param name="pointOneY"></param>
        /// <param name="pointTwoX"></param>
        /// <param name="pointTwoY"></param>
        /// <returns></returns>
        static double CalcDistance(double pointOneX, double pointOneY, double pointTwoX, double pointTwoY)
        {
            double firstDimension = pointTwoX - pointOneX;
            double secondDimension = pointTwoY - pointOneY;
            double firstDimensionSquare = firstDimension * firstDimension;
            double secondDimensionSquare = secondDimension * secondDimension;
            double distance = Math.Sqrt(firstDimensionSquare + secondDimensionSquare);
            return distance;
        }

        static bool IsHorizontal(double pointOneY, double pointTwoY)
        {
            bool check = (pointOneY == pointTwoY);
            return check;
        }

        static bool IsVertical(double pointOneX, double pointTwoX)
        {
            bool check = (pointOneX == pointTwoX);
            return check;
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(DigitToStringName(5));

            Console.WriteLine(FindMaxValue(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            var testPointOne = new TestPoint(3, -1);
            var testPointTwo = new TestPoint(3, 2.5);
            double testDistance = CalcDistance(
                testPointOne.CoordX, 
                testPointOne.CoordY, 
                testPointTwo.CoordX, 
                testPointTwo.CoordY
                );
            bool isHorizontal = IsHorizontal(testPointOne.CoordY, testPointTwo.CoordY);
            bool isVertical = IsVertical(testPointOne.CoordX, testPointTwo.CoordX);
            Console.WriteLine(testDistance);
            Console.WriteLine("Horizontal? " + isHorizontal);
            Console.WriteLine("Vertical? " + isVertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
