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
        [ExpectedException(typeof (ArgumentException),
            "Null created a Track.")]
        public void NullThrowsException()
        {
            Track.FromXElementFactory(null);
        }
    }
}
