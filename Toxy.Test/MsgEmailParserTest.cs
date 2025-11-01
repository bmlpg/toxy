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
    public class MsgEmailParserTest
    {
        [Test]
        public void HtmlMsg_ReadTextTest()
        {
            string path = TestDataSample.GetEmailPath("Azure pricing and services updates.msg");
            byte[] fileContent = File.ReadAllBytes(path);
            ParserContext context = new ParserContext("Azure pricing and services updates.msg", fileContent);
            var parser = ParserFactory.CreateText(context);

            string result=parser.Parse();
            ClassicAssert.IsNotNull(result);
            ClassicAssert.IsNotEmpty(result);
            ClassicAssert.IsTrue(result.IndexOf("[From] Azure Team<AzureTeam@e-mail.microsoft.com>") >= 0);
            ClassicAssert.IsTrue(result.IndexOf("[To] tonyqux@hotmail.com")>0);
            ClassicAssert.IsTrue(result.IndexOf("[Subject] Azure pricing and services updates") > 0);
            ClassicAssert.IsFalse(result.IndexOf("[Cc]") > 0);
            ClassicAssert.IsFalse(result.IndexOf("[Bcc]") > 0);
        }

        [Test]
        public void PureTextMsg_ReadTextTest()
        {
            string path = TestDataSample.GetEmailPath("raw text mail demo.msg");
            byte[] fileContent = File.ReadAllBytes(path);
            ParserContext context = new ParserContext("raw text mail demo.msg", fileContent);
            var parser = ParserFactory.CreateText(context);

            string result = parser.Parse();
            ClassicAssert.IsNotNull(result);
            ClassicAssert.IsNotEmpty(result);
        }

        [Test]
        public void HtmlMsg_ReadMsgEntityTest()
        {
            //patch for 'No data is available for encoding 936'
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            string path = TestDataSample.GetEmailPath("Azure pricing and services updates.msg");
            byte[] fileContent = File.ReadAllBytes(path);
            ParserContext context = new ParserContext("Azure pricing and services updates.msg", fileContent);
            var parser = ParserFactory.CreateEmail(context);

            var result = parser.Parse();
            ClassicAssert.AreEqual("Azure Team<AzureTeam@e-mail.microsoft.com>",result.From);

            ClassicAssert.AreEqual(1, result.To.Count);
            ClassicAssert.AreEqual(0, result.Cc.Count);
            ClassicAssert.AreEqual(0, result.Bcc.Count);

            ClassicAssert.AreEqual("tonyqux@hotmail.com", result.To[0]);
            ClassicAssert.AreEqual("Azure pricing and services updates", result.Subject);
            ClassicAssert.IsNotNull(result.TextBody);
            ClassicAssert.IsNotNull(result.HtmlBody);
        }
    }
}
