using Parser.DAL.Context;
using Parser.DAL.Interfaces;
using Parser.DAL.Interfaces.Uow;

namespace Parser.DAL.Repositories.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposedValue = false;
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private IFileRepository _fileRepository;
        public IFileRepository FileRepository => _fileRepository ??= new FileRepository(_dbContext);

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                _disposedValue = true;
            }
        }
    }
}
