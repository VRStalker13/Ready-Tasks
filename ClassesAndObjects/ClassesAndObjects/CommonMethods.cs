using System;
using System.Globalization;

namespace ClassesAndObjects
{
    public static class CommonMethods
    {


        public static int CheckNumber(int numsLenght, string str)
        {
            while (true)
            {
                Console.Write(str);

                if (int.TryParse(Console.ReadLine(), out int humNum))
                    if (humNum <= numsLenght & humNum > 0)
                        return humNum;

                Console.WriteLine("Try again: ");
            }
        }

        public static DateTime InputDoB()
        {
            DateTime dob;
            string input;

            do
            {
                Console.Write("Write Birthday in format dd.mm.yyyy (day.month.year): ");
                input = Console.ReadLine();
            }
            while (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out dob));            
            return dob;
        }

        public static string CheckString(string text)
        {
            while (true)
            {           
                Console.Write(text);
                var name = Console.ReadLine();
                var isString = true;

                foreach(char ch in name)
                {
                    if(!char.IsLetter(ch))
                    {
                        isString = false;
                        Console.WriteLine("You write not a string! ");
                        Console.WriteLine("Try again: ");
                        break;
                    }
                }   
                
                if (isString)
                  return name;                         
            }
        }
    }
}
