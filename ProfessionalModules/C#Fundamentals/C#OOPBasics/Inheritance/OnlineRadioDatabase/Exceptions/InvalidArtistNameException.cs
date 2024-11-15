﻿using System;
using System.Collections.Generic;
using System.Text;


public class InvalidArtistNameException:InvalidSongException
{
    private new const string Message = "Artist name should be between 3 and 20 symbols.";

    public InvalidArtistNameException() : base(Message)
    {
    }

    public InvalidArtistNameException(string message) : base(message)
    {
    }
}

