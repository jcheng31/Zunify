using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zunify.Models;

namespace ZunifyTests
{
    [TestClass]
    public class PlaylistTests
    {
        private const string EmptyPlaylistPath = @"Sample Playlists\Empty.zpl";
        private const string SimplePlaylistPath = @"Sample Playlists\Simple.zpl";

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Null path didn't throw an exception.")]
        public void ExceptionOnNullPath()
        {
            ZunePlaylist.FromFileFactory(null);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException),
            "Empty path didn't throw an exception.")]
        public void ExceptionOnEmptyPath()
        {
            ZunePlaylist.FromFileFactory(String.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentException),
            "Invalid path didn't throw an exception.")]
        public void ExceptionOnInvalidPath()
        {
            ZunePlaylist.FromFileFactory("this is clearly invalid.");
        }

        [TestMethod]
        public void CreatesPlaylistFromValidPath()
        {
            Assert.IsNotNull(ZunePlaylist.FromFileFactory(SimplePlaylistPath), "Proper path didn't return playlist object.");
        }

        [TestMethod]
        public void CreatesEmptyPlaylistFromFile()
        {
            ZunePlaylist playlist = ZunePlaylist.FromFileFactory(EmptyPlaylistPath);

            Assert.IsNotNull(playlist, "Empty playlist was null.");
            Assert.AreEqual(0, playlist.Count, "Empty playlist didn't have 0 items.");
            Assert.AreEqual("Empty", playlist.Name, "Empty playlist didn't have the correct name.");
        }

        [TestMethod]
        public void CreatesSimplePlaylistFromFile()
        {
            ZunePlaylist playlist = ZunePlaylist.FromFileFactory(SimplePlaylistPath);

            Assert.IsNotNull(playlist, "Simple playlist was null.");
            Assert.AreEqual(1, playlist.Count, "Simple playlist had incorrect count.");
            Assert.AreEqual("Simple", playlist.Name, "Simple playlist didn't have the correct name.");
        }
    }
}
