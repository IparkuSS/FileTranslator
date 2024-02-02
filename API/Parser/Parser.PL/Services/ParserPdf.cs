using Parser.PL.Services.Contracts;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System.IO;
using System.Text;

namespace Parser.PL.Services
{
    public class ParserPdf : IParser
    {
        public string ReadContentFile(MemoryStream memStream)
        {
            using (PdfLoadedDocument loadedDocument = new PdfLoadedDocument(memStream))
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
