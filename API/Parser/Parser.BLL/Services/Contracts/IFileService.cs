using Parser.BLL.Dtos;

namespace Parser.BLL.Services.Contracts
{
    public interface IFileService
    {
        public Task PostFile(FileDto fileDto);
    }
}
