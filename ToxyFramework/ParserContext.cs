using System;
using System.Collections.Generic;
using System.Text;

namespace Toxy
{
    public class ParserContext
    {
        public ParserContext(string fileName, byte[] fileContent):this(fileName, fileContent, null)
        { 
        
        }
        public ParserContext(string fileName, byte[] fileContent, Encoding encoding)
        {
            this.FileName = fileName;
            this.FileContent = fileContent;
            this.Properties = new Dictionary<string, string>();
            this.Encoding = encoding;
        }
        public string FileName { get; set; }

        public byte[] FileContent { get; set; }
        public Encoding Encoding { get; set; }
        
        public Dictionary<string, string> Properties { get; set; }
    }
}
