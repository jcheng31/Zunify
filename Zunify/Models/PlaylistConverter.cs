using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zunify.Models
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
