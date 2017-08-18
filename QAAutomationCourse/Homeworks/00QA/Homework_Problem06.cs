using System;


public class Program
{
	public static void Main()
	{
        int height = int.Parse(Console.ReadLine());
        
        for(int i = 0; i < height; i++)
            {
                PrintLine(1, i);
            }
        
        PrintLine (1, height);

        for(int i = height-1; i >= 1; i--)
            {
                PrintLine(1, i);
            }
        

    }

    static void PrintLine(int start, int end)
    {
        for (int i = start; i <= end; i++)
            {
                Console.Write(i + " ");
            }

        Console.WriteLine();
    }

}