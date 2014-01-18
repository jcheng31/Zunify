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
            if (element == null)
            {
                throw new ArgumentException("Received Null in factory method.");
            }

            return null;
        }

        [XmlAttribute("trackTitle")]
        public string Title { get; set; }
    }
}
