using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            using (FileStream s = File.Create(outputPath))
            using (StreamWriter writer = new StreamWriter(s))
            {
                writer.Write(playlist.ToListingWithFormat(formatString));
            }

        }
    }
}
