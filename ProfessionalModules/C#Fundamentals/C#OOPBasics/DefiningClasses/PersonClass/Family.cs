using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


public class Family
{
    private List<Person> members = new List<Person>();

    public void AddMember(Person member)
    {
        members.Add(member);
    }

    public Person GetOldest()
    {
        return members.OrderByDescending(p => p.Age).Take(1).ToArray()[0];
    }

    public void PrintOpinionPoll()
    {
        foreach (var person in members.Where(p => p.Age > 30).OrderBy(p=>p.Name))
        {
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}

