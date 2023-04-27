using System;

namespace First_Task
{
    public class Task13
    {
        // Дан двумерный массив поменять местами элементы, 
        // расположенные на главной диагонали с противоположной диагонально.

        public Task13(int[,] mas)
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

            for (var i = 0; i < rows; i++)
            {
                temp = mas[i, i];
                mas[i, i] = mas[i, columns - 1 - i];
                mas[i, columns - 1 - i] = temp;
            }

            Console.WriteLine("\nEnd massive: ");

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
