using System;


public class Program
{
	public static void Main()
	{

        int n = int.Parse(Console.ReadLine());
        PrintTopRow(n);
        for (int i = 0; i < n-2; i++)
            {
                PrintMiddleRow(n);
            }
        PrintTopRow(n);
    }

    static void PrintTopRow(int n)
    {
        Console.WriteLine(new string('-', 2 * n));
    }

    static void PrintMiddleRow(int n)
    {
        Console.Write("-");
        for (int j = 1; j < n; j++)
            {
                Console.Write("\\/");
            }
        Console.WriteLine("-");
    }
}