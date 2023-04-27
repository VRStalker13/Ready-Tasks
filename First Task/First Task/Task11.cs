using System;

namespace First_Task
{
    public class Task11
    {
        // Дан двумерный массив, поменять местами четные строки с нечетными.

        public Task11(int[,] mas)
        {
            int temp;
            var rows = mas.GetUpperBound(0) + 1;
            var columns = mas.GetUpperBound(1) + 1;
            Console.WriteLine("Start massive: ");

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                    Console.Write(mas[i, j] + " ");

                Console.WriteLine();
            }

            for (var i = 0; i < rows - rows % 2; i += 2)
            {
                for (var j = 0; j < columns; j++)
                {
                    temp = mas[i, j];
                    mas[i, j] = mas[i + 1, j];
                    mas[i + 1, j] = temp;
                }
            }

            Console.WriteLine();
            Console.WriteLine("End massive: ");

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                    Console.Write(mas[i, j] + " ");

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
