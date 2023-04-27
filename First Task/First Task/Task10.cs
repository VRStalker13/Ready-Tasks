using System;

namespace First_Task
{
    public class Task10
    {
        // Дан одномерный массив, получить сумму элементов которые: 
        // a) больше числа M b) Меньше числа N

        public Task10(int[] x, int M, int N)
        {
            var sumM = 0;
            var sumN = 0;

            for (var i = 0; i < x.Length; i++)
            {
                if (x[i] > M)
                    sumM += x[i];

                if (x[i] < N)
                    sumN += x[i];
            }

            Console.WriteLine("Result: ");
            Console.WriteLine($"Sum more then M({M}) = {sumM}");
            Console.WriteLine($"Sum smaller then N({N}) = {sumN}");
            Console.ReadLine();
        }
    }
}
