﻿using M183_Blog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mini_Blog_Engine.ViewModels
{
    public class Post_ViewModel
    {
        public Post_ViewModel()
        {

        }
        public Post_ViewModel(Post pPost)
        {
            Title = pPost.Title;
            Description = pPost.Description;
            Content = pPost.Content;
            Status = pPost.Status;
            UserId = pPost.UserId;
        }


        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public PostStatus Status { get; set; }
        //public virtual ICollection<Comment> Comment { get; set; }
        public int UserId { get; set; }
    }
}