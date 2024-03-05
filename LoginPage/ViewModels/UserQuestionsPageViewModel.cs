using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public ObservableCollection<Q> Questions { get; set; }
        public Player Player { get; set; }
        QService qService;
       

        public ICommand FilterCommand { get; set; }
        public ICommand ClearFilterCommand { get; set; }
        public ICommand ShowAllQuestions { get; set; }

        private List<Q> fullList;
        private List<Q> filteredList;
        private StatusQService statusQService;
        private int selectedIndex;
        public int SelectedIndex{ get { return selectedIndex; } set { selectedIndex = value; OnPropertyChanged(); } }
        public ObservableCollection<StatusQ> Status { get; set; } 
        public object SelectedSubject { get; set; }
       

        public UserQuestionsPageViewModel(QService qService, StatusQService statusService)
        {
            fullList = new List<Q>();   
            this.qService = qService;//הסרבי
            this.statusQService = statusService;
            Status = new ObservableCollection<StatusQ>();
            foreach(StatusQ s in statusQService.StatusQs)
            {
                Status.Add(s);
            }
            Questions = new ObservableCollection<Q>();
            ShowAllQuestions = new Command(async () => await ShowQuestions());
            FilterCommand = new Command(async () => await ShowFilteredQuestions());
          
        }

        public async Task ShowQuestions()
        {
           
            var list = qService.GetUserQuestion(Player);
            Questions.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                Questions.Add(list[i]);
            } 
        }

        public async Task ShowFilteredQuestions()
        {
            filteredList = fullList.Where(x=> x.Subject.Equals((string)SelectedSubject)).ToList();
            Questions.Clear();
            foreach (Q question in filteredList)
            {
                Questions.Add(question);
            }
            SelectedIndex = -1;
        }
        


      






    }
}
