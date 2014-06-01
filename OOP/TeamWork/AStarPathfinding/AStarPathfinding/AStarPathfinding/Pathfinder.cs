namespace AStarPathfinding
{
    using System;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using System.Collections.Generic;

    public class Pathfinder
    {
        private const int WalkableLandValue = 0;
        private readonly Point Target;

        // Stores an array of the walkable search nodes.
        private SearchNode[,] searchNodes;

        // The width and height of the map.
        private readonly int levelWidth;
        private readonly int levelHeight;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="map">Current level's map.</param>
        public Pathfinder(Map map)
        {
            this.levelWidth = map.Width;
            this.levelHeight = map.Height;
            this.InitializeSearchNodes(map);

            // FOR TEST
            this.Target = new Point(map.Width - 1, map.Height - 1);
        }

        /// <summary>
        /// Splits the level up into a grid of nodes.
        /// </summary>
        private void InitializeSearchNodes(Map map)
        {
            searchNodes = new SearchNode[levelWidth, levelHeight];

            // Create node for each tile.
            CreateNodeForEachTile(map);

            // Connect each node with its neighbours.
            ConnectEachNodeWithNeighbours();
        }

        /// <summary>
        /// Connect each node with its neighbours.
        /// </summary>
        private void ConnectEachNodeWithNeighbours()
        {
            // Connect each node with its neighbours.
            for (int coordX = 0; coordX < levelWidth; coordX++)
            {
                for (int coordY = 0; coordY < levelHeight; coordY++)
                {
                    SearchNode node = searchNodes[coordX, coordY];

                    // Look at nodes that are walkable.
                    if (node != null && node.Walkable)
                    {
                        // Array of possible neighbours (Diagonals are ignored).
                        Point[] neighbours =
                        {
                            new Point(coordX, coordY - 1),
                            new Point(coordX, coordY + 1),
                            new Point(coordX - 1, coordY),
                            new Point(coordX + 1, coordY)
                        };

                        // Traverse neghbours and store a reference to it if possible
                        AddReferencesToNeighbours(neighbours, node);
                    }
                }
            }
        }

        /// <summary>
        /// Traverse neghbours and store a reference to it if possible.
        /// </summary>
        private void AddReferencesToNeighbours(Point[] neighbourPositions, SearchNode node)
        {
            for (int count = 0; count < neighbourPositions.Length; count++)
            {
                Point position = neighbourPositions[count];

                // Check if the neighbour is part of the level.
                if ((position.X >= 0 && position.X <= levelWidth - 1) &&
                    (position.Y >= 0 && position.Y <= levelHeight - 1))
                {
                    SearchNode neighbour = searchNodes[position.X, position.Y];

                    // Add only walkable nodes.
                    if (neighbour != null && neighbour.Walkable)
                    {
                        // Store a reference to the neighbour.
                        node.Neighbours.Add(neighbour);
                    }
                }
            }
        }

        /// <summary>
        /// Creates node for each tile.
        /// </summary>
        private void CreateNodeForEachTile(Map map)
        {
            for (int coordX = 0; coordX < levelWidth; coordX++)
            {
                for (int coordY = 0; coordY < levelHeight; coordY++)
                {
                    var node = new SearchNode();
                    node.Position = new Point(coordX, coordY);

                    // Mark walkable terrain. 0 represent path on map grid.
                    node.Walkable = map.GetValue(coordX, coordY) == WalkableLandValue;

                    // Store only walkable nodes.
                    if (node.Walkable)
                    {
                        node.Neighbours = new List<SearchNode>(); // TO BE CONSIDERED!!!
                        searchNodes[coordX, coordY] = node;
                    }
                }
            }
        }

        /// <summary>
        /// Do the pathfinding from current point
        /// </summary>
        public Stack<Vector2> FindPath(Point startPoint, Map map, Point endPoint)
        {
            var startNode = searchNodes[startPoint.X, startPoint.Y];
            var endNode = searchNodes[endPoint.X, endPoint.Y];

            // Check if current position is outside the map
            if ((startPoint.X > map.Width - 1 || startPoint.X < 0) ||
                (startPoint.Y < 0 || startPoint.Y > map.Height - 1))
            {
                throw new ApplicationException("Starting point for search is outside the boundaries of the map!");
            }

            var openList = new List<SearchNode>();
            var closeList = new List<SearchNode>();

            InitializeStartnode(startPoint, map, openList);

            while (openList.Count > 0)
            {
                // Finds next active node (minimal F value)
                SearchNode activeNode = FindBestNode(openList);

                ProcessNeighbours(activeNode, openList);

                // Drop current active node from drop list
                openList.Remove(activeNode); // TO BE cONSIDERED IT'S SLOW!!!
                activeNode.InOpenList = false;
                closeList.Add(activeNode);
                activeNode.InClosedList = true;

                // Check if target is found.
                if (searchNodes[endPoint.X, endPoint.Y].InClosedList)
                {
                    break; // TODO Return path.
                }
            }

            // Save the path
            var path = FindFinalPath(startNode, endNode, closeList);
            return path;
        }
  
        private SearchNode FindBestNode(List<SearchNode> openList)
        {
            SearchNode activeNode = new SearchNode();

            // Finds next active node (minimal F value)
            int minF = int.MaxValue;
            foreach (var node in openList)
            {
                if (node.F < minF)
                {
                    minF = node.F;
                    activeNode = node;
                }
            }
            return activeNode;
        }
  
        private void ProcessNeighbours(SearchNode activeNode, List<SearchNode> openList)
        {
            foreach (var node in activeNode.Neighbours)
            {
                if (node.Walkable && !node.InClosedList)
                {
                    if (!node.InOpenList)
                    {
                        // Add neighbours to open list if it isn't already there
                        openList.Add(node);
                        node.InOpenList = true;

                        // Mark active node as parent.
                        node.SetParent(activeNode);

                        // Set G value.
                        node.G = activeNode.G + 10;
                    }
                    else
                    {
                        int tempG = activeNode.G + 10; // 10 IF THERE IS NO DIAGONAL
                        if (node.G < 0 || node.G > tempG)
                        {
                            tempG = node.G;

                            // Mark active node as parent.
                            node.SetParent(activeNode);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Ininitializes the srating node and add it to the open list.
        /// </summary>
        private void InitializeStartnode(Point currentPosition, Map map, List<SearchNode> openList)
        {
            searchNodes[currentPosition.X, currentPosition.Y].G = 0;
            searchNodes[currentPosition.X, currentPosition.Y].CalculateHValue(map, Target);
            openList.Add(searchNodes[currentPosition.X, currentPosition.Y]);
            searchNodes[currentPosition.X, currentPosition.Y].InOpenList = true;
        }

        /// <summary>
        /// Use the parent field of the search nodes to trace
        /// a path from the end node to the start node.
        /// </summary>
        private Stack<Vector2> FindFinalPath(SearchNode startNode, SearchNode endNode, List<SearchNode> closeList)
        {
            closeList.Add(endNode);
            SearchNode parentTile = endNode.Parent;
            var finalPath = new Stack<Vector2>();

            // Trace back through the nodes using the parent fields
            while (parentTile != startNode)
            {
                finalPath.Push(new Vector2(parentTile.Position.X * (int)Global.TileSize, parentTile.Position.Y * (int)Global.TileSize));
                parentTile = parentTile.Parent;
            }


            // Reverse the path and transform into world space.
            finalPath.Reverse();

            return finalPath;
        }
    }
}
