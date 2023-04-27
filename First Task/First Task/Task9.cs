using System;

namespace First_Task
{
    public class Task9
    {
        // Дан массив преобразовать его, так чтобы последний поменялась с первой 
        // предпоследний с вторым и т.д.

        public Task9(int[] x)
        {
            int temp;
            Console.WriteLine("Result: ");
            Console.Write($"[{x[0]}, ");

            for (var i = 1; i < x.Length - 1; i++)
                Console.Write($"{x[i]}, ");

            Console.Write($"{x[x.Length - 1]}] ->  ");

            for (var i = 0; i < x.Length / 2; i++)
            {
                temp = x[i];
                x[i] = x[x.Length - 1 - i];
                x[x.Length - 1 - i] = temp;
            }

            Console.Write($"[{x[0]}, ");

            for (var i = 1; i < x.Length - 1; i++)
                Console.Write($"{x[i]}, ");

            Console.Write($"{x[x.Length - 1]}] ");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
