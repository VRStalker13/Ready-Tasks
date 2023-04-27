using System;

namespace ClassesAndObjects
{
    public static class CommonMethods
    {
        public static int CheckNumber(int numsLenght, string str)
        {
            while (true)
            {
                Console.Write(str);
                var a = Console.ReadLine();

                if (int.TryParse(a, out int humNum))
                    if (humNum <= numsLenght & humNum > 0)
                        return humNum;

                Console.WriteLine("Try again: ");
            }
        }

        public static void AddBirthDay(int Month, int Year, string str, out int Day)
        {
            if (Month == 2)
            {
                if ((Year % 4 == 0 && Year % 100 != 0)
                    || (Year % 100 == 0 && Year % 400 == 0))
                    Day = CheckNumber(29, str);
                else
                    Day = CheckNumber(28, str);

                return;
            }

            if (Month % 2 == 0 && Month != 2)
                Day = CheckNumber(30, str);
            else
                Day = CheckNumber(31, str);
        }

    }
}
