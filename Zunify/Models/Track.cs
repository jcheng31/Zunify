using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Zunify.Models
{
    public class Track
    {
        public static Track FromXElementFactory(XElement element)
        {
            throw new NotImplementedException();
        }

        [XmlAttribute("trackTitle")]
        public string Title { get; set; }
    }
}
