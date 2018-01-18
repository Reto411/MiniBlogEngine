using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mini_Blog_Engine.Models
{
    public class Post
    {
        public Post()
        {
            this.Comment = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> DeletedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public PostStatus Status { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }


        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}