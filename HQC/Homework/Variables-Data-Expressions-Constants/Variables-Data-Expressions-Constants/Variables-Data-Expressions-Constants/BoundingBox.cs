//-----------------------------------------------------------------------
//    ACME Inc.
// <summary>1. Refactor the following code to use proper variable naming and simplified expressions:</summary>
//-----------------------------------------------------------------------
namespace ObjectManipulation
{
    /// <summary>
    /// Bounding box of an object.
    /// </summary>
    public class BoundingBox
    {
        /// <summary>
        /// Width of the bounding box.
        /// </summary>
        private double width;

        /// <summary>
        /// Height of the bounding box.
        /// </summary>
        private double height;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoundingBox"/> class
        /// </summary>
        /// <param name="initialWidht">Initial width.</param>
        /// <param name="initialHeight">Initial height.</param>
        public BoundingBox(double initialWidht, double initialHeight)
        {
            this.Width = initialWidht; 
            this.Height = initialHeight;
        }

        /// <summary>
        /// Gets or sets width of the bounding box.
        /// </summary>
        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                this.width = value;
            }
        }

        /// <summary>
        /// Gets or sets height of the bounding box.
        /// </summary>
        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                this.height = value;
            }
        }
    }
}
