namespace MinCQRS.DAL.Data
{
    using Microsoft.EntityFrameworkCore.Storage;
    using Microsoft.EntityFrameworkCore;
    using MinCQRS.DAL.Data.Interfaces;
    using System.Threading.Tasks;

    public class EFUnitOfWork<TDbContext> : IUnitOfWork
            where TDbContext : DbContext
    {
        private readonly TDbContext _context;

        public EFUnitOfWork(TDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context, nameof(context));
            _context = context;
        }

        //public IDbContextTransaction BeginTransaction()
        //{
        //    return context.Database.BeginTransaction();
        //}

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
        {
            return await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        //public void CommitTransaction()
        //{
        //    context.Database.CommitTransaction();
        //}

        public async Task CommitTransactionAsync(CancellationToken cancellationToken)
        {
            await _context.Database.CommitTransactionAsync(cancellationToken);
        }

        //public void RollbackTransaction()
        //{
        //    context.Database.RollbackTransaction();
        //}

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken)
        {
            await _context.Database.RollbackTransactionAsync(cancellationToken);
        }
    }
}
