using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodApp.Models;
using Microsoft.AspNetCore.Identity;
using CodApp.ViewModels;
using Microsoft.EntityFrameworkCore;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CodApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        private CodAppDbContext _db;
        public HomeController(CodAppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var bannerArticle = _db.Articles.FirstOrDefault(m => m.PageLabel == "Banner");
            var banner2Article = _db.Articles.FirstOrDefault(m => m.PageLabel == "Banner2");
            var banner3Article = _db.Articles.FirstOrDefault(m => m.PageLabel == "Banner3");
            var blurb1Article = _db.Articles.FirstOrDefault(m => m.PageLabel == "Blurb1");
            var blurb2Article = _db.Articles.FirstOrDefault(m => m.PageLabel == "Blurb2");
            var blurb3Article = _db.Articles.FirstOrDefault(m => m.PageLabel == "Blurb3");
            var blurb4Article = _db.Articles.FirstOrDefault(m => m.PageLabel == "Blurb4");
            var taglineArticle = _db.Articles.FirstOrDefault(m => m.PageLabel == "Tagline");
            Dictionary<string, Article> homeDictionary = new Dictionary<string, Article> { };
            homeDictionary["Banner"] = bannerArticle;
            homeDictionary["Tagline"] = taglineArticle;
            homeDictionary["Banner2"] = banner2Article;
            homeDictionary["Banner3"] = banner3Article;
            homeDictionary["Blurb1"] = blurb1Article;
            homeDictionary["Blurb2"] = blurb2Article;
            homeDictionary["Blurb3"] = blurb3Article;
            homeDictionary["Blurb4"] = blurb4Article;
            return View(homeDictionary);
        }

        public IActionResult EditHome()
        {
            var bannerArticle = _db.Articles.FirstOrDefault(m => m.PageLabel == "Banner");
            var banner2Article = _db.Articles.FirstOrDefault(m => m.PageLabel == "Banner2");
            var banner3Article = _db.Articles.FirstOrDefault(m => m.PageLabel == "Banner3");
            var blurb1Article = _db.Articles.FirstOrDefault(m => m.PageLabel == "Blurb1");
            var blurb2Article = _db.Articles.FirstOrDefault(m => m.PageLabel == "Blurb2");
            var blurb3Article = _db.Articles.FirstOrDefault(m => m.PageLabel == "Blurb3");
            var blurb4Article = _db.Articles.FirstOrDefault(m => m.PageLabel == "Blurb4");
            var taglineArticle = _db.Articles.FirstOrDefault(m => m.PageLabel == "Tagline");
            Dictionary<string, Article> homeDictionary = new Dictionary<string, Article> { };
            homeDictionary["Banner"] = bannerArticle;
            homeDictionary["Tagline"] = taglineArticle;
            homeDictionary["Banner2"] = banner2Article;
            homeDictionary["Banner3"] = banner3Article;
            homeDictionary["Blurb1"] = blurb1Article;
            homeDictionary["Blurb2"] = blurb2Article;
            homeDictionary["Blurb3"] = blurb3Article;
            homeDictionary["Blurb4"] = blurb4Article;
            return View(homeDictionary);
        }
    }
}
