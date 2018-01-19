using Mini_Blog_Engine.Models;
using System.Linq;

namespace Mini_Blog_Engine.Repository
{
    public class UserRepository : BaseRepository
    {
        public User GetUserByUsername(string username)
        {
            return db.Users.FirstOrDefault(x => x.Username == username);
        }
    }
}