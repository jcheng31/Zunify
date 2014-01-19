using System;
using System.Text;
using System.Xml.Linq;

namespace Zunify.Models
{
    public class Track
    {
        public string Title { get; set; }
        public string AlbumTitle { get; set; }
        public string Artist { get; set; }
        public string AlbumArtist { get; set; }
        public int Duration { get; set; }
        public string Path { get; set; }

        public static Track FromXElementFactory(XElement element)
        {
            if (element == null)
            {
                throw new ArgumentException("Received Null in factory method.");
            }

            Track t = new Track
            {
                Title = (string) element.Attribute("trackTitle"),
                AlbumTitle =  (string) element.Attribute("albumTitle"),
                Artist = (string) element.Attribute("trackArtist"),
                AlbumArtist = (string) element.Attribute("albumArtist"),
                Duration = (int) element.Attribute("duration"),
                Path = (string) element.Attribute("src")
            };

            return t;
        }


        public string ToFormattedString(string format)
        {
            if (String.IsNullOrWhiteSpace(format))
            {
                return String.Empty;
            }

            StringBuilder formatBuilder = new StringBuilder();

            string[] formatTokens = format.Split(' ');
            foreach (string token in formatTokens)
            {
                switch (token)
                {
                    case "$Title":
                        formatBuilder.Append(Title);
                        break;
                    case "$Artist":
                        formatBuilder.Append(Artist);
                        break;
                    case "$AlbumTitle":
                        formatBuilder.Append(AlbumTitle);
                        break;
                    case "$AlbumArtist":
                        formatBuilder.Append(AlbumArtist);
                        break;
                    default:
                        formatBuilder.Append(token);
                        break;
                }

                formatBuilder.Append(' ');
            }

            return formatBuilder.ToString().Trim();
        }
    }
}
