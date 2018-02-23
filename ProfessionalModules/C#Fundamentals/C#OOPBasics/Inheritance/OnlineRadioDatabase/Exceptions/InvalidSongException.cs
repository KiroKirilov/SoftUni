﻿using System;
using System.Collections.Generic;
using System.Text;


public class InvalidSongException : Exception
{
    
    private new const string Message = "Invalid song.";

    public InvalidSongException() : base(Message)
    {
    }

    public InvalidSongException(string message) : base(message)
    {
    }
}


