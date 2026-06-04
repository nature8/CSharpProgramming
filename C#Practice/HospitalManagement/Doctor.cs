class Doctor : Person
{
    public string department;

    //Its mandatory to call base constructor if the super class consisting of only parameterized constructor just like super() calling statement in Java!!
    /*public Doctor(int id, string name, string department) : base(id, name)
    {
        this.department = department;
    }*/

    public Doctor(int id, string name, string department)
    {
        this.id = id;
        this.name = name;
        this.department = department;
    }
   public override void GetDetails()
    {
        Console.WriteLine("Doctor's ID: "+id);
        Console.WriteLine("Doctor's name: "+name);
        Console.WriteLine("Doctor's department: "+department);
    }

    public override void PerformDuty()
    {
        Console.WriteLine($"Doctor {name} is treating patients.");
    }
}