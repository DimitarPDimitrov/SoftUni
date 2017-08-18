using System;
using System.Text;


public class Program
{
	public static void Main()
	{
    int numToSum = int.Parse(Console.ReadLine());

    decimal sum = 0;
    for (int i = 0; i < numToSum; i++)
        {
            decimal currentNum = Decimal.Parse(Console.ReadLine());
            sum += currentNum;
        }
    Console.WriteLine(sum);
    }
}