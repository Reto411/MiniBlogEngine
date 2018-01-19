using Mini_Blog_Engine.Models;
using System;
using System.Linq;

namespace Mini_Blog_Engine.Repository
{
    public class UserRepository : BaseRepository
    {

        public UserRepository(DataContext db)
                        : base(db)
        {

        }

        public User GetUserByUsername(string username)
        {
            return db.Users.FirstOrDefault(x => x.Username == username);
        }

        public void AddLogInWrongCredentialsOnUser(int userId)
        {
            var user = db.Users.Find(userId);
            var userLog = new UserLog("Wrong Credentials", user);
            db.UserLogs.Add(userLog);
            db.SaveChanges();
        }

        public void AddUserLog(int userId, string action)
        {
            var user = db.Users.Find(userId);
            var userLog = new UserLog(action, user);
            db.UserLogs.Add(userLog);
            db.SaveChanges();
        }

        public UserLogin CreateUserLogInForUserId(int userId, string ip, string sessionId)
        {
            var user = db.Users.Find(userId);
            var userLogin = new UserLogin()
            {
                User = user,
                UserId = user.Id,
                CreatedOn = DateTime.Now,
                IP = ip,
                SessionId = sessionId
            };
            db.SaveChanges();

            return userLogin;
        }
    }
}