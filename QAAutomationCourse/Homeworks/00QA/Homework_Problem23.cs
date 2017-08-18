using System;
using System.Text.RegularExpressions;

public class Program
{
	public static void Main()
	{      
        var text = Console.ReadLine();
		var inputWords = Console.ReadLine();
		var words = Regex.Split(text, ", ");
       
		foreach(var w in words)
		{
			var replacedString = new string ('*', w.Length);
			inputWords = inputWords.Replace(w, replacedString);
			//inputWords = inputWords.Insert(inputWords.IndexOf(w), replacedString);
			//inputWords = inputWords.Remove(inputWords.IndexOf(w), w.Length);
		}
        Console.WriteLine(inputWords);
    }
}