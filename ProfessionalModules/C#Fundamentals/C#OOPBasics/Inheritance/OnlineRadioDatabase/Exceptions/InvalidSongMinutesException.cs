﻿using System;
using System.Collections.Generic;
using System.Text;


public class InvalidSongMinutesException:InvalidSongLengthException
{
    private new const string Message = "Song minutes should be between 0 and 14.";

    public InvalidSongMinutesException() : base(Message)
    {
    }

    public InvalidSongMinutesException(string message) : base(message)
    {
    }
}

