﻿using Parser.PL.Services.Contracts;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System.Text;

namespace Parser.PL.Services
{
    public class ParserPdf : IParser
    {
        public string ReadContentFile(byte[] dataBytes)
        {
            using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(dataBytes))
            {
                StringBuilder text = new StringBuilder();

                foreach (PdfPageBase page in loadedDocument.Pages)
                {
                    text.Append(page.ExtractText());
                }

                return text.ToString();
            }
        }
    }

}
