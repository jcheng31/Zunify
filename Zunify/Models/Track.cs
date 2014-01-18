﻿using System;
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
                Duration = (int) element.Attribute("duration")
            };

            return t;
        }
    }
}
