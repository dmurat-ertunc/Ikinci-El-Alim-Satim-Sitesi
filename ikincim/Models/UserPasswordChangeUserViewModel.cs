using System.ComponentModel.DataAnnotations;

namespace ikincim.Models
{
    public class UserPasswordChangeUserViewModel
    {
        [Display(Name = "OldPassword")]
        [Required(ErrorMessage = " Eski Şifre Alanı Boş Bırakılmaz")]
        public string OldPassword { get; set; }

        [Display(Name = "NewPassword")]
        [Required(ErrorMessage = " Yeni Şifre Alanı Boş Bırakılmaz")]
        public string NewPassword { get; set; }

        [Display(Name = "ConfirmPassword")]
        [Required(ErrorMessage = " Yeni Şifre Tekrar Alanı Boş Bırakılmaz")]
        [Compare(nameof(NewPassword), ErrorMessage = " Şifreler Uyuşmuyor")]
        public string ConfirmPassword { get; set;
        }
    }
}
