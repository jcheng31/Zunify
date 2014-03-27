using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Zunify.Models;

namespace Zunify.MusicLookup
{
    public interface IMusicLookupService
    {
        Task<List<MusicTrack>> FindTracksAsync(String title, String artist, String album);
    }
}
