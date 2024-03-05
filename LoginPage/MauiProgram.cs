using LoginPage.Views;
using Microsoft.Extensions.Logging;
using LoginPage.ViewModels;
using LoginPage.Service;

namespace LoginPage
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //אד סינגלטון ודברים כאלו
            builder.Services.AddTransient<UserQuestionsPageView>();
            builder.Services.AddTransient<LoginPageView>();
            builder.Services.AddTransient<LoginPageViewModel>();
            builder.Services.AddTransient<UserQuestionsPageViewModel>();

            builder.Services.AddSingleton<QService>();
            builder.Services.AddSingleton<UserService>();
            builder.Services.AddSingleton<SubjectQService>();
            builder.Services.AddSingleton<StatusQService>();
           
#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}