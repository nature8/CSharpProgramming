class Patient : Person
{
    //make patient records private

    private string disease;
    public Patient(int id, string name, string disease) : base(id, name)
    {
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