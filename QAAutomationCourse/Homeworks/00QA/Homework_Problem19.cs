using System;
using System.Linq;

public class Program
    {

        class Point
        {

            private double x;
            private double y;

            public double X
            {
                get { return x; }
                set { x = value; }
            }
            public double Y
            {
                get { return y; }
                set { y = value; }
            }

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

        }


        public static void Main()
        {

            var inputP1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            var inputP2 = Console.ReadLine().Split().Select(int.Parse).ToList();

            Point point1 = new Point(inputP1[0], inputP1[1]);
            Point point2 = new Point(inputP2[0], inputP2[1]);



           Console.WriteLine("{0:f3}", CalcDistance(point1, point2));
    }

        static double CalcDistance(Point p1, Point p2)

        {
            double a = Math.Abs(p1.X - p2.X);
            double b = Math.Abs(p1.Y - p2.Y);

            double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

            return c;
        }
    }