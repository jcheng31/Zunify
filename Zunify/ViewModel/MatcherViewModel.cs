using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Zunify.Models;

namespace Zunify.ViewModel
{
    public class MatcherViewModel : ViewModelBase
    {
        public const string PlaylistPropertyName = "Playlist";
        public const string MatchesPropertyName = "Matches";

        private ZunePlaylist _playlist;
        private List<SongMatch> _matches;

        public ZunePlaylist Playlist
        {
            get
            {
                return _playlist;
            }

            set
            {
                if (_playlist == value)
                {
                    return;
                }

                RaisePropertyChanging(PlaylistPropertyName);
                _playlist = value;
                RaisePropertyChanged(PlaylistPropertyName);
            }
        }

        public List<SongMatch> Matches
        {
            get
            {
                return _matches;
            }

            set
            {
                if (_matches == value)
                {
                    return;
                }

                RaisePropertyChanging(MatchesPropertyName);
                _matches = value;
                RaisePropertyChanged(MatchesPropertyName);
            }
        }
    }
}
