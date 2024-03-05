using LoginPage.Models;
using LoginPage.Service;
using MonkeysMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LoginPage.ViewModels
{
    public class ApproveQuestionsPageViewModel : ViewModel
    {
        QService service;
        private Q selectedQuestion;
        public Q SelectedQuestion {  get { return selectedQuestion; } set { selectedQuestion = value; OnPropertyChanged(); } }
        private ObservableCollection<Q> Questions { get; set; }
        public ObservableCollection<Q> PenQuestions { get; set; }
        public ICommand LoadQuestionsCommand { get; private set; }
        public ICommand ApproveCommand { get; private set; }
        public ICommand DeclineCommand { get; private set; }
        public ICommand RefreshCommand { get; private set; }

        public ApproveQuestionsPageViewModel(QService qService)
        {
           this.service = qService;
           var list=service.GetQsWherePending();
            PenQuestions = new();
            for (int i = 0;i<list.Count; i++)
            {
                PenQuestions.Add(list[i]);
            }
            ApproveCommand = new Command<Q>((q) => ChangeStatusToApprove(q));
            DeclineCommand = new Command<Q>((q) => ChangeStatusToDecline(q));
            OnPropertyChanged("PenQuestions");
        }
        public void ChangeStatusToApprove(Q q)
        {
           q.StatusId = 1;
           
           PenQuestions.Remove(q);
           
        }
        public void ChangeStatusToDecline(Q q)
        {
            q.StatusId = 2;
            
                    PenQuestions.Remove(q);
           
        }

    }

  }
