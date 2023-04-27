using System;

namespace ClassesAndObjects
{
    class Student : Human
    {
        public String Faculty;
        public String Course;
        public String GroupNum;

        public Student(): base()
        {
            Console.WriteLine("Run construct Student without parametrs ");
            Faculty = "Undefined";
            Course = "Undefined";
            GroupNum = "Undefined";
        }

        public Student(Student stud) : base(stud.FirstName, stud.LastName, stud.Patronymic,
                          stud.Day, stud.Month, stud.Year)
        {
            Console.WriteLine("Run copy construct of Student ");
            Faculty = stud.Faculty;
            Course = stud.Course;
            GroupNum = stud.GroupNum;
        }

        public Student(String fname, String lname, String patr,
                       int bDay, int bMonth, int bYear,
                       String facultyName, String cour, String grNumber)
                       : base(fname, lname, patr, bDay, bMonth, bYear)
        {
            Console.WriteLine("Run construct with parametrs of Student");
            Faculty = facultyName;
            Course = cour;
            GroupNum = grNumber;
        }

        public override void ShowInformation()
        {
            Console.WriteLine("----------------------------------------------------- ");
            Console.WriteLine("All information about Student: ");
            Console.WriteLine($"Full Name: {Patronymic} {FirstName} {LastName}");
            Console.WriteLine($"Birthday: {Day}.{Month}.{Year}");
            ShowFullYears();
            Console.WriteLine($"Faculty: {Faculty}    Course: {Course}   Group: {GroupNum}");
            Console.WriteLine("----------------------------------------------------- ");
        }

        public override void ListChanges()
        {
            base.ListChanges();
            Console.WriteLine(" 7. Faculty name ");
            Console.WriteLine(" 8. Study Course ");
            Console.WriteLine(" 9. Group number ");
            Console.WriteLine("10. Close");
            Console.WriteLine();
        }

        public override void ChangeParam(int paramNum)
        {
            base.ChangeParam(paramNum);
            switch (paramNum)
            {
                case 7:
                    Console.Write("New faculty name is: ");
                    Faculty = Console.ReadLine();
                    break;
                case 8:
                    Console.Write("New Course num is: ");
                    Course = Console.ReadLine();
                    break;
                case 9:
                    Console.Write("New group num is: ");
                    GroupNum = Console.ReadLine();
                    break;
                default:
                    break;
            }

        }

        public override void AddParams()
        {
            base.AddParams();
            Console.Write("Faculty name: ");
            Faculty = Console.ReadLine();
            Console.Write("Study Course: ");
            Course = Console.ReadLine();
            Console.Write("Group number: ");
            GroupNum = Console.ReadLine();
            Console.WriteLine();
        }

        ~ Student()
        {
            Console.WriteLine($"Student {FirstName} {LastName} {Patronymic} has been deleted");
        }
    }
}


