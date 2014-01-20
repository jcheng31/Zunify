﻿using System;
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
            };

            return t;
        }
    }
}