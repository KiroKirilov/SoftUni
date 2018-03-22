using System;
using System.Collections.Generic;
using System.Text;


public class Sorter
{
    public static void Sort<T>(CustomList<T> list)
        where T:IComparable<T>
    {
        list.Sort();
    }
}

