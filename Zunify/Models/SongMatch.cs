using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zunify.Models
{
    public class SongMatch
    {
        public ZuneTrack OriginalTrack { get; private set; }
        public List<SpotifyTrack> Candidates { get; private set; }
        public SpotifyTrack MatchedTrack { get; set; }

        public SongMatch(ZuneTrack original, List<SpotifyTrack> candidates)
        {
            OriginalTrack = original;
            Candidates = candidates;
        }

    }
}
