namespace Parser.DAL.Interfaces.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Репозиторий для работы с таблицой File
        /// </summary>
        IFileRepository FileRepository { get; }

        void Commit();
    }
}
