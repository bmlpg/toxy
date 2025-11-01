using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Toxy.Test
{
        [TestFixture]
    public class ZipParserTest
    {
            [Test]
            public void TestParseDirectoryFromZip()
            {
                byte[] fileContent = File.ReadAllBytes(TestDataSample.GetFilePath("toxy.zip", null));
                ParserContext context = new ParserContext("toxy.zip", fileContent);
                ITextParser parser = ParserFactory.CreateText(context);
                string list = parser.Parse();
                ClassicAssert.IsNotNull(list);
                string[] lines = list.Split(new string[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
                ClassicAssert.AreEqual(68, lines.Length);
            }
    }
}
