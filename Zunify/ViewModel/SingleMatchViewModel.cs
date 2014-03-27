using System.Collections.Generic;
using System.Windows.Documents;
using GalaSoft.MvvmLight;
using Zunify.Models;

namespace Zunify.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class SingleMatchViewModel : ViewModelBase
    {
        private readonly SongMatch _match;

        public const string OriginalTrackPropertyName = "OriginalTrack";
        public const string CandidatesPropertyName = "Candidates";
        public const string MatchPropertyName = "Match";

        public ZuneTrack OriginalTrack
        {
            get
            {
                return _match.OriginalTrack;
            }

            set
            {
                if (_match.OriginalTrack == value)
                {
                    return;
                }

                RaisePropertyChanging(OriginalTrackPropertyName);
                _match.OriginalTrack = value;
                RaisePropertyChanged(OriginalTrackPropertyName);
            }
        }

        public List<SpotifyTrack> Candidates
        {
            get
            {
                return _match.Candidates;
            }

            set
            {
                if (_match.Candidates == value)
                {
                    return;
                }

                RaisePropertyChanging(CandidatesPropertyName);
                _match.Candidates = value;
                RaisePropertyChanged(CandidatesPropertyName);
            }
        }

        public SpotifyTrack Match
        {
            get
            {
                return _match.MatchedTrack;
            }

            set
            {
                RaisePropertyChanging(MatchPropertyName);
                _match.MatchedTrack = value;
                RaisePropertyChanged(MatchPropertyName);
            }
        }

        /// <summary>
        /// Initializes a new instance of the SingleMatchViewModel class.
        /// </summary>
        public SingleMatchViewModel(SongMatch match)
        {
            _match = match;
        }
    }
}