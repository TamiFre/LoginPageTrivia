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
        //רשימה של יוזרס חדשים
        public List<Users> listUsers { get; set; }

        public UserService()
        {
            this.listUsers = new List<Users>();
            FillList();
        }

        //מכניס רשומים לרשימה
        private void FillList()
        {
            listUsers.Add(new Users() { Name = "Gal", Password = "GalHatumtum" });
            listUsers.Add( new Users() { Name = "Tami", Password="ShaharHatumtum"});
            listUsers.Add( new Users() { Name = "Shahar", Password="FluffyHatumtum"});
        }


    }
}
