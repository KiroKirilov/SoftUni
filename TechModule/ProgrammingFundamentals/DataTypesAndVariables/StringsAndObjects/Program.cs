using System;

public class Program
{
    public static void Main()
    {
        string s1 = "Hello";
        string s2 = "World";
        object obj = s1 + " " + s2;
        string s3 = (string)obj;
        Console.WriteLine(s3);

    }
}