using System;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{      
        string input = Console.ReadLine();
		char[] separators = new char[] {',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']', ' '};
        var lowerCase = new List<string>();
        var upperCase = new List<string>();
        var mixedCase = new List<string>();

        string[] splitStrings = input.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        
         foreach(string str in splitStrings)
        {
            switch (checkString(str))
            {
                case "lower": 
                    lowerCase.Add(str);
                    break;
                case "upper": 
                    upperCase.Add(str);
                    break;
                case "mixed": 
                    mixedCase.Add(str);
                    break;
            }
        }

        Console.WriteLine("Lower-case: " + string.Join(", ", lowerCase));

        Console.WriteLine("Mixed-case: " + string.Join(", ", mixedCase));
        
        Console.WriteLine("Upper-case: " + string.Join(", ", upperCase));
		       
    }

    public static string checkString(string word)
        {

            if (isLower(word))
                {
                    return "lower";
                }
            
            else
                {
                    if (isUpper(word))
                        {
                            return "upper";
                        }
                    else
                        {
                            return "mixed";
                        }
                }
        }

        public static bool isUpper(string w)
        {
			int count = 0;
            for (int i = 0; i < w.Length; i++)
                {
                    if (Char.IsUpper(w[i]))
                        count++;
                }
			
			if(count == w.Length)
				return true;
			else
          		return false;
        }

        public static bool isLower(string w)
        {
            int count = 0;
            for (int i = 0; i < w.Length; i++)
                {
                    if (Char.IsLower(w[i]))
                        count++;
                }
			
			if(count == w.Length)
				return true;
			else
          		return false;
        }
}