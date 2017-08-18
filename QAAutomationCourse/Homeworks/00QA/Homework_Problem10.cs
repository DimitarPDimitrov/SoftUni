using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
	public static void Main()
	{      
        string input = Console.ReadLine();
        var numbers = input.Split(' ').Select(x => Int32.Parse(x)).ToList();


        List<int> reverseList = new List<int>();

        for (int i = numbers.Count - 1; i >= 0 ; i--)
        {
            if (numbers[i] >= 0)
            {
                reverseList.Add(numbers[i]);
            }
        }
		
        if (reverseList.Count == 0)
        {
            Console.WriteLine("empty");
        }
        else
        {
            for (int i = 0; i < reverseList.Count; i++)
            {
                Console.Write(reverseList[i] + " ");
            }
        }
    }
}