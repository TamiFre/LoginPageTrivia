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

        public ApproveQuestionsPageViewModel(QService qService)
        {
           service = qService;
           var list=qService.GetQsWherePending(Questions);
            for(int i = 0;i<list.Count; i++)
            {
                PenQuestions.Add(list[i]);
            }
            ApproveCommand = new Command(() => ChangeStatusToApprove());
            DeclineCommand = new Command(() => ChangeStatusToDecline());
        }
        public void ChangeStatusToApprove()
        {
            SelectedQuestion.StatusId = 1;
            foreach(Q q in PenQuestions)
            {
                if (q.StatusId == 1)
                    PenQuestions.Remove(q);
            }
        }
        public void ChangeStatusToDecline()
        {
            SelectedQuestion.StatusId = 2;
            foreach (Q q in PenQuestions)
            {
                if (q.StatusId == 2)
                    PenQuestions.Remove(q);
            }
        }

    }

  }
