namespace DefiningClassesPart2
{
    using System;

    public class DefiningClassesManager
    {
        private static Random rng = new Random();

        private static void Main()
        {
            // Point test
            Point3D nuevo = Point3D.ZeroPoint;
            var far = new Point3D(2.56, 3.8, 5.98);
            Console.WriteLine("first point - {0}\nsecond point - {1}", nuevo, far);
            var distance = DistanceCalc.CalcDistance(nuevo, far);
            Console.WriteLine("distance {0:F}", distance);

            // Path test
            var path = new Path(nuevo, far);
            for (int count = 0; count < 10; count++)
            {
                path.AddPoint(new Point3D(rng.Next(10), rng.Next(10), rng.Next(10)));
            }

            Console.WriteLine(path);
            PathStorage.SavePath(path);
            path = new Path();
            path = PathStorage.LoadPath();
            Console.WriteLine(path);
        }
    }
}
