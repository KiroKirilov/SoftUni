using System;
using System.Collections.Generic;
using System.Text;


public class Animal
{
    private string name;

    protected string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            name = value;
        }
    }

    private int age;

    protected int Age
    {
        get { return age; }
        set
        {
            if (string.IsNullOrWhiteSpace(value.ToString()) ||
              value < 0)
            {
                throw new ArgumentException("Invalid input!");
            }
            age = value;
        }
    }

    private string gender;

    protected string Gender
    {
        get { return gender; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid input!");
            }
            gender = value;
        }
    }

    public Animal(string name, int age, string gender)
    {
        Name = name;
        Age = age;
        Gender = gender;
    }

    public virtual string ProduceSound()
    {
        return "You should be overriding this.";
    }

    public override string ToString()
    {
        var sb = new StringBuilder()
            .AppendLine(GetType().Name)
            .AppendLine($"{Name} {Age} {Gender}")
            .Append(ProduceSound());

        return sb.ToString();
    }
}
  
