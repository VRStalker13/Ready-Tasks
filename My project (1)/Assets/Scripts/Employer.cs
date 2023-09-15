using System;

public class Employer : Human
{
    public string Organization;
    public string WorkPay;
    public string WorkExp;

    public Employer()
    {
        Console.WriteLine("Run construct Employer without parametrs ");
        Organization = "Undefined";
        WorkPay = "Undefined";
        WorkExp = "Undefined";
    }

    public Employer(string fname, string lname, string patr,
                    DateTime birthday, string org, string pay, string exp)
                    : base(fname, lname, patr, birthday)
    {
        Console.WriteLine("Run construct with parametrs of Employer");
        Organization = org;
        WorkPay = pay;
        WorkExp = exp;
    }

    public Employer(Employer empl) : base(empl.FirstName, empl.LastName, empl.Patronymic,
                              empl.Birthday)
    {
        Console.WriteLine("Run copy construct of Employer ");
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

    ~Employer()
    {
        Console.WriteLine($"Employer {FirstName} {LastName} {Patronymic} has been deleted");
    }
}


