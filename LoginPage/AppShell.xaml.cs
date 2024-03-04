using LoginPage.Views;

namespace LoginPage
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //רשמתי את העמוד לאפשל
            Routing.RegisterRoute("UserQuestionPage", typeof(UserQuestionsPageView));
            Routing.RegisterRoute("LoginPage", typeof(LoginPageView));
        }
    }
}