using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
class UGStudent: Student
{
        private string _degree;

    public string Degree
    {
        get { return _degree; }
        set { _degree = value; }
    }
    private string _stream;

    public string Stream
    {
        get { return _stream; }
        set { _stream = value; }
    }


    public UGStudent()
    {
    }

    //performed constructor chaining
    public UGStudent(string name, string id, int age,
                 double grade, string address,
                 string degree, string stream)
    : base(name, id, age, grade, address)
{
    Degree = degree;
    Stream = stream;
}
    public new  void Display()
    {
       
        Console.WriteLine("Name:{0}", Name);
        Console.WriteLine("Id:{0}", Id);
        Console.WriteLine("Age:{0}", Age);
        Console.WriteLine("Grade:{0}", Grade);
        Console.WriteLine("Address:{0}",Address);
        Console.WriteLine("Degree:{0}", Degree);
        Console.WriteLine("Stream:{0}", Stream);
    }

    public new bool IsPassed()
    {
        bool result;
        if (Grade >= 70)

            result=true;
        else
            result=false;

        return result;
    }


}