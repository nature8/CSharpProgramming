class AccountManagement{
    public static void ServiceAccount(Account account)
    {
        account.DisplayDetails();
        account.Deposit(1000);
        Console.WriteLine("After deposit:");
        account.DisplayDetails();
        account.Withdraw(500);
        Console.WriteLine("After withdrawal:");
        account.DisplayDetails();
    }
}