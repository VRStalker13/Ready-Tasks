using System;

namespace ClassesAndObjects
{
    public sealed class Driver : Employee
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
            return $"Full Name: {Patronymic} {FirstName} {LastName}  \nBirthday: {Birthday} \n"+ 
                ShowFullYears() + $"\n Organozation: {Organization} \nWork Pay: {WorkPay}   \nWork Experience: {WorkExp}"+
                $"\nCar model: {CarModel}  \nCar brand: {CarBrand}";                         
        }

        public override void ListChanges()
        {
            base.ListChanges();
            Console.WriteLine(" 5. Organization name ");
            Console.WriteLine(" 6. Work pay ");
            Console.WriteLine(" 7. Work experience ");
            Console.WriteLine(" 8. Car Brand ");
            Console.WriteLine(" 9. Car Model ");
            Console.WriteLine("10. Close");
            Console.WriteLine();
        }

        ~ Driver()
        {
            Console.WriteLine($"Driver {FirstName} {LastName} {Patronymic} has been deleted");
        }
    }
}
