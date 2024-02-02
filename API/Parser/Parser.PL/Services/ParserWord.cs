using Parser.PL.Services.Contracts;
using System.IO;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;

namespace Parser.PL.Services
{
    public class ParserWord : IParser
    {
        public string ReadContentFile(MemoryStream memStream)
        {
            using (WordDocument document = new WordDocument(memStream, FormatType.Automatic))
            {
                string contentFile = string.Empty;
                contentFile = document.GetText();

                return contentFile;
            }
        }
    }
}
