using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;


public class Lake<T>:IEnumerable<T>
{
    private List<T> numbers;

    public Lake(List<T> numbers)
    {
        this.numbers = numbers;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.numbers.Count; i+=2)
        {
            yield return numbers[i];
        }

        int secondStart = GetSecondStart();

        for (int i = secondStart; i >=0; i-=2)
        {
            yield return this.numbers[i];
        }
    }

    private int GetSecondStart()
    {
        if (this.numbers.Count%2==0)
        {
            return this.numbers.Count - 1;
        }

        return this.numbers.Count - 2;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

