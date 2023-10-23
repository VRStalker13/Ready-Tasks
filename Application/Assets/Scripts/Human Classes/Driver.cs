using System;

public sealed class Driver : Employer
{
    public string CarBrand;
    public string CarModel;

    public Driver(string fname, string lname, string patr,
                    DateTime birthday, string org, string pay, string exp, 
                    string brand, string model)
                    : base(fname, lname, patr, birthday, org, pay, exp)
    {
        Console.WriteLine("Run construct with parametrs of Driver");
        CarBrand = brand;
        CarModel = model;
    }

    public override string ToString()
    {
        return $"Full Name: {Patronymic} {FirstName} {LastName}  \nBirthday: {Birthday.ToString().Substring(0,10)} \n"+ 
            ShowFullYears() + $"\nOrganization: {Organization} \nWork Pay: {WorkPay}   \nWork Experience: {WorkExp}"+
            $"\nCar model: {CarModel}  \nCar brand: {CarBrand}";                         
    }

    public override string ListChanges()
    {
        var list = base.ListChanges() +
                   "\n8. Car Brand" +
                   "\n9. Car Model";
        return list;
    }
}
