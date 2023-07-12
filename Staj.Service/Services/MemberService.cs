using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Staj.Core.Models;
using Staj.Core.ViewModels;
using Staj.Repository.Models;
using Azure.Core;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Staj.Service.Services
{
    public class MemberService:IMemberService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
     
        public MemberService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) 
        { 
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<UserViewHomeModel> GetUserViewModelByUserName(string userName)
        {
            var currentUser = await _userManager.FindByNameAsync(userName);

            return new UserViewHomeModel
            {
                Email = currentUser!.Email,
                PhoneNumber = currentUser!.PhoneNumber,
                UserName = currentUser!.UserName,
                PictureUrl = currentUser!.Picture

            };
            
        }

        public async Task<bool> CheckPasswordAsync(string userName, string password)
        {
            var currentUser = await _userManager.FindByNameAsync(userName);

            return await _userManager.CheckPasswordAsync(currentUser!, password);
        }
        
        public async Task<(bool,IEnumerable<IdentityError>?)>  ChangePasswordAsync(string userName , string oldPassword,string newPassword)
        {
            var currentUser = await _userManager.FindByNameAsync(userName);

            var resultChangePassword = await _userManager.ChangePasswordAsync(currentUser!, oldPassword,
                newPassword);

            if (!resultChangePassword.Succeeded)
            {
                return (false, resultChangePassword.Errors);
            }
            await _userManager.UpdateSecurityStampAsync(currentUser!);
            await _signInManager.SignOutAsync();
            await _signInManager.PasswordSignInAsync(currentUser, newPassword, true, false);
            return (true, null);
        }

    }
}
