using System.Collections.Generic;
using System.Threading.Tasks;
using FirstBookStore.Models.DbModels;

namespace FirstBookStore.Repo
{
    public interface ICommentRepo : IBaseRepo<Comment>
    {
        Task<List<Comment>> GetByBook(int targetBook);
        Task AddLike(Comment entity);
        Task AddDislike(Comment entity);
        Task RemoveLike(Comment entity);
        Task RemoveDislike(Comment entity);
    }
}