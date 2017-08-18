using System;


public class Program
{
	public static void Main()
	{
        string[] days = new string [] {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};

        int numberOfDay = int.Parse(Console.ReadLine());

        if (numberOfDay >= 1 && numberOfDay <= 7)
        {
            Console.WriteLine(days[numberOfDay - 1]);
        }
        else
        {
            Console.WriteLine("Invalid Day!");
        }
    }
}