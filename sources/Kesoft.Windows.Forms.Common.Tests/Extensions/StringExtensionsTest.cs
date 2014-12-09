using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Kesoft.Common.Tests
{
    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    public class StringExtensionsTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void IsEmail()
        {
            Assert.AreEqual(null, null);
            var wrongEmails = new List<string>
                              {
                                  "", " ", "1", "a", "@",
                                  "@a", "a@", "@1", "1@", "@.", ".@",
                              };
            var rightEmails = new List<string>
                              {
                                  "a@b.c", "a.b@c.e.f"
                              };
            wrongEmails.ForEach(a => Assert.AreEqual(false, a.IsEmail()));
            rightEmails.ForEach(a => Assert.AreEqual(true, a.IsEmail()));
        }

        [Test]
        public void IsIpV4()
        {
            Assert.AreEqual(null, null);
            var wrongIps = new List<string>
                           {
                               "", " ", "1", "a", "z",
                               "1", "1.1", "1.1.1", "1.1.1.",
                               "256.0.0.0", "0.256.0.0", "0.0.256.0", "0.0.0.256"
                           };
            var rightIps = new List<string>
                           {
                               "0.0.0.0", "127.0.0.1", "255.255.255.255"
                           };
            wrongIps.ForEach(a => Assert.AreEqual(false, a.IsIpv4()));
            rightIps.ForEach(a => Assert.AreEqual(true, a.IsIpv4()));
        }
    }
}