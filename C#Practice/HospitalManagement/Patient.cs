class Patient : Person
{
    //make patient records private
    private string disease;

    //Its mandatory to call base constructor if the super class consisting of only parameterized constructor just like super() calling statement in Java!!
    /*public Patient(int id, string name, string disease) : base(id, name)
    {
        this.disease = disease;
    }*/

    public Patient(int id, string name, string disease)
    {
        this.id = id;
        this.name = name;
        this.disease = disease;
    }
    public override void GetDetails()
    {
        Console.WriteLine("Patient's name: "+name);
    }

    public override void PerformDuty()
    {
        Console.WriteLine($"Patient {name} is receiving treatment.");
    }
}