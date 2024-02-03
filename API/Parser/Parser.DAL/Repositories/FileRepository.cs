using Parser.DAL.Context;
using Parser.DAL.Interfaces;
using Parser.DAL.Models;

namespace Parser.DAL.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FileRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task PostFile(FileDb fileDb)
        {
            await _dbContext.Files.AddAsync(fileDb);
            // Дополнительные операции, если необходимо
        }
    }
}
