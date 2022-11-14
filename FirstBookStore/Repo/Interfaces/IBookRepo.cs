using System.Collections.Generic;
using System.Threading.Tasks;
using FirstBookStore.Models.DbModels;

namespace FirstBookStore.Repo.Interfaces
{
    public interface IBookRepo : IBaseRepo<Book>
    {
        Task<Book> GetByName(string name);
        Task<List<Book>> GetByCount();
    }
}