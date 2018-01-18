namespace Mini_Blog_Engine.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {

        }

        public string Username { get; set; }

        // TODO Encrypt
        public string Password { get; set; }
    }
}