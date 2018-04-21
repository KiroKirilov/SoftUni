using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private IReader reader;
    private IWriter writer;
    private ICommandInterpreter commandInterpreter;

    public Engine(IReader reader, IWriter writer,ICommandInterpreter commandInterpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        while (true)
        {
            List<string> args = this.reader.ReadLine().Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries).ToList();
            string commandName = args[0].ToLower();
            string result = this.commandInterpreter.ProcessCommand(args);
            this.writer.WriteLine(result);
            if (commandName=="shutdown")
            {
                break;
            }
        }
    }
}
