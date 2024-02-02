using Parser.PL.Services.Contracts;
using System.IO;
using Parser.PL.Helpers;

namespace Parser.PL.Services
{
    public class ParserTxt : IParser
    {
        public string ReadContentFile(MemoryStream memStream)
        {
            byte[] dataBytes = memStream.ToArray();
            System.Text.Encoding encoding = EncodingHelper.GetEncoding(dataBytes);
            string text = encoding.GetString(dataBytes);

            return text;
        }
    }
}
