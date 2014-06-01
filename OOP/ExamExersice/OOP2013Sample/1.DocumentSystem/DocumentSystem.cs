namespace DocumentSystem
{
    using System;
    using System.Collections.Generic;

    public class DocumentSystem
    {
        static void Main()
        {
            IList<string> allCommands = ReadAllCommands();
            ExecuteCommands(allCommands);
        }

        private static IList<string> ReadAllCommands()
        {
            List<string> commands = new List<string>();

            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "")
                {
                    // End of commands
                    break;
                }
                commands.Add(commandLine);
            }
            return commands;
        }

        private static void ExecuteCommands(IList<string> commands)
        {
            foreach (var commandLine in commands)
            {
                int paramsStartIndex = commandLine.IndexOf("[");
                string cmd = commandLine.Substring(0, paramsStartIndex);
                int paramsEndIndex = commandLine.IndexOf("]");
                string parameters = commandLine.Substring(
                    paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
                ExecuteCommand(cmd, parameters);
            }
        }

        private static void ExecuteCommand(string cmd, string parameters)
        {
            string[] cmdAttributes = parameters.Split(
                new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            if (cmd == "AddTextDocument")
            {
                AddTextDocument(cmdAttributes);
            }
            else if (cmd == "AddPDFDocument")
            {
                AddPdfDocument(cmdAttributes);
            }
            else if (cmd == "AddWordDocument")
            {
                AddWordDocument(cmdAttributes);
            }
            else if (cmd == "AddExcelDocument")
            {
                AddExcelDocument(cmdAttributes);
            }
            else if (cmd == "AddAudioDocument")
            {
                AddAudioDocument(cmdAttributes);
            }
            else if (cmd == "AddVideoDocument")
            {
                AddVideoDocument(cmdAttributes);
            }
            else if (cmd == "ListDocuments")
            {
                ListDocuments();
            }
            else if (cmd == "EncryptDocument")
            {
                EncryptDocument(parameters);
            }
            else if (cmd == "DecryptDocument")
            {
                DecryptDocument(parameters);
            }
            else if (cmd == "EncryptAllDocuments")
            {
                EncryptAllDocuments();
            }
            else if (cmd == "ChangeContent")
            {
                ChangeContent(cmdAttributes[0], cmdAttributes[1]);
            }
            else
            {
                throw new InvalidOperationException("Invalid command: " + cmd);
            }
        }

        private static void AddTextDocument(string[] attributes)
        {
            var parameters = SeparateParameters(attributes);
            string name;
            name = ExtractName(parameters, name);
            HandleNullName(name);

        }

        private static void AddPdfDocument(string[] attributes)
        {
            // TODO
        }

        private static void AddWordDocument(string[] attributes)
        {
            // TODO
        }

        private static void AddExcelDocument(string[] attributes)
        {
            // TODO
        }

        private static void AddAudioDocument(string[] attributes)
        {
            // TODO
        }

        private static void AddVideoDocument(string[] attributes)
        {
            // TODO
        }

        private static void ListDocuments()
        {
            // TODO
        }

        private static void EncryptDocument(string name)
        {
            // TODO
        }

        private static void DecryptDocument(string name)
        {
            // TODO
        }

        private static void EncryptAllDocuments()
        {
            // TODO
        }

        private static void ChangeContent(string name, string content)
        {
            // TODO
        }

        private static IList<KeyValuePair<string, object>> SeparateParameters(params string[] parametersAsString)
        {
            var parameters = new List<KeyValuePair<string, object>>();

            foreach (var pair in parametersAsString)
            {
                var intPair = pair.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
                parameters.Add(new KeyValuePair<string, object>(intPair[0], intPair[1]));
            }

            return parameters;
        }

        private static string ExtractName(IList<KeyValuePair<string, object>> parameters, string name)
        {
            int indexSave = -1;
            for (int index = 0; index < parameters.Count; index++)
            {
                if (parameters[index].Key.ToLowerInvariant() == "name")
                {
                    name = parameters[index].Value.ToString();
                    indexSave = index;
                }
            }

            parameters.RemoveAt(indexSave);
            return name;
        }

        private static void HandleNullName(string name)
        {
            if (name == null)
            {
                Console.WriteLine("Document has no name");
            }
        }
    }
}