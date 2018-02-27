using System;
using System.Collections.Generic;
using System.Text;


public class Private : Soldier, IPrivate
{
    public double Salary { get; private set; }

    public Private(string id, string fName,string lName,double salary)
        :base(id,fName,lName)
    {
        Salary = salary;
    }

    public override string ToString()
    {
        return $"{base.ToString()} Salary: {this.Salary:f2}";
    }
}