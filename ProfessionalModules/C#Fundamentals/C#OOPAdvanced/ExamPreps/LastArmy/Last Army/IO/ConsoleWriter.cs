using System.Text;

public class ConsoleWriter : IWriter
{
    private StringBuilder stringBuilder;

    public ConsoleWriter()
    {
        this.stringBuilder = new StringBuilder();
    }

    public void AppendLine(string message)
    {
        this.stringBuilder.AppendLine(message);
    }

    public void WriteAllLines()
    {
        System.Console.WriteLine(this.stringBuilder.ToString().Trim());
    }
}
