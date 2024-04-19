using System.ComponentModel.DataAnnotations;

namespace ikincim.Models
{
    public class UserInformationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Yas { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
