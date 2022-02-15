using System;
using System.Threading.Tasks;
using FirstBookStore.Models.DbModels;
using FirstBookStore.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Prng;

namespace FirstBookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepo _bookRepo;
        public BookController(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }
        
        [HttpGet]
        public async Task<ViewResult> GetBooks()
        {
            var response = await _bookRepo.Select();
            return View(response);
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ViewResult> Add(Book target)
        {
            if (ModelState.IsValid)
            {
                target.DateCreate = DateTime.Now;
                if (target.Description.Length>151)
                {
                    target.ShortDescription = target.Description.Substring(0, 150);
                    target.ShortDescription += "...";
                }
                await _bookRepo.Create(target);
                return View("Thanks");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<ViewResult> DeleteById(int id)
        {
            await _bookRepo.DeleteById(id);
            return View("Delete");
        }

        [HttpGet]
        public IActionResult Thanks()
        {
            return View();
        }

        public async Task<ViewResult> IndividualPage(int id)
        {
            var targetReview = await _bookRepo.Get(id);
            return View(targetReview);
        }
    }
}