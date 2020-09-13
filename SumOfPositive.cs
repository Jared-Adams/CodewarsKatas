using System;
using System.Linq;
namespace SumOfPositive
{
    class Program
    {
        /// <summary>
        /// Simply get the sum of all positive numbers in a given array
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine(PositiveSum(new int[] { -1, 2, 3, 4, -5 })); //9
            Console.ReadLine();
        }

        public static int PositiveSum(int[] arr) => arr.Where(x => x > 0).Sum();
    }
}
