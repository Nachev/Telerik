namespace Salaries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class EntryPoint
    {
        private static void Main(string[] args)
        {
            int employeesCount = int.Parse(Console.ReadLine());
            bool[,] graph = new bool[employeesCount, employeesCount];
            bool[] visited = new bool[employeesCount];

            for (int i = 0; i < employeesCount; i++)
            {
                string inputLine = Console.ReadLine();
                for (int j = 0; j < employeesCount; j++)
                {
                    if (inputLine[j] == 'N')
                    {
                        graph[i, j] = false;
                    }
                    else
                    {
                        graph[i, j] = true;
                    }
                }
            }

            var graphClass = new Graph(graph);
            graphClass.Traverse();
            graphClass.ShowSort();
        }
    }

    internal class Node
    {
        public int Id { get; set; }

        public int Salary { get; set; }

        public Node(int id)
        {
            this.Id = id;
            this.Salary = 0;
        }
    }
}
