using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

public class Category : ICategory
{
    private string name;
    private IList<IUser> users;
    private IList<ICategory> childCategories;
    private ICategory parent;

    public Category(string name)
    {
        this.Name = name;
        this.users = new List<IUser>();
        this.childCategories = new List<ICategory>();
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

    public ICategory Parent
    {
        get
        {
            return this.parent;
        }

        private set
        {
            this.parent = value;
        }
    }

    public IList<IUser> Users
    {
        get
        {
            return new ReadOnlyCollection<IUser>(this.users);
        }

        private set
        {
            this.users = value;
        }
    }

    public IList<ICategory> ChildCategories => new ReadOnlyCollection<ICategory>(this.childCategories);

    public void AddChild(ICategory child)
    {
        if (child==null)
        {
            throw new ArgumentNullException();
        }
        this.childCategories.Add(child);
        child.SetParent(this);
    }

    public void AddUser(IUser user)
    {
        if (user == null)
        {
            throw new ArgumentNullException();
        }
        this.users.Add(user);
        user.AddCategory(this);
    }

    public void MoveUsersToParent()
    {
        if (this.parent == null)
        {
            throw new InvalidOperationException();
        }

        foreach (var user in this.Users)
        {
            this.parent.AddUser(user);
        }
    }

    public void RemoveChild(string name)
    {
        var categoryToRemove = this.childCategories.FirstOrDefault(c => c.Name == name);
        this.childCategories?.Remove(categoryToRemove);
    }

    public void SetParent(ICategory category)
    {
        if (category == null)
        {
            throw new ArgumentNullException();
        }
        this.parent = category;
    }
}
