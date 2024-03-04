using LoginPage.ViewModels;

namespace LoginPage.Views;

public partial class LoginPageView : ContentPage
{
	public LoginPageView( LoginPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}