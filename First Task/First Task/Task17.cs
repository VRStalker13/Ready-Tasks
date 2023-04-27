using System;

namespace First_Task
{
    public class Task17
    {       
        // Дана строка, поменять все символы "C" на "E".

        public Task17(string str)
        {
            Console.WriteLine($"Your string is: {str}");
            var str1 = str.Replace("C", "E");
            Console.WriteLine($" New string is: {str1}");
            Console.ReadLine();
        }
    }
}
