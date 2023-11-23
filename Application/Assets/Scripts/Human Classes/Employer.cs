using System;

public class Employer : Human
{
    public string Organization;
    public string WorkPay;
    public string WorkExp;

    public Employer(string fname, string lname, string patr,
                    DateTime birthday, string org, string pay, string exp)
                    : base(fname, lname, patr, birthday)
    {
        Console.WriteLine("Run construct with parametrs of Employer");
        Organization = org;
        WorkPay = pay;
        WorkExp = exp;
    }
    
    public override string ToString()
    {
        return $"Full Name: {Patronymic} {FirstName} {LastName}  \nBirthday: {Birthday.ToString().Substring(0,10)} \n"+ 
            ShowFullYears() + $"\nOrganization: {Organization} \nWork Pay: {WorkPay}  \nWork Experience: {WorkExp}";                         
    }

    public override string ListChanges()
    {
        return base.ListChanges()+
                "\n5. Organization name" +
                "\n6. Work pay" +
                "\n7. Work experience";
    }
}


