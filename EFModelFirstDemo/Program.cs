using System;
using System.Linq;

namespace EFModelFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new EFModelFirstDemoDBContainer())
            {
                Console.WriteLine("Namen des Studenten:");

                var fn = Console.ReadLine();
                var student = new Student
                {
                    FirstName = fn,
                    LastName = "Leipzig"
                };

                db.Students.Add(student);
                db.SaveChanges();

                var query = from d in db.Students
                            orderby d.FirstName
                            select d;

                foreach (var item in query)
                {
                    Console.WriteLine(item.FirstName);
                }
                Console.ReadKey();

            }
        }
    }
}
