using System;
using System.Collections.Generic;
using System.Text;


public class Rectangle
{
    public string ID;
    double width;
    double height;
    double x;
    double y;

    public Rectangle(string id, double w,double h, double x, double y)
    {
        ID = id;
        width = w;
        height = h;
        this.x = x;
        this.y = y;
    }

    public string IntersectsWith(Rectangle rectangle)
    {
        if ((rectangle.y >= this.y && rectangle.y - rectangle.height <= this.y && rectangle.x <= this.x && rectangle.x + rectangle.width >= this.x) ||
                (rectangle.y >= this.y && rectangle.y - rectangle.height <= this.y && rectangle.x >= this.x && rectangle.x <= this.x + this.width) ||
                (rectangle.y <= this.y && rectangle.y >= this.y - this.height && rectangle.x <= this.x && rectangle.x + rectangle.width >= this.x) ||
                (rectangle.y <= this.y && rectangle.y >= this.y - this.height && rectangle.x >= this.x && rectangle.x <= this.x + this.width))
        {
            return "true";
        }
        else
        {
            return "false";
        }
    }
}

