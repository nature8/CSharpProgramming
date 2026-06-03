class SavingsAccount: Account{
    public override void Withdraw(double amount)
    {
        if(amount > balance)
        {
            Console.WriteLine("Insufficient funds for withdrawal.");
        }
        else
        {
            balance -= amount;
            Console.WriteLine("Withdrawal successful.");
        }
    }

    public override double CalculateInterest()
    {
        //lets assume interest to be 8% per annum
        balance += balance * 0.08; 
        return balance;
    }
}