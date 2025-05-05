using System.ComponentModel.DataAnnotations;

namespace ITICoursesManager.ViewModel
{
    public class RegisterVM
    {
        [MinLength(5)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
    }
}
