using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Staj.Repository.Models;
using System.Text;

namespace Staj.TagHelpers
{
    [HtmlTargetElement("user-role-names")]
    public class UserRoleNamesTagHelper:TagHelper
    {
        public string UserId { get; set; } = null!;

        private readonly UserManager<AppUser> _userManager;

        public UserRoleNamesTagHelper(Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = await _userManager.FindByIdAsync(UserId);

            var userRoles = await _userManager.GetRolesAsync(user!);

            var stringBuilder = new StringBuilder();

            userRoles.ToList().ForEach(X =>
            {
                stringBuilder.Append(@$"<span class='badge bg-secondary mx-1'>{X.ToLower()}</span>");
            });
            
            output.Content.SetHtmlContent(stringBuilder.ToString());

        }
    }
}
