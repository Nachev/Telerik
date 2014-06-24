namespace Matrix
{ 
    /// <summary>
    /// Struct that keeps a couple of coordinates.
    /// </summary>
    public struct CoordinatesCouple
    {
        /// <summary>Value for row in a matrix.</summary>
        private readonly int row;

        /// <summary>Value for column in a matrix.</summary>
        private readonly int col;

        /// <summary>
        /// Initializes a new instance of the <see cref="CoordinatesCouple"/> struct.
        /// </summary>
        /// <param name="initialRow">Initializing value for readonly field row.</param>
        /// <param name="initialCol">Initializing value for readonly field col.</param>
        public CoordinatesCouple(int initialRow, int initialCol)
        {
            this.row = initialRow;
            this.col = initialCol;
        }

        /// <summary>
        /// Gets value of currentColDirection field.
        /// </summary>
        /// <value>A column index.</value>
        public int Col
        {
            get
            {
                return this.col;
            }
        }

        /// <summary>
        /// Gets value of row field.
        /// </summary>
        /// <value>A row index.</value>
        public int Row
        {
            get
            {
                return this.row;
            }
        }
    }
}
