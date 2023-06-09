﻿using System;

namespace ClassesAndObjects
{
    public class Student : Human
    {
        public string Faculty;
        public string Course;
        public string GroupNum;

        public Student()
        {
            Console.WriteLine("Run construct Student without parametrs ");
            Faculty = "Undefined";
            Course = "Undefined";
            GroupNum = "Undefined";
        }

        public Student(Student stud) : base(stud.FirstName, stud.LastName, stud.Patronymic,
                          stud.Birthday)
        {
            Console.WriteLine("Run copy construct of Student ");
            Faculty = stud.Faculty;
            Course = stud.Course;
            GroupNum = stud.GroupNum;
        }

        public Student(string fname, string lname, string patr,
                       DateTime birthday, string facultyName, string cour, string grNumber)
                       : base(fname, lname, patr, birthday)
        {
            Console.WriteLine("Run construct with parametrs of Student");
            Faculty = facultyName;
            Course = cour;
            GroupNum = grNumber;
        }

        public override string ToString()
        {
            return $"Full Name: {Patronymic} {FirstName} {LastName}  \nBirthday: {Birthday} \n"+ 
                ShowFullYears() + $"\nFaculty: {Faculty}    \nCourse: {Course}   \nGroup: {GroupNum}";                         
        }

        public override void ListChanges()
        {
            base.ListChanges();
            Console.WriteLine(" 5. Faculty name ");
            Console.WriteLine(" 6. Study Course ");
            Console.WriteLine(" 7. Group number ");
            Console.WriteLine(" 8. Close");
            Console.WriteLine();
        }

        ~ Student()
        {
            Console.WriteLine($"Student {FirstName} {LastName} {Patronymic} has been deleted");
        }
    }
}


