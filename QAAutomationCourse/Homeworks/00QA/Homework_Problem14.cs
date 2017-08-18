using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int count = Convert.ToInt32(Console.ReadLine());

        var numbers = new int[count];

        for (int i = 0; i <= count - 1; i++)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            numbers[i] = num;
        }

        Console.WriteLine("Sum = " + numbers.Sum());
        Console.WriteLine("Min = " + numbers.Min());
        Console.WriteLine("Max = " + numbers.Max());
        Console.WriteLine("Average = " + numbers.Average());
    }
}