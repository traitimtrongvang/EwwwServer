namespace Application.Contracts.Driven.Database;

public interface IEwwwDbCtx
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}