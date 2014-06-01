namespace AStarPathfinding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// Reresents one node in the search space.
    /// </summary>
    public class SearchNode
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SearchNode()
        {
            this.G = int.MaxValue;
            this.H = int.MaxValue;
        }

        /// <summary>
        /// Location on map.
        /// </summary>
        public Point Position { get; set; }

        /// <summary>
        /// If true, this tile can be walked on.
        /// </summary>
        public bool Walkable { get; set; }

        /// <summary>
        /// The movement cost to move from the starting point A to a given square on the grid, 
        /// following the path generated to get there.
        /// </summary>
        public int G { get; set; }

        /// <summary>
        /// The estimated movement cost to move from that given square on the grid to the final destination, point B. 
        /// Calculated by Manhattan algorythm.(H = 10*(abs(currentX-targetX) + abs(currentY-targetY))).
        /// </summary>
        public int H { get; set; }

        /// <summary>
        /// F = G + H.
        /// </summary>
        public int F { get; private set; }

        /// <summary>
        /// Provides an easy way to check if this node
        /// is in the open list.
        /// </summary>
        public bool InOpenList { get; set; }

        /// <summary>
        /// Provides an easy way to check if this node
        /// is in the closed list.
        /// </summary>
        public bool InClosedList { get; set; }
        
        /// <summary>
        /// Points to the parent node of this node.
        /// </summary>
        public SearchNode Parent { get; private set; }

        /// <summary>
        /// This contains references to the four nodes surrounding
        /// this tile (Up, Down, Left, Right).
        /// </summary>
        public List<SearchNode> Neighbours { get; set; }

        /// <summary>
        /// Calculates the H value.
        /// </summary>
        public void CalculateHValue(Map map, Point target)
        {
            this.H = 10 * (Math.Abs(this.Position.X - target.X) + Math.Abs(this.Position.Y - target.Y));
        }

        /// <summary>
        /// Sets provided node as parent.
        /// </summary>
        public void SetParent(SearchNode parent)
        {
            this.Parent = parent;
            this.F = this.G + this.H;
        }
    }
}
