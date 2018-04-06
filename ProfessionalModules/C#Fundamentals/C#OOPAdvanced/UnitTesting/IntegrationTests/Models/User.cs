using System;
using System.Collections.Generic;
using System.Text;

public class User : IUser
{
    private string name;
    private HashSet<ICategory> categories;

    public User(string name)
    {
        this.Name = name;
        this.categories = new HashSet<ICategory>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }

        private set
        {
            if (string.IsNullOrWhiteSpace(value) || value == string.Empty)
            {
                throw new ArgumentException("Name can't be empty");
            }

            this.name = value;
        }
    }

public IReadOnlyCollection<ICategory> Categories => this.categories as IReadOnlyCollection<ICategory>;

    public void AddCategory(ICategory category)
    {
        if (category==null)
        {
            throw new ArgumentNullException();
        }
        this.categories.Add(category);
    }

    public void RemoveCategory(ICategory category)
    {
        if (category == null)
        {
            throw new ArgumentNullException();
        }

        if (!this.categories.Contains(category))
        {
            throw new ArgumentException();
        }
        this.categories.Remove(category);
    }
}