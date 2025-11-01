﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.IO;
using NUnit.Framework.Legacy;

namespace Toxy.Test
{
    /// <summary>
    /// Summary description for ExcelParserTest
    /// </summary>
    [TestFixture]
    public class Excel2007ParserTest:ExcelParserBaseTest
    {
        public Excel2007ParserTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [Test]
        public void TestExtractFooter()
        {
            BaseTestExtractSheetFooter("45540_classic_Footer.xlsx");
        }
        [Test]
        public void TestExtractHeader()
        {
            BaseTestExtractSheetHeader("45540_classic_Header.xlsx");
        }
        [Test]
        public void TestSheetWithHeaderRow()
        {
            BaseTestWithHeaderRow("SheetWithColumnHeader.xlsx");
        }
        [Test]
        public void TestExtractWithoutHeader()
        {
            BaseTestWithoutHeader("WithVariousData.xlsx");
        }
        [Test]
        public void TestExcelWithFormats()
        {
            BaseTestExcelFormatedString("Formatting.xlsx");
        }
        [Test]
        public void TestExcelWithComments()
        {
            base.BaseTestExcelComment("comments.xlsx");
        }
        [Test]
        public void TestParseSheetIndexOutOfRange()
        {
            byte[] fileContent = File.ReadAllBytes(TestDataSample.GetExcelPath("Formatting.xlsx"));
            ParserContext context = new ParserContext("Formatting.xlsx", fileContent);
            ISpreadsheetParser parser = ParserFactory.CreateSpreadsheet(context);
            try
            {
                ToxyTable ss = parser.Parse(50);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                ClassicAssert.IsTrue(ex.Message.Contains("This file only contains 3 sheet(s)."));
            }
        }
    }
}
