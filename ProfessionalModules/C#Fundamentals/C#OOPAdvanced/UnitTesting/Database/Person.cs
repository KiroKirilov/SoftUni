using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string username;
    private int id;

    public string Username => this.username;

    public int Id => this.id;

    public Person(int id,string username)
    {
        this.id = id;
        this.username = username;
    }
}

