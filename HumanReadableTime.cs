using System;

namespace HumanReadableTime
{
    class Program
    {
        /// <summary>
        /// Write a function, which takes a non-negative integer (seconds) as input and 
        /// returns the time in a human-readable format (HH:MM:SS)
        /// 
        /// HH = hours, padded to 2 digits, range: 00 - 99
        /// MM = minutes, padded to 2 digits, range: 00 - 59
        /// SS = seconds, padded to 2 digits, range: 00 - 59
        /// The maximum time never exceeds 359999 (99:59:59)
        /// 
        /// </summary>
        static void Main(string[] args)
        {
            Console.WriteLine(GetReadableTime(5729));
            Console.ReadLine();
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
