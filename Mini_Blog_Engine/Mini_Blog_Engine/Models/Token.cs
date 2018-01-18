using System;
using System.ComponentModel.DataAnnotations;

namespace M183_Blog.Models
{
    public class Token
    {
        [Key]
        public int Id { get; set; }
        public int TokenNr { get; set; }
        public int UserId { get; set; }
        public System.DateTime Expiry { get; set; }
        public virtual User User { get; set; }
        public Nullable<System.DateTime> DeletedOn { get; set; }
    }
}