namespace EncodingAndDecodingString
{
    using System;
    using System.Text;

    /*Write a program that encodes and decodes a string using given encryption key (cipher). 
     * The key consists of a sequence of characters. The encoding/decoding is done by performing 
     * XOR (exclusive or) operation over the first letter of the string with the first of the 
     * key, the second – with the second, etc. When the last key character is reached, the next is the first.*/

    public class EncodingAndDecodingString
    {
        private const string Cipher = "R2/d2";
        private const string SampleText = "This is some text to be encoded/decoded using XOR over letter`s numeral representation.";

        private static void Main()
        {
            string inputText = SampleText;
            string cipher = Cipher;
            string resultText = string.Empty;

            resultText = Coder(inputText, cipher);

            Console.WriteLine(resultText);

            resultText = Coder(resultText, cipher);

            Console.WriteLine(resultText);
        }

        private static string Coder(string inputText, string cipher)
        {
            StringBuilder result = new StringBuilder();
            int ciphLength = cipher.Length;
            for (int count = 0; count < inputText.Length; count++)
            {
                int cipherIndex = count % ciphLength;
                int nextItem = (int)inputText[count] ^ (int)cipher[cipherIndex];
                result.Append((char)nextItem);
            }

            return result.ToString();
        }
    }
}
