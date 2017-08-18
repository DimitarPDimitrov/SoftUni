using System;


public class Program
{
	public static void Main()
	{      
        int count = int.Parse(Console.ReadLine());
        int [] inputArray = new int [count];
        InitalizeArray(count, inputArray);

        int [] reverse = new int [count];
        ReverseArrayAndPrint(count, inputArray, reverse);
    }

    public static void InitalizeArray(int c, int [] arr)
    {
        
        for (int i = 0; i < c; i++)
            {
                int currentNum = int.Parse(Console.ReadLine());
                arr[i] = currentNum;
            }
    }

   public static void ReverseArrayAndPrint(int c, int [] arr, int [] inverted)
    {
       for(int i = 0; i < c; i++)
       {
           inverted[i] = arr[c-i-1];
           Console.Write(inverted[i] + " ");
       }
    }
}