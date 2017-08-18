using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	public static void Main()
    {      
        var numbers = Console.ReadLine().Split(' ').Select(x => Convert.ToDouble(x)).ToList();

       var exactNums = numbers.OrderByDescending(x => x).Take(3);
            Console.WriteLine(string.Join(" ", exactNums));
    }
}