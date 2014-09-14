namespace Salaries
{
    using System;
    using System.Collections.Generic;

    public class Graph
    {
        private readonly bool[,] edges;

        private readonly int count;

        public int[] Salaries;

        public Graph(bool[,] elements)
        {
            this.edges = elements;
            this.count = elements.GetLength(0);
            this.Salaries = new int[this.count];
        }

        public void Traverse()
        {
            for (int i = 0; i < this.count; i++)
            {
                if (this.Salaries[i] == 0)
                {
                    this.Dfs(i);
                }
            }
        }

        private void Dfs(int startIndex)
        {
            bool hasEmployees = false;

            for (int k = 0; k < this.count; k++)
            {
                if (this.edges[startIndex, k] && this.Salaries[k] == 0) 
                {
                    this.Dfs(k);
                    this.Salaries[startIndex] += this.Salaries[k];
                    hasEmployees = true;
                }
            }

            if (!hasEmployees)
            {
                this.Salaries[startIndex] = 1;
            }
        }

        public void ShowSort()
        {
            foreach (var node in this.Salaries)
            {
                Console.Write("{0} ", node);
            }
        }
    }
}
