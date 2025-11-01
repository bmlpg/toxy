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
    public class Powerpoint2007TextParserTest
    {
        [Test]
        public void ReadTextBasicTest()
        {
            string path = Path.GetFullPath(TestDataSample.GetPowerpointPath("testPPT.pptx"));
            byte[] fileContent = File.ReadAllBytes(path);
            ParserContext context = new ParserContext("testPPT.pptx", fileContent);
            ITextParser parser = ParserFactory.CreateText(context);
            string result = parser.Parse();
            ClassicAssert.IsNotNull(result);
            ClassicAssert.IsNotEmpty(result);
            string[] texts = result.Split(new string[]{"\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            ClassicAssert.AreEqual(14, texts.Length);
            ClassicAssert.AreEqual("Attachment Test", texts[0]);
            ClassicAssert.AreEqual("Rajiv", texts[1]);
            ClassicAssert.AreEqual("Different words to test against", texts[4]);
            ClassicAssert.AreEqual("Hello", texts[7]);
        }
    }
}