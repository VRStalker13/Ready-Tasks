using System;

namespace First_Task{
    public class Task2: Program
    {
        // С клавиатуры вводится число, вывести его в обратном порядке(358 → 853).

        public Task2()
        {                
            Console.Write("Write a Number: ");
            var str = Console.ReadLine();
            str = CheckNumber(str, out _);
            Console.Write($"Result: {str} -> ");
            var length = str.Length;

            for (var i = 0; i < length; i++)
                Console.Write(str[length - i - 1]);

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
