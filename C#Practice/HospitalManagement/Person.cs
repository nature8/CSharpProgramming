abstract class Person
{
    public int id;
    public string name;

    // If we use this constructor then we have to call base constructor in every derived class!!
    /*public Person(int id, string name)
    {
        this.id = id;
        this.name = name;
    }*/

    public abstract void GetDetails();
    public abstract void PerformDuty();
    
}