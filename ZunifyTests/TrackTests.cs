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
        private Track testTrack;

        [TestInitialize]
        public void Setup()
        {
            element = XElement.Parse(SampleTrackXml);
            testTrack = Track.FromXElementFactory(element);
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
            Assert.AreEqual("No Light, No Light", testTrack.Title, "Track title not set correctly.");
        }

        [TestMethod]
        public void TrackAlbumSetCorrectly()
        {
            Assert.AreEqual("Ceremonials (Deluxe Edition)", testTrack.AlbumTitle, "Track album not set correctly.");
        }

        [TestMethod]
        public void TrackArtistSetCorrectly()
        {
            Assert.AreEqual("Florence + the Machine", testTrack.Artist, "Track artist not set correctly.");
        }

        [TestMethod]
        public void TrackAlbumArtistSetCorrectly()
        {
            Assert.AreEqual("Florence + the Machine", testTrack.AlbumArtist, "Track album artist not set correctly.");
        }

        [TestMethod]
        public void TrackDurationSetCorrectly()
        {
            Assert.AreEqual(274837, testTrack.Duration, "Track duration not set correctly.");
        }

        [TestMethod]
        public void TrackPathSetCorrectly()
        {
            Assert.AreEqual(@"D:\Users\Jerome\My Music\Florence + the Machine\Ceremonials (Deluxe Edition)\07 No Light, No Light.mp3", testTrack.Path, "Track path not set correctly.");
        }

        [TestMethod]
        public void TrackEmptyFormatString()
        {
            Assert.AreEqual(String.Empty, testTrack.ToFormattedString(String.Empty));
        }

        [TestMethod]
        public void TrackNullFormatString()
        {
            Assert.AreEqual(String.Empty, testTrack.ToFormattedString(null));
        }

        [TestMethod]
        public void TrackArtistFormatString()
        {
            Assert.AreEqual("Florence + the Machine", testTrack.ToFormattedString("$Artist"));
        }

        [TestMethod]
        public void TrackTitleFormatString()
        {
            Assert.AreEqual("No Light, No Light", testTrack.ToFormattedString("$Title"));
        }
    }
}
