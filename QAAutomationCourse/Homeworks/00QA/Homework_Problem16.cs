using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
	public static void Main()
    {      
	
		char[] separators = new char[] {'.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?', ' '};
        var input = Console.ReadLine()
				.ToLower()
				.Split(separators, StringSplitOptions.RemoveEmptyEntries)
				.ToArray();
      
		var smallThan5 = new List<string> ();
		
		foreach (var word in input)
		{
			if (word.Length <5)
			{
				smallThan5.Add(word);
			}
		}
		
		var output = smallThan5
				.OrderBy(x => x)
				.Distinct();
		
		Console.WriteLine(string.Join(", ", output));
	}		
}