namespace TreeTasks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Tree;

    internal class SampleProgram
    {
        private static void Main()
        {
            var nodes = TreeInput();

            // a) the root node
            var root = FindTheRoot(nodes);
            Console.WriteLine("The root is: " + root.Value);

            // b) all leaf nodes
            var leaves = FindAllLeaves(root);
            PrintNodesValues("Leafs are: ", leaves);

            // c) all middle nodes
            var middleNodes = FindMiddleNodes(root);
            PrintNodesValues("Middle nodes are: ", middleNodes);

            // d) the longest path in the tree
            var longestPathLength = FindLongestPathLength(root);
            Console.WriteLine("Longest path is: " + longestPathLength);
        }
 
        private static void PrintNodesValues(string message, IList<Node<int>> nodes)
        {
            Console.WriteLine(message);
            foreach (var node in nodes)
            {
                Console.Write(node.Value);
                Console.Write(", ");
            }

            Console.WriteLine();
        }

        private static int FindLongestPathLength<T>(Node<T> rootNode)
        {
            var resultPathLength = new int();
            var discoveredNodes = new HashSet<Node<T>>();
            var nodesStack = new Stack<Node<T>>();

            nodesStack.Push(rootNode);
            int currentPathLength = 0;

            while (nodesStack.Count > 0)
            {
                var currentNode = nodesStack.Pop();

                if (!discoveredNodes.Contains(currentNode))
                {
                    discoveredNodes.Add(currentNode);
                    currentPathLength++;

                    if (currentNode.Children.Count > 0)
                    {
                        foreach (var child in currentNode.Children)
                        {
                            nodesStack.Push(child);
                        }
                    }
                    else
                    {
                        currentPathLength--;
                    }
                }

                if (currentPathLength > resultPathLength)
                {
                    resultPathLength = currentPathLength;
                }
            }

            return resultPathLength;
        }

        private static IList<Node<T>> FindMiddleNodes<T>(Node<T> rootNode)
        {
            var result = new List<Node<T>>();
            var stack = new Stack<IList<Node<T>>>();
            stack.Push(new List<Node<T>>() { rootNode });

            while (stack.Count > 0)
            {
                var currentList = stack.Pop();
                foreach (var child in currentList)
                {
                    if (child.Children.Count > 0)
                    {
                        stack.Push(child.Children);

                        if (child.HasParent)
                        {
                            result.Add(child);
                        }
                    }
                }
            }

            return result;
        }

        private static IList<Node<T>> FindAllLeaves<T>(Node<T> rootNode)
        {
            var result = new List<Node<T>>();
            var stack = new Stack<IList<Node<T>>>();
            stack.Push(new List<Node<T>>() { rootNode });

            while (stack.Count > 0)
            {
                var currentList = stack.Pop();
                foreach (var child in currentList)
                {
                    if (child.Children.Count > 0)
                    {
                        stack.Push(child.Children);
                    }
                    else
                    {
                        result.Add(child);
                    }
                }
            }

            return result;
        }

        private static Node<T> FindTheRoot<T>(IList<Node<T>> inputNodes)
        {
            foreach (var node in inputNodes)
            {
                if (!node.HasParent)
                {
                    return node;
                }
            }

            throw new ApplicationException("The tree has no root.");
        }

        private static IList<Node<int>> TreeInput()
        {
            Console.Write("Enter number of nodes N: ");
            string input = Console.ReadLine();
            int numberOfNodes = int.Parse(input);
            var nodes = new List<Node<int>>(numberOfNodes);

            for (int count = 0; count < numberOfNodes; count++)
            {
                nodes.Add(new Node<int>(count));
            }

            bool firstInput = true, secondInput = true;
            while (firstInput && secondInput)
            {
                Console.Write("Enter relation: ");
                string relationInput = Console.ReadLine();

                if (relationInput.Length <= 1)
                {
                    break;
                }

                string[] relationStringArr = relationInput.Split(' ');

                int parentId = new int();
                firstInput = int.TryParse(relationStringArr[0], out parentId);
                int childId = new int();
                secondInput = int.TryParse(relationStringArr[1], out childId);

                nodes[childId].HasParent = true;
                nodes[parentId].Children.Add(nodes[childId]);
            }
            return nodes;
        }
        //private static void Main(string[] args)
        //{
        //    var N = int.Parse(Console.ReadLine());
        //    var nodes = new Node<int>[N];
        //    for (int i = 0; i < N; i++)
        //    {
        //        nodes[i] = new Node<int>(i);
        //    }
        //    for (int i = 1; i <= N - 1; i++)
        //    {
        //        string edgeAsString = Console.ReadLine();
        //        var edgeParts = edgeAsString.Split(' ');
        //        int parentId = int.Parse(edgeParts[0]);
        //        int childId = int.Parse(edgeParts[1]);
        //        nodes[parentId].Children.Add(nodes[childId]);
        //        nodes[childId].HasParent = true;
        //    }
        //    // 1. Find the root
        //    var root = FindRoot(nodes);
        //    Console.WriteLine("The root of the tree is: {0}", root.Value);
        //    // 2. Find all leafs
        //    var leafs = FindAllLeafs(nodes);
        //    Console.Write("Leafs: ");
        //    foreach (var leaf in leafs)
        //    {
        //        Console.Write("{0}, ", leaf.Value);
        //    }
        //    Console.WriteLine();
        //    // 3. Find all middle nodes
        //    var middleNodes = FindAllMiddleNodes(nodes);
        //    Console.Write("Middle nodes: ");
        //    foreach (var node in middleNodes)
        //    {
        //        Console.Write("{0}, ", node.Value);
        //    }
        //    Console.WriteLine();
        //    // 4. Find the longest path from the root
        //    var longestPath = FindLongestPath(FindRoot(nodes));
        //    Console.WriteLine("Number of levels: {0}", longestPath + 1);
        //}
        //private static Node<int> FindRoot(Node<int>[] nodes)
        //{
        //    var hasParent = new bool[nodes.Length];
        //    foreach (var node in nodes)
        //    {
        //        foreach (var child in node.Children)
        //        {
        //            hasParent[child.Value] = true;
        //        }
        //    }
        //    for (int i = 0; i < hasParent.Length; i++)
        //    {
        //        if (!hasParent[i])
        //        {
        //            return nodes[i];
        //        }
        //    }
        //    throw new ArgumentException("nodes", "The tree has no root.");
        //}
        //private static int FindLongestPath(Node<int> root)
        //{
        //    if (root.Children.Count == 0)
        //    {
        //        return 0;
        //    }
        //    int maxPath = 0;
        //    foreach (var node in root.Children)
        //    {
        //        maxPath = Math.Max(maxPath, FindLongestPath(node));
        //    }
        //    return maxPath + 1;
        //}
        //private static List<Node<int>> FindAllMiddleNodes(Node<int>[] nodes)
        //{
        //    List<Node<int>> middleNodes = new List<Node<int>>();
        //    foreach (var node in nodes)
        //    {
        //        if (node.HasParent && node.Children.Count > 0)
        //        {
        //            middleNodes.Add(node);
        //        }
        //    }
        //    return middleNodes;
        //}
        //private static List<Node<int>> FindAllLeafs(Node<int>[] nodes)
        //{
        //    List<Node<int>> leafs = new List<Node<int>>();
        //    foreach (var node in nodes)
        //    {
        //        if (node.Children.Count == 0)
        //        {
        //            leafs.Add(node);
        //        }
        //    }
        //    return leafs;
        //}
    }
}