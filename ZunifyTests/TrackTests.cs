﻿using System;
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

        private const string Artist = "Florence + the Machine";
        private const string TrackTitle = "No Light, No Light";
        private const string AlbumTitle = "Ceremonials (Deluxe Edition)";

        private XElement element;
        private ZuneTrack testTrack;

        [TestInitialize]
        public void Setup()
        {
            element = XElement.Parse(SampleTrackXml);
            testTrack = ZuneTrack.FromXElementFactory(element);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException),
            "Null created a Track.")]
        public void NullThrowsException()
        {
            ZuneTrack.FromXElementFactory(null);
        }

        [TestMethod]
        public void TrackTitleSetCorrectly()
        {
            Assert.AreEqual(TrackTitle, testTrack.Title, "Track title not set correctly.");
        }

        [TestMethod]
        public void TrackAlbumSetCorrectly()
        {
            Assert.AreEqual(AlbumTitle, testTrack.AlbumTitle, "Track album not set correctly.");
        }

        [TestMethod]
        public void TrackArtistSetCorrectly()
        {
            Assert.AreEqual(Artist, testTrack.Artist, "Track artist not set correctly.");
        }

        [TestMethod]
        public void TrackAlbumArtistSetCorrectly()
        {
            Assert.AreEqual(Artist, testTrack.AlbumArtist, "Track album artist not set correctly.");
        }

        [TestMethod]
        public void TrackDurationSetCorrectly()
        {
            Assert.AreEqual(274837, testTrack.Duration, "Track duration not set correctly.");
        }

        [TestMethod]
        public void TrackPathSetCorrectly()
        {
            Assert.AreEqual(@"D:\Users\Jerome\My Music\Florence + the Machine\Ceremonials (Deluxe Edition)\07 No Light, No Light.mp3", testTrack.Identifier, "Track path not set correctly.");
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
            Assert.AreEqual(Artist, testTrack.ToFormattedString("$Artist"));
        }

        [TestMethod]
        public void TrackTitleFormatString()
        {
            Assert.AreEqual(TrackTitle, testTrack.ToFormattedString("$Title"));
        }

        [TestMethod]
        public void TrackAlbumTitleFormatString()
        {
            Assert.AreEqual(AlbumTitle, testTrack.ToFormattedString("$AlbumTitle"));
        }

        [TestMethod]
        public void TrackAlbumArtistFormatString()
        {
            Assert.AreEqual(Artist, testTrack.ToFormattedString("$AlbumArtist"));
        }

        [TestMethod]
        public void TrackTitleArtistFormatString()
        {
            Assert.AreEqual(TrackTitle + " " + Artist, testTrack.ToFormattedString("$Title $Artist"));
        }

        [TestMethod]
        public void TrackFormatStringWithOtherCharacters()
        {
            Assert.AreEqual(TrackTitle + " - " + AlbumTitle + " ; " + Artist, testTrack.ToFormattedString("$Title - $AlbumTitle ; $Artist"));
        }

        [TestMethod]
        public void TrackFormatStringWithoutSpaces()
        {
            Assert.AreEqual(TrackTitle + ", " + AlbumTitle, testTrack.ToFormattedString("$Title, $AlbumTitle"));
        }
    }
}
