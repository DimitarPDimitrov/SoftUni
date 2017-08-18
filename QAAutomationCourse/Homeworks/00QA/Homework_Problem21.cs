using System;

public class Program
{
     public static void Main()
        {
                string input = Console.ReadLine();
                char[] charString = input.ToCharArray();
                Array.Reverse(charString);
                Console.WriteLine(string.Join("", charString));
        }
}