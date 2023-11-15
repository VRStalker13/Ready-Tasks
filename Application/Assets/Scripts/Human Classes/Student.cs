using System;

    public class Student : Human
    {
        public string Faculty;
        public string Course;
        public string GroupNum;

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
            return $"Full Name: {Patronymic} {FirstName} {LastName}  \nBirthday: {Birthday.ToString().Substring(0,10)} \n"+ 
                ShowFullYears() + $"\nFaculty: {Faculty}    \nCourse: {Course}   \nGroup: {GroupNum}";                         
        }

        public override string ListChanges()
        {
            var list = base.ListChanges() +
                       "\n5. Faculty name" +
                       "\n6. Study Course" +
                       "\n7. Group number";
            return list;
        }
    }



