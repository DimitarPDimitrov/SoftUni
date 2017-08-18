using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	public static void Main()
    {      
	
        var input = Console.ReadLine();   
      	var numbers = input.Split(' ').Select(x => Convert.ToDouble(x)).ToList();
		
        var counts = new SortedDictionary<double, int>();
		
		foreach (var num in numbers)
            {
                if(counts.ContainsKey(num))
				{
					counts[num] ++;
				}
				else
				{
					counts.Add(num, 1);
				}
            }

		printDictionary(counts);
				
	}
	
	public static void printDictionary(SortedDictionary<double, int> dict)
		{
			foreach (KeyValuePair<double, int> kvp in dict)
			{
				Console.WriteLine("{0} -> " + "{1}", kvp.Key, kvp.Value);	
			}
		}
}
