using System;

public class Program
{
    public static void Main()
    {

        var input = Console.ReadLine();
        var subStr = Console.ReadLine();

        int count = 0;
        int position = 0;
        while(true)
            {
                var next = input.IndexOf(subStr, position, StringComparison.InvariantCultureIgnoreCase);
                if (next == -1)
                    {
                    break;
                    }
                count++;
                position = next + 1;
            }
        Console.WriteLine(count); 
    }
}