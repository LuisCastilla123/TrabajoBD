namespace CVMaker.Application.Abstractions
{
public interface IUnitOfWork
{
    Task BeginTransactionAsync(CancellatopnToken CancellationToken= default);
    Task CommitAsync(CancellationToken CancellationToken  = default);
    task RollbackAsync(CancellatonToken CancellationToken = default);
    Task<int> SaveChangesAdync(CancellationToken CancellationToken = default);
}

}