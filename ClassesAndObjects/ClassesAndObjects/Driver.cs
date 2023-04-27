using System;

namespace ClassesAndObjects
{
    sealed class Driver : Employee
    {
        public String CarBrand;
        public String CarModel;

        public Driver() : base()
        {
            Console.WriteLine("Run construct Driver without parametrs ");
            CarBrand = "Undefined";
            CarModel = "Undefined";
        }
        
        public Driver(Driver driver):base(driver.FirstName, driver.LastName, driver.Patronymic,
                                          driver.Day, driver.Month, driver.Year, driver.Organization,
                                          driver.WorkPay, driver.WorkExp)
        {
            Console.WriteLine("Run copy construct of Driver ");
            CarBrand = driver.CarBrand;
            CarModel = driver.CarModel;
        }

        public Driver(String fname, String lname, String patr,
                        int bDay, int bMonth, int bYear,
                        String org, String pay, String exp, 
                        String brand, String model)
                        : base(fname, lname, patr, bDay, bMonth, bYear, org, pay, exp)
        {
            Console.WriteLine("Run construct with parametrs of Driver");
            CarBrand = brand;
            CarModel = model;
        }

        public override void ShowInformation()
        {
            Console.WriteLine("----------------------------------------------------- ");
            Console.WriteLine("All information about Driver: ");
            Console.WriteLine($"Full Name: {FirstName} {LastName} {Patronymic}");
            Console.WriteLine($"Birthday: {Day}.{Month}.{Year}");
            ShowFullYears();
            Console.WriteLine($"Organozation: {Organization}");
            Console.WriteLine($"Work Pay: {WorkPay}   Work Experience: {WorkExp}");
            Console.WriteLine($"Car model: {CarModel}  Car brand: {CarBrand}");
            Console.WriteLine("----------------------------------------------------- ");
        }

        public override void ListChanges()
        {
            base.ListChanges();
            Console.WriteLine(" 7. Organization name ");
            Console.WriteLine(" 8. Work pay ");
            Console.WriteLine(" 9. Work experience ");
            Console.WriteLine("10. Car Brand ");
            Console.WriteLine("11. Car Model ");
            Console.WriteLine("12. Close");
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
                case 10:
                    Console.Write("Car brand is: ");
                    CarBrand = Console.ReadLine();
                    break;
                case 11:
                    Console.Write("Car model is: ");
                    CarModel = Console.ReadLine();
                    break;
                default:
                    break;
            }
        }

        public override void AddParams()
        {
            base.AddParams();
            Console.Write("Car Brand: ");
            CarBrand = Console.ReadLine();
            Console.Write("Car Model: ");
            CarModel = Console.ReadLine();
            Console.WriteLine();
        }

        ~ Driver()
        {

            Console.WriteLine($"Driver {FirstName} {LastName} {Patronymic} has been deleted");
        }
    }
}
