using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Before using static method");
            Student s1 = new Student(111, "Duy");
            Student s2 = new Student(222, "Nguyen");

            s1.Display();
            s2.Display();
            Console.WriteLine("_________________________");
            Console.WriteLine("After using static method");
            Student.Change();

            Student s3 = new Student(333, "Vy");
            Student s4 = new Student(444, "Quang");

            Console.WriteLine("Old student: ");
            s1.Display();
            s2.Display();

            Console.WriteLine("New student: ");
            s3.Display();
            s4.Display();

            Console.ReadKey();
        }
    }

    public class Student
    {
        private int rollno;
        private string name;
        private static string college = "BBDIT";

        public Student(int rollno, string name)
        {
            this.rollno = rollno;
            this.name = name;
        }

        public static void Change()
        {
            college = "CODEGYM";
        }

        public void Display()
        {
            Console.WriteLine("{0} {1} {2}",rollno, name, college);
        }
    }
}
