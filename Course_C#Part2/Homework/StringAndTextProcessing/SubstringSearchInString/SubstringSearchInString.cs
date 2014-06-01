namespace SubstringSearchInString
{
    using System;

    /*Write a program that finds how many times a substring is contained in a given text (perform case insensitive search).*/

    public class SubstringSearchInString
    {
        private const string TargetSubstring = "In";
        private const string SampleText = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

        private static void Main()
        {
            int length = SampleText.Length;
            int timesContained = 0;
            for (int strIndex = 0; strIndex < length; strIndex++)
            {
                bool isContained = new bool();
                int subsIndex = 0;
                while (SampleText[strIndex + subsIndex] == char.ToLowerInvariant(TargetSubstring[subsIndex]) || 
                    SampleText[strIndex + subsIndex] == char.ToUpperInvariant(TargetSubstring[subsIndex]))
                {
                    subsIndex++;

                    if (subsIndex >= TargetSubstring.Length)
                    {
                        isContained = true;
                        break;
                    }
                    else if (strIndex + subsIndex >= length)
                    {
                        break;
                    }
                }

                if (isContained)
                {
                    timesContained++;
                }

                strIndex += subsIndex;
            }

            Console.WriteLine("The substring \"{0}\" is contained {1} times in the text.", TargetSubstring, timesContained);
        }
    }
}
