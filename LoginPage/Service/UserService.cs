using LoginPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LoginPage.Service
{
    
    public class UserService
    {
     
        public List<Player> playersList { get; set; }
        public UserService()
        {
            this.playersList = new List<Player>();
            FillList();
        }
        private void FillList()
        {
            playersList.Add(new Player() { PlayerName = "Gal", PlayerPass = "Gal123" });
            playersList.Add(new Player() { PlayerName = "Tami", PlayerPass = "Tami123" });
            playersList.Add(new Player() { PlayerName = "ShaharOz", PlayerPass = "ShaharOz123" });
            playersList.Add(new Player() { PlayerName = "ShaharS", PlayerPass = "ShaharS123" });
        }

        public Player LoginSuc(Player ps)
        {
            Player player = playersList.FirstOrDefault(x => ps.PlayerName == x.PlayerName && ps.PlayerPass == x.PlayerPass);
            if (player != null )
                return player;
            else 
                return null;
                
        }

        
        

    }
}
