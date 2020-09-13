using System;

namespace TwoSum
{
	///<summary>
	///https://www.codewars.com/kata/52c31f8e6605bcc646000082/train/csharp/5d71b43e60f1c8001ec82842
	///Write a function that takes an array of numbers (integers for the tests) and a target number.
	///It should find two different items in the array that, when added together, give the target value.	
	///</summary>
    class Program
    {
        static void Main(string[] args)
        {
            TwoSum(new[] { 2, 2, 3 }, 4);
        }

        public static int[] TwoSum(int[] numbers, int target)
        {
            int[] _indices = new int[2];
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = 1; j < numbers.Length; j++)
                {
                    if (numbers[i] + numbers[j] == target && i != j)
                    {                      
                        _indices[0] = i;
                        _indices[1] = j;
                        Array.Sort(_indices);
                    }
                }
            }
            return _indices;
        }
    }
}
