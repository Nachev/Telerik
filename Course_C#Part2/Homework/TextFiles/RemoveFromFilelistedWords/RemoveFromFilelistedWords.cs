namespace RemoveFromFilelistedWords
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program that removes from a text file all words listed in given another text file.
    /// Handle all possible exceptions in your methods.
    /// </summary>
    public class RemoveFromFilelistedWords
    {
        /// <summary>
        /// Path to test file.
        /// </summary>
        private const string Path = @"..\..\TestFile.tst";

        /// <summary>
        /// Path to list of words to be deleted.
        /// </summary>
        private const string ListPath = @"..\..\ListOfWords.lst";

        /// <summary>
        /// Content of the test file.
        /// </summary>
        private const string TestContent = @"Line breaks are also white space characters. Note that although &#x2028; 
and &#x2029; are defined in [ISO10646] to unambiguously separate lines and paragraphs, respectively, these do not
constitute line breaks in HTML, nor does this specification include them in the more general category of white space
characters.
This specification does not indicate the behavior, rendering or otherwise, of space characters other than those 
explicitly identified here as white space characters. For this reason, authors should use appropriate elements and 
styles to achieve visual formatting effects that involve white space, rather than space characters.
For all HTML elements except PRE, sequences of white space separate ""words"" (we use the term ""word"" here to mean
""sequences of non-white space characters""). When formatting text, user agents should identify these words and lay 
them out according to the conventions of the particular written language (script) and target medium.";

        /// <summary>
        /// Content of file with word list to be replaced.
        /// </summary>
        private const string WantedContent = "test reason involve behavior words script space";

        /// <summary>
        /// Main method.
        /// </summary>
        private static void Main()
        {
            string tempPath = @"..\..\TemporaryTxtFile.tst";
            string backupFile = @"..\..\BackUpFile.tst";

            try
            {
                ManageTestFile(TestContent, Path);
                ManageTestFile(WantedContent, ListPath);

                string[] wanted = ExtractListOfWords(ListPath);

                ProcessFile(tempPath, wanted);

                ReplaceTestFile(tempPath, backupFile);
            }
            catch (ArgumentNullException argNullEx)
            {
                Console.WriteLine("Exception: Path is not entered!" + argNullEx.StackTrace);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine("Exception: Entered path is not valid!" + argEx.StackTrace);
            }
            catch (PathTooLongException pathLong)
            {
                Console.WriteLine("Exception: Entered path is too long!" + pathLong.StackTrace);
            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine("Exception: Entered directory in path cannot be found!" + dirNotFound.StackTrace);
            }
            catch (FileNotFoundException fileNotFound)
            {
                Console.WriteLine("Exception: Entered file in path cannot be found" + fileNotFound.StackTrace);
            }
            catch (IOException ioEx)
            {
                Console.WriteLine("Exception: Input / Output error! This file is already opened or inaccessible." + ioEx.StackTrace);
            }
            catch (UnauthorizedAccessException accessEx)
            {
                Console.WriteLine("Exception: Access violation! You do not have authorization to access this file." + accessEx.StackTrace);
            }
            catch (NotSupportedException nse)
            {
                string message = nse.Message;
                Console.WriteLine("Exception: {0} {1}", message, nse.StackTrace);
            }
        }

        private static string[] ExtractListOfWords(string path)
        {
            return File.ReadAllText(path).Split(' ');
        } 

        /// <summary>
        /// Replaces temporary file with test file.
        /// </summary>
        /// <param name="tempPath">Temporary file path.</param>
        /// <param name="backupFile">BackUp file path.</param>
        private static void ReplaceTestFile(string tempPath, string backupFile)
        {
            File.Replace(tempPath, Path, backupFile);
        }

        /// <summary>
        /// Process files.
        /// </summary>
        /// <param name="tempPath">Temporary file path.</param>
        private static void ProcessFile(string tempPath, string[] wanted)
        {
            using (StreamReader reader = new StreamReader(Path))
            {
                List<string> someLines = new List<string>();
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                    {
                        File.AppendAllLines(tempPath, someLines);
                        break;
                    }
                    else if (wanted.Any(line.Contains))
                    {
                        line = CreateNewLine(line, wanted);
                    }

                    someLines.Add(line);

                    if (someLines.Count >= 100)
                    {
                        File.AppendAllLines(tempPath, someLines);
                        someLines.Clear();
                    }
                }
            }
        }

        /// <summary>
        /// Creates new line with replaced substring
        /// </summary>
        /// <param name="line">Line content to be replaced.</param>
        /// <returns>Content of new line.</returns>
        private static string CreateNewLine(string line, string[] wanted)
        {
            StringBuilder newLine = new StringBuilder();
            string[] words = Regex.Split(line, @"(?<=[., ])");
            foreach (var element in words)
            {
                if (!DoesContain(wanted, element))
                {
                    newLine.Append(element);
                }
            }

            return newLine.ToString();
        }

        private static bool DoesContain(string[] wanted, string word)
        {
            bool isMatch = new bool();
            foreach (var item in wanted)
            {
                if (Regex.IsMatch(word, item + @"[\.|,| ]"))
                {
                    isMatch = true;
                }
            }

            return isMatch;
        }

        /// <summary>
        /// If test file exists deletes it and creates it again.
        /// </summary>
        /// <param name="content">Content of file to be written.</param>
        private static void ManageTestFile(string content, string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.WriteAllText(path, content);
        }
    }
}
