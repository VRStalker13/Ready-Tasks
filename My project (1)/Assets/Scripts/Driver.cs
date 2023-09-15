using System;

public sealed class Driver : Employer
{
    public string CarBrand;
    public string CarModel;

    public Driver()
    {
        Console.WriteLine("Run construct Driver without parametrs ");
        CarBrand = "Undefined";
        CarModel = "Undefined";
    }
    
    public Driver(Driver driver):base(driver.FirstName, driver.LastName, driver.Patronymic,
                                      driver.Birthday, driver.Organization,
                                      driver.WorkPay, driver.WorkExp)
    {
        Console.WriteLine("Run copy construct of Driver ");
        CarBrand = driver.CarBrand;
        CarModel = driver.CarModel;
    }

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
                        "\n5. Organization name" +
                        "\n6. Work pay" +
                        "\n7. Work experience" +
                        "\n8. Car Brand" +
                        "\n9. Car Model";
        return list;
    }

    ~ Driver()
    {
        Console.WriteLine($"Driver {FirstName} {LastName} {Patronymic} has been deleted");
    }
}
