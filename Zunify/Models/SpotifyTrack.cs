using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Zunify.Models
{
    public class SpotifyTrack : MusicTrack
    {
        public static SpotifyTrack FromJsonFactory(JObject json)
        {
            SpotifyTrack t = new SpotifyTrack
            {
                Title = (string) json["name"],
                AlbumTitle = (string)json["album"]["name"],
                Artist = (string) json["artists"].First()["name"],
                Duration = (int) json["length"],
                Identifier = (string) json["href"]
            };

            return t;
        }
    }
}
