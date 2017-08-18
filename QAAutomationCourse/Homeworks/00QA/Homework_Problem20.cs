using System;
using System.Linq;

public class ClosestTwoPoints
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
            
			public Point()
			{}

			public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

        }

        public static void Main()
        {

			var count = int.Parse(Console.ReadLine());
			
			Point[] points = new Point[count];
			for (int i = 0; i < points.Length; i++)
			{
				points[i] = new Point();
			}
				
			for(var i = 0; i < points.Length; i++)
			{
				var point = Console.ReadLine().Split().Select(int.Parse).ToArray();
				points[i].X = point[0];
				points[i].Y = point[1];
			}
			
			var closest = Double.MaxValue;
			Point closestP1 = new Point();
			Point closestP2 = new Point();
			
			for(var i=0; i < count; i++)
			{
				for(var j = i+1; j < count; j++)
				{
					var newClosest = CalcDistance(points[i], points[j]);
					if (newClosest < closest)
					{
						closest = newClosest;
						closestP1.X = points[i].X;
						closestP1.Y = points[i].Y;
						closestP2.X = points[j].X;
						closestP2.Y = points[j].Y;
					}
				}	
			}  
		   	Console.WriteLine("{0:f3}", closest);
			Console.WriteLine("({0}, {1})", closestP1.X, closestP1.Y);
			Console.WriteLine("({0}, {1})", closestP2.X, closestP2.Y);
    	}

        static double CalcDistance(Point p1, Point p2)
        {
            double a = Math.Abs(p1.X - p2.X);
            double b = Math.Abs(p1.Y - p2.Y);

            double c = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

            return c;
        }
}