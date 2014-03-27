using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Zunify.Models;

namespace Zunify.MusicLookup
{
    public class SpotifySearchService : IMusicLookupService
    {
        private const String SpotifyBaseAddress = "http://ws.spotify.com/search/1/";
        private const String SpotifyTrackSearch = "track.json?q=";

        public async Task<List<MusicTrack>> FindTracksAsync(string title, string artist, string album)
        {
            WebClient client = new WebClient();
            client.BaseAddress = SpotifyBaseAddress;
            String rawJson = await client.DownloadStringTaskAsync(SpotifyTrackSearch + title);

            JObject result = JObject.Parse(rawJson);

            List<MusicTrack> tracks = new List<MusicTrack>();
            foreach (JToken token in (JArray)result["tracks"])
            {
                var track = token as JObject;
                if (token != null)
                {
                    tracks.Add(SpotifyTrack.FromJsonFactory(track));
                }
            }

            return tracks;
        }
    }
}
