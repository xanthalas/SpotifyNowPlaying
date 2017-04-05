using System;
using SpotifyAPI.Local;
using SpotifyAPI.Local.Models;

namespace SpotifyNowPlaying
{
    class Program
    {

        private static SpotifyLocalAPI _spotify;
        static void Main(string[] args)
        {

            _spotify = new SpotifyLocalAPI();
            bool connected = connect();

            if (!connected)
            {
                return;
            }

            StatusResponse status = _spotify.GetStatus();
            if (status == null || status.Track == null || status.Track.TrackResource == null || status.Track.ArtistResource == null)
            {
                Console.WriteLine("Cannot retrieve information from Spotify client");
                return;
            }
            else
            { 
                var playing = (status.Playing) ? "" : " (paused)";

                Console.WriteLine($"Now playing: {status.Track.TrackResource.Name} by {status.Track.ArtistResource.Name}{playing}");
            }

        }

        private static bool connect()
        {
            if (!SpotifyLocalAPI.IsSpotifyRunning())
            {
                Console.WriteLine(@"Spotify isn't running!");
                return false;
            }
            if (!SpotifyLocalAPI.IsSpotifyWebHelperRunning())
            {
                Console.WriteLine(@"SpotifyWebHelper isn't running!");
                return false;
            }

            bool successful = _spotify.Connect();
            if (!successful)
            { 
                Console.WriteLine(@"Couldn't connect to the spotify client.");
            }

            return successful;
        }
    }
}
