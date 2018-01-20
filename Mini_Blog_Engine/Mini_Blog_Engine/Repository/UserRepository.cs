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

        public void AddUserLog(int? userId, string action)
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
                IP = ip,
                SessionId = sessionId
            };
            db.Userlogins.Add(userLogin);
            db.SaveChanges();

            return userLogin;
        }

        public void CleanupSession(int userId, string sessionId, string ip)
        {
            var user = db.Users.Find(userId);
            var session = db.Userlogins.FirstOrDefault(x => x.SessionId == sessionId && x.UserId == userId && x.IP == ip);
            if (session != null)
            {
                session.DeletedOn = DateTime.Now;
                var log = new UserLog("Logged Out", user);
                db.UserLogs.Add(log);
            }
            db.SaveChanges();
        }

        public bool IsSessionValid(int userId, string sessionId, string ip)
        {
            return db.Userlogins.FirstOrDefault(x => x.SessionId == sessionId && x.UserId == userId && x.IP == ip) != null;
        }
    }
}