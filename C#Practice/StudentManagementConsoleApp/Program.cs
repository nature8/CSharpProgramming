using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> students = new List<string>();

        students.Add("John");
        students.Add("David");
        students.Add("Sam");

        Console.WriteLine("Students List");

        foreach(var student in students)
        {
            Console.WriteLine(student);
        }

        Console.WriteLine(
            $"Total Students: {students.Count}");
    }
}
