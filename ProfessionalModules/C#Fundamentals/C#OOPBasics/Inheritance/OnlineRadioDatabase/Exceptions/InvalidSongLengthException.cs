﻿using System;
using System.Collections.Generic;
using System.Text;


public class InvalidSongLengthException:InvalidSongException
{
    private new const string Message = "Invalid song length.";

    public InvalidSongLengthException() : base(Message)
    {
    }

    public InvalidSongLengthException(string message) : base(message)
    {
    }
}

