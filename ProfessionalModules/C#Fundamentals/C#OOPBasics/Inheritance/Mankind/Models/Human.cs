using System;
using System.Collections.Generic;
using System.Text;


public class Human
{
    private string firstName;

    protected string FirstName
    {
        get { return firstName; }
        set
        {
            if (!Char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: firstName");
            }

            if (value.Length < 4)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }
            firstName = value;
        }
    }

    private string lastName;

    protected string LastName
    {
        get { return lastName; }
        set
        {
            if (!Char.IsUpper(value[0]))
            {
                throw new ArgumentException("Expected upper case letter! Argument: lastName");
            }

            if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName");
            }
            lastName = value;
        }
    }

    protected Human(string first, string last)
    {
        FirstName = first;
        LastName = last;
    }
}

