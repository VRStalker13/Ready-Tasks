using System;

namespace First_Task
{
    public class Task14
    {
        // Дана строка, посчитать количество символов "A"

        public Task14(string str)
        {
            Console.WriteLine($"Your string is: {str}");
            var counter = 0;

            for (var i = 0; i < str.Length; i++)
            {
                if (str[i] == 'A')
                    counter += 1;
            }

            Console.WriteLine($"A number of characters \"A\" is: {counter}");
            Console.ReadLine();
        }
    }
}
