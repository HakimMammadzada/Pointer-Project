using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PointerMVCcore.Data;
using PointerMVCcore.Models;
using NCV = Microsoft.AspNetCore.Identity;
namespace PointerMVCcore.Controllers
{
    public class AcountController : Controller
    {
        private readonly PointerDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly IPasswordValidator<AppUser> validator;
        private readonly SignInManager<AppUser> signInManager;
        public AcountController(PointerDbContext _context, IMapper _mapper, UserManager<AppUser> _userManager,
            IPasswordValidator<AppUser> _validator, SignInManager<AppUser> _signInManager)
        {
            context = _context;
            mapper = _mapper;
            userManager = _userManager;
            validator = _validator;
            signInManager = _signInManager;
        }
        [HttpGet]
        public IActionResult Registr()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registr(RegistrModel regist)
        {
            if (!ModelState.IsValid)
                return View(nameof(Registr));
            AppUser appUser =await userManager.FindByEmailAsync(regist.Email);

            if (appUser != null)
            {
                ModelState.AddModelError("", "Bu email var");
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var user = mapper.Map<AppUser>(regist);
                    var registrasiya = await userManager.CreateAsync(user, regist.Password);
                    if (registrasiya.Succeeded)
                        return View(nameof(Login));
                }
              
                
            }

            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {

            if (!ModelState.IsValid)
                return View(nameof(Login));

            AppUser currentuser =await userManager.FindByEmailAsync(login.Email);
            var pass =await validator.ValidateAsync(userManager, currentuser, login.Password);
            if(currentuser!=null && pass.Succeeded )
            {
                if(await signInManager.UserManager.IsInRoleAsync(currentuser, "Admin")){
                    return Content("Admin");
                }
                else
                {
                    return Content("User");
                }
                //NCV.SignInResult signInResult = await signInManager.PasswordSignInAsync(currentuser, login.Password, true, false);

                //if (signInResult.Succeeded)
                //{
                //    return RedirectToAction("Index", "Home");
                //}
                //else
                //{
                //    return View(nameof(Registr));
                //}
            }

          

            return View();
        }
    }
}