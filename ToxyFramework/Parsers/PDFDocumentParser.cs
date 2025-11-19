using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System.IO;

namespace Toxy.Parsers
{
    public class PDFDocumentParser : IDocumentParser
    {
        public PDFDocumentParser(ParserContext context)
        {
            this.Context = context;
        }

        public ToxyDocument Parse()
        {
            /*
            if (!File.Exists(Context.Path))
                throw new FileNotFoundException("File " + Context.Path + " is not found");
            */

            ToxyDocument rdoc = new ToxyDocument();
            ITextExtractionStrategy its = new LocationTextExtractionStrategy();

            using (PdfDocument document = new PdfDocument(new PdfReader(new MemoryStream(Context.FileContent))))
            {
                for (int i = 1; i <= document.GetNumberOfPages(); i++)
                {
                    string thePage = PdfTextExtractor.GetTextFromPage(document.GetPage(i), its);
                    string[] theLines = thePage.Split('\n');
                    foreach (var theLine in theLines)
                    {
                        ToxyParagraph para = new ToxyParagraph();
                        para.Text = theLine;
                        rdoc.Paragraphs.Add(para);
                    }
                }

                rdoc.TotalPageNumber = document.GetNumberOfPages();
            }
            return rdoc;
        }
        public ParserContext Context
        {
            get;
            set;
        }
    }
}
