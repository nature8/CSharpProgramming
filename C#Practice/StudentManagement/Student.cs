class Student
{
    private string _name;

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    private string _id;
    public string Id
    {
        get
        {
            return _id;
        }
        set
        {
            _id = value;
        }
    }

    private int _age;
    public int Age
    {
        get
        {
            return _age;
        }
        set
        {
            _age = value;
        }
    }

    private string _address;
    public string Address
    {
        get
        {
            return _address;
        }
        set
        {
            _address = value;
        }
    }

    private double _grade;

    public double Grade
    {
        get { return _grade; }
        set { _grade = value; }
    }


    public Student()
    {   
    }

    public Student(string name, string id, int age, double grade, string address)
    {
        this._name = name;
        this._id = id;
        this._age = age;
        this._grade = grade;
        this._address = address;
    }

    public void Display()
    {
        Console.WriteLine("Name:{0}",_name);
        Console.WriteLine("Id:{0}",_id);
        Console.WriteLine("Age:{0}",_age);
        Console.WriteLine("Grade:{0}",_grade);
        Console.WriteLine("Address:{0}",_address);

    }

    public bool IsPassed()
    {
        bool result;
        if (Grade >= 50)

            result = true;
        else
            result = false;

        return result;
    }

}