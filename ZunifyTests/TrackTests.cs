using System;
using Zunify.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ZunifyTests
{
    [TestClass]
    public class TrackTests
    {
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
    }
}
