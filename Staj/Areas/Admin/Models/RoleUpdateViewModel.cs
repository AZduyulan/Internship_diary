using System.ComponentModel.DataAnnotations;

namespace Staj.Areas.Admin.Models
{
    public class RoleUpdateViewModel
    {

        public string Id { get; set; } = null!;
        [Required(ErrorMessage = "Boş bırakmasana knk")]
        [Display(Name = "Rol Adı")]
        public string Name { get; set; } = null!;
    }
}
