using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LoginPage.Models;
using LoginPage.Service;
using MonkeysMVVM.ViewModels;

namespace LoginPage.ViewModels
{
    [QueryProperty(nameof(Player), "Player")]
    public class UserQuestionsPageViewModel : ViewModel
    {
        
        public ObservableCollection< Q> Questions { get; set ; }
        public Player Player { get; set; }
        
        QService qService;
        public ICommand ShowAllQuestions { get; set; }
        public UserQuestionsPageViewModel(QService qService)
        {
            
            this.qService = qService;//הסרבי
            ShowAllQuestions = new Command(async () => await ShowQuestions());
        }

        public async Task ShowQuestions()
        {
            //Questions = new ObservableCollection<Q>();
            var list = qService.GetUserQuestion(Player);
            for (int i = 0; i < list.Count; i++)
            {
                Questions.Add(list[i]);
            } 
        }


        

        


    }
}
