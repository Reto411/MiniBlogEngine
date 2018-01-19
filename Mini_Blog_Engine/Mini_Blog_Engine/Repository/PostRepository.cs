using Mini_Blog_Engine.Models;
using Mini_Blog_Engine.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Mini_Blog_Engine.Repository
{
    public class PostRepository
    {
        DataContext db;
        public List<PostViewModel> getlistPost_ViewModel()
        {
            var ListPosts = db.Posts;
            List<PostViewModel> listPostViewModel = new List<PostViewModel>();
            foreach (Post post in ListPosts)
            {
                listPostViewModel.Add(new PostViewModel(post));
            }
            return listPostViewModel;
        }
    }
}
