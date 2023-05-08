using System;

namespace ClassesAndObjects
{
    public abstract class Human
    {
        public string FirstName;
        public string LastName;
        public string Patronymic;        
        public DateTime Birthday;

        public Human()
        {
            Console.WriteLine("Run construct Human without parametrs ");
            FirstName = "Undefined";
            LastName = "Undefined";
            Patronymic = "Undefined";
            Birthday  = new DateTime();     
        }

        public Human(Human human)   
        {
            Console.WriteLine("Run copy construct of Human ");
            FirstName = human.FirstName;
            LastName = human.LastName;
            Patronymic = human.Patronymic;
            Birthday = human.Birthday;
        }

        public Human(string fname, string lname, string patr, 
                     DateTime birthday) 
        {
            Console.WriteLine("Run construct with parametrs of Human");
            FirstName = fname;
            LastName = lname;
            Patronymic = patr;
            Birthday = birthday;        
        }

        public virtual void ListChanges()
        {
            Console.Clear();
            Console.WriteLine("Please choose what do you want to change: ");
            Console.WriteLine(" 1. First name ");
            Console.WriteLine(" 2. Last name ");
            Console.WriteLine(" 3. Patronumic ");
            Console.WriteLine(" 4. Birthday ");
        }

        public virtual void ChangeParam(int paramNum)
        {
            switch (paramNum)
            {
                case 1:
                    FirstName = CommonMethods.CheckString("New name is: ");
                    break;
                case 2:
                    LastName = CommonMethods.CheckString("New last name is: ");
                    break;
                case 3:
                    Patronymic = CommonMethods.CheckString("New patronomic is: ");
                    break;
                case 4:
                    Birthday = CommonMethods.InputDoB();
                    break;

                default:
                    break;
            }
        }

        public string ShowFullYears()
        {
            var now = DateTime.Now;            
            var fullYears = now.Year - Birthday.Year - 1;

            if(now.Month > Birthday.Month || now.Month == Birthday.Month && now.Day >= Birthday.Day)            
                fullYears += 1;            

            return $"Full years: {fullYears}";
        }

        public virtual void AddParams()
        {
            FirstName = CommonMethods.CheckString("First name: ");
            LastName = CommonMethods.CheckString("Last name: ");
            Patronymic = CommonMethods.CheckString("Patronumic: ");
            Birthday = CommonMethods.InputDoB();
        }

        ~ Human()
        {
            Console.WriteLine($"Human {LastName} {FirstName} {Patronymic} has been deleted");
        }
    }
}


