using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var numberOfSongs = int.Parse(Console.ReadLine());
        var songs = new List<Song>();

        for (int i = 0; i < numberOfSongs; i++)
        {
            var inputData = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                var artistName = inputData[0];
                var songName = inputData[1];
                var songLength = new int[2];
                try
                {
                    songLength = inputData[2]
                                   .Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(int.Parse)
                                   .ToArray();
                }
                catch (Exception ex)
                {
                    throw new InvalidSongLengthException();
                }
                var minutes = songLength[0];
                var seconds = songLength[1];

                var song = new Song(artistName, songName, minutes, seconds);
                songs.Add(song);
                Console.WriteLine("Song added.");
            }
            catch (InvalidSongException ise)
            {
                Console.WriteLine(ise.Message);
            }
        }

        Console.WriteLine($"Songs added: {songs.Count}");
        Console.WriteLine($"Playlist length: {GetPlaylistLength(songs)}");
    }

    private static string GetPlaylistLength(List<Song> songs)
    {
        var totalSeconds = songs.Select(s => s.Seconds).Sum();
        var secondsToMinutes = totalSeconds / 60;
        var seconds = totalSeconds % 60;

        var totalMinutes = songs.Select(s => s.Minutes).Sum() + secondsToMinutes;
        var minutesToHours = totalMinutes / 60;
        var minutes = totalMinutes % 60;

        var hours = minutesToHours;

        return $"{hours}h {minutes}m {seconds}s";
    }
}

