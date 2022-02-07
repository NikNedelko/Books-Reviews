using System;
using FirstBookStore.DbData;
using FirstBookStore.Models.DbModels;

namespace FirstBookStore.Repo
{
    public class TestValues
    {
        private readonly AppDbContext _appDbContext;
        public TestValues(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Test()
        {
            Book testBook = new Book()
            {
                name = "Ktulhy",
                author = "Hovard Lovecraft",
                description = "very scary book",
                dateCreate = DateTime.Now,
                wasBuy = 999
            };
            _appDbContext.Books.Add(testBook);
            _appDbContext.SaveChanges();
        }
    }
}