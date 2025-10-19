using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Toxy.Test
{
    [TestFixture]
    public class OLE2MetadataParserTest
    {
        [Test]
        public void TestWord()
        {
            string path = Path.GetFullPath(TestDataSample.GetOLE2Path("TestEditTime.doc"));
            byte[] fileContent = File.ReadAllBytes(path);
            ParserContext context = new ParserContext("TestEditTime.doc", fileContent);
            IMetadataParser parser = ParserFactory.CreateMetadata(context);
            ToxyMetadata x = parser.Parse();
            Assert.AreEqual(18, x.Count);

            path = Path.GetFullPath(TestDataSample.GetOLE2Path("TestChineseProperties.doc"));
            fileContent = File.ReadAllBytes(path);
            context = new ParserContext("TestChineseProperties.doc", fileContent);
            parser = (IMetadataParser)ParserFactory.CreateMetadata(context);
            x = parser.Parse();
            Assert.AreEqual(18, x.Count);
            Assert.AreEqual("雅虎網站分類", x.Get("Comments").Value);
            Assert.AreEqual("參考資料", x.Get("Title").Value);
        }
        [Test]
        public void TestExcelFile()
        {
            string path = Path.GetFullPath(TestDataSample.GetExcelPath("comments.xls"));
            byte[] fileContent = File.ReadAllBytes(path);
            ParserContext context = new ParserContext("comments.xls", fileContent);
            IMetadataParser parser = (IMetadataParser)ParserFactory.CreateMetadata(context);
            ToxyMetadata x = parser.Parse();
            Assert.AreEqual(8, x.Count);
            Assert.AreEqual("Microsoft Excel", x.Get("ApplicationName").Value);
        }
        [Test]
        public void TestPowerPoint()
        {
            string path = Path.GetFullPath(TestDataSample.GetOLE2Path("Test_Humor-Generation.ppt"));
            byte[] fileContent = File.ReadAllBytes(path);
            ParserContext context = new ParserContext("Test_Humor-Generation.ppt", fileContent);
            IMetadataParser parser = (IMetadataParser)ParserFactory.CreateMetadata(context);
            ToxyMetadata x = parser.Parse();
            Assert.AreEqual(8, x.Count);
            Assert.AreEqual("Funny Factory", x.Get("Title").Value);
        }
        [Test]
        public void TestCorelDrawFile()
        {
            string path = Path.GetFullPath(TestDataSample.GetOLE2Path("TestCorel.shw"));
            byte[] fileContent = File.ReadAllBytes(path);
            ParserContext context = new ParserContext("TestCorel.shw", fileContent);
            IMetadataParser parser = (IMetadataParser)ParserFactory.CreateMetadata(context);
            ToxyMetadata x = parser.Parse();
            Assert.AreEqual(6, x.Count);
            Assert.AreEqual("thorsteb", x.Get("Author").Value);
            Assert.AreEqual("thorsteb", x.Get("LastAuthor").Value);
        }
        [Test]
        public void TestSolidWorksFile()
        {
            string path = Path.GetFullPath(TestDataSample.GetOLE2Path("TestSolidWorks.sldprt"));
            byte[] fileContent = File.ReadAllBytes(path);
            ParserContext context = new ParserContext("TestSolidWorks.sldprt", fileContent);
            IMetadataParser parser = (IMetadataParser)ParserFactory.CreateMetadata(context);
            ToxyMetadata x = parser.Parse();
            Assert.AreEqual(10, x.Count);
            Assert.AreEqual("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}", x.Get("ClassID").Value);
            Assert.AreEqual("scj", x.Get("LastAuthor").Value);
        }
    }
}
