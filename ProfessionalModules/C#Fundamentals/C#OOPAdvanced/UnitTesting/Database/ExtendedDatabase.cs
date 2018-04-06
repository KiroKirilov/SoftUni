using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


public class ExtendedDatabase
{
    private List< Person> people;
    private int currentId;

    public ExtendedDatabase()
    {
        this.people = new List< Person>();
    }

    public int Count => this.people.Count;

    public IReadOnlyCollection<Person> People => this.people as IReadOnlyCollection<Person>;

    public void Add(Person person)
    {
        var personUsername = person.Username;

        if (people.Any(p=>p.Id==person.Id))
        {
            throw new InvalidOperationException();
        }

        if (people.Any(p => p.Username == person.Username))
        {
            throw new InvalidOperationException();
        }

        people.Add(person);
    }

    public void Remove()
    {
        if (people.Count==0)
        {
            throw new InvalidOperationException();
        }

        people.RemoveAt(people.Count - 1);
    }

    public Person FindById(int id)
    {
        if (id<0)
        {
            throw new ArgumentOutOfRangeException();
        }

        if (!people.Any(p=>p.Id==id))
        {
            throw new InvalidOperationException();
        }

        return people.First(p => p.Id == id);
    }

    public Person FindByUsername(string username)
    {
        if (username==null)
        {
            throw new ArgumentNullException();
        }

        if (!people.Any(p=>p.Username==username))
        {
            throw new InvalidOperationException();
        }

        return people.First(p => p.Username == username);
    }
}

