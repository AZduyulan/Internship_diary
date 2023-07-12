using System.ComponentModel.DataAnnotations;

namespace Staj.Core.ViewModels
{
    public class SignInViewModel
    {
        public SignInViewModel()
        {

        }

        public SignInViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        [EmailAddress(ErrorMessage = "E-mail girmeniz lazıms")]
        [Required(ErrorMessage = "E-mail alanı boş bırakılamaz")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        
        [Display(Name = "BEni UNutma Ha")]
        public bool RememberMe { get; set; }
    }
}
