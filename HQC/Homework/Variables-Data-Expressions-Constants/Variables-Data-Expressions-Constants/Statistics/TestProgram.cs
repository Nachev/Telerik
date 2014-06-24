namespace Statistics
{
    /// <summary>
    /// Test program for task 2.
    /// </summary>
    public class TestProgram
    {
        /// <summary>
        /// Test main method
        /// </summary>
        public static void Main()
        {
            double[] testArr = new double[3] { 2.34, 2.43, 5.65 };
            var testSet = new Set(testArr);
            testSet.PrintStatistics();
        }
    }
}