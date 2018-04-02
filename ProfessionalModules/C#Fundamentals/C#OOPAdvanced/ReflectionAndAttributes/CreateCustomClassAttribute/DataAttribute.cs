using System;
using System.Collections.Generic;
using System.Text;

[AttributeUsage(AttributeTargets.Class)]
public class DataAttribute : Attribute
{
    public DataAttribute(string author, int revision, string description, params string[] reviewers)
    {
        this.Author = author;
        this.Revision = revision;
        this.Description = description;
        this.Reviewers = new List<string>(reviewers);
    }

    public string Author { get; private set; }

    public int Revision { get; private set; }

    public string Description { get; private set; }

    public List<string> Reviewers { get; private set; }
}

