namespace UpCaseTagImplementation
{
    using System;
    using System.Text;

    /*You are given a text. Write a program that changes the text in all regions surrounded by 
     * the tags <upcase> and </upcase> to uppercase. The tags cannot be nested.*/

    public class UpCaseTagImplementation
    {
        private const string OpenTag = "<upcase>";
        private const string CloseTag = "</upcase>";
        private const string SampleText = "We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";

        private static void Main()
        {
            string tag = OpenTag;
            bool toUpper = new bool();
            StringBuilder result = new StringBuilder();
            int length = SampleText.Length;
            for (int strIndex = 0; strIndex < length; strIndex++)
            {
                if (IsItTag(tag, length, strIndex))
                {
                    strIndex += tag.Length;
                    if (tag == OpenTag)
                    {
                        toUpper = true;
                        tag = CloseTag;
                    }
                    else
                    {
                        toUpper = false;
                        tag = OpenTag;
                    }
                }

                AppendNextElement(toUpper, result, strIndex);
            }

            Console.WriteLine(result);
        }

        private static void AppendNextElement(bool toUpper, StringBuilder result, int strIndex)
        {
            if (toUpper)
            {
                result.Append(char.ToUpper(SampleText[strIndex]));
            }
            else
            {
                result.Append(SampleText[strIndex]);
            }
        }

        private static bool IsItTag(string tag, int length, int strIndex)
        {
            bool isTag = new bool();
            int tagIndex = 0;
            while (SampleText[strIndex + tagIndex] == tag[tagIndex])
            {
                tagIndex++;

                if (tagIndex >= tag.Length)
                {
                    isTag = true;
                    break;
                }
                else if (strIndex + tagIndex >= length)
                {
                    break;
                }
            }

            return isTag;
        }
    }
}
