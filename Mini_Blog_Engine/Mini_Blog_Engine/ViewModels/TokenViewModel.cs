using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mini_Blog_Engine.ViewModels
{
    public class TokenViewModel
    {
        [Required]
        [Display(Name = "Secret Token Number")]
        public int Token { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}