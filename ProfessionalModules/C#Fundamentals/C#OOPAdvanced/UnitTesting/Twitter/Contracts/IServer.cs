using System;
using System.Collections.Generic;
using System.Text;

public interface IServer
{
    IReadOnlyCollection<ITweet> Tweets { get; }

    void SaveTweet(string tweetMessage);
}
