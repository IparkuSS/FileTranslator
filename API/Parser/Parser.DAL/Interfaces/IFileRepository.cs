using Parser.DAL.Models;

namespace Parser.DAL.Interfaces
{
    public interface IFileRepository
    {
        public Task PostFile(FileDb fileDb);
    }
}
