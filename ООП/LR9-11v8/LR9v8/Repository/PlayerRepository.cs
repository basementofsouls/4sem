using LR9v8.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LR9v8.Repository
{
    public class PlayerRepository : IRepository<Player>
    {
        private DataBaseContext db;

        public PlayerRepository(DataBaseContext context)
        {
            this.db = context;
        }

        public IEnumerable<Player> GetAll()
        {
            return db.Players;
        }

        public Player Get(int id)
        {
            return db.Players.Find(id);
        }

        public void Create(Player player)
        {
            try
            {
                db.Players.Add(new Player {Name = player.Name, Age = player.Age, Position = player.Position, Team = player.Team, TeamId = player.TeamId });
                db.SaveChanges();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        public void Update(Player player)
        {
            try
            {
                Player pl = db.Players.FirstOrDefault(e => e.Id == player.Id);

                if(pl != null)
                {
                    pl.Name = player.Name;
                    pl.Team = player.Team;
                    pl.Age = player.Age;
                    pl.Position = player.Position;
                    pl.TeamId = player.TeamId;
                }

                db.SaveChanges();
            }
            catch (Exception ex) { }//MessageBox.Show(ex.Message); 
        }

        public void Delete(int id)
        {
            Player player = db.Players.Find(id);
            if (player != null)
            {
                db.Players.Remove(player);
                db.SaveChanges();
            }
                
        }
    }
}
