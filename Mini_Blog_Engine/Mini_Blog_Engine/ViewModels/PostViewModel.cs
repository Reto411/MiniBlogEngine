using Mini_Blog_Engine.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mini_Blog_Engine.ViewModels
{
    public class PostViewModel
    {
        public PostViewModel()
        {

        }
        public PostViewModel(Post pPost)
        {
            Id = pPost.Id;
            Title = pPost.Title;
            Description = pPost.Description;
            Content = pPost.Content;
            Status = pPost.Status;
            UserId = pPost.UserId;
            ListComment = new List<CommentViewModel>();

            foreach (Comment comment in pPost.Comment)
            {
                ListComment.Add(new CommentViewModel(comment));
            }
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public PostStatus Status { get; set; }

        public List<CommentViewModel> ListComment { get; set; }
        //public virtual ICollection<Comment> Comment { get; set; }
        public int UserId { get; set; }
    }
}