class Nurse : Person
{
   private string department;
    public Nurse(int id, string name, string department) : base(id, name)
    {
        
        this.department = department;
    }
    public override void GetDetails()
    {
        Console.WriteLine("Nurse's ID: "+id);
        Console.WriteLine("Nurse's name: "+name);
        Console.WriteLine("Nurse's department: "+department);
    }
    public override void PerformDuty()
    {
        Console.WriteLine($"Nurse {name} is assisting doctors.");
    } 
}