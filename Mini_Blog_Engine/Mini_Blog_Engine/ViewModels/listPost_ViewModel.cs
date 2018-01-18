using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mini_Blog_Engine.ViewModels;

namespace Mini_Blog_Engine.ViewModels
{
    public class ListPost_ViewModel
    {
        ListPost_ViewModel(List<Post_ViewModel> pListPost)
        {
            listPost = pListPost;
        }

        private List<Post_ViewModel> listPost = new List<Post_ViewModel>();

        public List<Post_ViewModel> ListPost { get; }
    }
}