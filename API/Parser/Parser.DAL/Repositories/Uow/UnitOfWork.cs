using Microsoft.Data.SqlClient;
using Parser.DAL.Interfaces;
using Parser.DAL.Interfaces.Uow;
using System.Data;

namespace Parser.DAL.Repositories.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposedValue = false;
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        public string _connectionString;

        public UnitOfWork(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new SqlConnection(_connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        private IFileRepository _fileRepository;
        public IFileRepository FileRepository => _fileRepository ??= new FileRepository(_transaction);




        /// <summary>
        /// Метод делает commit, если не возникло проблем
        /// и делает rollback если проблемы возникли.
        /// </summary>
        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                ResetRepositories();
            }
        }

        /// <summary>
        /// Удаляет connection к бд
        /// </summary>
        private void Dispose(bool disposing)
        {
            if (_disposedValue)
            {
                return;
            }

            if (disposing)
            {
                _connection?.Close();
                _transaction?.Dispose();
                _transaction = null;
                _connection?.Dispose();
                _connection = null;
            }

            _disposedValue = true;
        }

        /// <summary>
        /// Удаляет connection к бд
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// сбрасывает репозитории, которые используются в uow
        /// </summary>
        private void ResetRepositories()
        {
            _fileRepository = null;
        }
    }
}
