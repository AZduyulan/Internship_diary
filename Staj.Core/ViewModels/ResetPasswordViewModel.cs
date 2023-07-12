using System.ComponentModel.DataAnnotations;

namespace Staj.Core.ViewModels
{
    public class ResetPasswordViewModel
    {
        [EmailAddress(ErrorMessage = "E-mail girmeniz lazıms")]
        [Required(ErrorMessage = "E-mail alanı boş bırakılamaz")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}
