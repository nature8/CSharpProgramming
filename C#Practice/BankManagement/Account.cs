abstract class Account
{
    long accountNumber = 987654321;
    string customerName = "John Doe";
    protected double balance = 50000;

    public double GetBalance()
    {
        return balance;
    }
    
    //Deposit
    public void Deposit(double amount)
    {
        balance += amount;
    }

    public abstract void Withdraw(double amount);

    public abstract double CalculateInterest();
    public void DisplayDetails()
    {
        Console.WriteLine($"Account: {accountNumber}");
        Console.WriteLine($"Customer: {customerName}");
        Console.WriteLine($"Balance: {balance}");
    }

    
}