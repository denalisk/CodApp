using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodApp.Models;
using Microsoft.AspNetCore.Identity;
using CodApp.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CodApp.Controllers
{
    public class NewsletterController : Controller
    {
        private CodAppDbContext _db;
        public NewsletterController(CodAppDbContext db)
        {
            _db = db;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var newsletters = _db.Newsletters.ToList();
            return View(newsletters);
        }

        public IActionResult AddReader(Reader reader)
        {
            var newReader = new Reader { Name = reader.Name, Email = reader.Email, StreetAddress = reader.StreetAddress, City = reader.City, State = reader.State };
            _db.Readers.Add(newReader);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Detail(int id)
        {
            var currentNewsletter = _db.Newsletters
                .Include(m => m.Articles)
                .FirstOrDefault(m => m.Id == id);
            return View(currentNewsletter);
        }

        [Authorize]
        public IActionResult Readers()
        {
            var readerList = _db.Readers.ToList();
            return View(readerList);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Newsletter newsletter)
        {
            var newNewsletter = new Newsletter { Title = newsletter.Title, Content = newsletter.Content };
            _db.Newsletters.Add(newNewsletter);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddArticle(Article article)
        {
            int targetNewsletterId = Int32.Parse(this.Request.Form["NewsletterId"]);
            var currentNewsletter = _db.Newsletters.FirstOrDefault(newsletters => newsletters.Id == targetNewsletterId);
            var newArticle = new Article { Title = article.Title, Content = article.Content, ImageSrcString = article.ImageSrcString };
            newArticle.Newsletter = currentNewsletter;
            _db.Articles.Add(newArticle);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditArticle(Article article)
        {
            int targetNewsletterId = Int32.Parse(this.Request.Form["NewsletterId"]);
            var currentNewsletter = _db.Newsletters.FirstOrDefault(newsletters => newsletters.Id == targetNewsletterId);
            article.Newsletter = currentNewsletter;
            _db.Entry(article).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
