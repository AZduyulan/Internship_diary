using Microsoft.AspNetCore.Identity;
using Staj.Repository.Models;
using Staj.Repository.Models;

namespace Staj.CustomValidations
{
    public class UserValidator : IUserValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {
            var errors = new List<IdentityError>();
            var isdigit = int.TryParse(user.UserName![0].ToString(), out _);

            if (isdigit)
            {
                errors.Add(new() { Code = "UserNameContainFirstLetterDigit", Description = "Kullanıcı adının ilk karakteri sayisal olamaz" });
            }
            
            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}
