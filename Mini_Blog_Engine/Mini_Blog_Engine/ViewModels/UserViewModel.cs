using Mini_Blog_Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mini_Blog_Engine.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(User pUser)
        {
            Username = pUser.Username;
            Firstname = pUser.Firstname;
            Familyname = pUser.Familyname;
            Password = pUser.Password;
            Role = pUser.Role;
            Mobilephonenumber = pUser.Mobilephonenumber;
            Status = pUser.Status;
        }

        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Familyname { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Mobilephonenumber { get; set; }
        public string Status { get; set; }
    }
}