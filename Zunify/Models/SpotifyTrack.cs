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
        public SpotifyTrack FromJsonFactory(JObject json)
        {
            throw new NotImplementedException();
        }
    }
}
