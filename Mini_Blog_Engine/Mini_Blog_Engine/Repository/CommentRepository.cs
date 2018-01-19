using Mini_Blog_Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mini_Blog_Engine.Repository
{
    public class CommentRepository : BaseRepository
    {
        public CommentRepository(DataContext db)
            : base(db)
        {

        }

        public List<Comment> GetListCommentByPostId(int postId)
        {
            return db.Comments.Where(x => x.PostId == postId).ToList();
        }

    }
}