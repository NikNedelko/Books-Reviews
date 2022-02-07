using System.Threading.Tasks;
using FirstBookStore.Models.DbModels;

namespace FirstBookStore.Repo
{
    public interface IBookRepo : IBaseRepo<Book>
    {
        Task<Book> GetByName(string name);
    }
}