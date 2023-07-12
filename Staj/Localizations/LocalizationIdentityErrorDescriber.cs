using Microsoft.AspNetCore.Identity;

namespace Staj.Localizations
{
    public class LocalizationIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string username)
        {
            return new() { Code = "DuplicateUserName", Description = "bu kullanıcı adı daha önceden alınmıştır" };

            //return base.DuplicateUserName(username);
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new() { Code = "DuplicateEmail", Description = "bu email daha önceden alınmıştır" };

            //gacı türkçeleştirmek istediğin her şeyi buraya  çakarsın sonra yorma beni
        }

        public override IdentityError PasswordTooShort(int length)
        {
            return new() { Code = "PasswordTooShort", Description = "Şifre kısa gaci düzelt" };

        }
    }
}
