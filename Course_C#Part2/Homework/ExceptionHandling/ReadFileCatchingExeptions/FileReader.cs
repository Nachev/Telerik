namespace ReadFileCatchingExeptions
{
    using System;
    using System.IO;
    using System.Text;
    using System.Security.AccessControl;

    /*Write a program that enters file name along with its full file path (e.g. C:\WINDOWS\win.ini), 
     * reads its contents and prints it on the console. Find in MSDN how to use System.IO.File.ReadAllText(…).
     * Be sure to catch all possible exceptions and print user-friendly error messages.*/

    public class FileReader
    {
        private static void Main()
        {
            Console.Title = "File reader";

            string path = @"..\..\TestFile.txt";
            string inputText = "This is sample text for testing purposes.";
            string reader = string.Empty;

            ManageTestFile(path, inputText);

            try
            {
                reader = ReadEmptyFile(path, reader);
                // reader = ReadNullPathFile(reader);
                // reader = ReadInvalidPathFile(reader);
                // reader = PathTooLong(reader);
                // reader = NonExistingDirectory(reader);
                // reader = FileNotFound(reader);
                // reader = InputOutputException(path, reader);
                // reader = AccessViolation(path, reader);
                // reader = NotSupported(reader);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Exception: Path is not entered!");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Exception: Entered path is not valid!");
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("Exception: Entered path is too long!");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Exception: Entered directory in path cannot be found!");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Exception: Entered file in path cannot be found");
            }
            catch (IOException)
            {
                Console.WriteLine("Exception: Input / Output error! This file is already opened or inaccessible.");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Exception: Access violation! You do not have authorization to access this file.");
            }
            catch (NotSupportedException nse)
            {
                string message = nse.Message;
                Console.WriteLine("Exception: {0}", message);
            }

            Console.WriteLine(reader);
        }

        private static void ManageTestFile(string path, string inputText)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            File.AppendAllText(path, inputText);
        }

        private static string NotSupported(string reader)
        {
            NotSupportedException nse = new NotSupportedException();
            throw nse;
        }

        private static string AccessViolation(string path, string reader)
        {
            // To test exception for access violation file access permitions for current user have to be changed.
            FileSecurity fSecurity = File.GetAccessControl(path);
            Console.Write("To test this exception enter your windows account name: ");
            string account = Console.ReadLine();

            // Remove the FileSystemAccessRule from the security settings.
            fSecurity.AddAccessRule(new FileSystemAccessRule(account, FileSystemRights.Read, AccessControlType.Deny));

            // Set the new access settings.
            File.SetAccessControl(path, fSecurity);

            reader = File.ReadAllText(path);
            return reader;
        }

        private static string InputOutputException(string path, string reader)
        {
            using (StreamWriter writer = File.AppendText(path))
            {
                writer.Write(File.ReadAllText(path));
            }
            return reader;
        }

        private static string FileNotFound(string reader)
        {
            reader = File.ReadAllText(@"..\..\NoFileThere.txt");
            return reader;
        }

        private static string NonExistingDirectory(string reader)
        {
            reader = File.ReadAllText(@"C:\Kernel\TestNonExistingFile.abc");
            return reader;
        }

        private static string PathTooLong(string reader)
        {
            StringBuilder longPath = new StringBuilder();
            Random rng = new Random();
            for (int count = 0; count < 260; count++)
            {
                longPath.Append(rng.Next(65, 91));
            }

            reader = File.ReadAllText(longPath.ToString());
            return reader;
        }

        private static string ReadInvalidPathFile(string reader)
        {
            string invalidPath = string.Empty;
            reader = File.ReadAllText(invalidPath);
            return reader;
        }

        private static string ReadNullPathFile(string reader)
        {
            string nullPath = null;
            reader = File.ReadAllText(nullPath);
            return reader;
        }

        private static string ReadEmptyFile(string path, string reader)
        {
            reader = File.ReadAllText(path);
            return reader;
        }
    }
}
