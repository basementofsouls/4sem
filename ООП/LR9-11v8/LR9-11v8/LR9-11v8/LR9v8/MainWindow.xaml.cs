using LR9v8.Models;
using LR9v8.UnitOfWrok;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace LR9v8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Data
        private Player Player;
        private UnitOfWork UOW;
        private Team Team;

        private int FilterTeamID = 0;
        private string FilterPlayerPosition = "";
        #endregion

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();
            UOW = new UnitOfWork();
            Player = new Player();
            Team = new Team();
        }
        #endregion

        #region PagePlayers
        public void AddPlayer(object sender, RoutedEventArgs e)
        {
            UOW.Players.Create(Player);
        }
        public void RemovePlayer(object sender, RoutedEventArgs e) 
        {
            UOW.Players.Delete(Player.Id);
        }
        public void UpdatePlayer(object sender, RoutedEventArgs e) 
        { 
            UOW.Players.Update(Player);
        }
        private void LoadPlayer(object sender, RoutedEventArgs e)
        {
            Player pll = UOW.Players.Get(Player.Id);
            Player = pll;
            if (pll != null)
            {
                TB_PlayerAge.Text = pll.Age.ToString();
                TB_PlayerName.Text = pll.Name;
                TB_PlayerPosition.Text = pll.Position;
                TB_PlayerTeamId.Text = pll.Id.ToString();
            }
        }
        public void ShowPlayer(object sender, RoutedEventArgs e) 
        {
            var players = UOW.Players.GetAll();

            if (FilterTeamID != 0)
                players = players.Where(p => p.TeamId == FilterTeamID);

            if (FilterPlayerPosition != "")
                players = players.Where(p => p.Position == FilterPlayerPosition);

            if (Radio1.IsChecked == true)
                players = players.OrderByDescending(p => p.Id);
            if (Radio2.IsChecked == true)
                players = players.OrderByDescending(p => p.Age);

            var result = from p in players
                         select new { Id = p.Id, Name = p.Name, Position = p.Position, Age = p.Age, TeamId = p.Id != 0 ? p.Id : 0 };

            DataGridPlayers.ItemsSource = result.ToList();
        }
        private void TB_PlayerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Player.Name = TB_PlayerName.Text;
        }
        private void TB_PlayerPosition_TextChanged(object sender, TextChangedEventArgs e)
        {
            Player.Position = TB_PlayerPosition.Text;
        }
        private void TB_PlayerAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Player.Age = Convert.ToInt32(TB_PlayerAge.Text);
            }
            catch { TB_PlayerAge.Text = ""; }
        }
        private void TB_PlayerTeamId_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Player.TeamId = Convert.ToInt32(TB_PlayerTeamId.Text);
            }
            catch { TB_PlayerTeamId.Text = ""; }
        }
        private void TB_SelectedPlayerID_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Player.Id = Convert.ToInt32(TB_SelectedPlayerID.Text);
            }
            catch { TB_SelectedPlayerID.Text = ""; }
        }
        private void TB_FilterTeamID_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (TB_FilterTeamID.Text == "")
                    FilterTeamID = 0;
                FilterTeamID = Convert.ToInt32(TB_FilterTeamID.Text);
            }
            catch { TB_FilterTeamID.Text = ""; }
        }
        private void TB_FilterPlayerPosition_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterPlayerPosition = TB_FilterPlayerPosition.Text;
        }
        #endregion

        #region PageTeam
        public void AddTeam(object sender, RoutedEventArgs e)
        {
            UOW.Teams.Create(Team);
        }
        public void RemoveTeam(object sender, RoutedEventArgs e)
        {
            UOW.Teams.Delete(Team.Id);
        }
        public void UpdateTeam(object sender, RoutedEventArgs e) 
        {
            UOW.Teams.Update(Team);
        }
        public void ShowTeam(object sender, RoutedEventArgs e)
        {
            var teams = UOW.Teams.GetAll().ToList();

            DataGridTeams.ItemsSource = from t in teams
                                        select new { Id = t.Id, Name = t.Name };
        }
        private void TB_TeamName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Team.Name = TB_TeamName.Text;
        }
        private void TB_TeamID_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Team.Id = Convert.ToInt32(TB_TeamID.Text);
            }
            catch { TB_TeamID.Text = ""; }
        }
        private async void ButtonTransaction_Click(object sender, RoutedEventArgs e)
        {
            using (DataBaseContext db = new DataBaseContext())
            {

                using (var transaction = db.Database.BeginTransaction())
                {

                    try
                    {
                        Team t1 = new Team { Name = "Барселона" };
                        Team t2 = new Team { Name = "Реал Мадрид" };
                        db.Teams.Add(t1);
                        db.Teams.Add(t2);
                        db.SaveChanges();

                        Player pl1 = new Player { Name = "Роналду", Age = 31, Position = "Нападающий", Team = t2 };
                        Player pl2 = new Player { Name = "Месси", Age = 28, Position = "Нападающий", Team = t1 };
                        Player pl3 = new Player { Name = "Хави", Age = 34, Position = "Полузащитник", Team = t1 };
                        db.Players.AddRange(new List<Player> { pl1, pl2, pl3 });
                        db.SaveChanges();

                        // Подтверждение транзакции
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Отмена транзакции в случае возникновения ошибки
                        MessageBox.Show(ex.Message);
                        transaction.Rollback();
                    }
                }
            }
        }

        #endregion

    }
}
