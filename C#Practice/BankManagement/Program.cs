class Program
{
    static void Main(string[] args)
    {
        SavingsAccount savings = new SavingsAccount();
        CurrentAccount current = new CurrentAccount();

        Console.WriteLine("Servicing Savings Account:");
        AccountManagement.ServiceAccount(savings);

        Console.WriteLine("\nServicing Current Account:");
        AccountManagement.ServiceAccount(current);
    }
}
