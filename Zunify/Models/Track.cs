﻿using System;
using System.Xml.Linq;

namespace Zunify.Models
{
    public class Track
    {
        public static Track FromXElementFactory(XElement element)
        {
            if (element == null)
            {
                throw new ArgumentException("Received Null in factory method.");
            }

            Track t = new Track {Title = (string) element.Attribute("trackTitle")};

            return t;
        }

        public string Title { get; set; }
    }
}
