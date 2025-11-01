﻿using NUnit.Framework;
using NUnit.Framework.Legacy;
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
            ClassicAssert.AreEqual(8, x.Count);
            ClassicAssert.AreEqual("SlideShow Sample", x.Get("Title").Value);
            ClassicAssert.AreEqual("Microsoft Office PowerPoint", x.Get("Application").Value);
        }

        [Test]
        public void TestDocx()
        {
            string path = Path.GetFullPath(TestDataSample.GetOOXMLPath("MultipleCoreProperties.docx"));
            byte[] fileContent = File.ReadAllBytes(path);
            ParserContext context = new ParserContext("MultipleCoreProperties.docx", fileContent);
            IMetadataParser parser = (IMetadataParser)ParserFactory.CreateMetadata(context);
            ToxyMetadata x = parser.Parse();
            ClassicAssert.AreEqual(12, x.Count);
            ClassicAssert.AreEqual("Format", x.Get("Title").Value);
            ClassicAssert.AreEqual("Microsoft Macintosh Word", x.Get("Application").Value);
        }

        [Test]
        public void TestXlsx()
        {
            string path = Path.GetFullPath(TestDataSample.GetOOXMLPath("sample.xlsx"));
            byte[] fileContent = File.ReadAllBytes(path);
            ParserContext context = new ParserContext("sample.xlsx", fileContent);
            IMetadataParser parser = (IMetadataParser)ParserFactory.CreateMetadata(context);
            ToxyMetadata x = parser.Parse();
            ClassicAssert.AreEqual(4, x.Count);
            ClassicAssert.AreEqual("Microsoft Excel", x.Get("Application").Value);
            ClassicAssert.AreEqual("12.0000", x.Get("AppVersion").Value);
        }
    }
}
