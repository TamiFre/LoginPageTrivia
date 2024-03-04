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
        public ObservableCollection< Q> QuestionsApproved { get; set ; }
        public ObservableCollection< Q> QuestionsDeclined { get; set ; }
        public ObservableCollection< Q> QuestionsPending { get; set ; }
        public Player Player { get; set; }
        
        QService qService;
        public ICommand ShowAllQuestions { get; set; }
        public ICommand ShowApproved { get; set; }
        public ICommand ShowDeclined { get; set; }
        public ICommand ShowPending { get; set; }

        public UserQuestionsPageViewModel(QService qService)
        {
            
            this.qService = qService;//הסרבי

            
            ShowAllQuestions = new Command(async () => await ShowQuestions());

            //ShowApproved = new Command(async () => await ShowAllApproved());
            //ShowDeclined = new Command(async () => await ShowAllDeclined());
            //ShowPending = new Command(async () => await ShowAllPending());
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
        //אמור לעשות כפתורים שמראים את כל השאלות הפנדינג וכו
        //public async Task ShowAllApproved()
        //{
        //    var list = qService.GetApprovedQuestions(Player);
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        QuestionsApproved.Add(list[i]);
        //    }
        //}

        //public async Task ShowAllPending()
        //{
        //    var list = qService.GetPendingQuestions(Player);
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        QuestionsPending.Add(list[i]);
        //    }
        //}

        //public async Task ShowAllDeclined()
        //{
        //    var list = qService.GetDeclinedQuestions(Player);
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        QuestionsDeclined.Add(list[i]);
        //    }
        //}






    }
}
