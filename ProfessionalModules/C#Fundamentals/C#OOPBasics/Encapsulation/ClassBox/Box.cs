using System;
using System.Collections.Generic;
using System.Text;


public class Box
{
    private double width;

    public double Width
    {
        get { return width; }
        set
        {
            if (IsPropValid(value))
                width = value;
            else
                throw new ArgumentException($"Width cannot be zero or negative.");
        }
    }  

    private double height;

    public double Height
    {
        get { return height; }
        set
        {
            if (IsPropValid(value))
                height = value;
            else
                throw new ArgumentException($"Height cannot be zero or negative.");
        }
    }


    private double length;

    public double Length
    {
        get { return length; }
        set
        {
            if (IsPropValid(value))
                length = value;
            else
                throw new ArgumentException($"Length cannot be zero or negative.");
        }
    }

    public Box(double w, double h, double l)
    {
        Width = w;
        Height = h;
        Length = l;
    }

    public double GetSurfaceArea()
    {
        var surfaceArea= 2*length*height + 2*width*height + 2*length*width;
        return surfaceArea;
    }

    public double GetLateralSurfaceArea()
    {
        var lateralSurfaceArea = 2 * length * height + 2 * width * height;
        return lateralSurfaceArea;
    }

    public double GetVolume()
    {
        var volume = width * height * length;
        return volume;
    }

    private bool IsPropValid(double propVal)
    {
        if (propVal > 0)
        {
            return true;
        }
        return false;
    }
}

