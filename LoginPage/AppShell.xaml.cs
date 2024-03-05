﻿using LoginPage.Views;

namespace LoginPage
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("ApproveQuestionsPage",typeof(ApproveQuestionsPageView));
        }
    }
}