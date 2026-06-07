class Program
{
    static void Main(string[] args)
    {
        string[] LstCity = {"Mumbai", "Delhi" , "Patna","London","Banglore","Newyork" };  
        //Create the query.
        var cities = from cityList in LstCity  
        select cityList;  
        //Execute the query.
        // 3. Query execution.   
        foreach (var c in cities)  
        {  
            Console.Write("{0,1} ", c);  
        }  

    }
}
