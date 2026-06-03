class Doctor : Person
{
    public string department;
    public Doctor(int id, string name, string department) : base(id, name)
    {
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