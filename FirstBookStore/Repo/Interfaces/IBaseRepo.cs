using System.Collections.Generic;
using System.Threading.Tasks;
using FirstBookStore.Models.DbModels;

namespace FirstBookStore.Repo
{
    public interface IBaseRepo<T>
    {
        Task<bool> Create(T entity);
        Task<Book> Get(int id);
        Task<List<Book>> Select();
        Task<bool> Delete(T entity);
        Task<bool> DeleteById(int id);
    }
}