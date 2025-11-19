using iText.Kernel.Pdf;
using System.Collections.Generic;
using System.IO;

namespace Toxy.Parsers
{
    public class PDFMetadataParser : IMetadataParser
    {
        public PDFMetadataParser(ParserContext context)
        {
            this.Context = context;
        }
        public ToxyMetadata Parse()
        {
            ToxyMetadata metadata = new ToxyMetadata();
            using (PdfDocument document = new PdfDocument(new PdfReader(new MemoryStream(Context.FileContent))))
            {
                PdfDictionary trailer = document.GetTrailer();
                PdfDictionary metadataInfo = trailer.GetAsDictionary(PdfName.Info);
                ICollection<PdfName> keys = metadataInfo.KeySet();

                foreach (var key in keys)
                {
                    metadata.Add(key.GetValue(), ((PdfString)metadataInfo.Get(key)).GetValue());
                }
            }

            return metadata;
        }

        public ParserContext Context { get; set; }
    }
}