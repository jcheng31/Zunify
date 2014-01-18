using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zunify.Models;

namespace ZunifyTests
{
    [TestClass]
    public class PlaylistTests
    {
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

    }
}
