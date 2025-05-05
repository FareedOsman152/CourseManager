using System.ComponentModel.DataAnnotations;

namespace ITICoursesManager.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage ="*")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remember me")]
        public bool RememberMe { get; set; }
    }
}
