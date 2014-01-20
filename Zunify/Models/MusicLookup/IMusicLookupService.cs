﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zunify.Models.MusicLookup
{
    public interface IMusicLookupService
    {
        Task<List<MusicTrack>> FindTracksAsync(String title, String artist, String album);
    }
}
