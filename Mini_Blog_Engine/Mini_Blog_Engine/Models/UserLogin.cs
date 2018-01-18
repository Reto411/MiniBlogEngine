using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mini_Blog_Engine.Models
{
    public class UserLogin
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }       
        public string SessionId { get; set; }
        public string IP { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<System.DateTime> DeletedOn { get; set; }

        public virtual User User { get; set; }
    }
}