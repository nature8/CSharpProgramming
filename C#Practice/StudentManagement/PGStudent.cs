using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class PGStudent:Student
{
    private string _specialization;

    public string Specialization
    {
        get { return _specialization; }
        set { _specialization = value; }
    }
    private int _noOfPapersPublished;

    public int NoOfPapersPublished
    {
        get { return _noOfPapersPublished; }
        set { _noOfPapersPublished = value; }
    }
	/*fill code here*/
    public PGStudent()
    {
    }
    public PGStudent(string name, string id, int age,
                 double grade, string address,
                 string specialization,
                 int noOfPapersPublished)
    : base(name, id, age, grade, address)
{
    Specialization = specialization;
    NoOfPapersPublished = noOfPapersPublished;
}
    public new void Display()
    {

        Console.WriteLine("Name:{0}", Name);
        Console.WriteLine("Id:{0}", Id);
        Console.WriteLine("Age:{0}", Age);
        Console.WriteLine("Grade:{0}", Grade);
        Console.WriteLine("Address:{0}", Address);
        Console.WriteLine("Specialization:{0}", Specialization);
        Console.WriteLine("No Of Papers Published:{0}", NoOfPapersPublished);
    }

    public new bool IsPassed()
    {
        bool result;
        if (Grade >= 70 && NoOfPapersPublished>=2)

            result = true;
        else
            result = false;

        return result;
    }
}

