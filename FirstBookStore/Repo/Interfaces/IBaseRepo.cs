using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstBookStore.Repo.Interfaces
{
    public interface IBaseRepo<T>
    {
        Task<bool> Create(T entity);
        Task<T> Get(int id);
        Task<List<T>> Select();
        Task<bool> Delete(T entity);
        Task<bool> DeleteById(int id);
    }
}