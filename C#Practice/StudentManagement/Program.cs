using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Program
{

    static void Main(string[] args)
    {

        string name, id, address, degree, stream, specialization;
        int age, noOfPapers, choice;
        double grade;

        Console.WriteLine("Menu");
        Console.WriteLine("1) Create a Student");
        Console.WriteLine("2) Create a UG Student");
        Console.WriteLine("3) Create a PG Student");
        Console.WriteLine("Enter your choice");
        choice = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter name");
        name = Console.ReadLine();
        Console.WriteLine("Enter id");
        id = Console.ReadLine();
        Console.WriteLine("Enter age");
        age = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter grade");
        grade = double.Parse(Console.ReadLine());
        Console.WriteLine("Enter address");
        address = Console.ReadLine();

        switch (choice)
        {
            case 1:
                Student student = new Student(name, id, age, grade, address);
                Console.WriteLine("Student Details");
                student.Display();
                if (student.IsPassed())
                    Console.WriteLine("Result : Pass");
                else
                    Console.WriteLine("Result : Fail");

                break;
            case 2:
                Console.WriteLine("Enter degree");
                degree = Console.ReadLine();
                Console.WriteLine("Enter stream");
                stream = Console.ReadLine();
                UGStudent ugstudent = new UGStudent(name, id, age, grade, address, degree, stream);
                Console.WriteLine("UG Student Details");
                ugstudent.Display();
                if (ugstudent.IsPassed())
                    Console.WriteLine("Result : Pass");
                else
                    Console.WriteLine("Result : Fail");

                break;
            case 3:
                Console.WriteLine("Enter specialization");
                specialization = Console.ReadLine();
                Console.WriteLine("Enter number of papers published");
                noOfPapers = int.Parse(Console.ReadLine());
                PGStudent pgstudent = new PGStudent(name, id, age, grade, address, specialization, noOfPapers);
                Console.WriteLine("PG Student Details");
                pgstudent.Display();
                if (pgstudent.IsPassed())
                    Console.WriteLine("Result : Pass");
                else
                    Console.WriteLine("Result : Fail");

                break;
            default:
                break;
        }

    }

}

