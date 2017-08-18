using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA01Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAcount acount = new BankAcount(2000m);
            Console.WriteLine(acount.Amount);
        }
    }
}
