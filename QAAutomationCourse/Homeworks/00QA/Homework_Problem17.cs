using System;
using System.Linq;

public class Program
{
	public static void Main()
    {      
			
		var nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
		var split = (nums.Length) / 4;

        var topLeftRow = nums.Take(split).Reverse().ToArray();
		var topRightRow = nums.Reverse().Take(split).ToArray();
		
      	var topRow = topLeftRow.Concat(topRightRow);
		var middleRow = nums.Skip(split).Take(2*split).ToArray();
				
		var sum = topRow.Select((x,index) => x+ middleRow[index]);
		
		Console.WriteLine(string.Join(" ", sum));	
	}		
}