using System.Text;

class Program
{
     static bool IsVowel(char ch)
    {
        ch = char.ToLower(ch);
        return ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u';
    }
    static string GetSimplifiedString(string str1, string str2)
    {
        StringBuilder temp = new StringBuilder();

        string lowerStr2 = str2.ToLower();

        // Remove common consonants
        foreach (char ch in str1)
        {
            char lowerCh = char.ToLower(ch);

            if (!IsVowel(lowerCh) && lowerStr2.Contains(lowerCh))
            {
                continue;
            }

            temp.Append(ch);
        }

        // Remove consecutive duplicates
        StringBuilder result = new StringBuilder();

        if (temp.Length > 0)
        {
            result.Append(temp[0]);

            for (int i = 1; i < temp.Length; i++)
            {
                if (char.ToLower(temp[i]) != char.ToLower(temp[i - 1]))
                {
                    result.Append(temp[i]);
                }
            }
        }

        return result.ToString();
        
    }
    
    static void Main(string[] args)
    {
        string str1 = Console.ReadLine();
        string str2 = Console.ReadLine();

        string result = GetSimplifiedString(str1, str2);
        Console.WriteLine(result);
    }
}