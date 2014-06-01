namespace Brackets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    public class Brackets
    {
        private static void Main()
        {
            int lines = int.Parse(Console.ReadLine());
            string indentation = Console.ReadLine();
            int indents = 0;
            string regex = @"(\s+|\{\s*|\}\s*)";
            for (int count = 0; count < lines; count++)
            {
                string lineInput = Console.ReadLine().Trim();
                string[] line = Regex.Split(lineInput, regex);
                StringBuilder result = new StringBuilder();
                for (int index = 0; index < line.Length; index++)
                {
                    line[index] = line[index].Trim();
                    if (line[index] == "{")
                    {
                        if (result.Length != 0 && result[result.Length - 1] != '\n')
                        {
                            result.AppendLine();
                        }

                        Indentation(indentation, indents, result);
                        indents += 1;
                        result.Append(line[index]).AppendLine();
                    }
                    else if (line[index] == "}")
                    {
                        if (result.Length != 0 && result[result.Length - 1] != '\n')
                        {
                            result.AppendLine();
                        }

                        indents -= 1;
                        Indentation(indentation, indents, result);
                        result.Append(line[index]).AppendLine();
                    }
                    else if (line[index] != string.Empty && line[index] != " ")
                    {
                        if (result.Length == 0 || result[result.Length - 1] == '\n')
                        {
                            Indentation(indentation, indents, result);
                        }
                        result.Append(line[index]).Append(' ');
                    }
                }

                if (result.Length > 0)
                {
                    Console.WriteLine(result.ToString().Trim());
                }
            }
        }

        private static void Indentation(string indentation, int indents, StringBuilder result)
        {
            for (int i = 0; i < indents; i++)
            {
                result.Append(indentation);
            }
        }
    }
}
