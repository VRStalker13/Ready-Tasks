using System;

namespace First_Task
{
    public class Task15
    {
        // Дана строка, посчитать количество слов.

        public Task15(string str)
        {
            var counter = 0;
            Console.WriteLine($"Your string is: {str}");
            str = str.Trim();

            if (str.Length != 0)
                counter += 1;

            for (var i = 0; i < str.Length - 1; i++)     
            {
                if (str[i] == ' ' && str[i + 1] != ' ')
                    counter += 1;            
            }

            Console.WriteLine($"A number of words is: {counter}");
            Console.ReadLine();
        }
    }
}
