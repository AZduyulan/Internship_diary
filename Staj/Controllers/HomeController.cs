using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Staj.Core.ViewModels;
using Staj.Extensions;

using System.Diagnostics;
using Staj.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Staj.Repository.Models;
using Staj.Service.Services;

namespace Staj.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailService _emailService;
        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailService)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult SignUp() 
        {

            return View();        
        }

        public IActionResult SignIn() 
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model,string? returnUrl=null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            returnUrl = returnUrl ?? Url.Action("Index", "Home");

            var hasUser =await _userManager.FindByEmailAsync(model.Email);
            if (hasUser==null)
            {
                ModelState.AddModelError(string.Empty, "Email veya şifre yanlış");
                return View();
            }
            var signInresult =await _signInManager.PasswordSignInAsync(hasUser, model.Password, model.RememberMe, true);
           
            if (signInresult.Succeeded)
            {
                return Redirect(returnUrl);
            }

            if (hasUser.AccessFailedCount==2) 
            {
                ModelState.AddModelErrorList(new List<string>() { "bİrdaHa yaniliş girersen kitlerim 3 dagga" });
                return View();
            }
            if (signInresult.IsLockedOut)
            {
                ModelState.AddModelErrorList(new List<string>() {"3 dagga boyunca giriş yapamıyon dayi deneme" });
                return View();
            }
            ModelState.AddModelErrorList(new List<string>() { "Email veya şifre yanlış" });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel request) 
        {
            
            if (!ModelState.IsValid)
            {
                return View();
            }

            var identityResult = await _userManager.CreateAsync(new() { UserName = request.UserName, Email = request.Email, PhoneNumber = request.Phone }, request.PasswordConfirm);

            if (identityResult.Succeeded) 
            {
                TempData["SuccessMessage"] = "Başarili balim geç";
                return View(nameof(HomeController.SignUp));
                    
            }
            ModelState.AddModelErrorList(identityResult.Errors.Select(x => x.Description).ToList());
           
            return View();
        }

        public IActionResult ResetPassword() 
        {
            //ŞİFREYİ UNUTMAYIN KNK
            return View();
        }

        [HttpPost]

            public async Task<IActionResult> ResetPassword(ResetPasswordViewModel request)
        {
            //YAPMADIM BUNU , BU YOK KNK
            var hasUser = await _userManager.FindByEmailAsync(request.Email);

            if (hasUser == null) 
            {
                ModelState.AddModelError(String.Empty, "Böyle bi emaaail yoks");
                return View();
            }

            string passwordResetsToken = await _userManager.GeneratePasswordResetTokenAsync(hasUser);

            var passwordResetLink = Url.Action("ResetPassword", "Home",new {userId=hasUser.Id,Token=passwordResetsToken},
                HttpContext.Request.Scheme);

            await _emailService.SendResetPasswordEmail(passwordResetLink!, hasUser.Email!);

            TempData["SuccessMessage"] = "E-postana attım bak";

            return RedirectToAction(nameof(ResetPassword));
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}