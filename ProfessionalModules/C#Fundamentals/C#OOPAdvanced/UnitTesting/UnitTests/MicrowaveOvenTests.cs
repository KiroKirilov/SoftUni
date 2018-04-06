using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class MicrowaveOvenTests
{
    [Test]
    public void SendTweetToServerShouldSendTheMessageToItsServer()
    {
        var writer = new Mock<IWriter>();
        var tweetRepo = new Mock<IServer>();
        tweetRepo.Setup(tr => tr.SaveTweet(It.IsAny<string>()));
        var microwaveOven = new MicrowaveOven(writer.Object, tweetRepo.Object);
        microwaveOven.SendTweetToServer("tui tuk");
        tweetRepo.Verify(tr => tr.SaveTweet(It.Is<string>(s => s == "tui tuk")),
            Times.Once);
    }

    [Test]
    public void WriteTweetShouldCallItsWriterWithTheTweetsMessage()
    {
        var writer = new Mock<IWriter>();
        writer.Setup(w => w.WriteLine(It.IsAny<string>()));
        var tweetRepo = new Mock<IServer>();
        var microwaveOven = new MicrowaveOven(writer.Object, tweetRepo.Object);
        microwaveOven.WriteTweet("tui tuk");
        writer.Verify(w => w.WriteLine(It.Is<string>(s => s == "tui tuk")));
    }
}