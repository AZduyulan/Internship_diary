using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Staj.TagHelpers
{
    [HtmlTargetElement("user-picture-thumbnail")]
    public class UserPictureThumbnailTagHepler:TagHelper
    {
        public string? PictureUrl { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";
            if (string.IsNullOrEmpty(PictureUrl))
            {
                output.Attributes.SetAttribute("src", "/userpictures/default_user_picture.jpg");
            }
            else
            {
                output.Attributes.SetAttribute("src", $"/userpictures/{PictureUrl}");
            }

        }
    }
}
