using System;
using System.Collections.Generic;

public class Palindromes
{
	public static void Main()
    {      
        string input = Console.ReadLine();
		char[] separators = new char[] {',', ';', ':', '.', '!', '?', ' '};
        string[] splitStrings = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
		
		var palindromes = new SortedSet<string>();
		
		foreach(var word in splitStrings)
		{
			var start = 0;
			var end = word.Length-1;
			bool isPalindrome = true;
			
			while (start < end)
			{
				if(word.Substring(start, 1) != word.Substring(end, 1))
				{
					isPalindrome = false;
					break;
				}
				start ++;
				end --;
			}
			
			if (isPalindrome)
			{
				palindromes.Add(word);
			}
		}
		Console.WriteLine(String.Join(", ", palindromes));
	}
}