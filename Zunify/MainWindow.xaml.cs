using System;
using System.Collections.Generic;
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
                Filter = "Zune Playlist File (*.zpl)|*.zpl"
            };

            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                playlistPath = dialog.FileName;
                SelectedPlaylistLabel.Content = playlistPath;
            }
        }
    }
}
