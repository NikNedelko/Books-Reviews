using System.Collections.Generic;
using FirstBookStore.DbData;
using FirstBookStore.Models.DbModels;
using System.Linq;
using System.Threading.Tasks;
using FirstBookStore.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FirstBookStore.Repo
{
    public class BookRepository : IBookRepo
    {
        private readonly AppDbContext _db;

        public BookRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Book entity)
        {
            await _db.Books.AddAsync(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Book> Get(int id)
        {
            return await _db.Books.FirstOrDefaultAsync(x=>x.id==id);
        }

        public async Task<List<Book>> Select()
        {
            return await _db.Books.ToListAsync();
        }

        public async Task<bool> Delete(Book entity)
        {
            _db.Books.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteById(int id)
        {
            var delEntity = _db.Books.First(x => x.id == id);
            _db.Books.Remove(delEntity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<Book> GetByName(string name)
        {
            return await _db.Books.FirstOrDefaultAsync(x=>x.Name==name);
        }
        
        public async Task<List<Book>> GetByCount()
        {
            var response= await _db.Books
                .OrderByDescending(x => x.DateCreate)
                .Take(3).ToListAsync();
            return response;
        }
    }
}