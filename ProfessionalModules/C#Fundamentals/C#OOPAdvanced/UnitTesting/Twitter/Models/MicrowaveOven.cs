using System;
using System.Collections.Generic;
using System.Text;

public class MicrowaveOven : IClient
{
    private IServer server;
    private IWriter writer;

    public MicrowaveOven(IWriter writer,IServer server)
    {
        this.writer = writer;
        this.server = server;
    }

    public void SendTweetToServer(string message)
    {
        this.server.SaveTweet(message);
    }

    public void WriteTweet(string message)
    {
        this.writer.WriteLine(message);
    }
}

