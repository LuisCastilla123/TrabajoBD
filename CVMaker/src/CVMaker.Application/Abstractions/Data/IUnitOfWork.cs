namespace CVMaker.Application.Abstractions
{
public interface IUnitOfWork
{
    Task BeginTransactionAsync(CancellationToken CancellationToken= default);
    Task CommitAsync(CancellationToken CancellationToken  = default);
    Task RollbackAsync(CancellationToken CancellationToken = default);
    Task<int> SaveChangesAsync(CancellationToken CancellationToken = default);
}

}