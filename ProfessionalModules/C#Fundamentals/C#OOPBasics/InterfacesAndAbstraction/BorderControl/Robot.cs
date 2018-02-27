using System;
using System.Collections.Generic;
using System.Text;


public class Robot : IIdentifiable
{
    public string Id { get; set; }

    public string Model { get; set; }

    public Robot(string model, string id)
    {
        this.Model = model;
        this.Id = id;
    }
}
