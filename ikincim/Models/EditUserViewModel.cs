using System.ComponentModel.DataAnnotations;

namespace ikincim.Models
{
    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Bu alan boş bırakılmaz")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Bu alan boş bırakılmaz")]
        public string Surname { get; set; }

        [Display(Name = "ErrorMessage")]
        [Required(ErrorMessage = "Bu alan boş bırakılmaz")]
        public string Email { get; set; }

        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Bu alan boş bırakılmaz")]
        public string UserName { get; set; }

        [Display(Name = "Yas")]
        [Required(ErrorMessage = "Bu alan boş bırakılmaz")]
        public string Yas { get; set; }

        [Display(Name = "PhoneNumber")]
        [Required(ErrorMessage = "Bu alan boş bırakılmaz")]
        public string PhoneNumber { get; set; }
    }
}
