using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Zunify.Exporters;
using Zunify.Models;
using Zunify.Views;

namespace Zunify.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public const String OutputFormatStringPropertyName = "OutputFormatString";
        public const String PlaylistPathPropertyName = "PlaylistPath";
        public const String PlaylistPropertyName = "Playlist";
        public const String HasPlaylistPropertyName = "HasPlaylist";
        public const String SelectedSongPropertyName = "SelectedSong";

        private String _playlistPath;
        private String _outputFormatString;
        private ZunePlaylist _playlist;
        private ZuneTrack _selectedSong;

        public String PlaylistPath
        {
            get
            {
                return _playlistPath;
            }

            set
            {
                if (_playlistPath == value)
                {
                    return;
                }

                RaisePropertyChanging(PlaylistPathPropertyName);
                _playlistPath = value;
                RaisePropertyChanged(PlaylistPathPropertyName);
            }
        }

        public String OutputFormatString
        {
            get
            {
                return _outputFormatString;
            }

            set
            {
                if (_outputFormatString == value)
                {
                    return;
                }

                RaisePropertyChanging(OutputFormatStringPropertyName);
                _outputFormatString = value;
                RaisePropertyChanged(OutputFormatStringPropertyName);
            }
        }

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
                RaisePropertyChanging(HasPlaylistPropertyName);
                _playlist = value;
                RaisePropertyChanged(PlaylistPropertyName);
                RaisePropertyChanged(HasPlaylistPropertyName);
            }
        }

        public ZuneTrack SelectedSong
        {
            get
            {
                return _selectedSong;
            }

            set
            {
                if (_selectedSong == value)
                {
                    return;
                }

                RaisePropertyChanging(SelectedSongPropertyName);
                _selectedSong = value;
                RaisePropertyChanged(SelectedSongPropertyName);
            }
        }

        public bool HasPlaylist
        {
            get { return Playlist != null; }
        }

        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        private RelayCommand _loadPlaylistFileCommand;
        public RelayCommand LoadPlaylistFileCommand
        {
            get
            {
                return _loadPlaylistFileCommand
                    ?? (_loadPlaylistFileCommand = new RelayCommand(ExecuteLoadPlaylistFileCommand));
            }
        }

        private void ExecuteLoadPlaylistFileCommand()
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Title = "Select Playlist",
                Filter = "Zune Playlist File (*.zpl)|*.zpl"
            };

            bool? result = dialog.ShowDialog();
            if (result != true)
            {
                return;
            }

            PlaylistPath = dialog.FileName;
            Playlist = ZunePlaylist.FromFileFactory(PlaylistPath);
        }

        private RelayCommand _saveParsedTextCommand;
        public RelayCommand SaveParsedTextCommand
        {
            get
            {
                return  _saveParsedTextCommand
                    ?? ( _saveParsedTextCommand = new RelayCommand(ExecuteSaveParsedTextCommand));
            }
        }

        private void ExecuteSaveParsedTextCommand()
        {
            if (Playlist == null)
            {
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog
            {
                Title = "Save Output",
                Filter = "Text File (*.txt)|*.txt"
            };

            bool? result = dialog.ShowDialog();
            if (result != true)
            {
                return;
            }

            String outputPath = dialog.FileName;
            String formatString = OutputFormatString;

            PlaylistConverter.ToTextFile(Playlist, outputPath, formatString);
        }

        private RelayCommand _matchDoubleClicked;
        public RelayCommand MatchDoubleClicked
        {
            get { return _matchDoubleClicked ?? (_matchDoubleClicked = new RelayCommand(ExecuteLoadMatchCommand)); }
        }

        private async void ExecuteLoadMatchCommand()
        {
            SongMatch match = await SongMatch.FromZuneTrackFactory(SelectedSong);
            
            SingleMatch matchWindow = new SingleMatch {DataContext = new SingleMatchViewModel(match)};
            matchWindow.ShowDialog();
        }
    }
}