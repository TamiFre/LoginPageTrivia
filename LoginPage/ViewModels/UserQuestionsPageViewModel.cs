using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginPage.Models;
using LoginPage.Service;
using MonkeysMVVM.ViewModels;

namespace LoginPage.ViewModels
{
    public class UserQuestionsPageViewModel: ViewModel
    {
        QService qService;

        public UserQuestionsPageViewModel(QService qService)
        {
            this.qService = qService;//הסרביס
            

        }

        


    }
}
