using System;

namespace ClassesAndObjects
{
    public class Employee : Human
    {
        public string Organization;
        public string WorkPay;
        public string WorkExp;

        public Employee()
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

        ~Employee()
        {
            Console.WriteLine($"Employee {FirstName} {LastName} {Patronymic} has been deleted");
        }
    }
}

