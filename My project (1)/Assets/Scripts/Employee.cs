using System;

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
        return $"Full Name: {Patronymic} {FirstName} {LastName}  \nBirthday: {Birthday.ToString().Substring(0,10)} \n"+ 
            ShowFullYears() + $"\nOrganization: {Organization} \nWork Pay: {WorkPay}  \nWork Experience: {WorkExp}";                         
    }

    public override string ListChanges()
    {
        var list = base.ListChanges()+
                        "\n5. Organization name" +
                        "\n6. Work pay" +
                        "\n7. Work experience";
        return list;
    }

    ~Employee()
    {
        Console.WriteLine($"Employee {FirstName} {LastName} {Patronymic} has been deleted");
    }
}


