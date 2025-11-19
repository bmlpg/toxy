using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using iText.Kernel.Pdf.Canvas.Parser.Listener;
using System.IO;
using System.Text;

namespace Toxy.Parsers
{
    public class PDFTextParser : ITextParser
    {
        public PDFTextParser(ParserContext context)
        {
            this.Context = context;
        }
        public string Parse()
        {
            /*
            if (!File.Exists(Context.Path))
                throw new FileNotFoundException("File " + Context.Path + " is not found");
            */

            using (PdfDocument document = new PdfDocument(new PdfReader(new MemoryStream(Context.FileContent))))
            {
                StringBuilder text = new StringBuilder();

                for (int i = 1; i <= document.GetNumberOfPages(); i++)
                {
                    ITextExtractionStrategy its = new LocationTextExtractionStrategy();
                    string thePage = PdfTextExtractor.GetTextFromPage(document.GetPage(i), its);
                    text.AppendLine(thePage);
                }
                return text.ToString();
            }
        }

        public ParserContext Context { get; set; }
    }
}