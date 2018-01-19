using Mini_Blog_Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mini_Blog_Engine.Repository
{
    public class TokenRepository : BaseRepository
    {
        public Token CreateToken(User user)
        {
            Token token = new Token()
            {
                Expiry = DateTime.Now.AddMinutes(5),
                TokenNr = new Random().Next(1, 999999),
                UserId = user.Id,
                User = user
            };
            db.Tokens.Add(token);
            db.SaveChanges();
            return token;
        }

        public bool TokenValid(int token, int userId)
        {
            return db.Tokens.FirstOrDefault(t => t.TokenNr == token && t.UserId == userId && t.Expiry > DateTime.Now) != null;
        }
    }
}