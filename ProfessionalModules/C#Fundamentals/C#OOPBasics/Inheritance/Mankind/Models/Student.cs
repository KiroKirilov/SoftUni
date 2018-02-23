using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Student : Human
{
    private string facultyNumber;

    public string FacultyNumber
    {
        get { return facultyNumber; }
        private set
        {
            if (IsFacNumValid(value))
                facultyNumber = value;
        }
    }

    private bool IsFacNumValid(string value)
    {
        if (value.Length < 5 || value.Length > 10 || !value.All(char.IsLetterOrDigit))
        {
            throw new ArgumentException("Invalid faculty number!");
        }

        return true;
    }

    public Student(string first,string last, string facNum)
        :base(first,last)
    {
        FacultyNumber = facNum;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"First Name: {FirstName}");
        sb.AppendLine($"Last Name: {LastName}");
        sb.AppendLine($"Faculty number: {FacultyNumber}");

        return sb.ToString();
    }
}

