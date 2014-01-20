using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Zunify.Models;

namespace ZunifyTests
{
    [TestClass]
    public class SpotifyTrackTests
    {
        private const String SampleTrackJson = @" {
            ""album"": {
            ""released"": ""2009"",
            ""href"": ""spotify:album:5RJ8TZt1tCycXGOsWENxpL"",
            ""name"": ""Alpinisms"",
            ""availability"": {
              ""territories"": ""AR BO BR CL CO DO EC GT HK HN MY NI PA PE PH PY SG SV TW US UY""
            }
          },
          ""name"": ""Iamundernodisguise"",
          ""popularity"": ""0.33"",
          ""external-ids"": [
            {
              ""type"": ""isrc"",
              ""id"": ""USVR90955001""
            }
          ],
          ""length"": 228.062,
          ""href"": ""spotify:track:2aYaiTHCFd3eZkP1fseOx9"",
          ""artists"": [
            {
              ""href"": ""spotify:artist:1mBdei7fcRpbUEYHgsQN9H"",
              ""name"": ""School Of Seven Bells""
            }
          ],
          ""track-number"": ""1""
        }";

        private SpotifyTrack testTrack;

        [TestInitialize]
        public void Setup()
        {
            JObject data = JObject.Parse(SampleTrackJson);
            testTrack = SpotifyTrack.FromJsonFactory(data);
        }

        [TestMethod]
        public void SpotifyTrackNameParse()
        {
            Assert.AreEqual("Iamundernodisguise", testTrack.Title);
        }

        [TestMethod]
        public void SpotifyTrackAlbumNameParse()
        {
            Assert.AreEqual("Alpinisms", testTrack.AlbumTitle);
        }

        [TestMethod]
        public void SpotifyTrackArtistNameParse()
        {
            Assert.AreEqual("School Of Seven Bells", testTrack.Artist);
        }

        [TestMethod]
        public void SpotifyTrackDurationParse()
        {
            Assert.AreEqual(228, testTrack.Duration);
        }

        [TestMethod]
        public void SpotifyTrackIdentifierParse()
        {
            Assert.AreEqual("spotify:track:2aYaiTHCFd3eZkP1fseOx9", testTrack.Identifier);
        }
    }
}
