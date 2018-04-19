using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    private const string TerminateMessage = "Enough! Pull back!";
    private IReader reader;
    private IWriter writer;

    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
        var input = this.reader.ReadLine();
        var gameController = new GameController(this.writer);

        while (!input.Equals(TerminateMessage))
        {
            try
            {
                gameController.GiveInputToGameController(input);
            }
            catch (ArgumentException arg)
            {
                writer.AppendLine(arg.Message);
            }
            input = this.reader.ReadLine();
        }

        gameController.RequestResult();
        writer.WriteAllLines();
    }
}

