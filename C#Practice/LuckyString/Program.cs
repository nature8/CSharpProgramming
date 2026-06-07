class Program{
    static bool IsValidString(string str, int subStrLength){

        for(int i = 0; i <= str.Length - subStrLength; i++){
            string subStr = str.Substring(i, subStrLength);
            bool isValid = true;
            foreach(char ch in subStr){
                if(ch != 'P' && ch != 'S' && ch != 'G'){
                    isValid = false;
                    break;
                }
            }

            if(! isValid){
                continue;
            }

            int count = 1;
            int maxCount = 1;

            for (int j = 1; j < subStr.Length; j++)
            {
                if (subStr[j] == subStr[j - 1])
                {
                    count++;
                    maxCount = Math.Max(maxCount, count);
                }
                else
                {
                    count = 1;
                }
            }

            if (maxCount >= subStrLength / 2)
            {
                return true;
            }
        }

        return false;

    }
    static void Main(string[] args){
        int subStrLength = Convert.ToInt32(Console.ReadLine());
        string str = Console.ReadLine();
        if(subStrLength > str.Length)
        {
            Console.WriteLine("Invalid");
            return;
        }
        if(IsValidString(str, subStrLength)){
            Console.WriteLine("YES");
        }
        else{
            Console.WriteLine("NO");
        }
    }
}