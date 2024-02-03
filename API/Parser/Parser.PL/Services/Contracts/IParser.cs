namespace Parser.PL.Services.Contracts
{
    public interface IParser
    {
        /// <summary>
        /// Метод для парсинга файлов.
        /// </summary>
        string ReadContentFile(byte[] dataBytes);

        /// <summary>
        /// Метод для записи файлов.
        /// </summary>
        byte[] ModifyAndCreateDocument(byte[] originalDataBytes, string modifiedText);
    }
}
