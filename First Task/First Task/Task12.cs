using System;

namespace First_Task
{
    public class Task12
    {
        // Дан двумерный массив получить максимальные элемента каждого столбца.

        public Task12(int[,] mas)
        {
            var rows = mas.GetUpperBound(0) + 1;
            var columns = mas.GetUpperBound(1) + 1;
            var max = new int[columns];

            for (var j = 0; j < columns; j++)
                max[j] = mas[1, j];

            Console.WriteLine("Start massive: ");

            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                    Console.Write(mas[i, j] + " ");

                Console.WriteLine();
            }

            for(var j = 0; j < columns; j++)   
            {
                for (var i = 1; i < rows; i++)  
                {
                    if (mas[i, j] > max[j])
                        max[j] = mas[i, j];           
                }
            }

            Console.WriteLine();
            Console.WriteLine("Max elements in columns is: ");

            for (var j = 0; j < columns; j++)
                Console.WriteLine($"{j + 1}: {max[j]}");

            Console.ReadLine();
        }
    }
}
