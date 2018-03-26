using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Clinic
{
    public string Name { get; set; }

    public Room[] Rooms { get; set; }

    public Clinic(string name, int amountOfRooms)
    {
        if (amountOfRooms%2==0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        this.Name = name;
        this.Rooms = new Room[amountOfRooms];

        for (int i = 0; i < amountOfRooms; i++)
        {
            this.Rooms[i] = new Room();
        }
    }

    public bool Add(Pet pet)
    {
        if (!this.HasEmptyRooms())
        {
            return false;
        }

        int centerId = ((int)Math.Ceiling(this.Rooms.Length / (double)2)) - 1;
        int i = centerId;
        int steps = 1;

        for (int j = 0; j < this.Rooms.Length; j++)
        {
            if (this.Rooms[i].Pet is null)
            {
                this.Rooms[i].Pet = pet;
                return true;
            }

            if (i >= centerId)
            {
                i = centerId - steps;
            }
            else
            {
                i = centerId + steps;
                steps++;
            }
        }
        return false;
    }

    public bool Release()
    {
        int centerId = ((int)Math.Ceiling(this.Rooms.Length / (double)2)) - 1;

        for (int i = centerId; i < this.Rooms.Length; i++)
        {
            if (this.Rooms[i].Pet != null)
            {
                this.Rooms[i].Pet = null;
                return true;
            }
        }

        for (int i = 0; i < centerId; i++)
        {
            if (this.Rooms[i].Pet != null)
            {
                this.Rooms[i].Pet = null;
                return true;
            }
        }
        return false;
    }

    public bool HasEmptyRooms()
    {
        return this.Rooms.Any(r => r.Pet is null);
    }

    public void Print()
    {
        Console.WriteLine(string.Join(Environment.NewLine,this.Rooms.ToList()));
    }

    public void Print(int roomId)
    {
        Console.WriteLine(this.Rooms[roomId - 1].ToString());
    }
}

