﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Toxy.Test
{
    [TestFixture]
    public class Word2007ParserTest
    {

        [Test]
        public void TestParseTextFromWord()
        {
            byte[] fileContent = File.ReadAllBytes(TestDataSample.GetWordPath("SampleDoc.docx"));
            ParserContext context = new ParserContext("SampleDoc.docx", fileContent);
            ITextParser parser = ParserFactory.CreateText(context);
            string doc = parser.Parse();

            Assert.IsNotNull(doc);

            string[] lines = doc.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual(7, lines.Length);
            Assert.AreEqual("I am a test document", lines[0]);
            Assert.AreEqual("This is page 1", lines[1]);
            Assert.AreEqual("I am Calibri (Body) in font size 11", lines[2]);
            Assert.AreEqual("\n", lines[3]);
            Assert.AreEqual("This is page two", lines[4]);
            Assert.AreEqual("It’s Arial Black in 16 point", lines[5]);
            Assert.AreEqual("It’s also in blue", lines[6]);
        }
        [Test]
        public void TestParseSimpleDocumentFromWord()
        {
            byte[] fileContent = File.ReadAllBytes(TestDataSample.GetWordPath("SampleDoc.docx"));
            ParserContext context = new ParserContext("SampleDoc.docx", fileContent);
            IDocumentParser parser = ParserFactory.CreateDocument(context);
            ToxyDocument doc = parser.Parse();
            Assert.AreEqual(7,doc.Paragraphs.Count);
            Assert.AreEqual("I am a test document",doc.Paragraphs[0].Text);
            Assert.AreEqual("This is page 1", doc.Paragraphs[1].Text);
            Assert.AreEqual("I am Calibri (Body) in font size 11", doc.Paragraphs[2].Text);
            Assert.AreEqual("\n", doc.Paragraphs[3].Text);
            Assert.AreEqual("This is page two", doc.Paragraphs[4].Text);
            Assert.AreEqual("It’s Arial Black in 16 point", doc.Paragraphs[5].Text);
            Assert.AreEqual("It’s also in blue", doc.Paragraphs[6].Text);
        }
        [Test]
        public void TestParseDocumentWithTable()
        {
            byte[] fileContent = File.ReadAllBytes(TestDataSample.GetWordPath("simple-table.docx"));
            ParserContext context = new ParserContext("simple-table.docx", fileContent);
            IDocumentParser parser = ParserFactory.CreateDocument(context);
            ToxyDocument doc = parser.Parse();
            Assert.AreEqual(8, doc.Paragraphs.Count);
            Assert.AreEqual("This is a Word document that was created using Word 97 – SR2.  It contains a paragraph, a table consisting of 2 rows and 3 columns and a final paragraph.", 
                doc.Paragraphs[0].Text);
            Assert.AreEqual("This text is below the table.", doc.Paragraphs[1].Text);
            Assert.AreEqual("Cell 1,1", doc.Paragraphs[2].Text);
            Assert.AreEqual("Cell 1,2", doc.Paragraphs[3].Text);
            Assert.AreEqual("Cell 1,3", doc.Paragraphs[4].Text);
            Assert.AreEqual("Cell 2,1", doc.Paragraphs[5].Text);
            Assert.AreEqual("Cell 2,2", doc.Paragraphs[6].Text);
            Assert.AreEqual("Cell 2,3", doc.Paragraphs[7].Text);
        }
    }
}
