using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Code_First_console_app
{
   class Program
    {
        static void Main(string[] args)
        {
            using(var db = new StudentContext())
            {
                Console.Write("Enter a Name for a New Student:");
                var name = Console.ReadLine();

                var Student = new Student { Name = name };
                db.Students.Add(Student);
                db.SaveChanges();

               var query = from b in db.Students
                            orderby b.Name
                            select b;
                foreach(var item in query)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }
    }
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }

        public virtual List<Teacher> Teacher { get; set; }
    }
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int StudentID { get; set; }
        public virtual Student Student { get; set; }
    }

    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; } 

    }
    
        
    }


    