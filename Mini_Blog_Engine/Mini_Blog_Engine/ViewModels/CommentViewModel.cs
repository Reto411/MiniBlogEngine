using Mini_Blog_Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mini_Blog_Engine.ViewModels
{
    public class CommentViewModel
    {

        public CommentViewModel(Comment pComment)
        {
            UserId = pComment.UserId;
            PostId = pComment.PostId;
            CreatedOn = pComment.CreatedOn;
            Commet = pComment.Commet;
            User = new UserViewModel(pComment.User);
        }

        public int UserId { get; set; }

        public UserViewModel User { get; set; }
        public int PostId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Commet { get; set; }
    }
}