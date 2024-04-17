using System.ComponentModel.DataAnnotations;

namespace ikincim.Models
{
    public class UserViewModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Name { get; set; }


        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Surname { get; set; }


        [Display(Name = "Email")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Email { get; set; }


        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string UserName { get; set; }


        [Display(Name = "Yas")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Yas { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Password { get; set; }


        [Display(Name = "PhoneNumber")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string PhoneNumber { get; set; }


    }
}
