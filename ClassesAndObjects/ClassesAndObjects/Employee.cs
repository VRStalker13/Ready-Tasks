using System;

namespace ClassesAndObjects
{
    public class Employee : Human
    {
        public string Organization;
        public string WorkPay;
        public string WorkExp;

        public Employee() : base()
        {
            Console.WriteLine("Run construct Employee without parametrs ");
            Organization = "Undefined";
            WorkPay = "Undefined";
            WorkExp = "Undefined";
        }

        public Employee(string fname, string lname, string patr,
                        DateTime birthday, string org, string pay, string exp)
                        : base(fname, lname, patr, birthday)
        {
            Console.WriteLine("Run construct with parametrs of Employee");
            Organization = org;
            WorkPay = pay;
            WorkExp = exp;
        }

        public Employee(Employee empl) : base(empl.FirstName, empl.LastName, empl.Patronymic,
                                  empl.Birthday)
        {
            Console.WriteLine("Run copy construct of Employee ");
            Organization = empl.Organization;
            WorkPay = empl.WorkPay;
            WorkExp = empl.WorkExp;
        }
        
        public override string ToString()
        {
            return $"Full Name: {Patronymic} {FirstName} {LastName}  \nBirthday: {Birthday} \n"+ 
                ShowFullYears() + $"\n Organozation: {Organization} \nWork Pay: {WorkPay}  \nWork Experience: {WorkExp}";                         
        }

        public override void ListChanges()
        {
            base.ListChanges();
            Console.WriteLine(" 5. Organization name ");
            Console.WriteLine(" 6. Work pay ");
            Console.WriteLine(" 7. Work experience ");
            Console.WriteLine(" 8. Close");
            Console.WriteLine();
        }

        public override void ChangeParam(int paramNum)
        {
            base.ChangeParam(paramNum);
            switch (paramNum)
            {
                case 5:
                    Console.Write("New Organization name is: ");
                    Organization = Console.ReadLine();
                    break;
                case 6:
                    Console.Write("New work pay is: ");
                    WorkPay = Console.ReadLine();
                    break;
                case 7:
                    Console.Write("New work experience is: ");
                    WorkExp = Console.ReadLine();
                    break;
                default:
                    break;
            }
        }

        public override void AddParams()
        {
            base.AddParams();
            Console.Write("Organisation name: ");
            Organization = Console.ReadLine();
            Console.Write("Working Pay: ");
            WorkPay= Console.ReadLine();
            Console.Write("Working Experience: ");
            WorkExp = Console.ReadLine();
            Console.WriteLine();
        }

        ~Employee()
        {
            Console.WriteLine($"Employee {FirstName} {LastName} {Patronymic} has been deleted");
        }
    }
}

