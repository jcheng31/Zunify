using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Zunify.Models;

namespace Zunify.MusicLookup
{
    class EchoNestSpotifySearchService : IMusicLookupService
    {
        private const String EchoNestSpotifySearchAddress = "http://developer.echonest.com/api/v4/song/search?api_key={0}&format=json&title={1}&artist={2}&bucket=id:spotify-WW";

        private string _apiKey;
        public EchoNestSpotifySearchService()
        {
            var resourceLoader = new ResourceManager("Resources.Keys", typeof(EchoNestSpotifySearchService).Assembly);
            _apiKey = resourceLoader.GetString("EchoNestApiKey");

        }
        public async Task<List<MusicTrack>> FindTracksAsync(string title, string artist, string album)
        {
            var requestAddress = String.Format(EchoNestSpotifySearchAddress, _apiKey, title, artist);

            WebClient client = new WebClient();
            var rawJson = await client.DownloadStringTaskAsync(requestAddress);

            var result = JObject.Parse(rawJson);

            List<MusicTrack> tracks = new List<MusicTrack>();

            return tracks;
        }
    }
}
