using Parser.PL.Services.Contracts;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System.IO;

namespace Parser.PL.Services
{
    public class ParserWord : IParser
    {
        public string ReadContentFile(byte[] dataBytes)
        {
            var stream = new MemoryStream(dataBytes);
            using (WordDocument document = new WordDocument(stream, FormatType.Automatic))
            {
                string contentFile = string.Empty;
                contentFile = document.GetText();

                return contentFile;
            }
        }
    }
}
