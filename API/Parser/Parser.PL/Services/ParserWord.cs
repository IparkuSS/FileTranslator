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
            using (WordDocument document = new WordDocument(new MemoryStream(dataBytes), FormatType.Automatic))
            {
                return document.GetText();
            }
        }

        public byte[] ModifyAndCreateDocument(byte[] originalDataBytes, string modifiedText)
        {
            var stream = new MemoryStream(originalDataBytes);

            // Загрузка оригинального документа
            using (WordDocument originalDocument = new WordDocument(stream, FormatType.Automatic))
            {
                // Изменение текста
                originalDocument.LastParagraph.Replace(default, modifiedText);

                // Создание нового документа с тем же форматом
                using (MemoryStream newStream = new MemoryStream())
                {
                    originalDocument.Save(newStream, FormatType.Automatic);
                    return newStream.ToArray();
                }
            }
        }
    }
}

