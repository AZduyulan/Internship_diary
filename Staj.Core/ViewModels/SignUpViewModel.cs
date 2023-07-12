using System.ComponentModel.DataAnnotations;

namespace Staj.Core.ViewModels
{
    public class SignUpViewModel
    {
        public SignUpViewModel()
        {
                
        }
        public SignUpViewModel(string userName, string email, string phone, string password)
        {
            UserName = userName;
            Email = email;
            Phone = phone;
            Password = password;
        }
        [Required(ErrorMessage ="Kullanıcı adı alanı boş bırakılamaz")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage ="E-mail girmeniz lazıms")]
        [Required(ErrorMessage = "E-mail alanı boş bırakılamaz")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon alanı boş bırakılamaz")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
        
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [Compare(nameof(Password),ErrorMessage ="Şifreler aynı olmalı dayi")]
        [Required(ErrorMessage = "Şifre tekrar alanı boş bırakılamaz")]
        [Display(Name = "Şifre Tekrarı" )]
        public string PasswordConfirm { get; set; }

    }
}
