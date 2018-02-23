using System;
using System.Collections.Generic;
using System.Text;


public class Song
{
    private string artistName;

    public string ArtistName
    {
        get { return artistName; }
        set
        {
            if (value.Length < 3 || value.Length > 20)
                throw new InvalidArtistNameException();
            artistName = value;
        }
    }

    private string songName;

    public string SongName
    {
        get { return songName; }
        set
        {
            if (value.Length < 3 || value.Length > 30)
                throw new InvalidSongNameException();
            songName = value;
        }
    }

    private int seconds;

    public int Seconds
    {
        get { return seconds; }
        set
        {
            if (value < 0 || value > 59)
                throw new InvalidSongSecondsException();
            seconds = value;
        }
    }

    private int minutes;

    public int Minutes
    {
        get { return minutes; }
        set
        {
            if (value < 0 || value > 14)
                throw new InvalidSongMinutesException();
            minutes = value;
        }
    }

    public Song(string artistName, string songName, int minutes, int seconds)
    {
        ArtistName = artistName;
        SongName = songName;
        Minutes = minutes;
        Seconds = seconds;
    }
}

