using LR9v8.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LR9v8.Repository
{
    public class TeamRepository : IRepository<Team>
    {
        private DataBaseContext db;

        public TeamRepository(DataBaseContext context)
        {
            this.db = context;
        }

        public IEnumerable<Team> GetAll()
        {
            return db.Teams.Include(o => o.Players);
        }

        public Team Get(int id)
        {
            return db.Teams.Find(id);
        }

        public void Create(Team order)
        {
            try
            {
                db.Teams.Add(new Team() {Name = order.Name, Players = order.Players });
                db.SaveChanges();
            }
            catch (Exception ex) { }

        }

        public void Update(Team order)
        {
            try
            {
                Team tm = db.Teams.FirstOrDefault(e => e.Id == order.Id);

                if (tm != null)
                {
                    tm.Name = order.Name;
                    db.SaveChanges();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void Delete(int id)
        {
            Team order = db.Teams.Find(id);
            if (order != null)
            {
                db.Teams.Remove(order);
                db.SaveChanges();
            }
        }
    }
}
