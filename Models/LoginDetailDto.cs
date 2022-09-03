using LoginDetailManagement.Entities;
using System.ComponentModel.DataAnnotations;

namespace LoginDetailManagement.Models
{
    public class LoginDetailDto
    {
        [Required]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Title Can not be empty")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Username Can not be empty")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password Can not be empty")]
        public string Password { get; set; }
    }
}
