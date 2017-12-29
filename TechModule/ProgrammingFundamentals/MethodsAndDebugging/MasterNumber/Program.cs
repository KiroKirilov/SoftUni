using System;

public class Program
{
    public static bool isPalindrome(long a)
    {
        long rem, sum = 0, temp;
        temp = a;
        while (a > 0)
        {
            rem = a % 10;
            a = a / 10;
            sum = sum * 10 + rem;
        }

        if (temp == sum)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool sumBy7(long a)
    {
        long sum = 0;
        while (a != 0)
        {
            sum += a % 10;
            a /= 10;
        }

        if (sum % 7 == 0)
            return true;
        else
            return false;
    }

    public static bool containsEven(long a)
    {
        long rem;
        while (a != 0)
        {
            rem = a % 10;
            if (rem % 2 == 0)
                return true;
            a /= 10;
        }

        return false;
    }

    public static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        for (long i = 1; i <= n; i++)
        {
            if (sumBy7(i) && containsEven(i) && isPalindrome(i))
                Console.WriteLine(i);
        }
    }
}