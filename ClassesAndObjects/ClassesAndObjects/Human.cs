using System;

namespace ClassesAndObjects
{
    abstract class Human
    {
        public String FirstName;
        public String LastName;
        public String Patronymic;        
        public int Day;
        public int Month;
        public int Year;
        public abstract void ShowInformation();

        public Human()
        {
            Console.WriteLine("Run construct Human without parametrs ");
            FirstName = "Undefined";
            LastName = "Undefined";
            Patronymic = "Undefined";
            Day = 0;
            Month = 0;
            Year = 0;            
        }

        public Human(Human human)   
        {
            Console.WriteLine("Run copy construct of Human ");
            FirstName = human.FirstName;
            LastName = human.LastName;
            Patronymic = human.Patronymic;
            Day = human.Day;
            Month = human.Month;
            Year = human.Year;
        }

        public Human(String fname, String lname, String patr, 
                     int bDay, int bMonth, int bYear) 
        {
            Console.WriteLine("Run construct with parametrs of Human");
            FirstName = fname;
            LastName = lname;
            Patronymic = patr;
            Day = bDay;
            Month = bMonth;
            Year = bYear;           
        }

        public virtual void ListChanges()
        {
            Console.Clear();
            Console.WriteLine("Please choose what do you want to change: ");
            Console.WriteLine(" 1. First name ");
            Console.WriteLine(" 2. Last name ");
            Console.WriteLine(" 3. Patronumic ");
            Console.WriteLine(" 4. Year of Birthday ");
            Console.WriteLine(" 5. Month of Birthday ");
            Console.WriteLine(" 6. Day of Birthday ");
        }

        public virtual void ChangeParam(int paramNum)
        {
            switch (paramNum)
            {
                case 1:
                    Console.Write("New name is: ");
                    FirstName = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("New last name is: ");
                    LastName = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("New patronomic is: ");
                    Patronymic = Console.ReadLine();
                    break;
                case 4:
                    Year = CommonMethods.CheckNumber(DateTime.Today.Year, "New Year of Birthday is: ");
                    break;
                case 5:
                    Month = CommonMethods.CheckNumber(12, "New Month of Birthday is: ");
                    break;
                case 6:
                    CommonMethods.AddBirthDay(Month, Year,
                                "New Day of Birthday is: ", out Day);
                    break;
                default:
                    break;
            }
        }

        public void ShowFullYears()
        {
            DateTime now = DateTime.Now;
            DateTime date = new DateTime(Year, Month, Day);
            int fullYears = now.Year - date.Year - 1;

            if(now.Month > date.Month || now.Month == date.Month && now.Day >= date.Day)            
                fullYears += 1;            

            Console.WriteLine($"Full years: {fullYears}");
        }

        public virtual void AddParams()
        {
            Console.Write("First name: ");
            FirstName = Console.ReadLine();
            Console.Write("Last name: ");
            LastName = Console.ReadLine();
            Console.Write("Patronumic: ");
            Patronymic = Console.ReadLine();
            Year = CommonMethods.CheckNumber(DateTime.Today.Year, "Year of Birthday: ");
            Month = CommonMethods.CheckNumber(12, "Month of Birthday: ");
            CommonMethods.AddBirthDay(Month, Year, "Day of Birthday: ", out Day);
        }

        ~ Human()
        {
            Console.WriteLine($"Human {LastName} {FirstName} {Patronymic} has been deleted");
        }
    }
}


