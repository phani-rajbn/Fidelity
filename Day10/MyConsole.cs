using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleFrameworkApp
{
    static class MyConsole
    {
        public static uint GetNumber(string question)
        {
            uint res;
        LABEL:
            Console.WriteLine(question);
            if (!uint.TryParse(Console.ReadLine(), out res))
            {
                Console.WriteLine("Invalid number, Number should be a whole number as integer and should be within the range of {0} and {1}", 0, uint.MaxValue);
                goto LABEL;
            }
            return res;
        }
        public static double GetDouble(string question)
        {
            double res;
        LABEL:
            Console.WriteLine(question);
            if (!double.TryParse(Console.ReadLine(), out res))
            {
                Console.WriteLine("Invalid number, Number should be a decimal number as fractions and should be within the range of {0} and {1}", double.MinValue, double.MaxValue);
                goto LABEL;
            }
            return res;
        }

        public static DateTime GetDate(string question)
        {
            Console.WriteLine(question);
            return DateTime.Parse(Console.ReadLine());
        }

        public static string GetString(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
    }
}
