using System.Collections.Generic;
using System.Threading.Tasks;
using FirstBookStore.DbData;
using FirstBookStore.Models.DbModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FirstBookStore.Repo.Interfaces;

namespace FirstBookStore.Repo
{
    public class CommentRepository : ICommentRepo
    {
        private readonly AppDbContext _db;

        public CommentRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(Comment entity)
        {
            await _db.Comments.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Comment> Get(int id)
        {
            return await _db.Comments.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<List<Comment>> Select()
        {
            return await _db.Comments.ToListAsync();
        }

        public async Task<bool> Delete(Comment entity)
        {
            _db.Comments.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteById(int id)
        {
            var delEntity = _db.Comments.First(x => x.id == id);
            _db.Comments.Remove(delEntity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task DeleteWithBook(int idOfBook)
        {
            var forDel = await _db.Comments.Where(x => x.BookId == idOfBook).ToListAsync();
            foreach (var com in forDel)
                await Delete(com);
        }
        public async Task<List<Comment>> GetByBook(int targetBook)
        {
            return await _db.Comments
                .Where(comment => comment.BookId == targetBook)
                .ToListAsync();
        }

        public async Task RemoveDislike(Comment entity)
        {
            var target = await Get(entity.id);
            await Delete(entity);
            target.Dislikes--;
            await Create(target);
        }
        
        public async Task AddLike(Comment entity)
        {
            var target = await Get(entity.id);
            await Delete(entity);
            target.Likes+=1;
            await Create(target);
        }
        
        public async Task AddDislike(Comment entity)
        {
            var target = await Get(entity.id);
            await Delete(entity);
            target.Dislikes++;
            await Create(target);
        }

        public async Task RemoveLike(Comment entity)
        {
            var target = await Get(entity.id);
            await Delete(entity);
            target.Likes--;
            await Create(target);
        }
    }
}