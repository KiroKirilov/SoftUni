using System;
using System.Collections.Generic;
using System.Text;

public class Server : IServer
{
    public IReadOnlyCollection<ITweet> Tweets => throw new NotImplementedException();

    public void SaveTweet(string tweetMessage)
    {
        throw new NotImplementedException();
    }
}