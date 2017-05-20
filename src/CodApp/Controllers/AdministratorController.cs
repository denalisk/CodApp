using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodApp.Models;
using Microsoft.AspNetCore.Identity;
using CodApp.ViewModels;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CodApp.Controllers
{
    public class AdministratorController : Controller
    {
        // GET: /<controller>/
        private readonly CodAppDbContext _db;
        private readonly UserManager<Admin> _adminManager;
        private readonly SignInManager<Admin> _signInManager;
        public AdministratorController(UserManager<Admin> adminManager, SignInManager<Admin> signInManager, CodAppDbContext db)
        {
            _db = db;
            _adminManager = adminManager;
            _signInManager = signInManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [Authorize]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var admin = new Admin { UserName = model.UserName, Email = model.Email };
            IdentityResult result = await _adminManager.CreateAsync(admin, model.Password);
            if (result.Succeeded)
            {
                var test = admin.Id;
                var currentUser = await _adminManager.FindByIdAsync(admin.Id);
                Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: true, lockoutOnFailure: false);
                if (signInResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}
