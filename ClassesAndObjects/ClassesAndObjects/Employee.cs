using System;

namespace ClassesAndObjects
{
    class Employee : Human
    {
        public String Organization;
        public String WorkPay;
        public String WorkExp;

        public Employee() : base()
        {
            Console.WriteLine("Run construct Employee without parametrs ");
            Organization = "Undefined";
            WorkPay = "Undefined";
            WorkExp = "Undefined";
        }

        public Employee(String fname, String lname, String patr,
                        int bDay, int bMonth, int bYear,
                        String org, String pay, String exp)
                        : base(fname, lname, patr, bDay, bMonth, bYear)
        {
            Console.WriteLine("Run construct with parametrs of Employee");
            Organization = org;
            WorkPay = pay;
            WorkExp = exp;
        }

        public Employee(Employee empl) : base(empl.FirstName, empl.LastName, empl.Patronymic,
                                  empl.Day, empl.Month, empl.Year)
        {
            Console.WriteLine("Run copy construct of Employee ");
            Organization = empl.Organization;
            WorkPay = empl.WorkPay;
            WorkExp = empl.WorkExp;
        }

        public override void ShowInformation()
        {
            Console.WriteLine("----------------------------------------------------- ");
            Console.WriteLine("All information about Employee: ");
            Console.WriteLine($"Full Name: {FirstName} {LastName} {Patronymic}");
            Console.WriteLine($"Birthday: {Day}.{Month}.{Year}");
            ShowFullYears();
            Console.WriteLine($"Organozation: {Organization}");
            Console.WriteLine($"Work Pay: {WorkPay}   Work Experience: {WorkExp}");
            Console.WriteLine("----------------------------------------------------- ");
        }

        public override void ListChanges()
        {
            base.ListChanges();
            Console.WriteLine(" 7. Organization name ");
            Console.WriteLine(" 8. Work pay ");
            Console.WriteLine(" 9. Work experience ");
            Console.WriteLine("10. Close");
            Console.WriteLine();
        }

        public override void ChangeParam(int paramNum)
        {
            base.ChangeParam(paramNum);
            switch (paramNum)
            {
                case 7:
                    Console.Write("New Organization name is: ");
                    Organization = Console.ReadLine();
                    break;
                case 8:
                    Console.Write("New work pay is: ");
                    WorkPay = Console.ReadLine();
                    break;
                case 9:
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

