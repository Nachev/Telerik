namespace Methods
{
    public class TestPoint
    {
        private double coordX;
        private double coordY;

        public TestPoint(double initCoordX, double initCoordY)
        {
            this.CoordX = initCoordX;
            this.CoordY = initCoordY;
        }

        public double CoordX
        {
            get
            {
                return this.coordX;
            }

            private set
            {
                this.coordX = value;
            }
        }

        public double CoordY
        {
            get
            {
                return this.coordY;
            }

            private set
            {
                this.coordY = value;
            }
        }
    }
}
