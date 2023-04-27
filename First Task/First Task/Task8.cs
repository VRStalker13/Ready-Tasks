using System;

namespace First_Task
{
    public class Task8
    {
        //Дан одномерный массив отсортировать отрицательные элементы. 
        // ([4, -1, 1, -2] → [4, -2, 1, -1])

        public Task8(int[] x)
        {
            var negativeLength = 0;
            var j = 0;
            Console.WriteLine("Result: ");
            Console.Write($"[{x[0]}, ");

            for (var i = 1; i < x.Length - 1; i++)
                Console.Write($"{x[i]}, ");

            Console.Write($"{x[x.Length - 1]}] ->  ");

            for (var i = 0; i < x.Length; i++)     
            {
                if (x[i] < 0)
                    negativeLength++;            
            }

            var negativeMas = new int[negativeLength];
            var negativePos = new int[negativeLength];

            for (var i = 0; i < x.Length; i++)
            {
                if (x[i] < 0)
                {
                    negativeMas[j] = x[i];
                    negativePos[j] = i;
                    j++;
                }
            }

            Array.Sort(negativeMas);

            for (var i = 0; i < negativeLength; i++)
                x[negativePos[i]] = negativeMas[i];

            Console.Write($"[{x[0]}, ");

            for (var i = 1; i < x.Length - 1; i++)
                Console.Write($"{x[i]}, ");

            Console.Write($"{x[x.Length - 1]}] \n");
            Console.ReadLine();
        }
    }
}
