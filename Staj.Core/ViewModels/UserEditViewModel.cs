using Microsoft.AspNetCore.Http;
using Staj.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Staj.Core.ViewModels
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı alanı boş bırakılamaz")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "E-mail girmeniz lazıms")]
        [Required(ErrorMessage = "E-mail alanı boş bırakılamaz")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon alanı boş bırakılamaz")]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Dogum Günnü")]
        public DateTime? BirthDay { get; set; }

        [Display(Name = "köyün")]
        public string City { get; set; }

        [Display(Name = "cinsin")]
        public Gender? Gender { get; set; }

        [Display(Name = "İfade-i SURATIN")]
        public IFormFile Picture { get; set; }



    }


}
