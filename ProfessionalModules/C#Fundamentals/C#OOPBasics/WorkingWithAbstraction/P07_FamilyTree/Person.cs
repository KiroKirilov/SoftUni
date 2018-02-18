using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    public Person(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
        Parents = new List<Person>();
        Children = new List<Person>();
    }

    public Person(string date)
    {
        Date = date;
        Parents = new List<Person>();
        Children = new List<Person>();
    }

    public Person(string firstName, string lastName, string date)
        : this(firstName, lastName)
    {
        Date = date;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Date { get; set; }
    public List<Person> Parents { get; set; }
    public List<Person> Children { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName} {Date}";
    }
}

