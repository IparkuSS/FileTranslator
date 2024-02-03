using Parser.PL.Helpers;
using Parser.PL.Services.Contracts;

namespace Parser.PL.Services
{
    public class ParserTxt : IParser
    {
        public string ReadContentFile(byte[] dataBytes)
        {
            System.Text.Encoding encoding = EncodingHelper.GetEncoding(dataBytes);
            string text = encoding.GetString(dataBytes);

            return text;
        }
    }
}
