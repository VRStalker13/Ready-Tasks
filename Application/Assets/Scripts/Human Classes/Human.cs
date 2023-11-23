﻿using System;

public abstract class Human
    {
        public string FirstName;
        public string LastName;
        public string Patronymic;        
        public DateTime Birthday;

        protected Human(string fname, string lname, string patr, 
                     DateTime birthday) 
        {
            Console.WriteLine("Run construct with parametrs of Human");
            FirstName = fname;
            LastName = lname;
            Patronymic = patr;
            Birthday = birthday;        
        }

        public virtual string ListChanges()
        {
            return "Please choose what do you want to change:" +
                    "\n1. First name" +
                    "\n2. Last name" +
                    "\n3. Patronymic" +
                    "\n4. Birthday";
        }

        protected string ShowFullYears()
        {
            var now = DateTime.Now;            
            var fullYears = now.Year - Birthday.Year - 1;

            if(now.Month > Birthday.Month || now.Month == Birthday.Month && now.Day >= Birthday.Day)            
                fullYears += 1;            

            return $"Full years: {fullYears}";
        }
   }



