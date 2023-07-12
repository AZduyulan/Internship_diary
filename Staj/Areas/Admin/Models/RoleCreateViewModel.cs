using System.ComponentModel.DataAnnotations;

namespace Staj.Areas.Admin.Models
{
    public class RoleCreateViewModel
    {
        [Required(ErrorMessage ="Boş bırakmasana knk")]
        [Display(Name="Rol Adı")]
        public string Name { get; set; }
    }
}
