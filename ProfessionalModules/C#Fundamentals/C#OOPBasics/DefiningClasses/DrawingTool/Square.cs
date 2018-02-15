using System;
using System.Collections.Generic;
using System.Text;


public class Square
{
    public int size;

    public Square(int size)
    {
        this.size = size;
    }

    public void Draw()
    {
        for (int i = 0; i < size; i++)
        {
            if (i == 0 || i == size - 1)
            {
                Console.WriteLine("|" + new string('-', size) + "|");
            }
            else
            {
                Console.WriteLine("|" + new string(' ', size) + "|");
            }
        }
    }
}

