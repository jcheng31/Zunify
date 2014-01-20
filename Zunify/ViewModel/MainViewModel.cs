using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Zunify.Models;

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

        private String _playlistPath;
        private String _outputFormatString;

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
            if (String.IsNullOrWhiteSpace(PlaylistPath))
            {
                return;
            }

            ZunePlaylist playlist = ZunePlaylist.FromFileFactory(PlaylistPath);

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

            PlaylistConverter.ToTextFile(playlist, outputPath, formatString);
        }
    }
}