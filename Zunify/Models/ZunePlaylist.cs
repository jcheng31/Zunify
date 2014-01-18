using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zunify.Models
{
    public class ZunePlaylist
    {
        public static ZunePlaylist FromFileFactory(String filePath)
        {
            if (String.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                throw new ArgumentException();
            }

            return null;
        }
    }
}
