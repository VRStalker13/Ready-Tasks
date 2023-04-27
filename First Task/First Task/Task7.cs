using System;

namespace First_Task
{
    public class Task7
    {
        // Дан одномерный массив получить сумму всех элементов расположенных в
        // четных и отдельно в нечетных позициях.

        public Task7(int[] x)
        {
            var sumChet = 0;
            var sumNechet = 0;

            for (var i = 0; i < x.Length; i++)
            {
                if (i % 2 == 0)
                    sumNechet += x[i];
                else
                    sumChet += x[i];
            }

            Console.WriteLine("Result:");
            Console.WriteLine($"Sum chet positions: {sumChet}");
            Console.WriteLine($"Sum Nechet positions: {sumNechet}\n");
            Console.ReadLine();
        }
    }
}
