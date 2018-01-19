using System.ComponentModel.DataAnnotations;

namespace Mini_Blog_Engine.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {

        }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}