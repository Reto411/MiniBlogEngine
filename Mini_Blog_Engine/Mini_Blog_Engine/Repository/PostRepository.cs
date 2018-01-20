using Mini_Blog_Engine.Models;
using Mini_Blog_Engine.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace Mini_Blog_Engine.Repository
{
    public class PostRepository : BaseRepository
    {
        public PostRepository(DataContext db)
            : base(db)
        {

        }


        public List<Post> GetPublishedPostList()
        {
            return db.Posts.Where(x => x.Status == PostStatus.Public).ToList();
        }
        public Post GetPostById(int postId)
        {
            return db.Posts.FirstOrDefault(x => x.Id == postId);
        }

        public List<Post> GetAllPost()
        {
            return db.Posts.ToList();
        }
    }
}
