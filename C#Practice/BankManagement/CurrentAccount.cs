class CurrentAccount: Account
{
    public override void Withdraw(double amount)
    {
        if (amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Withdrawn: {amount}");
        }
        else
        {
            Console.WriteLine("Insufficient Balance");
        }
    }

    // for current account, interest in not applicable!!!!
    public override double CalculateInterest()
    {
        return 0; 
    }
}
