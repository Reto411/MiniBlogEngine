using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mini_Blog_Engine.ViewModels;

namespace Mini_Blog_Engine.ViewModels
{
    public class ListPostViewModel
    {
        public ListPostViewModel(List<PostViewModel> pListPost)
        {
            listPost = pListPost;
        }

        private List<PostViewModel> listPost = new List<PostViewModel>();

        public List<PostViewModel> ListPost { get; }
    }
}