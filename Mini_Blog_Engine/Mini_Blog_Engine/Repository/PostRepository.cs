using Mini_Blog_Engine.Models;
using Mini_Blog_Engine.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Mini_Blog_Engine.Repository
{
    public class PostRepository
    {
        DataContext db;

        public List<Post_ViewModel> getlistPost_ViewModel()
        {
            //return db.Posts.Where(p => new Post_ViewModel(p));

            return new List<Post_ViewModel>();

        }


    }
}
