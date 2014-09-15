namespace FriendsOfPesho
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    internal class EntryPoint
    {
        private static void Main(string[] args)
        {
            // Input
            var firstLineInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int n = int.Parse(firstLineInput[0]); // Points on map
            int m = int.Parse(firstLineInput[1]); // Streets 
            int h = int.Parse(firstLineInput[2]); // Hospitals

            int[] hospitals = new int[h];
            var hospitalsInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int hospitalsCount = 0; hospitalsCount < h; hospitalsCount++)
            {
                hospitals[hospitalsCount] = int.Parse(hospitalsInput[hospitalsCount]);
            }

            var routes = new Dictionary<Node, IList<Relation>>(m);
            var nodesById = new Dictionary<int, Node>(m);
            for (int i = 0; i < m; i++)
            {
                var inputValues = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int buildingA = int.Parse(inputValues[0]);
                int buildingB = int.Parse(inputValues[1]);
                int distance = int.Parse(inputValues[2]);

                Node firstNode;
                if (nodesById.ContainsKey(buildingA))
                {
                    firstNode = nodesById[buildingA];
                }
                else
                {
                    firstNode = new Node(buildingA, int.MaxValue);
                    nodesById.Add(buildingA, firstNode);
                    routes.Add(firstNode, new List<Relation>());
                }

                Node secondNode;
                if (nodesById.ContainsKey(buildingB))
                {
                    secondNode = nodesById[buildingB];
                }
                else
                {
                    secondNode = new Node(buildingB, int.MaxValue);
                    nodesById.Add(buildingB, secondNode);
                    routes.Add(secondNode, new List<Relation>());
                }

                var firstRelation = new Relation(secondNode, distance);
                routes[firstNode].Add(firstRelation);


                var secondRelation = new Relation(firstNode, distance);
                routes[secondNode].Add(secondRelation);

            }

            // Mark hospitals
            foreach (var hospital in hospitals)
            {               
                nodesById[hospital].IsHospital = true;
            }

            // Solve
            int resultSumPath = int.MaxValue;
            foreach (var hospital in hospitals)
            {
                var currentHospital = nodesById[hospital];

                DijkstraAlgorithm(routes, currentHospital);

                int currentPath = new int();
                foreach (var pair in routes)
                {
                    if (!pair.Key.IsHospital)
                    {
                        currentPath += pair.Key.DijkstraDistance;
                    }
                }

                if (resultSumPath > currentPath)
                {
                    resultSumPath = currentPath;
                }
            }

            Console.WriteLine(resultSumPath);
        }

        private static void DijkstraAlgorithm(IDictionary<Node, IList<Relation>> graph, Node startingNode)
        {
            var queue = new PriorityQueue<Node>(false);

            foreach (var node in graph)
            {
                node.Key.DijkstraDistance = int.MaxValue;
            }

            startingNode.DijkstraDistance = 0;
            queue.Enqueue(startingNode);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                if (currentNode.DijkstraDistance == int.MaxValue)
                {
                    break;
                }

                foreach (var path in graph[currentNode])
                {
                    int calcDistance = currentNode.DijkstraDistance + path.Weight;
                    if (calcDistance < path.Destination.DijkstraDistance)
                    {
                        path.Destination.DijkstraDistance = calcDistance;
                        queue.Enqueue(path.Destination);
                    }
                }
            }
        }
    }

    internal class Node : IEquatable<Node>, IComparable<Node>, IComparable
    {
        private readonly int id;
        private int dijkstraDistance;

        public bool IsHospital { get; set; }

        public Node()
        {
            this.IsHospital = false;
            this.DijkstraDistance = int.MaxValue;
        }

        public Node(int id)
            : this()
        {
            this.id = id;
        }

        public Node(int id, int dijkstraDistance)
            : this(id)
        {
            this.DijkstraDistance = dijkstraDistance;
        }

        public int DijkstraDistance
        {
            get { return dijkstraDistance; }
            set { dijkstraDistance = value; }
        }

        public int Id
        {
            get { return id; }
        }

        public override int GetHashCode()
        {
            int hash = this.id.GetHashCode();
            return hash;
        }

        public bool Equals(Node other)
        {
            bool result = this.Id.CompareTo(other.Id) == 0;
            return result;
        }

        public int CompareTo(Node other)
        {
            int result = this.DijkstraDistance.CompareTo(other.DijkstraDistance);
            return result;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return -1;
            }

            if (!(obj is Node))
            {
                return -1;
            }

            return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
        }
    }

    internal class Relation : IComparable<Relation>
    {
        private Node destination;
        private int weight;

        public Relation(Node destination, int weight)
        {
            this.Destination = destination;
            this.Weight = weight;
        }

        public int Weight
        {
            get { return weight; }
            private set { weight = value; }
        }

        public Node Destination
        {
            get { return destination; }
            private set { destination = value; }
        }

        public int CompareTo(Relation other)
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }
    public class PriorityQueueDemo<T> where T : IComparable
    {
        private T[] heap;
        private int index;

        public PriorityQueueDemo()
        {
            this.heap = new T[16];
            this.index = 1;
        }

        public int Count
        {
            get
            {
                return this.index - 1;
            }
        }

        public void Enqueue(T element)
        {
            if (this.index >= this.heap.Length)
            {
                this.IncreaseArray();
            }

            this.heap[this.index] = element;

            int childIndex = this.index;
            int parentIndex = childIndex / 2;
            this.index++;

            while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
            {
                T swapValue = this.heap[parentIndex];
                this.heap[parentIndex] = this.heap[childIndex];
                this.heap[childIndex] = swapValue;

                childIndex = parentIndex;
                parentIndex = childIndex / 2;
            }
        }

        public T Dequeue()
        {
            T result = this.heap[1];

            this.heap[1] = this.heap[this.Count];
            this.index--;

            int rootIndex = 1;

            while (true)
            {
                int leftChildIndex = rootIndex * 2;
                int rightChildIndex = (rootIndex * 2) + 1;

                if (leftChildIndex > this.index)
                {
                    break;
                }

                int minChild;
                if (rightChildIndex > this.index)
                {
                    minChild = leftChildIndex;
                }
                else
                {
                    if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
                    {
                        minChild = leftChildIndex;
                    }
                    else
                    {
                        minChild = rightChildIndex;
                    }
                }

                if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
                {
                    T swapValue = this.heap[rootIndex];
                    this.heap[rootIndex] = this.heap[minChild];
                    this.heap[minChild] = swapValue;

                    rootIndex = minChild;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public T Peek()
        {
            return this.heap[1];
        }

        private void IncreaseArray()
        {
            var copiedHeap = new T[this.heap.Length * 2];

            for (int i = 0; i < this.heap.Length; i++)
            {
                copiedHeap[i] = this.heap[i];
            }

            this.heap = copiedHeap;
        }
    }

    internal class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private const int DefaultCapacity = 8;
        private int capacity;
        private T[] array;
        private int count;
        private bool priorityMax;

        public PriorityQueue(bool priorityMax = true)
        {
            this.capacity = DefaultCapacity;
            Initialize(priorityMax);
        }

        public PriorityQueue(int initialCapacity, bool priorityMax = true)
        {
            if (initialCapacity < 1)
            {
                throw new ArgumentException("Illegal value for initial capacity. Must be non-zero positive value.");
            }

            this.capacity = initialCapacity;
            Initialize(priorityMax);
        }

        public PriorityQueue(ICollection<T> inputArray, bool priorityMax = true)
        {
            if (inputArray == null)
            {
                throw new ArgumentNullException("Cannot convert null value to priority queue.");
            }

            this.capacity = inputArray.Count;
            Initialize(priorityMax);

            foreach (var item in inputArray)
            {
                this.Enqueue(item);
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Enqueue(IEnumerable<T> elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Cannot add null collection to the queue.");
            }

            foreach (var element in elements)
            {
                this.Enqueue(element);
            }
        }

        public void Enqueue(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("Cannot add null value to the queue.");
            }

            if (this.count >= this.capacity)
            {
                this.Resize();
            }

            this.array[this.count] = element;
            if (this.priorityMax)
            {
                this.ShiftMaxUp();
            }
            else
            {
                this.ShiftMinUp();
            }

            this.count++;
        }

        public T Dequeue()
        {
            if (this.count <= 0)
            {
                throw new ApplicationException("Cannot dequeue from empty queue!");
            }

            T headElement = this.array[0];
            this.array[0] = this.array[this.count - 1];
            this.count--;
            if (this.priorityMax)
            {
                this.ShiftMaxDown();
            }
            else
            {
                this.ShiftMinDown();
            }

            return headElement;
        }

        public T Peek()
        {
            if (this.count <= 0)
            {
                throw new ArgumentException("Cannot peek into empty priority queue!");
            }

            return this.array[0];
        }

        public void Print()
        {
            Console.WriteLine(string.Join(", ", this.array.Take(this.count)));
        }

        private void Initialize(bool priorityMax)
        {
            this.priorityMax = priorityMax;
            this.array = new T[this.capacity];
            this.count = 0;
        }

        private void Resize()
        {
            this.capacity = this.capacity * 2;
            T[] newArray = new T[this.capacity];
            for (int i = 0; i < this.count; i++)
            {
                newArray[i] = this.array[i];
            }

            this.array = newArray;
        }

        private void ShiftMinUp()
        {
            this.ShiftUp((x, y) => x.CompareTo(y) < 0);
        }

        private void ShiftMinDown()
        {

            this.ShiftDown(((x, y) => x.CompareTo(y) > 0), ((x, y) => x.CompareTo(y) < 0));
        }

        private void ShiftMaxUp()
        {
            this.ShiftUp((x, y) => x.CompareTo(y) > 0);
        }

        private void ShiftMaxDown()
        {
            this.ShiftDown(((x, y) => x.CompareTo(y) < 0), ((x, y) => x.CompareTo(y) > 0));
        }

        private void ShiftUp(Func<T, T, bool> compare)
        {
            int currentPosition = this.count;
            int parentPosition = (currentPosition - 1) / 2;

            while (currentPosition > 0)
            {
                if (compare(this.array[currentPosition], this.array[parentPosition]))
                {
                    this.Swap(currentPosition, parentPosition);
                }
                else
                {
                    return;
                }

                currentPosition = parentPosition;
                parentPosition = (currentPosition - 1) / 2;
            }
        }

        private void ShiftDown(Func<T, T, bool> compareChildren, Func<T, T, bool> compareToParent)
        {
            int currentPosition = 0;
            int leftChildPosition = (currentPosition * 2) + 1;
            int rightChildPosition = leftChildPosition + 1;

            while (leftChildPosition < this.count)
            {
                int index = leftChildPosition;

                if (rightChildPosition < this.count &&
                    compareChildren(this.array[leftChildPosition], this.array[rightChildPosition]))
                {
                    index = rightChildPosition;
                }

                if (compareToParent(this.array[currentPosition], this.array[index]))
                {
                    return;
                }

                this.Swap(currentPosition, index);

                leftChildPosition = (index * 2) + 1;
                rightChildPosition = leftChildPosition + 1;
                currentPosition = index;
            }
        }

        private void Swap(int first, int second)
        {
            T oldValue = this.array[first];
            this.array[first] = this.array[second];
            this.array[second] = oldValue;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.array.GetEnumerator();
        }
    }
}
