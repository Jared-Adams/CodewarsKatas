using System;

namespace CreatePhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CreatePhoneNumber(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }));

            Console.WriteLine(GetReadableTime(5));
        }
        public static string CreatePhoneNumber(int[] numbers)
        {
            string _number = "() -";
            for (int i = 0; i < 10; i++)
            {
                _number = (i < 3) ? _number.Insert(i + 1, numbers[i].ToString()) : _number;

                _number = (i >= 3 && i < 6) ? _number.Insert(i + 3, numbers[i].ToString()) : _number;

                _number = (i >= 6) ? _number.Insert(i + 4, numbers[i].ToString()) : _number;
            }
            return _number;
        }

        public static string GetReadableTime(int seconds)
        {
            int _hours = (seconds / 3600);
            int _minutes = ((seconds - (_hours * 3600)) / 60);
            int _seconds = ((seconds - (_minutes * 60)) % 60);

            return $"{_hours:d2}:{_minutes:d2}:{_seconds:d2}";
        }
    }
}
