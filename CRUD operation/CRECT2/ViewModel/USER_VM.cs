using System.ComponentModel.DataAnnotations;

namespace CRECT2.ViewModel
{
    public class USER_VM
    {
       

        [Required]
        [MinLength(3)]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("password",ErrorMessage = "is not match with password")]
        public string ConfirmPass { get; set; }

    }
}
