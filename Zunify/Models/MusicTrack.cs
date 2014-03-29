using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zunify.Models
{
    public abstract class MusicTrack
    {
        public String Title { get; set; }
        public String AlbumTitle { get; set; }
        public String Artist { get; set; }
        public String Identifier { get; set; }
        public int Duration { get; set; }
        public Boolean IsExplicit { get; set; }
    }
}
