using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Zunify.Models.MusicLookup;

namespace Zunify.Models
{
    public class SongMatch : ObservableObject
    {
        public const string OriginalTrackPropertyName = "OriginalTrack";
        public const string CandidatesPropertyName = "Candidates";
        public const string MatchedTrackPropertyName = "MatchedTrack";

        private ZuneTrack _originalTrack;
        private List<SpotifyTrack> _candidates;
        private SpotifyTrack _matchedTrack;

        public ZuneTrack OriginalTrack
        {
            get
            {
                return _originalTrack;
            }

            set
            {
                if (_originalTrack == value)
                {
                    return;
                }

                RaisePropertyChanging(OriginalTrackPropertyName);
                _originalTrack = value;
                RaisePropertyChanged(OriginalTrackPropertyName);
            }
        }

        public List<SpotifyTrack> Candidates
        {
            get
            {
                return _candidates;
            }

            set
            {
                if (_candidates == value)
                {
                    return;
                }

                RaisePropertyChanging(CandidatesPropertyName);
                _candidates = value;
                RaisePropertyChanged(CandidatesPropertyName);
            }
        }

        public SpotifyTrack MatchedTrack
        {
            get
            {
                return _matchedTrack;
            }

            set
            {
                if (_matchedTrack == value)
                {
                    return;
                }

                RaisePropertyChanging(MatchedTrackPropertyName);
                _matchedTrack = value;
                RaisePropertyChanged(MatchedTrackPropertyName);
            }
        }

        public SongMatch(ZuneTrack original, List<SpotifyTrack> candidates)
        {
            OriginalTrack = original;
            Candidates = candidates;

            if (candidates.Count > 0)
            {
                MatchedTrack = candidates[0];
            }
        }

        public static async Task<SongMatch> FromZuneTrackFactory(ZuneTrack originalTrack)
        {
            IMusicLookupService lookupService = new SpotifySearchService();
            List<MusicTrack> tracks = await lookupService.FindTracksAsync(originalTrack.Title, originalTrack.Artist, originalTrack.AlbumTitle);

            return new SongMatch(originalTrack, tracks.Cast<SpotifyTrack>().ToList());
        }

    }
}
