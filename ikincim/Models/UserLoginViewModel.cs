using System.ComponentModel.DataAnnotations;

namespace ikincim.Models
{
    public class UserLoginViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Email { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Password { get; set; }
    }
}
