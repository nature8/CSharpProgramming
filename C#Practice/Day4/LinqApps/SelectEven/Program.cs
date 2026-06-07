using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLINQEx
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Data source. 
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            // 2. Query creation. 

            var numQuery = from num in numbers 
                           where (num % 2) == 0 
                           select num;

            // 3. Query execution. 
            foreach (int num in numQuery)
            {  
                //Console.Write("{0} " + num);
                Console.Write(" " + num);
            }

            Console.ReadKey();
        }

        }
    }
