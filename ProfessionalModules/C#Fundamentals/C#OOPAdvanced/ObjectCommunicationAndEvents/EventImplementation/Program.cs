using EventImplementation;
using System;


public class Program
{
    static void Main(string[] args)
    {
        var dispatcher = new Dispatcher();
        var handler = new Handler();

        dispatcher.NameChange += handler.OnDispatcherNameChange;

        var name = "";

        while ((name=Console.ReadLine())!="End")
        {
            dispatcher.Name = name;
        }
    }
}

