using System;
using System.Windows;
using Microsoft.Win32;
using Zunify.Models;

namespace Zunify
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private String playlistPath;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChoosePlaylistClick(object sender, RoutedEventArgs e)
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

            playlistPath = dialog.FileName;
            SelectedPlaylistLabel.Content = playlistPath;
        }

        private void ParseAndSaveClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(playlistPath))
            {
                return;
            }

            ZunePlaylist playlist = ZunePlaylist.FromFileFactory(playlistPath);

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
            String formatString = OutputFormatString.Text;
            
            PlaylistConverter.ToTextFile(playlist, outputPath, formatString);
        }
    }
}
