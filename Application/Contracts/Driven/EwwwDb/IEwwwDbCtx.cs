namespace Application.Contracts.Driven.EwwwDb;

public interface IEwwwDbCtx
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}