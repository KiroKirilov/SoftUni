using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

public class TweetTests
{
    [Test]
    public void ReceiveMessageShouldInvokeItsClientToWriteTheMessage()
    {
        var client = new Mock<IClient>();
        client.Setup(c => c.WriteTweet(It.IsAny<string>()));
        var tweet = new Tweet(client.Object);
        tweet.ReceiveMessage("Test");
        client.Verify(c => c.WriteTweet(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public void ReceiveMessageShouldInvokeItsClientToSendTheMessageToTheServer()
    {
        var client = new Mock<IClient>();
        client.Setup(c => c.SendTweetToServer(It.IsAny<string>()));
        var tweet = new Tweet(client.Object);
        tweet.ReceiveMessage("Test");
        client.Verify(c => c.SendTweetToServer(It.IsAny<string>()), Times.Once);
    }
}