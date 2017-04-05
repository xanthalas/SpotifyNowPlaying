# SpotifyNowPlaying
Get the currently playing track name from Spotify client and write to the command line


This is a very simple command line client which will connect to the local Spotify client, retrieve the name and artist of the currently playing track and write it to the console.

It was written to be used with [Limebar](https://github.com/xanthalas/Limebar).

### Note

When Spotify is running in offline mode then the Spotify API call will not be able to retrieve information. Switching Spotify to online, running SpotifyNowPlaying once, and then switching it back to offline seems to allow subsequent connections to work fine.

It will also be unable to retrieve track data if Spotify is configured to use a Proxy server which it can't access.