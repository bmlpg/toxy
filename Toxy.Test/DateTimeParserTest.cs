using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Toxy.Test
{
    [TestFixture]
    public class DateTimeParserTest
    {
        [Test]
        public void TestParseDatetimeWithTimezone()
        {
            ClassicAssert.AreEqual(new DateTime(2008, 10, 24, 20, 9, 6), DateTimeParser.Parse("24-oct-08 21:09:06 CEST"));
            ClassicAssert.AreEqual(new DateTime(2012, 4, 20, 9, 10, 0), DateTimeParser.Parse("2012-04-20 10:10:00+0200"));
            ClassicAssert.AreEqual(new DateTime(2014, 12, 12, 18, 13, 30), DateTimeParser.Parse("Fri, 12 Dec 2014 12:13:30 -0600 (CST)"));

        }

        [Test]
        public void TestParseDatetimeWithoutTimezone()
        {
            ClassicAssert.AreEqual(new DateTime(2014, 12, 12, 12, 13, 30), DateTimeParser.Parse("Fri, 12 Dec 2014 12:13:30"));
        }
    }
}
