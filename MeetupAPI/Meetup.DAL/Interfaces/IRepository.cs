namespace Meetup.DAL.Interfaces
{
    public interface IRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAll(CancellationToken ct);

        Task<TEntity> GetById(int id, CancellationToken ct);

        Task<TEntity> Update(TEntity item, CancellationToken ct);

        Task<TEntity> Create(TEntity item, CancellationToken ct);

        Task DeleteById(int id, CancellationToken ct);
    }
}
