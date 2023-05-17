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
            string input;
            DateTime birthday;

            do
            {
                Console.Write("Write Birthday in format dd.mm.yyyy (day.month.year): ");
                 input = Console.ReadLine();
            }
            while (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out birthday));      
            
            return birthday;
        }

        public static string CheckString(this string str,string text)
        {
            while (true)
            {           
                Console.Write(text);
                var name = Console.ReadLine();
                var isString = true;
                var lenght = name.Length;

                if (lenght < 2)
                {
                    Console.WriteLine("You write not a string! ");
                    Console.WriteLine("Try again: ");
                    continue;
                }

                if (!char.IsLetter(name[0]) || !char.IsLetter(name[1]) || !char.IsLetter(name[lenght-2]) || !char.IsLetter(name[lenght-1]))
                    {
                        Console.WriteLine("You write not a string! ");
                        Console.WriteLine("Try again: ");
                        isString = false;
                    }
                else if(lenght > 2)
                {
                    var counter = 0;
                    for(int i = 2; i < lenght; i++)
                    {                        
                        if (name[i]=='-' & counter < 1)
                        {
                            counter+=1;
                            continue;
                        }
                           
                        if(!char.IsLetter(name[i]))
                        {
                            isString = false;
                            Console.WriteLine("You write not a string! ");
                            Console.WriteLine("Try again: ");
                            break;
                        }
                    }   
                }
                
                if (isString)
                  return name;                         
            }
        }
    }
}
