using Mini_Blog_Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mini_Blog_Engine.Repository
{
    public class BaseRepository
    {
        protected DataContext db;
        protected BaseRepository()
        {
            this.db = new DataContext();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}