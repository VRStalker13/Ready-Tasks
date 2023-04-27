using System;

namespace First_Task
{
    public class Task6
    {
        // Реализовать метод который получает число X и возвращает все 
        // cовершенные числа в диапазоне 0..X (X=10 → 6).

        public Task6(int x)
        {
            var sum = 0;
            Console.WriteLine("Result: ");
            Console.Write($"X={x} -> ");

            for (var i = 1; i <= x; i++)
            {
                for (var j = 1; j <= i / 2; j++)      
                {
                    if (i % j == 0)
                        sum += j;                
                }

                if (i == sum)
                    Console.Write($"{i} ");

                sum = 0;
            }

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
