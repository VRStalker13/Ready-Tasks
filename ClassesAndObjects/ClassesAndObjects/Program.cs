using System;
using System.Collections.Generic;

namespace ClassesAndObjects
{
    class Program
    {   
        public List<Human> listHum = new List<Human>() { };

        static void Main()
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
                        ShowAllHumans(out var count);
                        break;
                    default:
                        return;                        
                }
            }
        }

        public void ShowAllHumans(out int counter)
        {            
            Console.Clear();
            Console.WriteLine("List of all Humans:");
            counter = 0;
            foreach (var st in listHum)
            {
                st.ShowInformation();
                counter += 1; 
            }

            Console.WriteLine();
            Console.ReadLine();
        }

        public void ShowOneHuman()
        {                     
            Console.Clear();
            var i = 1;

            foreach (var st in listHum)
            {
                Console.WriteLine($"{i}. {st.FirstName} {st.LastName} {st.Patronymic}");
                i += 1;
            }

            Console.WriteLine($"{i}. Close");
            var humNum = CommonMethods.CheckNumber(i, "Write a number: ");

            if (humNum != i)
            {
                Console.WriteLine();
                listHum[humNum - 1].ShowInformation();
                Console.WriteLine("----------------------------------------------------- ");
                Console.ReadLine();
            }
        }

        public void DeleteHuman()
        {
            Console.Clear();
            var i = 1;

            foreach (var st in listHum)
            {
                Console.WriteLine($"{i}. {st.FirstName} {st.LastName} {st.Patronymic} ");
                i += 1;
            }

            Console.WriteLine($"{i}. Close");
            var humNum = CommonMethods.CheckNumber(i, "Write a number who will be deleted: ");

            if (humNum != i)
            {
                listHum.RemoveAt(humNum - 1);
                Console.ReadLine();
            }
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
                    break;
                case 2:
                    Console.WriteLine("\n --------Please add information about Employee---------- \n");
                    hum = new Employee();
                    break;
                case 3:
                    Console.WriteLine("\n ----------Please add information about Driver---------- \n");
                    hum = new Driver();
                    break;
            }

            hum.AddParams();
            listHum.Add(hum);
            Console.WriteLine();
            Console.ReadLine();
        }

        public void Change()
        {
            var i = 1;
            Console.Clear();
            Console.WriteLine("The list of Humans: ");
            Console.WriteLine();

            foreach (var stu in listHum)
            {
                Console.WriteLine($"{i}. {stu.FirstName} {stu.LastName} {stu.Patronymic} ");
                i += 1;
            }

            Console.WriteLine($"{i}. Close ");
            var humNum = CommonMethods.CheckNumber(i,"Write a number: ");

            var listSize = 0;
            if (listHum[humNum - 1] is Student)
                listSize = 10;
            else if (listHum[humNum - 1] is Employee)
                listSize = 10;
            else if (listHum[humNum - 1] is Driver)
                listSize = 12;
            Console.WriteLine("\n--------------------------------------------------");

            if (humNum != i)
            {                
                listHum[humNum - 1].ListChanges();
                var paramNum = CommonMethods.CheckNumber(listSize, "Write a number: ");
                listHum[humNum - 1].ChangeParam(paramNum);
                Console.WriteLine("\n--------------------------------------------------");
                Console.ReadLine();
            }           
        }
    }
}
