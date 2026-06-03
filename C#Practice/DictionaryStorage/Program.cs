
class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Welcome to the C# programming world!");
        Dictionary<String, Double> products = new Dictionary<String, Double>();
        products.Add("Laptop", 999.99);
        products.Add("Smartphone", 499.99);
        products.Add("Headphones", 199.99);
        Console.WriteLine("Product List:");
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Key}: ${product.Value}");
        }
    }
}