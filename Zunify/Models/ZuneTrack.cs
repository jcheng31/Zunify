using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Zunify.Models
{
    public class ZuneTrack : MusicTrack
    {
        public string AlbumArtist { get; set; }

        public static ZuneTrack FromXElementFactory(XElement element)
        {
            if (element == null)
            {
                throw new ArgumentException("Received Null in factory method.");
            }

            ZuneTrack t = new ZuneTrack
            {
                Title = (string)element.Attribute("trackTitle"),
                AlbumTitle = (string)element.Attribute("albumTitle"),
                Artist = (string)element.Attribute("trackArtist"),
                AlbumArtist = (string)element.Attribute("albumArtist"),
                Duration = (int)element.Attribute("duration"),
                Identifier = (string)element.Attribute("src"),
                IsExplicit = false // We have no way of determining this from playlist info.
            };

            return t;
        }


        public string ToFormattedString(string format)
        {
            if (String.IsNullOrWhiteSpace(format))
            {
                return String.Empty;
            }


            var formatPattern = new Regex(@"\$\w+?\b");

            MatchEvaluator replacer = match =>
            {
                switch (match.Value)
                {
                    case "$Title":
                        return Title;
                    case "$Artist":
                        return Artist;
                    case "$AlbumTitle":
                        return AlbumTitle;
                    case "$AlbumArtist":
                        return AlbumArtist;
                    default:
                        return match.Value;
                }
            };

            String formatted = formatPattern.Replace(format, replacer);
            return formatted;
        }
    }
}
