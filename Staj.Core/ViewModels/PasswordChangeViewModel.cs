using System.ComponentModel.DataAnnotations;

namespace Staj.Core.ViewModels
{
    public class PasswordChangeViewModel
    {
        //[DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz")]
        [Display(Name = "Eski Şifre ")]
        public string PasswordOld { get; set; } = null!;

        //[DataType(DataType.Password)]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz")]
        [Display(Name = "Yeni Şifre")]
        public string PasswordNew{ get; set; } = null!;

        //[DataType(DataType.Password)]
        [Compare(nameof(PasswordNew),ErrorMessage ="Şifre Aynı Değildir")]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz")]
        [Display(Name = "Yeni Şifre tekrar")]
        public string PasswordNewConfirm { get; set; } = null!;
    }
}
