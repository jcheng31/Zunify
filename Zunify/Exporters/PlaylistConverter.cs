using System;
using System.IO;
using Zunify.Models;

namespace Zunify.Exporters
{
    public class PlaylistConverter
    {
        public static void ToTextFile(ZunePlaylist playlist, String filePath, String format)
        {
            using (FileStream s = File.Create(filePath))
            using (StreamWriter writer = new StreamWriter(s))
            {
                writer.Write(playlist.ToListingWithFormat(format));
            }
        }
    }
}
