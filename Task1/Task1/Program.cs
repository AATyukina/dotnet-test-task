using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                CountPol(Console.ReadLine());
            }
            else
            {
                String enterStr = "";
                foreach (String s in args)
                {
                    enterStr += s;
                }
                CountPol(Console.ReadLine());
            }
        }

        private static void CountPol(String enterStr)
        {
            enterStr = new Regex(@"\W").Replace(enterStr, "");
            String newStr = new String(enterStr.ToCharArray().Reverse().ToArray());
            if (enterStr.Equals(newStr))
                Console.WriteLine("Полиндром");
            else
                Console.WriteLine("Не полиндром");
        }
    }
}
