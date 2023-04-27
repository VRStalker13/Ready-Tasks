using System;

namespace First_Task
{    
    public class Task1: Program
    {
        // С клавиатуры вводятся 3 числа. Вывести их в порядке возрастания (Например: 4, 7, 2 → 2, 4, 7).

        public Task1()
        {
            var nums = new int[3];
            var numsLength = nums.Length;      
            
            Console.WriteLine("Please write 3 numbers:");
            Console.Write("First: ");
            var a = Console.ReadLine();
            CheckNumber(a, out nums[0]);

            Console.Write("Second: ");
            var b = Console.ReadLine();
            CheckNumber(b, out nums[1]);

            Console.Write("Third: ");
            var c = Console.ReadLine();
            CheckNumber(c, out nums[2]);

            Console.WriteLine("\nResult: ");
            Show(nums);
            Console.Write(" -> ");
            Array.Sort(nums);
            Show(nums);
            Console.ReadLine();
        }

        public void Show(int[] mas)
        {
            var length = mas.Length;

            if(length>0)
                Console.Write(mas[0]);

            if(length > 1)
            {
                for(var i = 1; i < length; i++)
                    Console.Write(", " + mas[i]);
            }
        }
    }
}
