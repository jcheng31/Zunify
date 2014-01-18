using System;
using Zunify.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZunifyTests
{
    [TestClass]
    public class TrackTests
    {
        private const String SampleTrackXml =
            @"<media src=""D:\Users\Jerome\My Music\Florence + the Machine\Ceremonials (Deluxe Edition)\07 No Light, No Light.mp3"" serviceId=""{6FA7FA06-0100-11DB-89CA-0019B92A3933}"" albumTitle=""Ceremonials (Deluxe Edition)"" albumArtist=""Florence + the Machine"" trackTitle=""No Light, No Light"" trackArtist=""Florence + the Machine"" duration=""274837"" />";

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Empty String successfully created a Track.")]
        public void EmptyStringThrowsException()
        {
            Track.FromXmlStringFactory(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException),
            "Null successfully created a Track.")]
        public void NullThrowsException()
        {
            Track.FromXmlStringFactory(null);
        }

        [TestMethod]
        public void XmlStringCreatesTrack()
        {
            Assert.IsNotNull(Track.FromXmlStringFactory(SampleTrackXml), "Proper XML failed to create a Track.");
        }

        [TestMethod]
        public void TitleProperlySet()
        {
            Track t = Track.FromXmlStringFactory(SampleTrackXml);
            Assert.AreEqual("No Light, No Light", t.Title);
        }
    }
}
