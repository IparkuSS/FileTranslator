using System.IO;

namespace Parser.PL.Services.Contracts
{
    public interface IParser
    {
        /// <summary>
        /// Метод для парсинга файлов.
        /// </summary>
        string ReadContentFile(byte[] dataBytes);
    }
}
