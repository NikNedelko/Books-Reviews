using System.Collections.Generic;
using System.Threading.Tasks;
using FirstBookStore.Models.DbModels;

namespace FirstBookStore.Repo
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