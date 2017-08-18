using System;

public class Program
{
	public static void Main()
	{
      // Console.WriteLine("Enter the radius of the circle:");
       double radius = double.Parse(Console.ReadLine());
       Console.WriteLine("{0:f12}", Math.PI * radius * radius );
    }
}