using Parser.PL.Helpers;
using Parser.PL.Services.Contracts;
using System.Text;

namespace Parser.PL.Services
{
    public class ParserTxt : IParser
    {
        public string ReadContentFile(byte[] dataBytes) =>
            EncodingHelper.GetEncoding(dataBytes).GetString(dataBytes);

        public byte[] ModifyAndCreateDocument(byte[] originalDataBytes, string modifiedText)
        {
            // Определение кодировки оригинального файла
            Encoding originalEncoding = EncodingHelper.GetEncoding(originalDataBytes);

            // Изменение текста
            string modifiedTextWithEncoding = originalEncoding.GetString(originalDataBytes);
            modifiedTextWithEncoding = modifiedText; // Замените эту строку на вашу логику изменения текста

            // Кодирование измененного текста в байты с той же кодировкой
            byte[] modifiedBytes = originalEncoding.GetBytes(modifiedTextWithEncoding);

            return modifiedBytes;
        }
    }
}
