using System;

namespace First_Task
{
    public class Task3 : Program
    {
        // Реализовать метод вычисляющий факториал из числа введенного
        // с клавиатуры (5 → 120).

        public Task3()
        {            
            int number;
            var factorial = 1;
            Console.Write("Write a Number: ");
            var str = Console.ReadLine();
            CheckNumber(str, out number);
            
            while (true)
            {
                if (number >= 0)
                    break;

                Console.Clear();
                Console.WriteLine("Please write a positive number ");
                Console.Write("Write a Number: ");
                str = Console.ReadLine();
                CheckNumber(str, out number);                
            }

            Console.Write($"Result: {str} -> ");

            for (var i = 2; i <= number; i++)
                factorial *= i;

            Console.WriteLine(factorial);
            Console.ReadLine();
        }
    }
}
