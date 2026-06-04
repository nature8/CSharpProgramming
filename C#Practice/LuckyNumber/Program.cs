
class Program
{
    static int SumOf(int n)
    {
        int sum = 0;
        while (n > 0)
        {
            sum += n % 10;
            n /= 10;
        }
        return sum;
    }

    static bool IsPrime(int n)
    {
        if (n <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0) return false;
        }
        return true;
    }

    static bool IsLucky(int n)
    {
        if(SumOf(n*n) == SumOf(n) * SumOf(n))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    static void Main(string[] args)
    {
        int num1, num2;
        num1 = Convert.ToInt32(Console.ReadLine());
        num2 = Convert.ToInt32(Console.ReadLine());
        int count=0; 
        for(int i=num1; i<=num2; i++)
        {   
            if(!IsPrime(i))
            {
                if (IsLucky(i))
            {
                count++;
            }
            }
            

        }
        Console.WriteLine(count);
    }
}
