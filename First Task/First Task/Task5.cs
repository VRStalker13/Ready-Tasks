using System;

namespace First_Task
{
    public class Task5
    {
        // Реализовать метод, который получает число X и возвращает 
        // все четные числа в диапазоне от 0..X (X=10 → 0, 2, 4, 6, 8, 10).

        public  Task5(int x)
        {
            Console.WriteLine("Result: ");
            Console.Write($"X={x} -> 0");

            for (var i = 2; i <= x; i += 2 )            
                 Console.Write($", {i}");                                     

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
