using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zunify.Models
{
    public class ZunePlaylist
    {
        public static void FromFileFactory(String filePath)
        {
            if (String.IsNullOrEmpty(filePath))
            {
                throw new ArgumentException();
            }
        }
    }
}
