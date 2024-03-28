namespace MinCQRS.DAL.Data.Interfaces
{
    using Microsoft.EntityFrameworkCore.Storage;
    using System.Threading.Tasks;


    public interface IUnitOfWork
    {
        //IDbContextTransaction BeginTransaction();
        //void CommitTransaction();
        //void RollbackTransaction();

        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
        Task CommitTransactionAsync(CancellationToken cancellationToken);
        Task RollbackTransactionAsync(CancellationToken cancellationToken);
    }
}
