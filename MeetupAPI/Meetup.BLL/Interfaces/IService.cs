namespace Meetup.BLL.Interfaces
{
    public interface IService<TModel>
    {
        Task<IEnumerable<TModel>> GetAll(CancellationToken ct);

        Task<TModel> GetById(int id, CancellationToken ct);

        Task<TModel> Update(TModel item, CancellationToken ct);

        Task<TModel> Create(TModel item, CancellationToken ct);

        Task<bool> DeleteById(int id, CancellationToken ct);
    }
}
