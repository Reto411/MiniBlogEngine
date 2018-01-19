using Mini_Blog_Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mini_Blog_Engine.Repository
{
    public class RepositoryBase
    {
        protected DataContext db;

        private bool disposed = false;

        protected RepositoryBase(DataContext db)
        {
            this.db = db;
        }

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

        /// <summary>
        /// Database Disposing
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}