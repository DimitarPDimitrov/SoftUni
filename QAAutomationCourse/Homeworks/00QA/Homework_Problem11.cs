using System;
using System.Linq;


public class Program
{
	public static void Main()
	{      
        string input = Console.ReadLine();
        var numbers = input.Split(' ').Select(x => Double.Parse(x)).ToList();

        bool areEq = true;
        while (areEq)
        {  
            bool areNotSwaped = true;
            for (int i = 0; i < numbers.Count - 1; i++)
            {

                if (numbers[i] == numbers[i+1])
                {
                    numbers[i] += numbers[i+1];
                    numbers.RemoveAt(i+1);
                    i ++;
                    areNotSwaped = false;
                }
                
            }
            
            if (areNotSwaped)
            {
                areEq = false;
            }
        }
        
        for (int j = 0; j <= numbers.Count-1; j++)
        {
            Console.Write(numbers[j] + " ");
        }
    }
}