using System;

namespace First_Task
{
    public class Task18
    {
        // Дана строка, посчитать количество слов, которые начинаются на букву "K".

        public Task18(string str)
        {
            var counter = 0;
            Console.WriteLine($"Your string is: {str}");
            str = str.Trim();

            if (str.Length != 0)
                counter += 1;

            for (var i = 0; i < str.Length - 1; i++)   
            {
                if (str[i] == ' ' && str[i + 1] == 'K')
                    counter += 1;   
            }

            Console.WriteLine($"Result is: {counter}");
            Console.ReadLine();
        }
    }
}
