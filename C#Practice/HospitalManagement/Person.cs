abstract class Person
{
    public int id;
    public string name;

    public Person(int id, string name)
    {
        this.id = id;
        this.name = name;
    }

    public abstract void GetDetails();
    public abstract void PerformDuty();
    
}