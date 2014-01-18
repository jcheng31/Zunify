using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Zunify.Models
{
    public class ZunePlaylist
    {
        public string Name { get; set; }
        public List<Track> Tracks { get; set; }
        public int Count { get { return Tracks.Count; } }

        public static ZunePlaylist FromFileFactory(String filePath)
        {
            if (String.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                throw new ArgumentException();
            }

            ZunePlaylist p = new ZunePlaylist();

            try
            {
                XDocument playlistXml = XDocument.Load(filePath);
                XElement mainDocument = playlistXml.Element("smil");
                XElement head = mainDocument.Element("head");
                
                p.Name = (string)head.Element("title");
            }
            catch (XmlException)
            {
                p.Name = Path.GetFileNameWithoutExtension(filePath);
            }

            return p;
        }
    }
}
