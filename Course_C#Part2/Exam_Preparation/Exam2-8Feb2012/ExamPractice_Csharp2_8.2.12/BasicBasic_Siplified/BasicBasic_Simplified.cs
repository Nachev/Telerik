using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BasicBasic_Simplified
{
    public class Basic_Basic
    {
        //private static List<char> operations = new List<char>() { '+', '-', '=', '<', '>' };
        //private static List<string> keyWords = new List<string>() { "IF", "THEN", "GOTO", "CLS", "STOP", "PRINT", "RUN" };
        //private static List<char> variableList = new List<char>() { 'V', 'W', 'X', 'Y', 'Z' };

        private static void Main()
        {
            SortedDictionary<int, string> lines = new SortedDictionary<int, string>();
            Dictionary<string, int> variables = new Dictionary<string, int>() { { "V", 0 }, { "W", 0 }, { "X", 0 }, { "Y", 0 }, { "Z", 0 } };
            Input(lines);
            //foreach (var item in lines)
            //{
            //    Console.WriteLine(item.Key + " --> " + item.Value);
            //    Console.ReadKey();
            //} 

            Processing(lines, variables);
        }

        private static void Processing(SortedDictionary<int, string> lines, Dictionary<string, int> variables)
        {
            StringBuilder screen = new StringBuilder();
            int key = lines.Keys.First();
            while (true)
            {
                key = ProcessLine(lines, variables, ref screen, key);
            }
        }

        private static int ProcessLine(SortedDictionary<int, string> lines, Dictionary<string, int> variables, ref StringBuilder screen, int key)
        {
            string[] lineElements = lines[key].Split(new[] { ' ' });
            int index = 0;
            if (variables.ContainsKey(lineElements[index]))
            {
                index = HandleFirstVariable(variables, lineElements, index);
            }
            else if (lineElements[index] == "IF")
            {
                index = HandleBoolean(variables, lineElements, index);
            }
            else if (lineElements[index] == "PRINT" || lineElements[index] == "CLS")
            {
                index = HandleScreenCommand(variables, ref screen, lineElements, index);
            }
            else if (lineElements[index] == "STOP")
            {
                Console.Write(screen);
                Environment.Exit(0);
            }

            if (index < lineElements.Length && lineElements[index] == "GOTO")
            {
                index++;
                key = int.Parse(lineElements[index]);
            }
            else
            {
                do
                {
                    key++;
                }
                while (!lines.ContainsKey(key));
            }

            return key;
        }

        private static int HandleScreenCommand(Dictionary<string, int> variables, ref StringBuilder screen, string[] lineElements, int index)
        {
            if (lineElements[index] == "PRINT")
            {
                index++;
                if (variables.ContainsKey(lineElements[index]))
                {
                    screen.Append(variables[lineElements[index]]).AppendLine();
                }
                else
                {
                    screen.Append(lineElements[index]).AppendLine();
                }
            }
            else if (lineElements[index] == "CLS")
            {
                screen.Clear();
            }

            index += 1;
            return index;
        }

        private static int HandleBoolean(Dictionary<string, int> variables, string[] lineElements, int index)
        {
            bool isOK = new bool();
            index += 1;

            int tempVar1 = ManageVariablesInIf(variables, lineElements, ref index);

            index += 1;

            if (lineElements[index] == ">")
            {
                index += 1;
                isOK = tempVar1 > ManageVariablesInIf(variables, lineElements, ref index);
            }
            else if (lineElements[index] == "<")
            {
                index += 1;
                isOK = tempVar1 < ManageVariablesInIf(variables, lineElements, ref index);
            }
            else if (lineElements[index] == "=")
            {
                index += 1;
                isOK = tempVar1 == ManageVariablesInIf(variables, lineElements, ref index);
            }

            index += 2;

            if (isOK)
            {
                if (lineElements[index] != "GOTO")
                {
                    index = HandleFirstVariable(variables, lineElements, index);
                }
            }
            else
            {
                index += 2;
            }

            return index;
        }

        private static int ManageVariablesInIf(Dictionary<string, int> variables, string[] lineElements, ref int index)
        {
            int tempVar1 = new int();
            if (lineElements[index] == "-")
            {
                index += 1;
                tempVar1 = int.Parse(lineElements[index]) * -1;
            }
            else if (variables.ContainsKey(lineElements[index]))
            {
                tempVar1 = variables[lineElements[index]];
            }
            else
            {
                tempVar1 = int.Parse(lineElements[index]);
            }

            return tempVar1;
        }

        private static int HandleFirstVariable(Dictionary<string, int> variables, string[] lineElements, int index)
        {
            int mainIndex = index++;
            int tempVar = new int();
            if (lineElements[index++] != "=")
            {
                throw new SystemException();
            }
            else if (lineElements[index] == "-")
            {
                index++;
                tempVar = HandleNextVar(variables, lineElements, -1, index);
                variables[lineElements[mainIndex]] = tempVar;

                if (lineElements.Length > index + 1)
                {
                    index++;
                    if (lineElements[index] == "+")
                    {
                        index++;
                        tempVar = HandleNextVar(variables, lineElements, 1, index);
                        variables[lineElements[mainIndex]] += tempVar;
                    }
                    else
                    {
                        index++;
                        tempVar = HandleNextVar(variables, lineElements, 1, index);
                        variables[lineElements[mainIndex]] -= tempVar;
                    }
                }
            }
            else
            {
                tempVar = HandleNextVar(variables, lineElements, 1, index);
                variables[lineElements[mainIndex]] = tempVar;

                if (lineElements.Length > index + 1)
                {
                    index++;
                    if (lineElements[index] == "+")
                    {
                        index++;
                        tempVar = HandleNextVar(variables, lineElements, 1, index);
                        variables[lineElements[mainIndex]] += tempVar;
                    }
                    else
                    {
                        index++;
                        tempVar = HandleNextVar(variables, lineElements, 1, index);
                        variables[lineElements[mainIndex]] -= tempVar;
                    }
                }
            }

            index += 1;
            return index;
        }

        private static int HandleNextVar(Dictionary<string, int> variables, string[] lineElements, int coef, int index)
        {
            int tempVar = new int();
            int nextVar = new int();
            if (variables.ContainsKey(lineElements[index]))
            {
                nextVar = variables[lineElements[index]] * coef;
            }
            else if (int.TryParse(lineElements[index], out tempVar))
            {
                nextVar = tempVar * coef;
            }
            return nextVar;
        }

        private static void Input(SortedDictionary<int, string> lines)
        {
            string tempLine = string.Empty;
            string regex = @"(?<=^\d+)\s";
            while (tempLine != "RUN")
            {
                tempLine = Console.ReadLine();
                tempLine = Normalize(tempLine).Trim();

                if (tempLine == "RUN")
                {
                    int lastKey = lines.Keys.Last() + 1;
                    lines.Add(lastKey, "STOP");
                    break;
                }

                string[] parts = Regex.Split(tempLine, regex);
                lines.Add(int.Parse(parts[0]), parts[1]);
            }
        }

        private static string Normalize(string input)
        {
            string[] lineArr = input.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return string.Join(" ", lineArr);
        }
    }
}
