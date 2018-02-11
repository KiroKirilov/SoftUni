using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class _07BalancedParentheses
{
    public static void Main()
    {
        // {, [, (, ), ], } - eligible
        var input = Console.ReadLine();
        var stack = new Stack<char>();

        var isSymmetrical = true;

        foreach (char bracket in input)
        {
            switch (bracket)
            {
                case '[':
                case '(':
                case '{':
                    stack.Push(bracket);
                    break;

                case '}':
                    if (!stack.Any())
                        isSymmetrical = false;

                    else if (stack.Pop() != '{')
                        isSymmetrical = false;
                    break;

                case ')':
                    if (!stack.Any())
                        isSymmetrical = false;

                    else if (stack.Pop() != '(')
                        isSymmetrical = false;
                    break;

                case ']':
                    if (!stack.Any())
                        isSymmetrical = false;

                    else if (stack.Pop() != '[')
                        isSymmetrical = false;
                    break;
            }

            if (!isSymmetrical)
                break;
        }

        Console.WriteLine(isSymmetrical ? "YES" : "NO");
    }
}
