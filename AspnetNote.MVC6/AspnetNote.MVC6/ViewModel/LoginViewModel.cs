using System.ComponentModel.DataAnnotations;

namespace AspnetNote.MVC6.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="please input User ID.")]
        public string UserId { get; set; }

        [Required(ErrorMessage = "please input password.")]
        public string UserPassword { get; set; }
    }
}
