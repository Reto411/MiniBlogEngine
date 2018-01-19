  using System; 
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using Mini_Blog_Engine.Helpers;

namespace Mini_Blog_Engine.Models
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<UserLog> UserLogs { get; set; }
        public virtual DbSet<UserLogin> Userlogins { get; set; }
        
        public virtual DbSet<Token> Tokens { get; set; }



        // Just a litle Seed method
        public void Seed()
        {
            User user1 = new User
            {
                Username ="Reto411",
                Password = HashHelper.Hash("1234"),
                Firstname = "Reto",
                Familyname = "Bürgisser",
                Mobilephonenumber = "+41 79 705 88 72", 
                Role = "1",
                Status = "single"
            };
            User user2 = new User()
            {
                Username = "Manuel Prieto",
                Password = HashHelper.Hash("1234"),
                Firstname = "Manuel",
                Familyname = "Prieto",
                Mobilephonenumber = "751 2451 44447",
                Role = "1",
                Status = "single"
            };
            Comment myComment = new Comment
            {
                Commet = "First Comment",
                CreatedOn = DateTime.Today,
                User = user1
            };
            Post publicPost = new Post()
            {
                Content = "Just a litle text to see",
                CreatedOn = DateTime.Now,
                Description = "The Description of the little text",
                Status = PostStatus.Public,
                Title = "Example Text",
                User = user1

            };
            publicPost.Comment.Add(myComment);
            publicPost.Comment.Add(myComment);
            publicPost.Comment.Add(myComment);
            Post privatePost = new Post()
            {
                Content = "I am writing some around around around.",
                CreatedOn = DateTime.Now,
                Description = "Everything goes around around around!",
                Status = PostStatus.Private,
                Title = "Around, Around, Around!",
                User = user2
            };
            privatePost.Comment.Add(myComment);
            privatePost.Comment.Add(myComment);
            privatePost.Comment.Add(myComment);

            this.Users.Add(user1);
            this.Posts.Add(privatePost);
            this.Posts.Add(publicPost);
            this.Users.Add(user2);
            this.Comments.Add(myComment);
            this.SaveChanges();
        }
    }
}