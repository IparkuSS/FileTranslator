using Parser.DAL.Interfaces;
using Parser.DAL.Models;
using System.Data;

namespace Parser.DAL.Repositories
{
    public class FileRepository : IFileRepository
    {
        public FileRepository(IDbTransaction transaction) { }


        public Task PostFile(FileDb fileDb)
        {
            throw new NotImplementedException();
        }
    }
}
