using System;
using System.Threading.Tasks;
using FirstBookStore.Models.DbModels;
using FirstBookStore.Repo;
using Microsoft.AspNetCore.Mvc;
namespace FirstBookStore.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentRepo _commentRepo;
        public CommentController(ICommentRepo commentRepo)
        {
            _commentRepo = commentRepo;
        }

        // [HttpGet]
        // public async Task<ViewResult> GetComments()
        // {
        //     var response = await _commentRepo.Select();
        //     return View(response);
        // }
        
       [HttpGet]
        public async Task<ViewResult> GetByBook(int id)
        {
            var response = await _commentRepo.GetByBook(id);
            return View(response);
        }

        private static int _bookIdForAddMethod = new int();
        
        [HttpGet]
        public IActionResult Add(int id)
        {
            _bookIdForAddMethod = id;
            return View();
        }
        
        [HttpPost]
        public async Task<ViewResult> Add(Comment target)
        {
            if (ModelState.IsValid)
            {
                target.DateAdd = DateTime.Now;
                target.BookId = _bookIdForAddMethod;
                _bookIdForAddMethod = -1;
                await _commentRepo.Create(target);
                return View("Thanks");
            }
            else
            {
                return View();
            }
        }
        //in developing
        public async Task /*<ViewResult>*/ AddLike(Comment entity)
        {
            await _commentRepo.AddLike(entity);
            await GetByBook(entity.BookId);
        }
        
        public async Task<ViewResult> AddDislike(Comment entity)
        {
            await _commentRepo.AddDislike(entity);
            return await GetByBook(entity.BookId);
        }
        
        public async Task<ViewResult> RemoveLike(Comment entity)
        {
            await _commentRepo.RemoveLike(entity);
            return await GetByBook(entity.BookId);
        }
        
        public async Task<ViewResult> RemoveDislike(Comment entity)
        { 
            await _commentRepo.RemoveDislike(entity);
            return await GetByBook(entity.BookId);
        }

        public async Task<ViewResult> DeleteById(int id)
        {
            var entityForReturn = await _commentRepo.Get(id);
            await _commentRepo.DeleteById(id);
            return View("Delete",entityForReturn);
        }
    }
}