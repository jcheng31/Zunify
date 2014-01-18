using System;
using System.Xml.Linq;
using Zunify.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZunifyTests
{
    [TestClass]
    public class TrackTests
    {
        private const String SampleTrackXml =
            @"<media src=""D:\Users\Jerome\My Music\Florence + the Machine\Ceremonials (Deluxe Edition)\07 No Light, No Light.mp3"" serviceId=""{6FA7FA06-0100-11DB-89CA-0019B92A3933}"" albumTitle=""Ceremonials (Deluxe Edition)"" albumArtist=""Florence + the Machine"" trackTitle=""No Light, No Light"" trackArtist=""Florence + the Machine"" duration=""274837"" />";

        private XElement element;

        [TestInitialize]
        public void Setup()
        {
            element = XElement.Parse(SampleTrackXml);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException),
            "Null created a Track.")]
        public void NullThrowsException()
        {
            Track.FromXElementFactory(null);
        }

        [TestMethod]
        public void TrackTitleSetCorrectly()
        {
            Track t = Track.FromXElementFactory(element);

            Assert.AreEqual("No Light, No Light", t.Title, "Track title not set correctly.");
        }

        [TestMethod]
        public void TrackAlbumSetCorrectly()
        {
            Track t = Track.FromXElementFactory(element);

            Assert.AreEqual("Ceremonials (Deluxe Edition)", t.AlbumTitle, "Track album not set correctly.");
        }

        [TestMethod]
        public void TrackArtistSetCorrectly()
        {
            Track t = Track.FromXElementFactory(element);

            Assert.AreEqual("Florence + the Machine", t.Artist, "Track artist not set correctly.");
        }

        [TestMethod]
        public void TrackAlbumArtistSetCorrectly()
        {
            Track t = Track.FromXElementFactory(element);

            Assert.AreEqual("Florence + the Machine", t.AlbumArtist, "Track album artist not set correctly.");
        }

        [TestMethod]
        public void TrackDurationSetCorrectly()
        {
            Track t = Track.FromXElementFactory(element);

            Assert.AreEqual(274837, t.Duration, "Track duration not set correctly.");
        }

        [TestMethod]
        public void TrackPathSetCorrectly()
        {
            Track t = Track.FromXElementFactory(element);

            Assert.AreEqual(@"D:\Users\Jerome\My Music\Florence + the Machine\Ceremonials (Deluxe Edition)\07 No Light, No Light.mp3", t.Path, "Track path not set correctly.");
        }
    }
}
