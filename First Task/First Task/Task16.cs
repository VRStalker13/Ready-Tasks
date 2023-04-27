using System;

namespace First_Task
{
    public class Task16
    {
        // Дана строка, перевернуть ее (компьютер → ретюьпмок).

        public Task16(string str)
        {
            var lenght = str.Length;
            var newStr = new Char[lenght];            

            Console.WriteLine($"Your string is: {str}");

            for (var i = 0; i < lenght; i++)
                newStr[i] = str[lenght - 1 - i];

            var newString = new string(newStr);
            Console.WriteLine($"New string is: {newString}");
            Console.ReadLine();
        }
    }
}
