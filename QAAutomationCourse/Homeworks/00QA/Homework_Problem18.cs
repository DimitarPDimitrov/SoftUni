using System;
using System.Globalization;

public class Program
{
	public static void Main()
    {      
			
		var date = Console.ReadLine();
        var weekDay = DateTime.ParseExact(date, "d-M-yyyy", CultureInfo.InvariantCulture);
		
        Console.WriteLine(weekDay.DayOfWeek);
	}	
}