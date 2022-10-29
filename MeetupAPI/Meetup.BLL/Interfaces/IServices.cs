using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.BLL.Interfaces
{
    public interface IServices<TModel>
    {
        Task<IEnumerable<TModel>> GetAll(CancellationToken ct);

        Task<TModel> GetById(int id, CancellationToken ct);

        Task<TModel> Update(TModel item, CancellationToken ct);

        Task<TModel> Create(TModel item, CancellationToken ct);

        Task DeleteById(int id, CancellationToken ct);
    }
}
