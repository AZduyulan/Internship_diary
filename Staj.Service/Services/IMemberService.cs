using Microsoft.AspNetCore.Identity;
using Staj.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Staj.Service.Services
{
    public interface IMemberService
    {
        public Task<UserViewHomeModel> GetUserViewModelByUserName(string userName);

        public Task LogOut();

        public Task<bool> CheckPasswordAsync(string userName, string password);

        public Task<(bool, IEnumerable<IdentityError>?)> ChangePasswordAsync(string userName, string oldPassword, string newPassword);
    }
}
