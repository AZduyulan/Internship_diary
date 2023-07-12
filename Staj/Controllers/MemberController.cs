using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;
using Staj.Areas.Admin.Models;
using Staj.Extensions;
using Staj.Core.ViewModels;
using System.Drawing.Printing;
using System.Security.Policy;
using Staj.Core.Models;
using Staj.Repository.Models;
using Staj.Service.Services;

namespace Staj.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IFileProvider _fileProvider;
        private readonly IMemberService _memberService;
        private string userName => User.Identity!.Name!;
        public MemberController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IFileProvider fileProvider,IMemberService memberService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _fileProvider = fileProvider;
            _memberService = memberService;
        }

        public async Task<IActionResult> Index()
        { 
            return View(await _memberService.GetUserViewModelByUserName(userName));
        }
        public async Task LogOut()
        {
            await _memberService.LogOut();

        }

        public IActionResult PasswordChange()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PasswordChange(PasswordChangeViewModel request)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            if (await _memberService.CheckPasswordAsync(userName,request.PasswordOld))
            {
                ModelState.AddModelError(string.Empty, "eski şifreniz yanliş");
                return View();
            }

            var (isSuccess,errors) = await _memberService.ChangePasswordAsync(userName, request.PasswordOld, request.PasswordNew);

            if (!isSuccess)
            {
                ModelState.AddModelErrorList(errors!);
                return View();
            }

            

            TempData["SuccessMessage"] = "Şİfren değişti balım";
            return View();
        }

        public async Task<IActionResult> UserEdit()
        {
            ViewBag.gender = new SelectList(Enum.GetNames(typeof(Gender)));
            var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
            var userEditViewModel = new UserEditViewModel()
            {
                UserName = currentUser.UserName,
                Email = currentUser.Email,
                Phone = currentUser.PhoneNumber,
                BirthDay = currentUser.BirthDay,
                City = currentUser.City,
                Gender = currentUser.Gender,
                


            };
            return View(userEditViewModel);
        }

        [HttpPost]

        public async Task<IActionResult> UserEdit(UserEditViewModel request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var currentUser = await _userManager.FindByNameAsync(User.Identity!.Name!);

            currentUser.UserName = request.UserName;
            currentUser.Email = request.Email;
            currentUser.PhoneNumber = request.Phone;
            currentUser.BirthDay = request.BirthDay;
            currentUser.City = request.City;
            currentUser.Gender = request.Gender;




            if (request.Picture != null && request.Picture.Length > 0)
            {
                var wwwrootFolder = _fileProvider.GetDirectoryContents("wwwroot");
                var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(request.Picture.FileName)}";

                var newPicturePath = Path.Combine(wwwrootFolder!.First(x => x.Name == "userpictures").PhysicalPath!, randomFileName);

                using var stream = new FileStream(newPicturePath, FileMode.Create);

                await request.Picture.CopyToAsync(stream);

                currentUser.Picture = randomFileName;  
            }


            var updateToUserResult = await _userManager.UpdateAsync(currentUser);

            if (!updateToUserResult.Succeeded)
            {
                ModelState.AddModelErrorList(updateToUserResult.Errors);
                return View();
            }

            await _userManager.UpdateSecurityStampAsync(currentUser);
            await _signInManager.SignOutAsync();
            await _signInManager.SignInAsync(currentUser, true);

            TempData["SuccessMessage"] = "Üye Bilgileriniz Başarıyla Güncellenmiştir";
            var userEditViewModel = new UserEditViewModel()
            {
                UserName = currentUser.UserName,
                Email = currentUser.Email,
                Phone = currentUser.PhoneNumber,
                BirthDay = currentUser.BirthDay,
                City = currentUser.City,
                Gender = currentUser.Gender,


            };
            return View(userEditViewModel);

        }

        public IActionResult AccessDenied(string ReturlUrl) 
        {
            string message = string.Empty;

            message = "Bu sayfaya yetkin yok , berkay hazretleriyle konuş belki olur";
            ViewBag.message=message;
            return View();
        }
    }
}
