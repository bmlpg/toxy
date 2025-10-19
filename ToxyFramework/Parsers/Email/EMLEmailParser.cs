﻿using HLIB.MailFormats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Toxy.Parsers
{
    public class EMLEmailParser:IEmailParser
    {
        public EMLEmailParser(ParserContext context)
        {
            this.Context = context;
        }

        public ToxyEmail Parse()
        {
            /*
            if (!File.Exists(Context.Path))
                throw new FileNotFoundException("File " + Context.Path + " is not found");
            */

            ToxyEmail email = new ToxyEmail();
            using (MemoryStream stream = new MemoryStream(Context.FileContent))
            {
                EMLReader reader = new EMLReader(stream);
                email.From = reader.From;
                email.To = new List<string>(reader.To.Split(';'));
                if (reader.CC != null)
                    email.Cc = new List<string>(reader.CC.Split(';'));
                email.TextBody = reader.Body;
                email.HtmlBody = reader.HTMLBody;
                email.Subject = reader.Subject;
                email.ArrivalTime = reader.X_OriginalArrivalTime;
            }

            return email;
        }

        public ParserContext Context
        {
            get;
            set;
        }
    }
}
