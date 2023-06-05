using LR9v8.Models;
using LR9v8.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR9v8.UnitOfWrok
{
    public class UnitOfWork : IDisposable
    {
        private DataBaseContext db = new DataBaseContext();
        private PlayerRepository playerRepository;
        private TeamRepository teamRepository;

        public PlayerRepository Players
        {
            get
            {
                if (playerRepository == null)
                    playerRepository = new PlayerRepository(db);
                return playerRepository;
            }
        }

        public TeamRepository Teams
        {
            get
            {
                if (teamRepository == null)
                    teamRepository = new TeamRepository(db);
                return teamRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public async void SaveAsync()
        {
            db.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }

}
