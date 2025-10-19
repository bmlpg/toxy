using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Toxy.Test
{
    [TestFixture]
    public class OOXMLParserTest
    {
        [Test]
        public void TestPptx()
        {
            string path = Path.GetFullPath(TestDataSample.GetOOXMLPath("SampleShow.pptx"));
            byte[] fileContent = File.ReadAllBytes(path);
            ParserContext context = new ParserContext("SampleShow.pptx", fileContent);
            IMetadataParser parser = (IMetadataParser)ParserFactory.CreateMetadata(context);
            ToxyMetadata x = parser.Parse();
            Assert.AreEqual(8, x.Count);
            Assert.AreEqual("SlideShow Sample", x.Get("Title").Value);
            Assert.AreEqual("Microsoft Office PowerPoint", x.Get("Application").Value);
        }

        [Test]
        public void TestDocx()
        {
            string path = Path.GetFullPath(TestDataSample.GetOOXMLPath("MultipleCoreProperties.docx"));
            byte[] fileContent = File.ReadAllBytes(path);
            ParserContext context = new ParserContext("MultipleCoreProperties.docx", fileContent);
            IMetadataParser parser = (IMetadataParser)ParserFactory.CreateMetadata(context);
            ToxyMetadata x = parser.Parse();
            Assert.AreEqual(12, x.Count);
            Assert.AreEqual("Format", x.Get("Title").Value);
            Assert.AreEqual("Microsoft Macintosh Word", x.Get("Application").Value);
        }

        [Test]
        public void TestXlsx()
        {
            string path = Path.GetFullPath(TestDataSample.GetOOXMLPath("sample.xlsx"));
            byte[] fileContent = File.ReadAllBytes(path);
            ParserContext context = new ParserContext("sample.xlsx", fileContent);
            IMetadataParser parser = (IMetadataParser)ParserFactory.CreateMetadata(context);
            ToxyMetadata x = parser.Parse();
            Assert.AreEqual(4, x.Count);
            Assert.AreEqual("Microsoft Excel", x.Get("Application").Value);
            Assert.AreEqual("12.0000", x.Get("AppVersion").Value);
        }
    }
}
