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
    public class AudioParserTest
    {
        [Test]
        public void TestParseMp3()
        {
            string path = Path.GetFullPath(TestDataSample.GetAudioPath("sample_both.mp3"));
            byte[] fileContent = File.ReadAllBytes(path);
            ParserContext context = new ParserContext("sample_both.mp3", fileContent);
            IMetadataParser parser = (IMetadataParser)ParserFactory.CreateMetadata(context);
            ToxyMetadata x = parser.Parse();
            ClassicAssert.AreEqual(15, x.Count);
        }
        [Test]
        public void TestParseMp3_Id3v1Only()
        {
            string path = Path.GetFullPath(TestDataSample.GetAudioPath("sample_v1_only.mp3"));
            byte[] fileContent = File.ReadAllBytes(path);
            ParserContext context = new ParserContext("sample_v1_only.mp3", fileContent);
            IMetadataParser parser = (IMetadataParser)ParserFactory.CreateMetadata(context);
            ToxyMetadata x = parser.Parse();
            ClassicAssert.AreEqual(11, x.Count);
        }
        [Test]
        public void TestParseMp3_Id3v2Only()
        {
            string path = Path.GetFullPath(TestDataSample.GetAudioPath("sample_v2_only.mp3"));
            byte[] fileContent = File.ReadAllBytes(path);
            ParserContext context = new ParserContext("sample_v2_only.mp3", fileContent);
            IMetadataParser parser = (IMetadataParser)ParserFactory.CreateMetadata(context);
            ToxyMetadata x = parser.Parse();
            ClassicAssert.AreEqual(15, x.Count);
        }
        [Test]
        public void TestParseApe()
        {
            string path = Path.GetFullPath(TestDataSample.GetAudioPath("sample.ape"));
            byte[] fileContent = File.ReadAllBytes(path);
            ParserContext context = new ParserContext("sample.ape", fileContent);
            IMetadataParser parser = (IMetadataParser)ParserFactory.CreateMetadata(context);
            ToxyMetadata x = parser.Parse();
            ClassicAssert.AreEqual(15, x.Count);

        }
        [Test]
        public void TestParseWma()
        {
            string path = Path.GetFullPath(TestDataSample.GetAudioPath("sample.wma"));
            byte[] fileContent = File.ReadAllBytes(path);
            ParserContext context = new ParserContext("sample.wma", fileContent);
            IMetadataParser parser = (IMetadataParser)ParserFactory.CreateMetadata(context);
            ToxyMetadata x = parser.Parse();
            ClassicAssert.AreEqual(17, x.Count);
        }
        [Test]
        public void TestParseFlac()
        {
            string path = Path.GetFullPath(TestDataSample.GetAudioPath("sample.flac"));
            byte[] fileContent = File.ReadAllBytes(path);
            ParserContext context = new ParserContext("sample.flac", fileContent);
            IMetadataParser parser = (IMetadataParser)ParserFactory.CreateMetadata(context);
            ToxyMetadata x = parser.Parse();
            ClassicAssert.AreEqual(16, x.Count);
        }
    }
}
