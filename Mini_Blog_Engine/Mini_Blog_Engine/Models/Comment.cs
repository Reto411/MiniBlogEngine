using System;
using System.ComponentModel.DataAnnotations;

namespace M183_Blog.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string Commet { get; set; }
        public virtual User User { get; set; }
        public virtual Post Posts { get; set; }
    }
}