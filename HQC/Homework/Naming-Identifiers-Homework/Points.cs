namespace Minesweeper
{
    public class Points
    {
        private string name;
        private int pointsCount;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int PointsCount
        {
            get { return pointsCount; }
            set { pointsCount = value; }
        }

        public Points(string name, int points)
        {
            this.name = name;
            this.pointsCount = points;
        }
    }
}
