using MonkeysMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPage.ViewModels
{
    public class LoginPageViewModel: ViewModel
    {
        private string name;
        private string password;
        public string Name { get { return name; } set { name = value; OnPropertyChanged(); } }
        public string Password { get { return password; } set { password = value; OnPropertyChanged(); } }
    }
}
