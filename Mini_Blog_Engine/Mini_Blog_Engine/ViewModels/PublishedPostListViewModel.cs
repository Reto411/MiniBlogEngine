using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mini_Blog_Engine.Models;
using Mini_Blog_Engine.ViewModels;

namespace Mini_Blog_Engine.ViewModels
{
    public class PublishedPostListViewModel
    {
        public PublishedPostListViewModel(List<Post> posts)
        {
            ListPost = new List<PostViewModel>();
            foreach (Post post in posts)
            {
                ListPost.Add(new PostViewModel(post));
            }
        }

        public List<PostViewModel> ListPost { get; }
    }
}