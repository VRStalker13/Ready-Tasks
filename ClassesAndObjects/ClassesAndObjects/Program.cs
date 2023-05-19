using System;
using System.Collections.Generic;

namespace ClassesAndObjects
{
    public class Program
    {   
        public List<Human> listHum = new List<Human>() { };

        public static void Main()
        {           
            var run = new Program();
            Console.ReadLine();
        }

        public Program()
        {           
           Run();
        }        

        public void Run()
        {
            while (true)
            {                               
                Console.Clear();
                Console.WriteLine("List of features: ");
                Console.WriteLine("1. Add information about a new person. ");
                Console.WriteLine("2. Edit the fields of an existing record about a person. ");
                Console.WriteLine("3. Delete information about a person. ");
                Console.WriteLine("4. Show information about the Human ");
                Console.WriteLine("5. Show information about the all Humans ");
                Console.WriteLine("6. Stop a program \n");
                var num = CommonMethods.CheckNumber(6,"Write a number: ");              

                switch(num)
                {
                    case 1:
                        AddHuman();
                        break;
                    case 2:
                        Change();
                        break;
                    case 3:
                        DeleteHuman();
                        break;
                    case 4:
                        ShowOneHuman();
                        break;
                    case 5:
                        ShowAllHumans();
                        break;
                    default:
                        return;                        
                }
            }
        }

        public void ShowAllHumans()
        {            
            Console.Clear();
            Console.WriteLine("List of all Humans:");
            Console.WriteLine("------------------------------------------");

            foreach (var hum in listHum) 
            {
                Console.WriteLine(hum);
                Console.WriteLine("------------------------------------------");
            }               

            Console.WriteLine();
            Console.ReadLine();
        }

        public void ShowOneHuman()
        {                     
            Console.Clear();
            var count =  ShowListHumans();
            var humNum = CommonMethods.CheckNumber(count + 1, "Write a number: ");

            if (humNum == count + 1)
                return;            

            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------- ");
            Console.WriteLine("All information about Human: ");
            Console.WriteLine(listHum[humNum - 1]);
            Console.WriteLine("----------------------------------------------------- ");
            Console.ReadLine();            
        }

        public void DeleteHuman()
        {
            Console.Clear();
            var count =  ShowListHumans();
            var humNum = CommonMethods.CheckNumber(count + 1, "Write a number who will be deleted: ");

            if (humNum == count + 1)
                return;  

            listHum.RemoveAt(humNum - 1);
            Console.ReadLine();            
        }

        public void AddHuman()
        {   
            Console.Clear();
            Console.WriteLine("List of features ");
            Console.WriteLine("1. Add Student ");
            Console.WriteLine("2. Add Employee ");
            Console.WriteLine("3. Add Driver ");
            Console.WriteLine("4. Close ");
            Console.WriteLine();
            var num = CommonMethods.CheckNumber(4,"Write a number: ");     
            Console.WriteLine("\n");       
            Human hum = null;

            switch (num)
            {
                case 1:
                    Console.WriteLine("\n --------Please add information about Student----------- \n");
                    hum = new Student();
                    hum.FirstName = hum.FirstName.CheckString("First name: ");
			        hum.LastName = hum.LastName.CheckString("Last name: ");
			        hum.Patronymic = hum.Patronymic.CheckString("Patronumic: ");
			        hum.Birthday = CommonMethods.InputDoB();   
                    Student stud = (Student)hum;
                    Console.Write("Faculty name: ");
                    stud.Faculty = Console.ReadLine();
                    Console.Write("Study Course: ");
                    stud.Course = Console.ReadLine();
                    Console.Write("Group number: ");
                    stud.GroupNum = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine("\n --------Please add information about Employee---------- \n");
                    hum = new Employee();
                    hum.FirstName = hum.FirstName.CheckString("First name: ");
			        hum.LastName = hum.LastName.CheckString("Last name: ");
			        hum.Patronymic = hum.Patronymic.CheckString("Patronumic: ");
			        hum.Birthday = CommonMethods.InputDoB();
                    Employee empl = (Employee)hum;
                    Console.Write("Organisation name: ");
                    empl.Organization = Console.ReadLine();
                    Console.Write("Working Pay: ");
                    empl.WorkPay = Console.ReadLine();
                    Console.Write("Working Experience: ");
                    empl.WorkExp = Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine("\n ----------Please add information about Driver---------- \n");
                    hum = new Driver();
                    hum.FirstName = hum.FirstName.CheckString("First name: ");
			        hum.LastName = hum.LastName.CheckString("Last name: ");
			        hum.Patronymic = hum.Patronymic.CheckString("Patronumic: ");
			        hum.Birthday = CommonMethods.InputDoB();
                    Driver driver = (Driver)hum;
                    Console.Write("Organisation name: ");
                    driver.Organization = Console.ReadLine();
                    Console.Write("Working Pay: ");
                    driver.WorkPay = Console.ReadLine();
                    Console.Write("Working Experience: ");
                    driver.WorkExp = Console.ReadLine();
                    Console.Write("Car Brand: ");
                    driver.CarBrand = Console.ReadLine();
                    Console.Write("Car Model: ");
                    driver.CarModel = Console.ReadLine(); 
                    break;
            }

            listHum.Add(hum);
            Console.WriteLine();
            Console.ReadLine();
        }

        public int ShowListHumans()
        {
            var count = listHum.Count;

            for (var i = 0; i < count; i++)            
                Console.WriteLine($"{i + 1}. {listHum[i].FirstName} {listHum[i].LastName} {listHum[i].Patronymic}");     

            Console.WriteLine($"{count + 1}. Close");
            return count;
        }

        public void Change()
        {
            Console.Clear();
            Console.WriteLine("The list of Humans: ");
            Console.WriteLine();
            var count = ShowListHumans();
            var humNum = CommonMethods.CheckNumber(count + 1,"Write a number: ");

            Console.WriteLine("\n--------------------------------------------------");

            if (humNum == count + 1)
                return;   

            listHum[humNum - 1].ListChanges();

            if (listHum[humNum - 1] is Student stud)
                ChangeStudent(stud, humNum);

            if (listHum[humNum - 1] is Employee empl)
                ChangeEmployee(empl, humNum);

            if (listHum[humNum - 1] is Driver driver)
                ChangeDriver(driver, humNum);  

            Console.WriteLine("\n--------------------------------------------------");
            Console.ReadLine();
        }

        public void ChangeDriver(Driver driver, int humNum)
        {
            var paramNum = CommonMethods.CheckNumber(9,"Please write a number: ");

            switch (paramNum)
            {
                case 1:
                    listHum[humNum - 1].FirstName = listHum[humNum - 1].FirstName.CheckString("New name is: ");
                    return;
                case 2:
                    listHum[humNum - 1].LastName = listHum[humNum - 1].LastName.CheckString("New last name is: ");
                    return;
                case 3:
                    listHum[humNum - 1].Patronymic = listHum[humNum - 1].Patronymic.CheckString("New patronomic is: ");
                    return;
                case 4:
                    listHum[humNum - 1].Birthday = CommonMethods.InputDoB();
                    return;
                case 5:
                    Console.Write("New Organization name is: ");
                    driver.Organization = Console.ReadLine();
                    return;
                case 6:
                    Console.Write("New work pay is: ");
                    driver.WorkPay = Console.ReadLine();
                    return;
                case 7:
                    Console.Write("New work experience is: ");
                    driver.WorkExp = Console.ReadLine();
                    return;
                case 8:
                    Console.Write("Car brand is: ");
                    driver.CarBrand = Console.ReadLine();
                    return;
                case 9:
                    Console.Write("Car model is: ");
                    driver.CarModel = Console.ReadLine();
                    return;                    
                default:
                    break;
            }
        }
        
        public void ChangeEmployee(Employee empl, int humNum)
        {
            var paramNum = CommonMethods.CheckNumber(7,"Please write a number: ");

            switch (paramNum)
            {
                case 1:
                    listHum[humNum - 1].FirstName = listHum[humNum - 1].FirstName.CheckString("New name is: ");
                    return;
                case 2:
                    listHum[humNum - 1].LastName = listHum[humNum - 1].LastName.CheckString("New last name is: ");
                    return;
                case 3:
                    listHum[humNum - 1].Patronymic = listHum[humNum - 1].Patronymic.CheckString("New patronomic is: ");
                    return;
                case 4:
                    listHum[humNum - 1].Birthday = CommonMethods.InputDoB();
                    return;
                case 5:
                    Console.Write("New Organization name is: ");
                    empl.Organization = Console.ReadLine();
                    return;
                case 6:
                    Console.Write("New work pay is: ");
                    empl.WorkPay = Console.ReadLine();
                    return;
                case 7:
                    Console.Write("New work experience is: ");
                    empl.WorkExp = Console.ReadLine();
                    return;
                default:
                    break;
            }
        }

        public void ChangeStudent(Student stud, int humNum)
        {
            var paramNum = CommonMethods.CheckNumber(7,"Please write a number: ");

            switch (paramNum)
            {
                case 1:
                    listHum[humNum - 1].FirstName = listHum[humNum - 1].FirstName.CheckString("New name is: ");
                    return;
                case 2:
                    listHum[humNum - 1].LastName = listHum[humNum - 1].LastName.CheckString("New last name is: ");
                    return;
                case 3:
                    listHum[humNum - 1].Patronymic = listHum[humNum - 1].Patronymic.CheckString("New patronomic is: ");
                    return;
                case 4:
                    listHum[humNum - 1].Birthday = CommonMethods.InputDoB();
                    return;
                case 5:
                    Console.Write("New faculty name is: ");
                    stud.Faculty = Console.ReadLine();
                    return;
                case 6:
                    Console.Write("New Course num is: ");
                    stud.Course = Console.ReadLine();
                    return;
                case 7:
                    Console.Write("New group num is: ");
                    stud.GroupNum = Console.ReadLine();
                    return;
                default:
                    break;
            }
        }
    }
}
